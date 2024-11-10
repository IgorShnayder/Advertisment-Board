namespace Advertisements;

public class Advertisement
{
    private string _title;
    private string _text;
    
    public Advertisement(string title, string text)
    {
        _title = title;
        _text = text;
    }

    public string GetAdvertisementTitle()
    {
        return _title;
    }

    public string GetAdvertisementText()
    {
        return _text;
    }
}