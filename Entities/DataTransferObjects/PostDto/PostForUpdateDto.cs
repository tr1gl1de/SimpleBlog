namespace Entities.DataTransferObjects.PostDto;

public class PostForUpdateDto
{
    public List<string>? Tags { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
}