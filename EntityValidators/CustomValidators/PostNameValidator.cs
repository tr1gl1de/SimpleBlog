using FluentValidation;

namespace EntityValidators.CustomValidators;

public static class PostNameValidator
{
    public static IRuleBuilderOptions<T, string> PostNameValidation<T>(
        this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .NotEmpty()
            .NotNull()
            .MinimumLength(ValidationConsts.PostNameMinLength)
            .MaximumLength(ValidationConsts.PostNameMaxLength);
    }
}