public class Bus : Vehicle
{
    public int NumOfSeats{ get; set; }

    public Bus(string vehNumber, string vehName, string vehColor, int wheelCount,string vehCategory, int seatCount) : base(vehNumber, vehName, vehColor, wheelCount, vehCategory)
    {
        NumOfSeats = seatCount;
    }

    public override string VehicleDisplay(Vehicle vehicle)
    {
        return base.VehicleDisplay(vehicle)+$",Seat count:{NumOfSeats}";
    }
}