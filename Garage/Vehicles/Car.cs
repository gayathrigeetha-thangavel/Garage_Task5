public class Car : Vehicle
{
    public string FuelType{ get; set; }

    public Car(string vehNumber, string vehName, string vehColor, int wheelCount,string vehCategory, string fuelType) : base(vehNumber, vehName, vehColor, wheelCount, vehCategory)
    {
        FuelType = fuelType;
    }

    public override string VehicleDisplay(Vehicle vehicle)
    {
        return base.VehicleDisplay(vehicle)+$",Fuel Type:{FuelType}";
    }
}