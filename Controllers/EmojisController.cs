using EmojiGeneratorAPI;
using EmojiGeneratorAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmojiGeneratorAPI;

[ApiController]
[Route("api/[controller]")]
public class EmojisController : ControllerBase
{
    private readonly IRepository _emojiRepo;
    public EmojisController(IRepository emojiRepo)
    {
        _emojiRepo = emojiRepo;
    }


    [HttpGet]
    public async Task<ActionResult<Emoji>> GetAll()
    {
        IEnumerable<Emoji> emojis = await _emojiRepo.Get();
        return Ok(emojis);
    }

    [HttpGet]
    [Route("{category}")]
    public async Task<ActionResult<List<Emoji>>> GetByCategory(string category)
    {
        IEnumerable<Emoji> emojis = await _emojiRepo.Get();

        var groups = from emoji in emojis
                     group emoji by emoji.Category;


        List<Emoji>? result = new List<Emoji>();

        foreach (var group in groups)
        {
            if (group.Key.ToLower() == category.ToLower())
            {
                result = group.ToList();
            }
        }
        if (result != null && result.Count > 0)
        {
            return Ok(result);

        }
        return BadRequest("Data with the current input cannot be found. Please try again.");
    }

    [HttpGet]
    [Route("{category}/{limit}")]
    public async Task<ActionResult<List<Emoji>>> GetByLimit(string category, int limit)
    {
        IEnumerable<Emoji> emojis = await _emojiRepo.Get();

        var groups = from emoji in emojis
                     group emoji by emoji.Category;

        List<Emoji>? result = new List<Emoji>();

        foreach (var group in groups)
        {
            if (group.Key.ToLower() == category.ToLower())
            {
                result = group.Take(limit).ToList();
            }
        }

        if (result != null || result.Count > 0)
        {
            return Ok(result);
        }
        return BadRequest("Data with the current input cannot be found. Please try again.");
    }

}