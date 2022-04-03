using System;
using System.ComponentModel.DataAnnotations;

namespace Geti.Api.ViewModels.Usuario
{
    public class UserBasicoViewModel
    {
        [Key]
        public string Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }
    }

    public class LoginResponseViewModel
    {
        public string AccessToken { get; set; }

        public UserBasicoViewModel User { get; set; }
    }

    public class UserChangePasswordViewModel
    {
        public string Senha { get; set; }
        public string ConfirmacaoSenha { get; set; }
    }
}
