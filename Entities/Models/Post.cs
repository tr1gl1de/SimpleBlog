﻿namespace Entities.Models;

public class Post
{
    public Guid Id { get; set; }
    public string UsernameCreator { get; set; } = string.Empty;
    public DateTime CreateData { get; set; } = DateTime.UtcNow;
    public DateTime? UpdateData { get; set; }
    public string[]? Tags { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public int LikesCount { get; set; } = 0;
    public Comment[]? Comments { get; set; }
    public int Views { get; set; } = 0;
}