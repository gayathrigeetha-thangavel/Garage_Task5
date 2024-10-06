using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class Garage<T> : IGarageHandler<T>, IEnumerable<T> where T  : Vehicle
{
    public T[] vehicles;
    private int count;
    public int maxCapacity;

    public int Count
    {
        get { return count; }
        set { count = value; }
    }

    UserValidation userValidation;

    //constructor for the garage class
    public Garage(int maxCapacity)
    {
        this.maxCapacity = maxCapacity;
        vehicles = new T[maxCapacity];
        count = 0;
        userValidation = new UserValidation();
    }


    // Add the vehicle to the garage with required details
    public bool AddVehicle(T vehicle)
    {
        if (count >= maxCapacity)
        {
            return false;
        }
        vehicles[count++] = vehicle; 
        return true;
    }


    // Remove the vehicle from the garage by vehicle registration number
    public bool RemoveVehicle(string vehicleRegNumber)
    {

        if (string.IsNullOrWhiteSpace(vehicleRegNumber.ToString()))
        {
            userValidation.PrintMessage("Invalid Registration number", "error");
            return false;
        }
        else
        {
            try{
                if (Regex.IsMatch(vehicleRegNumber,@"^[A-Za-z0-9]+$"))
                {
                    for (int i = 0; i < vehicles.Length; i++) 
                    { 
                        if (vehicles[i].VehicleNumber.Equals(vehicleRegNumber, StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine($"{vehicles[i].VehicleName} removed from the garage");

                            for (int j = i; j < count - 1; j++)
                            {
                                vehicles[j] = vehicles[j + 1];  
                            }

                            vehicles[count - 1] = null; 
                            count--;  
                            return true;
                        }
                        else
                        {
                            userValidation.PrintMessage("Error:Vehicle is not found", "error");
                        }
                    }
                }
                else{
                    return false;
                }
            }
            catch (Exception ex)
            {
                userValidation.PrintMessage($"Error: {ex.Message})", "error");
            }
        }
        return false;
    }


    public Vehicle GetVehicle(string vehicleRegNumber)
    {
        return  null;
    }

    public T GetVehicle(int index)
    {
        if (index < 0 || index >= count)
            Console.WriteLine("Invalid index.");

        return vehicles[index];
    }

    public IEnumerator<T> GetEnumerator()
    {
       for (int i = 0; i < Count ; i++)
       {
         yield return GetVehicle(i);
       }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
       return GetEnumerator();
    }
}