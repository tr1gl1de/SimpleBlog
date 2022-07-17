namespace Entities.Models;

public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Displayname { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public List<Post>? Posts { get; set; }
    public List<Post>? LikedPosts { get; set; }
    public List<Comment>? Comments { get; set; }
    public List<Comment>? LikedComments { get; set; }
    public Roles Roles { get; set; } = Roles.User;
    public DateTime RegistrationDate { get; set; }
}