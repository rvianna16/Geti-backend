using FluentValidation;
using Geti.Business.Models;

namespace Geti.Business.Validations
{
    public class SoftwareValidation : AbstractValidator<Software>
    {
        public SoftwareValidation()
        {
            RuleFor(e => e.Nome)
            .NotEmpty()
            .WithMessage("Nome do software não pode estar vazio")
            .MinimumLength(2)
            .WithMessage("Nome do software precisa ter no mínimo {MinLength} caracteres")
            .MaximumLength(100)
            .WithMessage("Nome do software deve ter no máximo {MaxLength} caracteres");

            RuleFor(e => e.Descricao)
            .MaximumLength(2000)
            .WithMessage("Descrição deve ter no máximo {MaxLength} caracteres");
        }
    }
}
