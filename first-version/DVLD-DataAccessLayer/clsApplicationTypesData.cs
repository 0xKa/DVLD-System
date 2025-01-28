using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsApplicationTypesData
    {
        public static bool GetApplicationType(int ApplicationTypeID, ref string ApplicationTypeTitle, ref double ApplicationFees)
        {
            bool IsFound = false;

            SqlConnection connection  = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    ApplicationTypeTitle = (string)reader["ApplicationTypeTitle"];
                    ApplicationFees = Convert.ToDouble(reader["ApplicationFees"]);
                }
                reader.Close();

            }
            catch { IsFound = false; }
            finally { connection.Close(); }


            return IsFound;
        }
    
        public static bool UpdateApplicationType(int ApplicationTypeID, string ApplicationTypeTitle, double ApplicationFees)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE [dbo].[ApplicationTypes]
                               SET [ApplicationTypeTitle] = @ApplicationTypeTitle
                                  ,[ApplicationFees] = @ApplicationFees
                             WHERE ApplicationTypeID = @ApplicationTypeID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
            command.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

            try
            {
                connection.Open();
                RowsAffected = command.ExecuteNonQuery();
            }
            catch { }
            finally { connection.Close(); }


            return RowsAffected > 0;

        }

        public static DataTable GetAllApplicationTypes()
        {
            DataTable dtApplicationTypes = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM ApplicationTypes;";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    dtApplicationTypes.Load(reader);

                reader.Close();
            }
            catch { }
            finally { connection.Close(); }

            return dtApplicationTypes;
        }

        public static bool IsApplicationTypeExist(int ApplicationTypeID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT 1 FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            
            try
            {
                connection.Open();
                IsFound = (command.ExecuteScalar() != null);
            }
            catch { IsFound = false; }
            finally { connection.Close(); }


            return IsFound;
        }

    }
}
