using EmojiGeneratorAPI;
using EmojiGeneratorAPI.Models;
namespace EmojiGeneratorAPIj.Repository;

public class EmojiRepository : IRepository
{
    private readonly HttpClient _httpClient;
    private List<Emoji> _emojis = new List<Emoji>();
    public EmojiRepository()
    {
        _httpClient = new HttpClient();
    }
    public async Task Get()
    {
        var response = await _httpClient.GetAsync("https://emojihub.herokuapp.com/api/all");
        var data = await response.Content.ReadAsStringAsync();

        // _emojis = from emoji in data
        //           select emoji;
    }
}