using Contracts.PostDto;
using EntityValidators.CustomValidators;
using FluentValidation;

namespace EntityValidators.Validators.PostValidators;

public class PostForCreateDtoValidator : AbstractValidator<PostForCreationDto>
{
    public PostForCreateDtoValidator()
    {
        RuleFor(post => post.Name).PostNameValidation();
        RuleFor(post => post.Tags)!.PostTagsValidation();
        RuleFor(post => post.Text).PostTextValidation();
    }   
}