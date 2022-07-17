namespace Contracts.CommentDto;

public class CommentForCreationDto
{
    public Guid PostId { get; set; }
    public string Text { get; set; } = string.Empty;
    public Guid? ParentCommentId { get; set; }
}