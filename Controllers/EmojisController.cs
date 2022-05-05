using EmojiGeneratorAPIj.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EmojiGeneratorAPI;

[ApiController]
[Route("api/[controller]")]
public class EmojisController : ControllerBase
{
    [HttpGet]
    public ActionResult GetAll()
    {
        IRepository emojiRepo = new EmojiRepository();
        return Ok(emojiRepo.Get());
    }

}