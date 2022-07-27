using Contracts.PostDto;
using FluentValidation;

namespace EntityValidators.Validators.PostValidators;

public class PostForCreateDtoValidator : AbstractValidator<PostForCreationDto>
{
    public PostForCreateDtoValidator()
    {
        RuleFor(post => post.Name).NotNull().MinimumLength(3).MaximumLength(30);
        RuleFor(post => post.Tags).Must(post => post?.Count <= 10);
        RuleFor(post => post.Text).NotNull().MinimumLength(3);
    }   
}