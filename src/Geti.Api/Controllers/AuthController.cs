using AutoMapper;
using Geti.Api.Data;
using Geti.Api.Extensions;
using Geti.Api.ViewModels;
using Geti.Api.ViewModels.Usuario;
using Geti.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Geti.Api.Controllers
{
    [Authorize]
    [Route("api/")]
    public class AuthController : MainController
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;
        public AuthController(INotificador notificador,
                              SignInManager<ApplicationUser> signInManager,
                              UserManager<ApplicationUser> userManager,
                              IOptions<AppSettings> appSettings,
                              IMapper mapper) : base(notificador)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }


        [HttpGet("usuarios")]
        public async Task<ActionResult<IEnumerable<UserBasicoViewModel>>> Usuarios(string filtro)
        {
            IQueryable<ApplicationUser> usersQuery = _userManager.Users;

            if (filtro != null)
            {
                usersQuery = usersQuery.Where(c =>
                c.FullName.ToLower().Contains(filtro.Trim().ToLower()) ||
                c.Email.ToLower().Contains(filtro.Trim().ToLower()));
            }
            var users = _mapper.Map<IEnumerable<UserBasicoViewModel>>(await usersQuery.ToListAsync());

            return CustomResponse(users);
        }

        [HttpPut("usuarios/{id}")]
        public async Task<ActionResult<UserBasicoViewModel>> AlterarSenha(string id, UserChangePasswordViewModel userPassword)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null) return NotFound();

            if (userPassword.Senha != userPassword.ConfirmacaoSenha)
            {
                NotificarErro("As senhas não coincidem");
                return CustomResponse();
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, userPassword.Senha);

            if (result.Succeeded)
            {
                return CustomResponse();
            }

            foreach (var error in result.Errors)
            {
                NotificarErro(error.Description);
            }

            return CustomResponse();
        }

        [HttpDelete("usuarios/{id}")]
        public async Task<ActionResult<UserBasicoViewModel>> RemoverUsuario(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var userAutenticadoId = HttpContext.User.Claims.First(c => c.Type.Contains("nameidentifier")).Value;
            if(userAutenticadoId == id)
            {
                NotificarErro("Não é possível excluir o próprio usuário");
                return CustomResponse();
            }

            if (user == null) return NotFound();

            await _userManager.DeleteAsync(user);

            return CustomResponse();
        }

        [HttpPost("novo-usuario")]
        public async Task<ActionResult> Registrar(RegisterUserViewModel registerUser)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);            

            var user = new ApplicationUser()
            {
                FullName = registerUser.Nome,
                UserName = registerUser.Email,
                Email = registerUser.Email,
                EmailConfirmed = true,
            };            

            if(registerUser.Senha != registerUser.ConfirmacaoSenha)
            {
                NotificarErro("As senhas não coincidem");

            }else
            {
                var result = await _userManager.CreateAsync(user, registerUser.Senha);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return CustomResponse(registerUser);
                }

                foreach (var error in result.Errors)
                {
                    NotificarErro(error.Description);
                }
            }           

            return CustomResponse(registerUser);
        }
        
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginUserViewModel loginUser)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Senha, false, true);

            if (result.Succeeded)
            {
                return CustomResponse(await GerarJwt(loginUser.Email));
            }

            if (result.IsLockedOut)
            {
                NotificarErro("Usuário temporáriamente bloqueado por tentativas inválidas");
                return CustomResponse(loginUser);
            }

            NotificarErro("Usuário ou senha incorretos");
            return CustomResponse(loginUser);

        }

        [AllowAnonymous]
        [HttpPost("check-token")]
        public bool CheckToken()
        {
            return HttpContext.User.Identity.IsAuthenticated;
        }

        private async Task<LoginResponseViewModel> GerarJwt(string email)
        {
            var user = await _userManager.FindByNameAsync(email);            

            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim("name", user.FullName)
                 }),
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            var encondedToken = tokenHandler.WriteToken(token);
            var response = new LoginResponseViewModel
            {
                AccessToken = encondedToken,
                User = new UserBasicoViewModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    Nome = user.FullName
                }
            };
            return response;
        }
    }
}
