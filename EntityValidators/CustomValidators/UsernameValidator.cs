using FluentValidation;

namespace EntityValidators.CustomValidators;

public static class UsernameValidator
{
    public static IRuleBuilderOptions<T, string> UsernameValidation<T>(
        this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .NotEmpty()
            .NotNull()
            .MinimumLength(ValidationConsts.UsernameMinLength)
            .MaximumLength(ValidationConsts.UsernameMaxLength);
    }
}