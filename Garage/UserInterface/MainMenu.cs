
public class MainMenu
{
    public void MenuItems()
    {

        MenuHandler menuHandler= new MenuHandler();

        //Main menu started here...
        Console.WriteLine("Welcome to the Garage:");
        int input = 0;
        do
        {
            ShowMenu();
            input = getUserChoice();
            executeUserChoice(input, menuHandler);
        }while (input != 0);   
    }

    private void ShowMenu()
    {
        Console.WriteLine("Main Menu");
        Console.WriteLine("1: Create garage and set the capacity");
        Console.WriteLine("2: Add/Remove vehicles from the garage");
        Console.WriteLine("3: List all the vehicles in the garage");
        Console.WriteLine("4: List the vehicle by types");
        Console.WriteLine("5: Search vehicles by Color and Wheel count");
        Console.WriteLine("0: Quit\n");
    }

    private static int getUserChoice()
    {
        Console.WriteLine("Enter your choice:");
        int userInput = Convert.ToInt32(Console.ReadLine());
        return userInput;
    }

    //main menu actions
    private static void executeUserChoice(int choice, MenuHandler menuHandler)
    {
        switch (choice)
        {
            case 0:
                Console.WriteLine("Exiting...");
                break;
            case 1:
                menuHandler.CreateGarageSet();
                break;
            case 2:
                menuHandler.AddOrRemoveVehicles();
                break;
            case 3:
                menuHandler.ListAllVehicles();
                break;
            case 4:
                menuHandler.ListDifferentTypesOfVehicles();
                break;
            case 5:
                menuHandler.SearchVehiclesByColorAndWheelCount(); 
                break;
            default:
                Console.WriteLine("Choose only 1 to 5 options\n");
                break;
        }
    }

}