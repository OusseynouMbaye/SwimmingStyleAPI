using FluentValidation;
using SwimmingStyleAPI.Entitites;

namespace SwimmingStyleAPI.Validation
{
    public class SwimmingStyleEntitiesValidator : AbstractValidator<SwimmingStyleEntities>
    {
        public SwimmingStyleEntitiesValidator()
        {
            RuleFor(swimmingStyle => swimmingStyle.Name)
                .NotNull()
                .WithMessage("you should provide valid name");
           /* RuleFor(swimmingStyle => swimmingStyle.Image)
                .NotNull()
                .WithMessage("you should provide valid image");
            RuleFor(swimmingStyle => swimmingStyle.Description)
                .Length(1, 200)
                .WithMessage("you should provide valid description");
            RuleFor(swimmingStyle => swimmingStyle.Tags)
                .NotNull()
                .WithMessage("you should provide valid tags");
            RuleForEach(swimmingStyle => swimmingStyle.Tags)
                .Length(1, 10)
                .WithMessage("you should provide valid tags");*/
        }
    }
}
