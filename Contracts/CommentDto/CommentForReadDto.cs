namespace Contracts.CommentDto;

public class CommentForReadDto
{
    public Guid CommentId { get; set; }
    public string UsernameCreator { get; set; } = string.Empty;
    public DateTime CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public string Text { get; set; } = string.Empty;
    public int LikesCount { get; set; }
    public Guid? ParentCommentId { get; set; }
    public List<CommentForReadDto>? ChildrenComments { get; set; }
}