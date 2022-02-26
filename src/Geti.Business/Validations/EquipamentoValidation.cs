using FluentValidation;
using Geti.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geti.Business.Validations
{
    public  class EquipamentoValidation : AbstractValidator<Equipamento>
    {
        public EquipamentoValidation()
        {
            RuleFor(e => e.Patrimonio)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} não pode estar vazio")
                .Length(1, 50)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(e => e.Colaborador)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} não pode estar vazio");

            RuleFor(e => e.StatusEquipamento)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} não pode estar vazio");

        }
    }
}
