using FluentValidation;
using Nutrivida.Domain.DTOs;

namespace Nutrivida.Domain.Entities.FluentValidation
{
    public class ExpensiveValidation : FluentValidation<ExpensiveDTO>
    {
        public ExpensiveValidation()
        {
            SetValidation();
        }

        /// <summary>
        /// Valida as properties da Entidade
        /// </summary>
        public override void SetValidation()
        {
            RuleFor(f => f.Value)
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser informado.");

            RuleFor(rs => rs.ExpensiveCategoryId)
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser informado.");

            RuleFor(rs => rs.FinancialRecordId)
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser informado.");

            //RuleFor(f => f.Description)
            //    .NotEmpty().WithMessage("O campo {PropertyName} precisa ser informado.")
            //    .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
