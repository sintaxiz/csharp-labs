using ChoiceContender.WebPrincess.Network;

namespace ChoiceContender.WebPrincess;

public class WebFreind : IFreind
{
    private readonly RestApi _restApi;
    private int _attemptId;
    private Comparation _comraration;

    public WebFreind(RestApi restApi)
    {
        _restApi = restApi;
    }

    public async Task<bool> AskWhoBetter(int i)
    {
        _restApi.NextContender(_attemptId);
        return await _comraration.compare(i, _attemptId);
    }

    public void SetAttempt(int attemptId)
    {
        _attemptId = attemptId;
    }
}