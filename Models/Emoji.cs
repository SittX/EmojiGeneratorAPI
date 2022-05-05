namespace EmojiGeneratorAPI.Models;

public class Emoji
{
    public string? Name { get; set; }
    public string? Category { get; set; }
    public string? Group { get; set; }
    public string[]? HtmlCode { get; set; }
    public string[]? Unicode { get; set; }
}