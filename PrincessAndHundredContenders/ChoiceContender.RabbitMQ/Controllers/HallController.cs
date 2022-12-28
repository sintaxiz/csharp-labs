using ChoiceContender.RabbitMQ.DataContracts;
using ChoiceContender.RabbitMQ.Dto;
using ChoiceContender.RabbitMQ.Model;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Contender = ChoiceContender.RabbitMQ.Dto.Contender;

namespace ChoiceContender.RabbitMQ.Controllers;

[ApiController]
[Route("api/")]
public class HallController : ControllerBase
{
    private readonly ILogger<HallController> _logger;

    private readonly IRequestClient<NextContenderRequest> _client;

    private HallModel? _hallModel;
    
    public HallController(ILogger<HallController> logger, IPublishEndpoint publishEndpoint, IRequestClient<NextContenderRequest> client)
    {
        _logger = logger;
        _client = client;
        _hallModel = HallModel.getInstance();
    }

    [HttpPost("hall/reset")]
    public void Reset([FromQuery] int session)
    {
        _logger.Log(LogLevel.Information, "{session: 0}",session.ToString());
        _hallModel.ResetAttempts();
    }

    [HttpPost( "hall/{attemptForNext}/next")]
    public async Task<Contender> NextContender([FromRoute] string attemptForNext, [FromQuery] int session)
    {
        var nextContenderMessage = 
            await _client.GetResponse<NextContender>(new { AttemptName = attemptForNext });
        return new Contender(nextContenderMessage.Message.Name);
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