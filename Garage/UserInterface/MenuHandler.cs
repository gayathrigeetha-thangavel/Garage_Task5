
using System.Net.Http.Headers;

public class MenuHandler : Vehicle
{
    int garageCapacity = 0;
    UserValidation userValidation = new UserValidation();

    Garage<Vehicle> vehicleGarage = new Garage<Vehicle>(0);

    Vehicle vehicle = new Vehicle();


    // Main menu: Case 1 : create and set the capacity of the garage
    internal void CreateGarageSet()
    {
        Console.WriteLine("Enter the capacity of the garage:");
        garageCapacity = int.Parse(Console.ReadLine());
        bool isCheckInteger = userValidation.ValidateInteger(garageCapacity);
        try{
            if (isCheckInteger)
            {
                vehicleGarage = new Garage<Vehicle>(garageCapacity);
                Console.WriteLine("Garage is ready to park the vehicles");
                vehicleGarage.maxCapacity = garageCapacity;
            }
            else
            {
                Console.WriteLine("Garage is empty");
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Log error:{ex.Message}");
        }
    }


    // Main menu: Case 2: Add or remove vehicles. Handled separate switch case to execute this operation with sub menu

    internal void AddOrRemoveVehicles()
    {
        int userChoice = 0;
        bool isRunning = true;
        do{
            Console.WriteLine("Choose the operation which you want:\n1: Add vehicle\n2: Remove vehicle\n0.Back to main men\n");
            Console.WriteLine("Enter your choice:");
            userChoice = int.Parse(Console.ReadLine());
            switch (userChoice)
            {
                case 0:
                    Console.WriteLine("Back to main menu...");
                    isRunning = false;
                    break;
                case 1:
                    AddVehicleToTheGarage();
                    break;
                case 2:
                    RemoveVehiclefromTheGarage();
                    break;
                default:
                    Console.WriteLine("Choose 0,1, 2 options\n");
                    break;
            }
        }while(isRunning);
    }

    
    // SubMenu : case1 : Add the vehicles to the garage
    internal void AddVehicleToTheGarage()
    {
        bool isVehicleAdded = false;
    
        try{
            GetVehicleDetails();
            if (vehicle.VehicleCategory == VehicleType.car.ToString())
            {
                isVehicleAdded = vehicleGarage.AddVehicle(new Car(vehicle.VehicleNumber,vehicle.VehicleName,vehicle.VehicleColor,vehicle.NumberOfWheels, vehicle.VehicleCategory,"Petrol"));
            }
            else if (vehicle.VehicleCategory == VehicleType.bus.ToString())
            {
                isVehicleAdded = vehicleGarage.AddVehicle(new Bus(vehicle.VehicleNumber,vehicle.VehicleName,vehicle.VehicleColor,vehicle.NumberOfWheels, vehicle.VehicleCategory,50));
            }
            else if (vehicle.VehicleCategory == VehicleType.motorcycle.ToString())
            {
                isVehicleAdded = vehicleGarage.AddVehicle(new MotorCycle(vehicle.VehicleNumber,vehicle.VehicleName,vehicle.VehicleColor,vehicle.NumberOfWheels, vehicle.VehicleCategory,300));
            }  
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
        if(isVehicleAdded) {
            Console.WriteLine($"{vehicle.VehicleName} successfully added to the parking\n"); 
        }
        else {
            Console.WriteLine("Parking is full\n");   
        }
    }

    //Method to get the user inputs
    internal void GetVehicleDetails()
    {
        //get all the details from the user 
        Console.WriteLine("Enter the vehicle details:");
        Console.WriteLine("Enter the registration number:");
        vehicle.VehicleNumber = Console.ReadLine();
        Console.WriteLine("Enter the vehicle name:");
        vehicle.VehicleName = Console.ReadLine();
        Console.WriteLine("Enter the vehicle color:");
        vehicle.VehicleColor = Console.ReadLine();
        Console.WriteLine("Enter the no.of.wheels in the vehicle:");
        vehicle.NumberOfWheels = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the vehicle type:");
        vehicle.VehicleCategory = Console.ReadLine();

        userValidation.ValidateInputsToAddVehicle(vehicle); // validate all the user inputs 
    }


    //SubMenu : case2: remove the vehciles from  the garage by Registration number
    internal void RemoveVehiclefromTheGarage()
    {
        Console.WriteLine("Enter the vehicle registration number to remove:");
        string inputRegNumber = Console.ReadLine();
        userValidation.ValidateRegNumber(inputRegNumber);
        bool isVehicleRemoved = vehicleGarage.RemoveVehicle(inputRegNumber);
        if(isVehicleRemoved) {
            userValidation.PrintMessage($"{inputRegNumber} was removed.", "success");
        }
        else{
            userValidation.PrintMessage("Invalid vehicle format","error");
        }
    }

    //main menu : case 3: List all the vehicles in the garage
    internal void ListAllVehicles()
    {
        Console.WriteLine("All Vehicles in the garage:");
        foreach(Vehicle printVehicle in vehicleGarage) {
            Console.WriteLine(printVehicle.VehicleDisplay(printVehicle));
        }
    }

    //Main menu : case 4: list all the vehicle details searching by vehicle type
    internal void ListDifferentTypesOfVehicles()
    {
        Console.WriteLine("Search the vehicle by vehicle type(car, bus, motorcycle)");
        Console.WriteLine("Enter the vehcile type:"); 
        string inputVehicleType = Console.ReadLine();
        bool isValidVehicleType = userValidation.ValidateVehicleType(inputVehicleType);
        if(isValidVehicleType) {
            SearchAndListTheVehicleByType(inputVehicleType);
        }
        else {
            userValidation.PrintMessage("Invalid vehicle type", "error");
        }
    }

    public void SearchAndListTheVehicleByType(string inputVehicleType)
    {
        List<Vehicle> mySearchList = new List<Vehicle>();
        //search and add the matched vehicle
        foreach(Vehicle vehicle in vehicleGarage){
            if (vehicle.VehicleCategory.Equals(inputVehicleType)) {
                mySearchList.Add(vehicle);
            }
        }

        //display the vehicles
        foreach(Vehicle myVehicle in mySearchList) {
            Console.WriteLine(myVehicle.VehicleDisplay(myVehicle));
        }
    }

    internal void SearchVehiclesByColorAndWheelCount()
    {
        List<Vehicle> mySearchvehicles = new List<Vehicle>();

        Console.WriteLine("Search vehicles by color and wheel count");
        Console.WriteLine("Enter the color:");
        string inputColor = Console.ReadLine();
        
        Console.WriteLine("Enter the wheel count");
        int inputWheelCount = int.Parse(Console.ReadLine());

        ValidateInputs(inputColor, inputWheelCount);
        
        //Search and add those matched vehicles to seperate list
        foreach (Vehicle vehicle in vehicleGarage){
            if(vehicle.VehicleColor.Equals(inputColor, StringComparison.OrdinalIgnoreCase) && vehicle.NumberOfWheels == inputWheelCount) 
            {
                mySearchvehicles.Add(vehicle);
            }
        }
        
        // Display the vehicles from newly added list
         foreach(Vehicle myVehicle in mySearchvehicles) {
            Console.WriteLine(myVehicle.VehicleDisplay(myVehicle));
        }
    }

    private void ValidateInputs(string inputColor, int inputWheelCount)
    {
       if (!userValidation.ValidateString(inputColor))
        {
            userValidation.PrintMessage("Color should not be null","error");
        }
        if (!userValidation.ValidateInteger(inputWheelCount))
        {
            userValidation.PrintMessage("Wheel count should not be zero", "error");
        }
    }
}