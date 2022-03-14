using FluentValidation;
using Geti.Business.Models;

namespace Geti.Business.Validations
{
    public class LicencaValidation : AbstractValidator<Licenca>
    {
        public LicencaValidation()
        {
            RuleFor(e => e.Nome)
            .NotEmpty()
            .WithMessage("Nome da licença não pode estar vazio")
            .MinimumLength(2)
            .WithMessage("Nome da licença precisa ter no mínimo {MinLength} caracteres")
            .MaximumLength(50)
            .WithMessage("Nome da licença deve ter no máximo {MaxLength} caracteres");

            RuleFor(e => e.Chave)
            .NotEmpty()
            .WithMessage("Chave da licença não pode estar vazio")
            .MinimumLength(1)
            .WithMessage("Chave da licença precisa ter no mínimo {MinLength} caracteres")
            .MaximumLength(100)
            .WithMessage("Chave da licença deve ter no máximo {MaxLength} caracteres");

            RuleFor(e => e.SoftwareId)
            .NotNull()
            .WithMessage("Software referente a licença não pode estar vazio");   
           
        }
    }
}
