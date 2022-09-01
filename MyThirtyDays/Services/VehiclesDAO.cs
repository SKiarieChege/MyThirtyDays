using Microsoft.Data.SqlClient;
using MyThirtyDays.Models;

namespace MyThirtyDays.Services
{
    public class VehiclesDAO : IVehicleDataService
    {
        string connectionString = @"Data Source=SChege;Initial Catalog=MyThirtyDays;User ID=sa;Password=myadmin01?;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public int Delete(VehiclesModel vehicle)
        {
            int NewIdNumber = -1;

            string sqlStatement = "DELETE FROM DBO.Vehicles WHERE VehicleId = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.AddWithValue("@Id", vehicle.VehicleId);

                try
                {
                    connection.Open();

                    NewIdNumber = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return NewIdNumber;
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
            VehiclesModel foundVehicle = null;

            string sqlStatement = "SELECT * FROM DBO.Vehicles WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Id", VehicleId);

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        foundVehicle = new VehiclesModel
                        {
                            VehicleId = (int)reader[0],
                            VehicleMake = (string)reader[1],
                            VehicleModel= (string)reader[1],
                            VehicleCapacity = (decimal)reader[2],
                            VehicleRegistrationPlate = (string)reader[3]
                        };
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return foundVehicle;
        }

        public int Insert(VehiclesModel vehicle)
        {
            int NewIdNumber = -1;

            string sqlStatement = "INSERT INTO DBO.Vehicles(VehicleMake,VehicleModel,VehicleCapacity,VehicleRegistrationPlate)" +
                                    "SELECT  VehicleMake = @Make, VehicleModel = @Model, " +
                                    "VehicleCapacity = @Capacity, VehicleRegistrationPlate= @Registration";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Make", vehicle.VehicleMake);
                command.Parameters.AddWithValue("@Model", vehicle.VehicleModel);
                command.Parameters.AddWithValue("@Capacity", vehicle.VehicleCapacity);
                command.Parameters.AddWithValue("@Registration", vehicle.VehicleRegistrationPlate);


                try
                {
                    connection.Open();

                    NewIdNumber = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return NewIdNumber;
        }

        public List<VehiclesModel> SearchVehicles(string SearchTerm)
        {
            throw new NotImplementedException();
        }

        public int Update(VehiclesModel vehicle)
        {
            int NewIdNumber = -1;

            string sqlStatement = "UPDATE DBO.Vehicles SET VehicleMake = @Make, VehicleModel = @Model, " +
                                    "VehicleCapacity = @Capacity, VehicleRegistrationPlate= @Registration";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Make", vehicle.VehicleMake);
                command.Parameters.AddWithValue("@Model", vehicle.VehicleModel);
                command.Parameters.AddWithValue("@Capacity", vehicle.VehicleCapacity);
                command.Parameters.AddWithValue("@Registration", vehicle.VehicleRegistrationPlate);


                try
                {
                    connection.Open();

                    NewIdNumber = Convert.ToInt32(command.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return NewIdNumber;
        }
    }
}
