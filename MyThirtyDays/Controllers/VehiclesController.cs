using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyThirtyDays.Models;
using MyThirtyDays.Services;

namespace MyThirtyDays.Controllers
{
    public class VehiclesController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            VehiclesDAO vehicles = new VehiclesDAO();
            return View(vehicles.GetAllVehicles());
        }

        [Authorize]
        public IActionResult ShowDetails(int VehicleId)
        {
            VehiclesDAO vehicles = new VehiclesDAO();
            VehiclesModel vehicle = vehicles.GetVehicleById(VehicleId);

            return View("vehicle",vehicle);
        }

        [Authorize]
        public IActionResult CreateVehicle()
        {
            return View();
        }

        [Authorize]
        public IActionResult ProcessCreate(VehiclesModel vehicle)
        {
            VehiclesDAO vehicles = new VehiclesDAO();
            vehicles.Insert(vehicle);

            return View("Index", vehicles.GetAllVehicles());

        }

        [Authorize]
        public IActionResult Edit(int VehicleId)
        {
            VehiclesDAO vehicles = new VehiclesDAO();
            VehiclesModel vehicle = vehicles.GetVehicleById(VehicleId);

            return View("VehicleEditForm", vehicle);
        }

        [Authorize]
        public IActionResult ProcessEdit(VehiclesModel vehicle)
        {
            VehiclesDAO vehicles = new VehiclesDAO();
            vehicles.Update(vehicle);

            return View("Index", vehicles.GetAllVehicles());

        }

        [Authorize]
        public IActionResult Delete(int VehicleId)
        {
            VehiclesDAO vehicles = new VehiclesDAO();
            VehiclesModel vehicle = vehicles.GetVehicleById(VehicleId);
            vehicles.Delete(vehicle);

            return View("Index", vehicles.GetAllVehicles());

        }

    }
}
