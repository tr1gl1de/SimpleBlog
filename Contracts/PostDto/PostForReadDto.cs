using Contracts.CommentDto;

namespace Contracts.PostDto;

public class PostForReadDto
{
    public string UsernameCreator { get; set; } = string.Empty;
    public DateTime CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public List<string>? Tags { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public int LikesCount { get; set; } = 0;
    public List<CommentForReadDto>? Comments { get; set; }
    public int Views { get; set; } = 0;
}