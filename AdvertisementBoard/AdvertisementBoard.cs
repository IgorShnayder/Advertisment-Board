namespace Advertisements;

public class AdvertisementBoard 
{
    private List<User> _users = new();
    
    private enum AdvertisementMenu
    {
        CreateNewAdvertisement,
        ShowUserAdvertisementFully, 
        DeleteUserAdvertisement,
        DeleteUserAdvertisements, 
        ShowOtherUsersAdvertisements,
        ReturnToAuthorizationMenu, 
        ProgramExit
    } 
    
    public void GetAdvertisementMenu(User user)
    {
        while(true)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Welcome, {user.GetName()}!\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Number of your listings - {user.GetAdvertisementsQuantity()}.\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1. Create a new listing.");
            Console.WriteLine("2. Show your listing in full.");
            Console.WriteLine("3. Delete your listing.");
            Console.WriteLine("4. Delete all your listings.");
            Console.WriteLine("5. View listings from other users.");
            Console.WriteLine("6. Log out and return to the login menu.");
            Console.WriteLine("7. Exit the program.\n");
            Console.ResetColor();
            Console.Write("Select the action number: ");
                
            Console.ForegroundColor = ConsoleColor.Yellow;
            var consoleMenuItem = (AdvertisementMenu)InputExсeption.InputExсeptionCatch(7);
            Console.WriteLine();
            Console.ResetColor();
                 
            switch (consoleMenuItem) 
            {
                case AdvertisementMenu.CreateNewAdvertisement:
                    CreateNewAdvertisement(user);
                    break;
                     
                case AdvertisementMenu.ShowUserAdvertisementFully:
                    ShowAdvertisementFully(user);
                    break;
                    
                case AdvertisementMenu.DeleteUserAdvertisement:
                    DeleteAdvertisement(user);
                    break;
                    
                case AdvertisementMenu.DeleteUserAdvertisements:
                    DeleteAdvertisements(user);
                    break;
                    
                case AdvertisementMenu.ShowOtherUsersAdvertisements:
                    PrintOtherUsersAdvertisement(user);
                    break;
                   
                case AdvertisementMenu.ReturnToAuthorizationMenu:
                    new LoginAndRegistration().ShowAuthorizationMenu(this);
                    break;
                   
                case AdvertisementMenu.ProgramExit:
                    ProgramExit();
                    break;
                    
                default:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nYou have selected an action not available in this section. Please try again.");
                    Console.ResetColor();
                    break;
            }
        }
    }
    
    public bool HasUser(string login, string password)  
    {
        return _users.Any(boardUser => boardUser.GetLogin() == login && boardUser.GetPassword() == password);
    }
    
    public User GetUser(string login, string password)
    { 
        var authorizedUserIndex = _users.FindIndex(boardUser => boardUser.GetLogin() == login && boardUser.GetPassword() == password);
        return _users[authorizedUserIndex];
    }

    public bool IsLoginFree(string login)
    {
        return _users.All(user => user.GetLogin() != login);
    }

    public void AddNewUser(string login, string password, string name)
    {
        _users.Add(new User(login, password, name));
    }
    
    private void PrintOtherUsersAdvertisement(User user)
    {
        var usersWithAdvertisements = _users.Where(users => users.GetLogin() != user.GetLogin()).ToList();

        if (usersWithAdvertisements.Count == 0)
        {
            Console.WriteLine("There are no listings from other users on the board yet.\n");
            return;
        }
        
        foreach (var users in usersWithAdvertisements)
        {
            if (users.GetAdvertisementsQuantity() <= 0) continue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"User's listings {users.GetName()}:\n");
            Console.ResetColor();
            users.GetAllAdvertisements();
        }
    }
    
    private void CreateNewAdvertisement(User user)
    {
        Console.Write("Please enter the title of your listing: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        var advertisementTitle = Console.ReadLine();
        Console.ResetColor();
                   
        if (user.IsAdvertisementTitleTaken(advertisementTitle))
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nYou already have a listing with this title. Please create a different one.");
            Console.ResetColor();
            return;
        }
                   
        Console.Write("\nPlease enter the text of your listing: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        var advertisementText = Console.ReadLine();
        Console.ResetColor();
                   
        var advertisement = new Advertisement(advertisementTitle, advertisementText);
        user.AddAdvertisement(advertisement);
        Console.WriteLine();
    }

    private void ShowAdvertisementsTitle(User user)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Your listings: \n");
        Console.ResetColor();
        user.PrintAllAdvertisementsTitle();
    }

    private void ShowAdvertisementFully(User user)
    {
        if (user.GetAdvertisementsQuantity() <= 0)
        {
            GetZeroAdvertisement();
            return;
        }
                   
        ShowAdvertisementsTitle(user);
            
        Console.Write("Enter the number of the listing you want to display: ");
                       
        var advertisementNumber = InputExсeption.InputExсeptionCatch(user.GetAdvertisementsQuantity());
                       
        if (advertisementNumber >= 0 && advertisementNumber <= user.GetAdvertisementsQuantity())
        {
            user.PrintAdvertisementTitleAndName(advertisementNumber);
            Console.WriteLine();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nYou don't have a listing with that number.\n");
        }
    }

    private void DeleteAdvertisement(User user)
    {
        if (user.GetAdvertisementsQuantity() <= 0)
        {
            GetZeroAdvertisement();
            return;
        }
        
        ShowAdvertisementsTitle(user);
            
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Enter the number of the listing you want to delete: ");
        Console.ResetColor();
                   
        Console.ForegroundColor = ConsoleColor.Yellow;
        var numberOfAdvertisement = InputExсeption.InputExсeptionCatch(user.GetAdvertisementsQuantity());
        Console.ResetColor();
                       
        user.DeleteAdvertisement(numberOfAdvertisement);
    }

    private void GetZeroAdvertisement()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("You have no listings created.\n");
        Console.ResetColor();
    }
    
    private void DeleteAdvertisements(User user)
    {
        if (user.GetAdvertisementsQuantity() <= 0)
        {
            GetZeroAdvertisement();
            return;
        }
        
        user.DeleteAllAdvertisement();
    }
    
    private void ProgramExit()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("All the best!");
        Console.ResetColor();
        Environment.Exit(0);
    }
}