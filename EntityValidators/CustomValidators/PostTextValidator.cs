using FluentValidation;

namespace EntityValidators.CustomValidators;

public static class PostTextValidator
{
    public static IRuleBuilderOptions<T, string> PostTextValidation<T>(
        this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .NotNull()
            .NotEmpty()
            .MinimumLength(ValidationConsts.PostTextMinLength)
            .MaximumLength(ValidationConsts.PostTextMaxLength);
    }
}