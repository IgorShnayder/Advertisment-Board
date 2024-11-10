namespace Advertisements;

public class User
{
    private string _login;
    private string _password;
    private string _userName;
    private List<Advertisement> _advertisements;

    public User(string login, string password, string name)
    {
        _login = login;
        _password = password;
        _userName = name;
        _advertisements = new List<Advertisement>();
    }

    private enum AdvertisementDeleteMenu
    {
        DeleteAdvertisement,
        NotDelete
    }
    
    public string GetLogin()
    {
        return _login;
    }

    public string GetPassword()
    {
        return _password;
    }

    public string GetName()
    {
        return _userName;
    }

    public void AddAdvertisement(Advertisement advertisement)
    {
        _advertisements.Add(advertisement);
    }
    
    public void GetAllAdvertisements()
    {
        foreach (var advertisement in _advertisements)
        {
            Console.Write("Title: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{advertisement.GetAdvertisementTitle()}");
            Console.ResetColor();
            Console.Write("Listing text: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{advertisement.GetAdvertisementText()}\n");
            Console.ResetColor();
        }
    }
    
    public void DeleteAdvertisement(int index)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nYour listing will be permanently deleted. Are you sure you want to delete it?\n");
        Console.ResetColor();
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("1. Yes.");
        Console.WriteLine("2. No.");
        Console.ResetColor();
        Console.Write("\nSelect the action number: ");
                       
        Console.ForegroundColor = ConsoleColor.Yellow;
        var consoleMenuItem = (AdvertisementDeleteMenu)InputExсeption.InputExсeptionCatch(2);;
        Console.ResetColor();

        switch (consoleMenuItem)
        {
            case AdvertisementDeleteMenu.DeleteAdvertisement:
                _advertisements.RemoveAt(index);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nYour listing has been deleted.\n");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"You have {_advertisements.Count} listings.\n");
                Console.ResetColor();
                break;
            
            case AdvertisementDeleteMenu.NotDelete:
                GetNotRemoveAdvertisement();
                break;
            
            default:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nYou have selected an action not supported in this section. Please try again.");
                Console.ResetColor();
                break;
        }
    }

    public void DeleteAllAdvertisement()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("All your listings will be permanently deleted. Are you sure you want to delete them?\n");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("1. Yes.");
        Console.WriteLine("2. No.");
        Console.ResetColor();
        Console.Write("\nSelect the action number: ");

        Console.ForegroundColor = ConsoleColor.Yellow;
        var advertisementDeleteMenu = (AdvertisementDeleteMenu)InputExсeption.InputExсeptionCatch(2);
        Console.ResetColor();

        switch (advertisementDeleteMenu)
        {
            case AdvertisementDeleteMenu.DeleteAdvertisement:
                _advertisements.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nAll listings have been deleted.\n");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"You have {_advertisements.Count} listings.\n");
                Console.ResetColor();
                break;

            case AdvertisementDeleteMenu.NotDelete:
                GetNotRemoveAdvertisement();
                break;

            default:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(
                    "\nYou have selected an action not supported in this section. Please try again.");
                Console.ResetColor();
                break;
        }
    }

    private void GetNotRemoveAdvertisement()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nYou can continue working with your listings.\n");
        Console.ResetColor();
    }

    public int GetAdvertisementsQuantity()
    {
        return _advertisements.Count;
    }

    public bool IsAdvertisementTitleTaken(string name)
    {
       return _advertisements.Any(advertisement => advertisement.GetAdvertisementTitle() == name);
    }

    public void PrintAllAdvertisementsTitle()
    {
        for (var i = 0; i < _advertisements.Count; i++)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{i + 1}. {_advertisements[i].GetAdvertisementTitle()}\n");
            Console.ResetColor();
        }
    }

    public void PrintAdvertisementTitleAndName(int index)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nYour listing: \n");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write($"Listing title: ");
        Console.ResetColor();
        Console.WriteLine($"{_advertisements[index].GetAdvertisementTitle()}\n");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Listing text: ");
        Console.ResetColor();
        Console.WriteLine($"{_advertisements[index].GetAdvertisementText()}");
    }
}