using Entities.Models;

namespace Entities.DataTransferObjects.PostDto;

public class PostForReadDto
{
    public string UsernameCreator { get; set; } = string.Empty;
    public DateTime CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public string[]? Tags { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public int LikesCount { get; set; } = 0;
    public Comment[]? Comments { get; set; }
    public int Views { get; set; } = 0;
}