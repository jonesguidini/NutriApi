using System.ComponentModel.DataAnnotations;
using FluentValidation;
using Nutrivida.Domain.Contracts.FluentValidation;

namespace Nutrivida.Domain.Entities.FluentValidation
{
    public class FluentValidation<TEntity> : AbstractValidator<TEntity>, IFluentValidation<TEntity>  where TEntity : class
    {
        private ValidationResult validation;

        public FluentValidation() {
        }

        public ValidationResult GetValidations()
        {
            return validation;
        }

        public virtual void SetValidation() { }

        public virtual void SetValidation(ValidationResult _validation) {
            validation = _validation;
        }

    }
}
