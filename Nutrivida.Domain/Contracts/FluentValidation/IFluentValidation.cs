using System.ComponentModel.DataAnnotations;

namespace Nutrivida.Domain.Contracts.FluentValidation
{
    public interface IFluentValidation<TEntity> where TEntity : class 
    {
        void SetValidation();

        ValidationResult GetValidations();
    }
}
