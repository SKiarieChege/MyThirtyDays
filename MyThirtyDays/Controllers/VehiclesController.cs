using Microsoft.AspNetCore.Mvc;
using MyThirtyDays.Models;
using MyThirtyDays.Services;

namespace MyThirtyDays.Controllers
{
    public class VehiclesController : Controller
    {
        public IActionResult Index()
        {
            VehiclesDAO vahicles = new VehiclesDAO();
            return View();
        }

        public IActionResult ShowDetails(int VehicleId)
        {
            VehiclesDAO vehicles = new VehiclesDAO();
            VehiclesModel vehicle = vehicles.GetVehicleById(VehicleId);

            return View(vehicle);
        }

        public IActionResult CreateVehicle()
        {
            return View();
        }

        public IActionResult ProcessCreate(VehiclesModel vehicle)
        {
            VehiclesDAO vehicles = new VehiclesDAO();
            vehicles.Insert(vehicle);

            return View("Index", vehicles.GetAllVehicles());

        }

        public IActionResult Edit(int VehicleId)
        {
            VehiclesDAO vehicles = new VehiclesDAO();
            VehiclesModel vehicle = vehicles.GetVehicleById(VehicleId);

            return View("VehicleEditForm", vehicle);
        }

        public IActionResult ProcessEdit(VehiclesModel vehicle)
        {
            VehiclesDAO vehicles = new VehiclesDAO();
            vehicles.Update(vehicle);

            return View("Index", vehicles.GetAllVehicles());

        }

        public IActionResult Delete(int VehicleId)
        {
            VehiclesDAO vehicles = new VehiclesDAO();
            VehiclesModel vehicle = vehicles.GetVehicleById(VehicleId);
            vehicles.Delete(vehicle);

            return View("Index", vehicles.GetAllVehicles());

        }

    }
}
