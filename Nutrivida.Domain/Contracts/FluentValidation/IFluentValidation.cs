using System.ComponentModel.DataAnnotations;
using Nutrivida.Domain.Entities;

namespace Nutrivida.Domain.Contracts.FluentValidation
{
    public interface IFluentValidation<TEntity> where TEntity : class 
    {
        void SetValidation();

        ValidationResult GetValidations();
    }
}
