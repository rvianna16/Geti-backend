using FluentValidation;
using Geti.Business.Models;

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
                .IsInEnum().NotEmpty()
                .WithMessage("Tipo do equipamento deve ser informado");

            RuleFor(e => e.DataAquisicao)
                .NotEmpty()
                .WithMessage("Data de Aquisição deve ser informada");

            RuleFor(e => e.ColaboradorId)                
                .NotNull()
                .WithMessage("Colaborador responsável pelo equipamento deve ser informado");

            RuleFor(e => e.StatusEquipamento)
                .IsInEnum().NotEmpty()
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
