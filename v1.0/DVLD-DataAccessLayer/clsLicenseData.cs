using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsLicenseData
    {
        public static bool GetLicenseInfo(int LicenseID, ref int ApplicationID, ref int DriverID,
            ref int LicenseClass, ref DateTime IssueDate, ref DateTime ExpirationDate,
            ref string Notes, ref double PaidFees, ref bool IsActive, ref byte IssueReason,
            ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Licenses WHERE LicenseID = @LicenseID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    ApplicationID = (int)reader["ApplicationID"];
                    DriverID = (int)reader["DriverID"];
                    LicenseClass = (int)reader["LicenseClass"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    Notes =  Convert.ToString(reader["Notes"]);
                    PaidFees = Convert.ToDouble(reader["PaidFees"]);
                    IsActive = (bool)reader["IsActive"];
                    IssueReason = (byte)reader["IssueReason"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];

                }
                reader.Close();

            }
            catch { isFound = false; }
            finally { connection.Close(); }


            return isFound;
        }


        public static int AddNewLicense(int ApplicationID, int DriverID,
            int LicenseClass, DateTime IssueDate, DateTime ExpirationDate,
            string Notes, double PaidFees, bool IsActive, byte IssueReason, int CreatedByUserID)
        {
            int LicenseID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO [dbo].[Licenses]
           ([ApplicationID]
           ,[DriverID]
           ,[LicenseClass]
           ,[IssueDate]
           ,[ExpirationDate]
           ,[Notes]
           ,[PaidFees]
           ,[IsActive]
           ,[IssueReason]
           ,[CreatedByUserID])
     VALUES
           (@ApplicationID
           ,@DriverID
           ,@LicenseClass
           ,@IssueDate
           ,@ExpirationDate
           ,@Notes
           ,@PaidFees
           ,@IsActive
           ,@IssueReason
           ,@CreatedByUserID)
SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
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
                    LicenseID = insertedID;
                }

            }
            catch { }
            finally { connection.Close(); }


            return LicenseID;
        }

        public static bool UpdateLicense(int LicenseID, int ApplicationID, int DriverID,
            int LicenseClass, DateTime IssueDate, DateTime ExpirationDate,
            string Notes, double PaidFees, bool IsActive, byte IssueReason, int CreatedByUserID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE [dbo].[Licenses]
   SET [ApplicationID] = @ApplicationID
      ,[DriverID] = @DriverID
      ,[LicenseClass] = @LicenseClass
      ,[IssueDate] = @IssueDate
      ,[ExpirationDate] = @ExpirationDate
      ,[Notes] = @Notes
      ,[PaidFees] = @PaidFees
      ,[IsActive] = @IsActive
      ,[IssueReason] = @IssueReason
      ,[CreatedByUserID] = @CreatedByUserID
 WHERE LicenseID = @LicenseID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@Notes", string.IsNullOrEmpty(Notes) ? (object)DBNull.Value : Notes); 
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();
                RowsAffected = command.ExecuteNonQuery();
            }
            catch { }
            finally { connection.Close(); }


            return RowsAffected > 0;
        }

        public static bool DeleteLicense(int LicenseID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"DELETE FROM [dbo].[Licenses]
      WHERE @LicenseID = LicenseID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();
                RowsAffected = command.ExecuteNonQuery();

            }
            catch { return false; }
            finally { connection.Close(); }

            return RowsAffected > 0;
        }

        public static int GetLicenseIDByApplicationID(int ApplicationID)
        {
            int ID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT LicenseID FROM Licenses WHERE ApplicationID = @ApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();
                ID = (int)command.ExecuteScalar();
            }
            catch { }
            finally { connection.Close(); }


            return ID;
        }
    }
}
