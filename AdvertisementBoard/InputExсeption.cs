namespace Advertisements;

public abstract class InputExсeption
{
    public static int InputExсeptionCatch(int MenuItems) 
    {
        var inputDigit = 0;
        var inputExceptionCatch = true;
        
        while (inputExceptionCatch)
        {
            try
            {
                inputDigit = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.Write("\nYou entered not acceptable character for this menu. Please try again. Select the action number: ");
                continue;
            }
    
            if (inputDigit > 0 && inputDigit < MenuItems + 1)
            {
                inputExceptionCatch = false;
            }
            else
            {
                Console.Write("\nYou entered not acceptable character for this menu. Please try again. Select the action number: ");
            }
        }
        
        return inputDigit - 1;
    }
}