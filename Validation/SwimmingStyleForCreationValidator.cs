using FluentValidation;
using SwimmingStyleAPI.Models.SwimmingStyleDto;

namespace SwimmingStyleAPI.Validation
{
    public class SwimmingStyleForCreationValidator : AbstractValidator<SwimmingStyleForCreation>
    {
        public SwimmingStyleForCreationValidator()
        {
            RuleFor(swimmingStyle => swimmingStyle.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("you should provide valid name")
                .MaximumLength(50);
            RuleFor(swimmingStyle => swimmingStyle.Image)
                .NotNull()
                .NotEmpty()
                .WithMessage("Tu aurais pas oublie une image fumier")
                .MaximumLength(150);
            RuleForEach(swimmingStyle => swimmingStyle.Tags)
                .NotNull()
                .NotEmpty()
                .WithMessage("Aloooeooo");
            RuleFor(swimmingStyle => swimmingStyle.Description)
                .NotNull()
                .NotEmpty()
                .MaximumLength(250);

        }
    }
}
