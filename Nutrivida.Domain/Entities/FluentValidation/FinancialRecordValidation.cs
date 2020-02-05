using FluentValidation;
using Nutrivida.Domain.DTOs;

namespace Nutrivida.Domain.Entities.FluentValidation
{
    public class FinancialRecordValidation : ValidationBase<FinancialRecordDTO>
    {
        public FinancialRecordValidation()
        {
            SetValidation();
        }

        /// <summary>
        /// Valida as properties da Entidade
        /// </summary>
        public override void SetValidation()
        {
            //RuleFor(f => f.NumMeals)
            //    .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser informado.");

            //RuleFor(rs => rs.NumProducts)
            //    .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser informado.");

            RuleFor(rs => rs.Sales)
                .NotNull().WithMessage("Informe pelo menos uma venda.");

            When(rs => rs.Sales == null && rs.Expensives == null, () =>
            {
                RuleFor(f => f.Sales)
                    .NotNull()
                    .WithMessage("Informe pelo menos uma venda ou despesa.");
            });

            //RuleFor(f => f.SalesObservation)
            //    .NotEmpty().WithMessage("O campo {PropertyName} precisa ser informado.")
            //    .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            //RuleFor(f => f.ExpensivesObservation)
            //    .NotEmpty().WithMessage("O campo {PropertyName} precisa ser informado.")
            //    .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
