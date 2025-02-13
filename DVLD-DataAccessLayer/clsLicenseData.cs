using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsLicenseData
    {
        public static bool GetLicenseInfo(int ID, ref int ApplicationID, ref int DriverID, ref int LicenseClassID,
            ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes, ref decimal PaidFees,
            ref bool IsActive, ref byte IssueReason, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM License WHERE ID = @ID;";

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
                    LicenseClassID = (int)reader["LicenseClassID"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    Notes = reader["Notes"] as string; // Allow Null
                    PaidFees = (decimal)reader["PaidFees"];
                    IsActive = (bool)reader["IsActive"];
                    IssueReason = (byte)reader["IssueReason"]; // Allow Null
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                }
                reader.Close();
            }
            catch { isFound = false; }
            finally { connection.Close(); }

            return isFound;
        }

        public static int AddNewLicense(int ApplicationID, int DriverID, int LicenseClassID,
            DateTime IssueDate, DateTime ExpirationDate, string Notes, decimal PaidFees,
            bool IsActive, byte IssueReason, int CreatedByUserID)
        {
            int ID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO [dbo].[License]
                    ([ApplicationID], [DriverID], [LicenseClassID], [IssueDate], [ExpirationDate],
                     [Notes], [PaidFees], [IsActive], [IssueReason], [CreatedByUserID])
                VALUES (@ApplicationID, @DriverID, @LicenseClassID, @IssueDate, @ExpirationDate,
                        @Notes, @PaidFees, @IsActive, @IssueReason, @CreatedByUserID);
                SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(Notes) ? (object)DBNull.Value : Notes);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);
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

        public static bool UpdateLicense(int ID, int ApplicationID, int DriverID, int LicenseClassID,
            DateTime IssueDate, DateTime ExpirationDate, string Notes, decimal PaidFees,
            bool IsActive, byte IssueReason, int CreatedByUserID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE [dbo].[License]
                    SET [ApplicationID] = @ApplicationID
                        ,[DriverID] = @DriverID
                        ,[LicenseClassID] = @LicenseClassID
                        ,[IssueDate] = @IssueDate
                        ,[ExpirationDate] = @ExpirationDate
                        ,[Notes] = @Notes
                        ,[PaidFees] = @PaidFees
                        ,[IsActive] = @IsActive
                        ,[IssueReason] = @IssueReason
                        ,[CreatedByUserID] = @CreatedByUserID
                    WHERE ID = @ID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(Notes) ? (object)DBNull.Value : Notes);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);
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

        public static bool DeleteLicense(int ID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"DELETE FROM [dbo].[License]
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

        public static DataTable GetAllLicenses()
        {
            DataTable dtLicense = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM License;";

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

        public static bool IsLicenseExist(int ID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT 1 FROM License WHERE ID = @ID;";

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
