using MyThirtyDays.Models;

namespace MyThirtyDays.Services
{
    public interface IVehicleDataService
    {
        List<VehiclesModel> GetAllVehicles();

        List<VehiclesModel> SearchVehicles(string SearchTerm);

        VehiclesModel GetVehicleById(int VehicleId);
        int Insert(VehiclesModel Vehicle);
        int Delete(VehiclesModel Vehicle);
        int Update(VehiclesModel Vehicle);
    }
}
