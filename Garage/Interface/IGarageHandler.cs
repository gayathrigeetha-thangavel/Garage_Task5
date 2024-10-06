using System.Collections;
public interface IGarageHandler<T> where T : Vehicle 
{

    int Count {get; set; }
    bool AddVehicle(T vehicle);
    bool RemoveVehicle(string vehicleRegNumber);
    Vehicle GetVehicle(string vehicleRegNumber);

    T GetVehicle(int index);
}

