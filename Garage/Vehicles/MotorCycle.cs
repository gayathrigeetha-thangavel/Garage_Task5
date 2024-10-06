public class MotorCycle : Vehicle
{
    public double CylinderVolume{ get; set; }
    public MotorCycle(string vehNumber, string vehName, string vehColor, int wheelCount,string vehCategory, double volume) : base(vehNumber, vehName, vehColor, wheelCount, vehCategory)
    {
        CylinderVolume = volume;
    }

    public override string VehicleDisplay(Vehicle vehicle)
    {
        return base.VehicleDisplay(vehicle)+$",Cylinder Volume:{CylinderVolume}CC";
    }
}