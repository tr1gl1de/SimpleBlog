using EntityValidators.Validators.PostValidators;

namespace EntityValidators;

public class ValidatorManager
{
    public PostForCreateDtoValidator PostForCreateValidator { get; } = new();
}