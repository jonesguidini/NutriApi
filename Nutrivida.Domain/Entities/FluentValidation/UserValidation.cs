using FluentValidation;
using Nutrivida.Domain.DTOs;

namespace Nutrivida.Domain.Entities.FluentValidation
{
    public class UserValidation : ValidationBase<UserForRegisterDTO>
    {
        public UserValidation()
        {
            SetValidation();
        }

        /// <summary>
        /// Valida as properties da Entidade
        /// </summary>
        public override void SetValidation()
        {
            RuleFor(f => f.Username)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser informado.")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.Email)
                .EmailAddress().WithMessage("Informe um {PropertyName} válido.")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.Password)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser informado.")
                .Length(6, 20).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.PasswordConfirmation)
                .NotEmpty().WithMessage("A confirmação da senha precisa ser informado.")
                .Length(2, 100).WithMessage("A confirmação da senha precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(x => x.PasswordConfirmation)
                .Equal(x => x.Password)
                .WithMessage("A Confirmação de Senha está diferente da Senha.");
        }
    }
}
