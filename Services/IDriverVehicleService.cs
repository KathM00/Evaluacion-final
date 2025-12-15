using ProyectoFinalTecWeb.Entities;

namespace ProyectoFinalTecWeb.Services
{
    public interface IDriverVehicleService
    {
        Task AssignDriverToVehicle(Guid vehicleId, Guid driverId);
        Task RemoveDriverFromVehicle(Guid vehicleId, Guid driverId);
        Task<IEnumerable<Vehicle>> GetVehiclesByDriver(Guid driverId);
        Task<IEnumerable<Driver>> GetDriversByVehicle(Guid vehicleId);
    }
}
