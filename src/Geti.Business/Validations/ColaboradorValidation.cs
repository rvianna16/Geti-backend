using FluentValidation;
using Geti.Business.Models;

namespace Geti.Business.Validations
{
    public class ColaboradorValidation : AbstractValidator<Colaborador>
    {
        public ColaboradorValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage("Nome do colaborador não pode estar vazio")
                .MinimumLength(2)
                .WithMessage("Nome do colaborador precisa ter no mínimo {MinLength} caracteres")
                .MaximumLength(100)
                .WithMessage("Nome do colabrador deve ter no máximo {MaxLength} caracteres");                

            RuleFor(c => c.Email)
                .NotEmpty()
                .WithMessage("E-mail do colaborador não pode estar vazio")
                .Length(2, 50)
                .WithMessage("E-mail do colaborador precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
