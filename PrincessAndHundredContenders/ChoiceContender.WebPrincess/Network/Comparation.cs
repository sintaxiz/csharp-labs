namespace ChoiceContender.WebPrincess.Network;

public class Comparation
{
    private List<string> _contenders;
    private RestApi _restApi;
    
    public Comparation(string name1, string name2)
    {
        _restApi = new RestApi();
    }

    public void AddContender(string name)
    {
        _contenders.Add(name);
    }

    public async Task<bool> compare(int i, int id)
    {
        var compareResult = await _restApi.СompareContenders(new Comparation(_contenders[i], _contenders.Last()), id);
        if (compareResult == _contenders[i])
        {
            return false;
        }
        return true;
    }
}