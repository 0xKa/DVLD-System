using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsLicenseClassData
    {
        public static bool GetLicenseClassInfo(int ID, ref string Title, ref string Description, ref byte MinimumAge, ref byte ValidityYears, ref decimal Fees)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM LicenseClass WHERE ID = @ID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    Title = reader["Title"].ToString();
                    Description = reader["Description"].ToString();
                    MinimumAge = (byte)reader["MinimumAge"];
                    ValidityYears = (byte)reader["ValidityYears"];
                    Fees = (decimal)reader["Fees"];
                }
                reader.Close();
            }
            catch { isFound = false; }
            finally { connection.Close(); }

            return isFound;
        }

        public static int AddNewLicenseClass(string Title, string Description, byte MinimumAge, byte ValidityYears, decimal Fees)
        {
            int ID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO LicenseClass (Title, Description, MinimumAge, ValidityYears, Fees) 
                         VALUES (@Title, @Description, @MinimumAge, @ValidityYears, @Fees); 
                         SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Title", Title);
            command.Parameters.AddWithValue("@Description", Description);
            command.Parameters.AddWithValue("@MinimumAge", MinimumAge);
            command.Parameters.AddWithValue("@ValidityYears", ValidityYears);
            command.Parameters.AddWithValue("@Fees", Fees);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ID = insertedID;
                }
            }
            catch { }
            finally { connection.Close(); }

            return ID;
        }

        public static bool UpdateLicenseClass(int ID, string Title, string Description, byte MinimumAge, byte ValidityYears, decimal Fees)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE LicenseClass 
                         SET Title = @Title, Description = @Description, MinimumAge = @MinimumAge, 
                             ValidityYears = @ValidityYears, Fees = @Fees 
                         WHERE ID = @ID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Title", Title);
            command.Parameters.AddWithValue("@Description", Description);
            command.Parameters.AddWithValue("@MinimumAge", MinimumAge);
            command.Parameters.AddWithValue("@ValidityYears", ValidityYears);
            command.Parameters.AddWithValue("@Fees", Fees);
            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                RowsAffected = command.ExecuteNonQuery();
            }
            catch { }
            finally { connection.Close(); }

            return RowsAffected > 0;
        }

        public static bool DeleteLicenseClass(int ID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"DELETE FROM LicenseClass WHERE ID = @ID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                RowsAffected = command.ExecuteNonQuery();
            }
            catch { return false; }
            finally { connection.Close(); }

            return RowsAffected > 0;
        }

        public static DataTable GetAllLicenseClasses()
        {
            DataTable dtLicenseClasses = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM LicenseClass;";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    dtLicenseClasses.Load(reader);

                reader.Close();
            }
            catch { }
            finally { connection.Close(); }

            return dtLicenseClasses;
        }

        public static byte GetLicenseValidityYears(int LicenseClassID)
        {
            byte ValidityYears = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT ValidityYears FROM LicenseClass WHERE ID = @LicenseClassID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();
                ValidityYears = (byte)command.ExecuteScalar();
            }
            catch { }
            finally { connection.Close(); }


            return ValidityYears;
        }
        public static byte GetMinimumAllowedAge(int LicenseClassID)
        {
            byte LicenseAge = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT MinimumAge FROM LicenseClass WHERE ID = @LicenseClassID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();
                LicenseAge = (byte)command.ExecuteScalar();
            }
            catch { }
            finally { connection.Close(); }


            return LicenseAge;
        }
        public static decimal GetClassFees(int LicenseClassID)
        {
            decimal Fees = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Fees FROM LicenseClass WHERE ID = @LicenseClassID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();
                Fees = (decimal)command.ExecuteScalar();
            }
            catch { }
            finally { connection.Close(); }


            return Fees;
        }

    }

}
