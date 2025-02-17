using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsDetainedLicenseData
    {
        public static bool GetDetainedLicenseInfo(int ID, ref int LicenseID, ref DateTime DetainDate, ref decimal FineFees,
            ref int CreatedByUserID, ref bool IsReleased, ref DateTime? ReleasedDate, ref int? ReleasedByUserID, ref int? ReleaseApplicationID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM DetainedLicense WHERE ID = @ID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    LicenseID = (int)reader["LicenseID"];
                    DetainDate = (DateTime)reader["DetainDate"];
                    FineFees = (decimal)reader["FineFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsReleased = (bool)reader["IsReleased"];
                    ReleasedDate = reader["ReleasedDate"] as DateTime?; // Allow Null
                    ReleasedByUserID = reader["ReleasedByUserID"] as int?; // Allow Null
                    ReleaseApplicationID = reader["ReleaseApplicationID"] as int?; // Allow Null
                }
                reader.Close();
            }
            catch { isFound = false; }
            finally { connection.Close(); }

            return isFound;
        }
        public static bool GetDetainedLicenseInfoByLicenseID(int LicenseID, ref int ID, ref DateTime DetainDate, ref decimal FineFees,
            ref int CreatedByUserID, ref bool IsReleased, ref DateTime? ReleasedDate, ref int? ReleasedByUserID, ref int? ReleaseApplicationID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM DetainedLicense WHERE LicenseID = @LicenseID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    ID = (int)reader["ID"];
                    DetainDate = (DateTime)reader["DetainDate"];
                    FineFees = (decimal)reader["FineFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsReleased = (bool)reader["IsReleased"];
                    ReleasedDate = reader["ReleasedDate"] as DateTime?; // Allow Null
                    ReleasedByUserID = reader["ReleasedByUserID"] as int?; // Allow Null
                    ReleaseApplicationID = reader["ReleaseApplicationID"] as int?; // Allow Null
                }
                reader.Close();
            }
            catch { isFound = false; }
            finally { connection.Close(); }

            return isFound;
        }

        public static int AddNewDetainedLicense(int LicenseID, DateTime DetainDate, decimal FineFees, int CreatedByUserID,
            bool IsReleased, DateTime? ReleasedDate, int? ReleasedByUserID, int? ReleaseApplicationID)
        {
            int ID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO [dbo].[DetainedLicense]
                    ([LicenseID], [DetainDate], [FineFees], [CreatedByUserID], [IsReleased],
                     [ReleasedDate], [ReleasedByUserID], [ReleaseApplicationID])
                VALUES (@LicenseID, @DetainDate, @FineFees, @CreatedByUserID, @IsReleased,
                        @ReleasedDate, @ReleasedByUserID, @ReleaseApplicationID);
                SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@DetainDate", DetainDate);
            command.Parameters.AddWithValue("@FineFees", FineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsReleased", IsReleased);
            command.Parameters.AddWithValue("@ReleasedDate", ReleasedDate ?? (object)DBNull.Value); // Handle Null
            command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID ?? (object)DBNull.Value); // Handle Null
            command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID ?? (object)DBNull.Value); // Handle Null

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

        public static bool UpdateDetainedLicense(int ID, int LicenseID, DateTime DetainDate, decimal FineFees,
            int CreatedByUserID, bool IsReleased, DateTime? ReleasedDate, int? ReleasedByUserID, int? ReleaseApplicationID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE [dbo].[DetainedLicense]
                    SET [LicenseID] = @LicenseID
                        ,[DetainDate] = @DetainDate
                        ,[FineFees] = @FineFees
                        ,[CreatedByUserID] = @CreatedByUserID
                        ,[IsReleased] = @IsReleased
                        ,[ReleasedDate] = @ReleasedDate
                        ,[ReleasedByUserID] = @ReleasedByUserID
                        ,[ReleaseApplicationID] = @ReleaseApplicationID
                    WHERE ID = @ID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@DetainDate", DetainDate);
            command.Parameters.AddWithValue("@FineFees", FineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsReleased", IsReleased);
            command.Parameters.AddWithValue("@ReleasedDate", ReleasedDate ?? (object)DBNull.Value); // Handle Null
            command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID ?? (object)DBNull.Value); // Handle Null
            command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID ?? (object)DBNull.Value); // Handle Null
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

        public static bool DeleteDetainedLicense(int ID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"DELETE FROM [dbo].[DetainedLicense]
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

        public static DataTable GetAllDetainedLicenses()
        {
            DataTable dtDetainedLicense = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM vDetainedLicenses ORDER BY ID DESC;";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    dtDetainedLicense.Load(reader);

                reader.Close();
            }
            catch { }
            finally { connection.Close(); }

            return dtDetainedLicense;
        }

        public static bool IsLicenseDetained(int LicenseID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT 1 FROM DetainedLicense WHERE LicenseID = @LicenseID AND IsReleased = 0;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

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
