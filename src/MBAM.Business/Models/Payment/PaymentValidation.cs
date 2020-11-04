using FluentValidation;

namespace MBAM.Business.Models.Payment
{
    public class PaymentValidation : AbstractValidator<Payment>
    {
        public PaymentValidation()
        {
            RuleFor(f => f.Description)
                .NotEmpty().WithMessage("The field {PropertyName} is required")
                .Length(3, 200)
                .WithMessage("The field {PropertyName} needs {MinLength} e {MaxLength} characters");

            RuleFor(x => x.Value)
                .Custom((x, context) =>
                {
                    if (x <= 0)
                    {
                        context.AddFailure($"the value must be greater than zero");
                    }
                });

        }
    }
}
