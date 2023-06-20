using FluentValidation;
using SwimmingStyleAPI.Entitites;

namespace SwimmingStyleAPI.Validation.StatsSwimmingstylevalidation
{
    public class StatsSwimmingStyleEntitiesValidator : AbstractValidator<StatsSwimmingstyleEntities>
    {

        public StatsSwimmingStyleEntitiesValidator()
        {
            RuleFor(x => x.Speed).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Endurance).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Technique).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Difficulty).GreaterThanOrEqualTo(0);
        }
    }
}
