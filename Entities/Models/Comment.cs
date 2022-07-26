﻿namespace Entities.Models;

public class Comment
{
    public Guid Id { get; set; }
    public Guid PostId { get; set; }
    public string UsernameCreator { get; set; } = string.Empty;
    public DateTime CreateDate { get; set; } = DateTime.UtcNow;
    public DateTime? UpdateDate { get; set; }
    public string Text { get; set; } = string.Empty;
    public uint LikesCount { get; set; } = 0;
    public Guid? ParentCommentId { get; set; }
    public List<Comment>? ChildrenComments { get; set; }
}