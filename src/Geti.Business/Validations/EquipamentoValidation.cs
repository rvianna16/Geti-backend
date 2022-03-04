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
                .WithMessage("Patrimônio do equipamento não pode estar vazio")
                .MinimumLength(2)
                .WithMessage("Patrimônio do equipamento precisa ter no mínimo {MinLength} caracteres")
                .MaximumLength(30)
                .WithMessage("Patrimônio do equipamento deve ter no máximo {MaxLength} caracteres");

            RuleFor(e => e.Descricao)
                .MaximumLength(4000)
                .WithMessage("Descrição deve ter no máximo {MaxLength} caracteres");

            RuleFor(e => e.TipoEquipamento)
                .NotEmpty()
                .WithMessage("Tipo do equipamento deve ser informado");

            RuleFor(e => e.ColaboradorId)                
                .NotNull()
                .WithMessage("Colaborador responsável pelo equipamento deve ser informado");

            RuleFor(e => e.StatusEquipamento)
                .NotEmpty()
                .WithMessage("Status do equipamento deve ser informado");

            RuleFor(e => e.Modelo)
                .MaximumLength(50)
                .WithMessage("Modelo deve ter no máximo {MaxLength} caracteres");

            RuleFor(e => e.Processador)
                .MaximumLength(100)
                .WithMessage("Processador deve ter no máximo {MaxLength} caracteres");

            RuleFor(e => e.Armazenamento)
                .MaximumLength(100)
                .WithMessage("Armazenamento deve ter no máximo {MaxLength} caracteres");

            RuleFor(e => e.IP)
                .MaximumLength(30)
                .WithMessage("IP deve ter no máximo {MaxLength} caracteres");

        }
    }
}
