using EntityValidators.Validators.PostValidators;
using EntityValidators.Validators.UserValidators;

namespace EntityValidators;

public class ValidatorManager
{
    public PostForCreateDtoValidator PostForCreateValidator { get; } = new();
    public UserForReadDtoValidator UserForReadValidator { get; } = new();
}