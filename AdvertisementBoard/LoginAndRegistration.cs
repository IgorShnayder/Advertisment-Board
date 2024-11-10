namespace Advertisements;

public class LoginAndRegistration
{
    private int _authorizationCount;

    private enum AuthorizationMenu 
    {
         Login,
         Registration,
         ProgramExit
    }
    
    public void ShowAuthorizationMenu(AdvertisementBoard advertisementBoard)
    {
        var isAuthorized = false;
        User activeUser = null;
        
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Unauthorized users cannot create listings! " +
                          "Successful login is only possible if you have an account or after registration.\n");
        Console.ResetColor();
        
        while(!isAuthorized) 
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1. Log in.");
            Console.WriteLine("2. Register.");
            Console.WriteLine("3. Exit the program.");
            Console.ResetColor();
            Console.Write("\nSelect the action number: ");
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            var authorizationMenu = (AuthorizationMenu)InputExсeption.InputExсeptionCatch(3);
            Console.ResetColor();
            
            switch (authorizationMenu) 
            {
                case AuthorizationMenu.Login:
                    if (IsLoginSuccessful(advertisementBoard, ref activeUser)) 
                    {
                        isAuthorized = true;
                    }
                    break;
                
                case AuthorizationMenu.Registration:
                    Register(advertisementBoard); 
                    break;
                
                case AuthorizationMenu.ProgramExit:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nAll the best!");
                    Console.ResetColor();
                    Environment.Exit(0);
                    break;
                
                default:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nYou have selected an action not supported to begin using our application. " +
                                      "Please try again.");
                    Console.ResetColor();
                    break;
            }
        }
        
        advertisementBoard.GetAdvertisementMenu(activeUser);
    }
    

    private bool IsLoginSuccessful(AdvertisementBoard advertisementBoard, ref User activeUser)
    {
        Console.WriteLine("\nPlease enter your login and password to authenticate.\n");
        
        Console.Write("Login: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        var login = Console.ReadLine();
        Console.ResetColor();
            
        Console.Write("Password: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        var password = Console.ReadLine();
        Console.ResetColor();
        
        var hasAuthorization = advertisementBoard.HasUser(login, password);
        
        if (hasAuthorization)
        {
            _authorizationCount = 0;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nYou have successfully logged in.\n");
            Console.ResetColor();
            activeUser = advertisementBoard.GetUser(login, password);
        }
        else
        {
            _authorizationCount++;
            
            if (_authorizationCount > 4)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nYou have attempted to log in {_authorizationCount} times. For security reasons, " +
                                  $"the login is blocked for the next 5 minutes. Please try again in 5 minutes.");
                Console.ResetColor();
                Environment.Exit(0);
            }
            else 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nThe login or password is incorrect, or an account with this login does not exist. " +
                                  "Please try entering your login and password again, or register.\n");
                Console.ResetColor();
            }
        }
        
        return hasAuthorization;
    }

    private void Register(AdvertisementBoard advertisementBoard) 
    {
        Console.WriteLine("\nPlease enter your login and password to register.");

        var isLoginAvailable = false; 
                                        
        string login = null;
        
        while (!isLoginAvailable) 
        {
            Console.Write("\nLogin: ");
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            login = Console.ReadLine();
            Console.ResetColor();

            isLoginAvailable = advertisementBoard.IsLoginFree(login);

            if (isLoginAvailable) continue;
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nThis login is already registered, please try another one!");
            Console.ResetColor();
        }
        
        Console.Write("Password: ");
        
        Console.ForegroundColor = ConsoleColor.Yellow;
        var password = Console.ReadLine();
        Console.ResetColor();
        
        Console.Write("Name: ");
        
        Console.ForegroundColor = ConsoleColor.Yellow;
        var userName = Console.ReadLine();
        Console.ResetColor();
        
        advertisementBoard.AddNewUser(login, password, userName);
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nYou have successfully registered!\n");
        Console.ResetColor();
        
        _authorizationCount = 0;
    }
}