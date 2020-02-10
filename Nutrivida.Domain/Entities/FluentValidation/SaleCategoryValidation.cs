﻿using FluentValidation;
using Nutrivida.Domain.DTOs;

namespace Nutrivida.Domain.Entities.FluentValidation
{
    public class SaleCategoryValidation : FluentValidation<SaleCategoryDTO>
    {
        public SaleCategoryValidation()
        {
            SetValidation();
        }

        /// <summary>
        /// Valida as properties da Entidade
        /// </summary>
        public override void SetValidation()
        {
            RuleFor(f => f.Category)
                .NotEmpty().WithMessage("O campo 'categoria' deve ser informado.")
                .Length(2, 100).WithMessage("O campo 'categoria' precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
