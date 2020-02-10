using FluentValidation;
using Nutrivida.Domain.DTOs;

namespace Nutrivida.Domain.Entities.FluentValidation
{
    public class FinancialRecordValidation : FluentValidation<FinancialRecordDTO>
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

            RuleFor(rs => rs.Sales)
                .NotNull().WithMessage("Informe pelo menos uma venda.");

            When(rs => rs.Sales == null && rs.Expensives == null, () =>
            {
                RuleFor(f => f.Sales)
                    .NotNull()
                    .WithMessage("Informe pelo menos uma venda ou despesa.");
            });

        }
    }
}
