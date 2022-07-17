﻿namespace Entities.Models;

public class Post
{
    public Guid Id { get; set; }
    public string UsernameCreator { get; set; } = string.Empty;
    public DateTime CreateDate { get; set; } = DateTime.UtcNow;
    public DateTime? UpdateDate { get; set; }
    public List<string>? Tags { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public int LikesCount { get; set; } = 0;
    public List<Comment>? Comments { get; set; }
    public int CommentsCount { get; set; } = 0;
    public int Views { get; set; } = 0;
}