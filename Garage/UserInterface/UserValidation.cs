using System.Text.RegularExpressions;

public class UserValidation
{

    ConsoleMessage consoleMessage = new ConsoleMessage();
    internal bool ValidateInteger(int inputNumber)
    {
        if (inputNumber <= 0)
        {
            return false;
        }
        return true;
    }

    internal bool ValidateString(string inputString)
    {
        if (string.IsNullOrEmpty(inputString))
        {
            return false;
        }
        return true;
    }


    public bool ValidateInputsToAddVehicle(Vehicle vehicle)
    {
        ValidateRegNumber(vehicle.VehicleNumber);
        ValidateString(vehicle.VehicleName);
        ValidateString(vehicle.VehicleColor);
        ValidateInteger(vehicle.NumberOfWheels);
        bool isValid = ValidateVehicleType(vehicle.VehicleCategory);
        if (!isValid)
        { 
            consoleMessage.PrintMessage("Vehicle type should not be null.", "error");
        }
        return true;
    }

    public bool ValidateRegNumber(string regNumber)
    {
        try{
            if (!ValidateString(regNumber))
            {
                Console.WriteLine("Registration number should not be null");
            }
            else
            {
                bool isValidRegNumber= Regex.IsMatch(regNumber,@"^[A-Za-z0-9]+$");
            
                if (isValidRegNumber)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Registration number is in invalid format\n");
                }
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine($"{ex.Message}\n");
        }
        return false;
    }

    public bool ValidateVehicleType(string vehicleTypeString)
    {
        if (!ValidateString(vehicleTypeString))
        {
            return false;
        }
        else
        {
            foreach (VehicleType item in Enum.GetValues(typeof(VehicleType)))
            {
                if (vehicleTypeString.Equals(item.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
        }
        return false ;
    } 


    

}