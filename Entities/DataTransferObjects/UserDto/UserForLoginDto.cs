﻿namespace Entities.DataTransferObjects.UserDto;

public class UserForLoginDto
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}