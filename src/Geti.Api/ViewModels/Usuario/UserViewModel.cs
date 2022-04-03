namespace Geti.Api.ViewModels
{
    public class RegisterUserViewModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string ConfirmacaoSenha { get; set; }
    }

    public class LoginUserViewModel
    {
        public string Email { get; set; }
        public string Senha { get; set; }

    }  

}
