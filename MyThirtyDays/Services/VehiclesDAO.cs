using Microsoft.Data.SqlClient;
using MyThirtyDays.Models;

namespace MyThirtyDays.Services
{
    public class VehiclesDAO : IVehicleDataService
    {
        string connectionString = @"Data Source=SChege;Initial Catalog=MyThirtyDays;User ID=sa;Password=myadmin01?;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public int Delete(VehiclesModel Vehicle)
        {
            throw new NotImplementedException();
        }

        public List<VehiclesModel> GetAllVehicles()
        {
            List<VehiclesModel> foundVehicles = new List<VehiclesModel>();

            string SqlStatement = "SELECT * FROM dbo.Vehicles";

            using(SqlConnection Connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(SqlStatement, Connection);
                try {
                    Connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while(reader.Read())
                    {
                        foundVehicles.Add(new VehiclesModel { VehicleId = (int)reader[0], VehicleMake = (string)reader[1], VehicleModel = (string)reader[2], VehicleCapacity = (decimal)reader[3], VehicleRegistrationPlate = (string)reader[4] });
                    }
                    
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return foundVehicles;
        }

        public VehiclesModel GetVehicleById(int VehicleId)
        {
            throw new NotImplementedException();
        }

        public int Insert(VehiclesModel Vehicle)
        {
            throw new NotImplementedException();
        }

        public List<VehiclesModel> SearchVehicles(string SearchTerm)
        {
            throw new NotImplementedException();
        }

        public int Update(VehiclesModel Vehicle)
        {
            throw new NotImplementedException();
        }
    }
}
