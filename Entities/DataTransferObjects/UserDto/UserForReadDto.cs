using Entities.Models;

namespace Entities.DataTransferObjects.UserDto;

public class UserForReadDto
{
    public string Username { get; set; } = string.Empty;
    public string Displayname { get; set; } = string.Empty;
    public Roles Role { get; set; }
}