using FluentValidation;

namespace EntityValidators.CustomValidators;

public static class PostTagsValidator
{
    public static IRuleBuilderOptions<T, IList<string>> PostTagsValidation<T>(
        this IRuleBuilder<T, IList<string>> ruleBuilder)
    {
        return ruleBuilder
            .Must(post => post?.Count <= ValidationConsts.PostTagsMaxLength);
    }
}