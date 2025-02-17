using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsInternationalLicenseData
    {
        public static bool GetInternationalLicenseInfo(int ID, ref int ApplicationID, ref int DriverID, ref int LocalLicenseID,
            ref DateTime IssueDate, ref DateTime ExpirationDate, ref bool IsActive, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM InternationalLicense WHERE ID = @ID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    ApplicationID = (int)reader["ApplicationID"];
                    DriverID = (int)reader["DriverID"];
                    LocalLicenseID = (int)reader["LocalLicenseID"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    IsActive = (bool)reader["IsActive"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                }
                reader.Close();
            }
            catch { isFound = false; }
            finally { connection.Close(); }

            return isFound;
        }
        
        public static bool GetActiveInternationalLicenseInfoByDriverID(int DriverID, ref int ID, ref int ApplicationID, ref int LocalLicenseID,
            ref DateTime IssueDate, ref DateTime ExpirationDate, ref bool IsActive, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM InternationalLicense WHERE DriverID = @DriverID AND IsActive = 1;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    ID = (int)reader["ID"];
                    ApplicationID = (int)reader["ApplicationID"];
                    LocalLicenseID = (int)reader["LocalLicenseID"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    IsActive = (bool)reader["IsActive"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                }
                reader.Close();
            }
            catch { isFound = false; }
            finally { connection.Close(); }

            return isFound;
        }

        public static int AddNewInternationalLicense(int ApplicationID, int DriverID, int LocalLicenseID,
            DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {
            int ID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            //before adding a new international license we must disable the previous one
            string query = @"
                UPDATE [InternationalLicense] SET IsActive = 0 WHERE DriverID = @DriverID;

                INSERT INTO [dbo].[InternationalLicense]
                    ([ApplicationID], [DriverID], [LocalLicenseID], [IssueDate], [ExpirationDate],
                     [IsActive], [CreatedByUserID])
                VALUES (@ApplicationID, @DriverID, @LocalLicenseID, @IssueDate, @ExpirationDate,
                        @IsActive, @CreatedByUserID);
                SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LocalLicenseID", LocalLicenseID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

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

        public static bool UpdateInternationalLicense(int ID, int ApplicationID, int DriverID, int LocalLicenseID,
            DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE [dbo].[InternationalLicense]
                    SET [ApplicationID] = @ApplicationID
                        ,[DriverID] = @DriverID
                        ,[LocalLicenseID] = @LocalLicenseID
                        ,[IssueDate] = @IssueDate
                        ,[ExpirationDate] = @ExpirationDate
                        ,[IsActive] = @IsActive
                        ,[CreatedByUserID] = @CreatedByUserID
                    WHERE ID = @ID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LocalLicenseID", LocalLicenseID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
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

        public static bool DeleteInternationalLicense(int ID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"DELETE FROM [dbo].[InternationalLicense]
                    WHERE ID = @ID;";

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

        public static DataTable GetDriverInternationalLicenses(int DriverID)
        {
            DataTable dtLicense = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT ID, ApplicationID, LocalLicenseID, IssueDate, ExpirationDate, IsActive
                                FROM InternationalLicense WHERE DriverID = @DriverID ORDER BY IsActive DESC, ID DESC;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    dtLicense.Load(reader);

                reader.Close();
            }
            catch { }
            finally { connection.Close(); }

            return dtLicense;
        }
        public static DataTable GetAllInternationalLicenses()
        {
            DataTable dtLicense = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT ID, ApplicationID, DriverID, LocalLicenseID, IssueDate, ExpirationDate, IsActive AS 'Active Status' FROM [InternationalLicense];";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    dtLicense.Load(reader);

                reader.Close();
            }
            catch { }
            finally { connection.Close(); }

            return dtLicense;
        }

        public static bool IsInternationalLicenseExist(int ID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT 1 FROM InternationalLicense WHERE ID = @ID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                IsFound = (command.ExecuteScalar() != null);
            }
            catch { }
            finally { connection.Close(); }

            return IsFound;
        }
    }
}
