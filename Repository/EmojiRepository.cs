using System.Net.Http.Json;
using System.Text.Json;
using EmojiGeneratorAPI;
using EmojiGeneratorAPI.Models;
using Newtonsoft.Json;
namespace EmojiGeneratorAPI;

public class EmojiRepository : IRepository
{
    private static List<Emoji>? _emojis;
    private readonly IHttpClientFactory _httpClientFactory;
    static EmojiRepository()
    {
        _emojis = new List<Emoji>();
    }
    public EmojiRepository(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IEnumerable<Emoji>> Get()
    {
        if (_emojis == null || _emojis.Count <= 0)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var json = await httpClient.GetStringAsync("https://emojihub.herokuapp.com/api/all");
            _emojis = JsonConvert.DeserializeObject<List<Emoji>>(json);
            return _emojis;
        }
        else
        {
            return _emojis;
        }
    }
}