using ChoiceContender.Web.Dto;
using ChoiceContender.Web.Model;
using Microsoft.AspNetCore.Mvc;

namespace ChoiceContender.Web.Controllers;

[ApiController]
[Route("api/")]
public class HallController : ControllerBase
{
    private readonly ILogger<HallController> _logger;

    private HallModel? _hallModel;
    
    public HallController(ILogger<HallController> logger)
    {
        _logger = logger;
        _hallModel = HallModel.getInstance();
    }

    [HttpPost("hall/reset")]
    public void Reset([FromQuery] int session)
    {
        _logger.Log(LogLevel.Information, "{session: 0}",session.ToString());
        _hallModel.ResetAttempts();
    }

    [HttpPost( "hall/{attemptForNext}/next")]
    public Contender NextContender([FromRoute] string attemptForNext, [FromQuery] int session)
    {
        var nextContenderName = _hallModel.CallNextContenderForAttempt(attemptForNext);
        return new Contender(nextContenderName);
    }

    [HttpGet("hall/{attemptForSelect}/select")]
    public ContenderRank SelectContender([FromRoute] string attemptForSelect, [FromQuery] int session)
    {
        var rank = _hallModel.SelectContenderForAttempt(attemptForSelect);
        if (rank == -1)
        {
            throw new BadHttpRequestException("attempt not found");
        }
        return new ContenderRank(rank);
    }

    
    [HttpPost("friend/{attemptForCompare}/compare")]
    public Contender CompareContenders([FromRoute] string attemptForCompare, string contender1, string contender2, [FromQuery] int session)
    {
        var nameWhoBetter = _hallModel.CompareContendersForAttempt(attemptForCompare, contender1, contender2);
        if (nameWhoBetter.Equals(""))
        {
            throw new BadHttpRequestException("wrong contenders!");
        }
        return new Contender(nameWhoBetter);
    }

}