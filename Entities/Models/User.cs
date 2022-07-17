namespace Entities.Models;

public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Displayname { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public Post[]? Posts { get; set; }
    public Post[]? LikedPosts { get; set; }
    public Comment[]? Comments { get; set; }
    public Comment[]? LikedComments { get; set; }
    public Roles Roles { get; set; } = Roles.User;
    public DateTime RegistrationDate { get; set; }
}