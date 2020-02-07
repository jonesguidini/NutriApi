﻿using FluentValidation;
using Nutrivida.Domain.DTOs;

namespace Nutrivida.Domain.Entities.FluentValidation
{
    public class ExpensiveCategoryValidation : FluentValidation<ExpensiveCategoryDTO>
    {
        public ExpensiveCategoryValidation()
        {
            SetValidation();
        }

        /// <summary>
        /// Valida as properties da Entidade
        /// </summary>
        public override void SetValidation() {

            RuleFor(f => f.Category)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser informado.")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
