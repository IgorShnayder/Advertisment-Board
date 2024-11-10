namespace Advertisements;

public static class Program
{
    public static void Main()
    { 
        var newBoard = new AdvertisementBoard();
        var programStart = new LoginAndRegistration();
        programStart.ShowAuthorizationMenu(newBoard);
    }
}

