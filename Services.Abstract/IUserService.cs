using Contracts.UserDto;

namespace Services.Abstract;

public interface IUserService
{
    Task<UserForReadDto> RegisterUserAsync(UserForRegDto userForReg, CancellationToken cancellationToken = default);
    Task<UserForReadDto> AuthenticateUserAsync(UserForLoginDto userForLogin, CancellationToken cancellationToken = default);
    Task<UserForReadDto> GetUserByUsername(string username, CancellationToken cancellationToken = default);

    Task UpdateUserByUsername(string username, UserForUpdateDto userForUpdate,
        CancellationToken cancellationToken = default);
}