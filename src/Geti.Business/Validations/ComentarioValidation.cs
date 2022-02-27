using FluentValidation;
using Geti.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geti.Business.Validations 
{
    public class ComentarioValidation : AbstractValidator<Comentario>
    {
        public ComentarioValidation()
        {
            RuleFor(c => c.DataComentario)
                .NotEmpty()
                .WithMessage("A data da criação do comentário deve ser informada");

            RuleFor(c => c.Descricao)
                .NotEmpty()
                .WithMessage("Descrição não pode estar vazia")
                .MinimumLength(5)
                .WithMessage("Descrição precisa ter no mínimo {MinLength} caracteres")
                .MaximumLength(500)
                .WithMessage("Descrição deve ter no máximo {MaxLength} caracteres");
        }
    }
}
