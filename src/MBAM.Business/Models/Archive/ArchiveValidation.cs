using FluentValidation;

namespace MBAM.Business.Models.Archive
{
    public class ArchiveValidation : AbstractValidator<Archive>
    {
        public ArchiveValidation()
        {
            RuleFor(f => f.Path)
                .NotEmpty().WithMessage("The field {PropertyName} is required")
                .Length(3, 200)
                .WithMessage("The field {PropertyName} needs {MinLength} e {MaxLength} characters");
        }
    }
}
