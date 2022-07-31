using Contracts.UserDto;
using EntityValidators.CustomValidators;
using FluentValidation;

namespace EntityValidators.Validators.UserValidators;

public class UserForReadDtoValidator : AbstractValidator<UserForReadDto>
{
    public UserForReadDtoValidator()
    {
        RuleFor(u => u.Username).UsernameValidation();
        RuleFor(u => u.Displayname).DisplaynameValidation();
    }
}