using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsDetainedLicensesData
    {
        public static bool GetDetainedLicenseInfo(int DetainID, ref int LicenseID, ref DateTime DetainDate, ref double FineFees, ref int CreatedByUserID, ref bool IsReleased, ref DateTime? ReleasedDate, ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM DetainedLicenses WHERE DetainID = @DetainID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DetainID", DetainID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    LicenseID = (int)reader["LicenseID"];
                    DetainDate = (DateTime)reader["DetainDate"];
                    FineFees = Convert.ToDouble(reader["FineFees"]);
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsReleased = (bool)reader["IsReleased"];
                    ReleasedDate = Convert.ToDateTime(reader["ReleasedDate"]);
                    ReleasedByUserID = Convert.ToInt32(reader["ReleasedByUserID"]);
                    ReleaseApplicationID = Convert.ToInt32(reader["ReleaseApplicationID"]);
                }
                reader.Close();
            }
            catch { isFound = false; }
            finally { connection.Close(); }

            return isFound;
        }

        public static int AddNewDetainedLicense(int LicenseID, DateTime DetainDate, double FineFees, int CreatedByUserID, bool IsReleased, DateTime? ReleasedDate, int ReleasedByUserID, int ReleaseApplicationID)
        {
            int DetainID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO DetainedLicenses
           ([LicenseID], [DetainDate], [FineFees], [CreatedByUserID], [IsReleased], [ReleasedDate], [ReleasedByUserID], [ReleaseApplicationID])
           VALUES
           (@LicenseID, @DetainDate, @FineFees, @CreatedByUserID, @IsReleased, @ReleasedDate, @ReleasedByUserID, @ReleaseApplicationID)
           SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@DetainDate", DetainDate);
            command.Parameters.AddWithValue("@FineFees", FineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsReleased", IsReleased);
            command.Parameters.AddWithValue("@ReleasedDate", (object)ReleasedDate ?? DBNull.Value);
            command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID == -1 ? (object)DBNull.Value : ReleasedByUserID);
            command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID == -1 ? (object)DBNull.Value : ReleaseApplicationID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    DetainID = insertedID;
                }
            }
            catch { }
            finally { connection.Close(); }

            return DetainID;
        }

        public static bool UpdateDetainedLicense(int DetainID, int LicenseID, DateTime DetainDate, double FineFees, int CreatedByUserID, bool IsReleased, DateTime? ReleasedDate, int ReleasedByUserID, int ReleaseApplicationID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE DetainedLicenses
           SET [LicenseID] = @LicenseID,
               [DetainDate] = @DetainDate,
               [FineFees] = @FineFees,
               [CreatedByUserID] = @CreatedByUserID,
               [IsReleased] = @IsReleased,
               [ReleasedDate] = @ReleasedDate,
               [ReleasedByUserID] = @ReleasedByUserID,
               [ReleaseApplicationID] = @ReleaseApplicationID
           WHERE DetainID = @DetainID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DetainID", DetainID);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@DetainDate", DetainDate);
            command.Parameters.AddWithValue("@FineFees", FineFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsReleased", IsReleased);
            command.Parameters.AddWithValue("@ReleasedDate", (object)ReleasedDate ?? DBNull.Value);
            command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID == -1 ? (object)DBNull.Value : ReleasedByUserID);
            command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID == -1 ? (object)DBNull.Value : ReleaseApplicationID);

            try
            {
                connection.Open();
                RowsAffected = command.ExecuteNonQuery();
            }
            catch { }
            finally { connection.Close(); }

            return RowsAffected > 0;
        }

        public static bool DeleteDetainedLicense(int DetainID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"DELETE FROM DetainedLicenses WHERE DetainID = @DetainID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DetainID", DetainID);

            try
            {
                connection.Open();
                RowsAffected = command.ExecuteNonQuery();
            }
            catch { return false; }
            finally { connection.Close(); }

            return RowsAffected > 0;
        }

        public static bool IsDetainedLicenseExists(int DetainID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT 1 FROM DetainedLicenses WHERE DetainID = @DetainID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DetainID", DetainID);

            try
            {
                connection.Open();
                IsFound = (command.ExecuteScalar() != null);
            }
            catch { }
            finally { connection.Close(); }

            return IsFound;
        }

        public static DataTable GetAllDetainedLicenses()
        {
            DataTable dtDetainedLicenses = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM DetainedLicenses;";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    dtDetainedLicenses.Load(reader);

                reader.Close();
            }
            catch { }
            finally { connection.Close(); }

            return dtDetainedLicenses;
        }
    }

}
