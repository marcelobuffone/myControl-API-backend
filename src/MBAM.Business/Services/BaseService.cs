using FluentValidation;
using FluentValidation.Results;
using MBAM.Business.Interfaces;
using MBAM.Business.Messages;
using MBAM.Business.Models;

namespace MBAM.Business.Services
{
    public abstract class BaseService
    {
        private readonly IMessenger _messenger;

        protected BaseService(IMessenger messenger)
        {
            _messenger = messenger;
        }

        protected void Notify(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notify(error.ErrorMessage);
            }
        }

        protected void Notify(string mensagem)
        {
            _messenger.Handle(new Message(mensagem));
        }

        protected bool ExecuteValidation<TV, TE>(TV validation, TE entity) where TV : AbstractValidator<TE> where TE : Entity<TE>
        {
            var validator = validation.Validate(entity);

            if (validator.IsValid) return true;

            Notify(validator);

            return false;
        }
    }
}
