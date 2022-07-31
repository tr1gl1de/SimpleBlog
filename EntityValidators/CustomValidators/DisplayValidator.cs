using FluentValidation;

namespace EntityValidators.CustomValidators;

public static class DisplayValidator
{
    public static IRuleBuilderOptions<T, string> DisplaynameValidation<T>(
        this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .NotEmpty()
            .NotNull()
            .MinimumLength(ValidationConsts.DisplaynameMinLength)
            .MaximumLength(ValidationConsts.DisplaynameMaxLength);
    }
}