public class Vehicle
{
    public string VehicleNumber { get; set;}
    public string VehicleName{ get; set; }
    public string VehicleColor{ get; set; }
    public int NumberOfWheels{ get; set; }
    public string VehicleCategory{ get; set; }

    public Vehicle()
    {
        Console.WriteLine("Vehicle class Started here..");
    }
    public Vehicle(string vehNumber, string vehName, string vehColor, int wheelCount, string vehCategory){
        VehicleNumber = vehNumber;
        VehicleName = vehName;
        VehicleColor = vehColor;
        NumberOfWheels = wheelCount;
        VehicleCategory = vehCategory;
    }

    public virtual string VehicleDisplay(Vehicle vehicle)
    {
        if (vehicle == null) {
           return "Vehicle list is empty";
        }
        else{
           return $"Registration Number:{vehicle.VehicleNumber},Name:{vehicle.VehicleName},Color:{vehicle.VehicleColor},No.of.Wheels:{vehicle.NumberOfWheels},Category:{vehicle.VehicleCategory}";
        }

    }


}