using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsLocalDLApplicationData
    {
        public static bool GetLDLApplicationInfo(int LocalDrivingLicenseApplicationID, 
            ref int ApplicationID, ref int LicenseClassID)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    ApplicationID = (int)reader["ApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];
                }
                reader.Close();

            }
            catch { return false; }
            finally { connection.Close(); }

            return IsFound;
        }

        public static int AddNewLDLApplication(int ApplicationID, int LicenseClassID)
        {
            int LDL_ApplicationID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO [dbo].[LocalDrivingLicenseApplications]
                                   ([ApplicationID],[LicenseClassID])
                            VALUES (@ApplicationID, @LicenseClassID)
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    LDL_ApplicationID = insertedID;


            }
            catch { }
            finally { connection.Close(); }

            return LDL_ApplicationID;
        }

        public static bool UpdateLDLApplication(int LocalDrivingLicenseApplicationID, int ApplicationID, int LicenseClassID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE [dbo].[LocalDrivingLicenseApplications]
                            SET [ApplicationID] = @ApplicationID
                                ,[LicenseClassID] = @LicenseClassID
                            WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();
                RowsAffected = command.ExecuteNonQuery();
            }
            catch { }
            finally { connection.Close(); }


            return RowsAffected > 0;
        }

        public static bool DeleteLDLApplication(int LocalDrivingLicenseApplicationID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"DELETE FROM [dbo].[LocalDrivingLicenseApplications]
                              WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();
                RowsAffected = command.ExecuteNonQuery();

            }
            catch { return false; }
            finally { connection.Close(); }

            return RowsAffected > 0;
        }

        public static DataTable GetLocalDrivingLicenseApplication_View()
        {
            DataTable dtLDLAview = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM LocalDrivingLicenseApplications_View;";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    dtLDLAview.Load(reader);

                reader.Close();
            }
            catch { }
            finally { connection.Close(); }

            return dtLDLAview;

        }


        /// <summary>
        /// Checks if an applicant is allowed to submit a new application for a specific license class.
        /// A person cannot apply for another application with the same class if they have an application with status 1 (New) or 3 (Completed).
        /// </summary>
        /// <param name="ApplicantPersonID">The ID of the applicant person.</param>
        /// <param name="LicenseClassID">The ID of the license class.</param>
        /// <returns>True if the application is allowed, otherwise false.</returns>
        public static bool IsApplicationAllowed(int ApplicantPersonID, int LicenseClassID)
        {
            bool IsAllowed = true;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT 1
	                             FROM LocalDrivingLicenseApplications
	                             JOIN Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
	                             JOIN LicenseClasses ON LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID
                             WHERE ApplicationStatus IN (1,3) AND ApplicantPersonID = @ApplicantPersonID AND LicenseClasses.LicenseClassID = @LicenseClassID";

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

        public static bool IsApplicationExist(int LocalDrivingLicenseApplicationID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT 1 FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();
                IsFound = (command.ExecuteScalar() != null);
            }
            catch { }
            finally { connection.Close(); }


            return IsFound;
        }

        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            byte PassedTestCount = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT PassedTestCount FROM LocalDrivingLicenseApplications_View WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

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
