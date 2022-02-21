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
                .WithMessage("O campo {PropertyName} não pode estar vaizo")
                .Length(2, 30)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Email)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} não pode estar vaizo")
                .Length(2, 50)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
