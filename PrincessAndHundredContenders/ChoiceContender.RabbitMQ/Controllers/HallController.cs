using ChoiceContender.RabbitMQ.SharedClassLibrary;
using ChoiceContender.Web.Dto;
using ChoiceContender.Web.Model;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace ChoiceContender.RabbitMQ.Controllers;

[ApiController]
[Route("api/")]
public class HallController : ControllerBase
{
    private readonly ILogger<HallController> _logger;

    private readonly IPublishEndpoint _publishEndpoint;
    
    private HallModel? _hallModel;
    
    public HallController(ILogger<HallController> logger, IPublishEndpoint publishEndpoint)
    {
        _logger = logger;
        _publishEndpoint = publishEndpoint;
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
    public async Task<IActionResult> SelectContender([FromRoute] string attemptForSelect, [FromQuery] int session)
    {
        var rank = _hallModel.SelectContenderForAttempt(attemptForSelect);
        if (rank == -1)
        {
            throw new BadHttpRequestException("attempt not found");
        }
        await _publishEndpoint.Publish<ChosenContender>(
            new
            {
                Id = 1,
                rank
            });
        
        return Ok();
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