using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace DVLD_DataAccessLayer
{
    public class clsLicenseClassesData
    {

        public static DataTable GetAllLicenseClasses()
        {
            DataTable dtLicenseClasses = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM LicenseClasses;";

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

        public static string GetClassName(int LicenseClassID)
        {
            string ClassName = string.Empty;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT ClassName FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();
                ClassName = (string)command.ExecuteScalar();
            }
            catch { }
            finally { connection.Close(); }


            return ClassName;
        }
        
        public static byte GetLicenseLengthInYears(int LicenseClassID)
        {
            byte LicenseAge = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT DefaultValidityLength FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID;";

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
        
        public static byte GetMinimumAllowedAge(int LicenseClassID)
        {
            byte LicenseAge = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT MinimumAllowedAge FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID;";

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

    }
}
