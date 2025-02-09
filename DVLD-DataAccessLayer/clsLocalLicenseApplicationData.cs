using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsLocalLicenseApplicationData
    {
        public static bool GetLocalLicenseApplicationInfo(int ID, ref int ApplicationID, ref int LicenseClassID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM LocalLicenseApplication WHERE ID = @ID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    ApplicationID = Convert.ToInt32(reader["ApplicationID"]);
                    LicenseClassID = Convert.ToInt32(reader["LicenseClassID"]);
                }
                reader.Close();
            }
            catch { isFound = false; }
            finally { connection.Close(); }

            return isFound;
        }

        public static bool GetLocalLicenseApplicationInfoByApplicationID(int ApplicationID, ref int ID, ref int LicenseClassID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM LocalLicenseApplication WHERE ApplicationID = @ApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    ID = Convert.ToInt32(reader["ID"]);
                    LicenseClassID = Convert.ToInt32(reader["LicenseClassID"]);
                }
                reader.Close();
            }
            catch { isFound = false; }
            finally { connection.Close(); }

            return isFound;
        }

        public static int AddNewLocalLicenseApplication(int ApplicationID, int LicenseClassID)
        {
            int ID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO LocalLicenseApplication (ApplicationID, LicenseClassID) 
                         VALUES (@ApplicationID, @LicenseClassID);
                         SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

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

        public static bool UpdateLocalLicenseApplication(int ID, int ApplicationID, int LicenseClassID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE LocalLicenseApplication 
                         SET ApplicationID = @ApplicationID, LicenseClassID = @LicenseClassID 
                         WHERE ID = @ID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
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

        public static bool DeleteLocalLicenseApplication(int ID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"DELETE FROM LocalLicenseApplication WHERE ID = @ID;";

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

        public static DataTable GetAllLocalLicenseApplications()
        {
            DataTable dtLocalLicenseApplications = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM vLocalLicenseApplications 
ORDER BY ApplicationDate DESC;";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    dtLocalLicenseApplications.Load(reader);

                reader.Close();
            }
            catch { }
            finally { connection.Close(); }

            return dtLocalLicenseApplications;
        }

        /// <summary>
        /// Checks if an applicant is allowed to submit a new application for a specific license class.
        /// A person cannot apply for another application with the same class if they have an application with status 1 (New) or 3 (Completed).
        /// </summary>
        /// <param name="ApplicantPersonID">The ID of the applicant person.</param>
        /// <param name="LicenseClassID">The ID of the license class.</param>
        /// <returns>True if the application is allowed, otherwise false.</returns>
        public static bool CanAPersonApplyForThisClass(int ApplicantPersonID, int LicenseClassID)
        {
            bool IsAllowed = true;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query 
                    = @"SELECT 1
                    FROM LocalLicenseApplication
                    JOIN [Application] ON [Application].ID = [LocalLicenseApplication].ApplicationID
                    JOIN [LicenseClass] ON [LocalLicenseApplication].LicenseClassID = LicenseClass.ID
                    WHERE [Application].Status IN (1,3) 
                    AND [Application].ApplicantPersonID = @ApplicantPersonID
                    AND [LicenseClass].ID = @LicenseClassID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();
                IsAllowed = (command.ExecuteScalar() == null); //application allowed if query return null
            }
            catch { }
            finally { connection.Close(); }

            return IsAllowed;

        }

        public static byte GetPassedTestCount(int LocalLicenseApplicationID)
        {
            byte PassedTestCount = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT PassedTests FROM vLocalLicenseApplications WHERE ID = @LocalLicenseApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalLicenseApplicationID", LocalLicenseApplicationID);

            try
            {
                connection.Open();
                PassedTestCount = Convert.ToByte(command.ExecuteScalar());
            }
            catch { }
            finally { connection.Close(); }


            return PassedTestCount;
        }

    }

}
