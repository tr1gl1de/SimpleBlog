using Contracts.UserDto;
using FluentValidation;

namespace EntityValidators.Validators.UserValidators;

public class UserForReadDtoValidator : AbstractValidator<UserForReadDto>
{
    public UserForReadDtoValidator()
    {
        RuleFor(u => u.Username).NotNull().MinimumLength(3).MaximumLength(10);
        RuleFor(u => u.Displayname).NotNull().MinimumLength(3).MaximumLength(20);
    }
}