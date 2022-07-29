using Contracts.UserDto;
using FluentValidation;

namespace EntityValidators.Validators.UserValidators;

public class UserForReadDtoValidator : AbstractValidator<UserForReadDto>
{
    public UserForReadDtoValidator()
    {
        RuleFor(u => u.Username).NotNull().MinimumLength(3).MaximumLength(25);
        RuleFor(u => u.Displayname).NotNull().MinimumLength(2).MaximumLength(30);
    }
}