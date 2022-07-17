namespace Contracts.CommentDto;

public class CommentForReadDto
{
    public string UsernameCreator { get; set; } = string.Empty;
    public DateTime CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public string Text { get; set; } = string.Empty;
    public int LikesCount { get; set; }
    public int CommentsCount { get; set; }
}