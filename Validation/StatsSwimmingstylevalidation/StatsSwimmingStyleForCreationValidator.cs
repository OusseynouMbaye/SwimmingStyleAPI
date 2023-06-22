using FluentValidation;
using SwimmingStyleAPI.Models.StatsDto;

namespace SwimmingStyleAPI.Validation.StatsSwimmingstylevalidation
{
    public class StatsSwimmingStyleForCreationValidator : AbstractValidator<StatsSwimmingstyleForCreationDto>
    {
        public StatsSwimmingStyleForCreationValidator()
        {
            RuleFor(statsSwimmingStyle => statsSwimmingStyle.Speed)
                .NotNull()
                .WithMessage("you should provide valid speed");
            RuleFor(statsSwimmingStyle => statsSwimmingStyle.Endurance)
                .NotNull()
                .InclusiveBetween(1,9)
                .WithMessage("you should provide value for endurance between 1 to 9");
            RuleFor(statsSwimmingStyle => statsSwimmingStyle.Technique)
                .NotNull()
                .WithMessage("you should provide valid technique");
            RuleFor(statsSwimmingStyle => statsSwimmingStyle.Difficulty)
                .NotNull()
                .WithMessage("you should provide valid difficulty");
        }
    }
}
