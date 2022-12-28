using ChoiceContender.WebPrincess.Network;

namespace ChoiceContender.WebPrincess;

public class WebHall : IHall
{
    private RestApi _api;
    private int _attemptId;

    public WebHall(RestApi api)
    {
        _api = api;
    }

    public int GetContendersCount()
    {
        return 100;
    }

    public int CurrentContender { get; set; }
    public async Task CallNextContender()
    {
        await _api.NextContender(_attemptId);
        CurrentContender++;
    }

    public void SetAttemptId(int attemptId)
    {
        _attemptId = attemptId;
    }
}