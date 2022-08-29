using System.ComponentModel;

namespace MyThirtyDays.Models
{
    public class VehiclesModel
    {
        public int VehicleId { get; set; }
        [DisplayName("Vehicle Make")]
        public string VehicleMake { get; set; }
        [DisplayName("Vahicle Model")]
        public string VehicleModel { get; set; }
        [DisplayName("Vehicle Carrying Capacity")]
        public decimal VehicleCapacity { get; set; }
        [DisplayName("Vehicle Registration Plate")]
        public string VehicleRegistrationPlate { get; set; }    
    }
}
