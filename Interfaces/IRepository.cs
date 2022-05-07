using EmojiGeneratorAPI.Models;
namespace EmojiGeneratorAPI;

public interface IRepository
{
    Task<IEnumerable<Emoji>> Get();
}