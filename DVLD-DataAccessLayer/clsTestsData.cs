using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsTestsData
    {
        public static bool GetTestInfo(int TestID, ref int TestAppointmentID, ref bool TestResult,
            ref string Notes, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Tests WHERE TestID = @TestID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestID", TestID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    TestResult = (bool)reader["TestResult"];
                    Notes = (string)reader["Notes"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];

                }
                reader.Close();

            }
            catch { isFound = false; }
            finally { connection.Close(); }


            return isFound;
        }


        public static int AddNewTest(int TestAppointmentID, bool TestResult, 
            string Notes, int CreatedByUserID)
        {
            int TestID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"
UPDATE [dbo].[Tests]
   SET [TestAppointmentID] = @TestAppointmentID
      ,[TestResult] = @TestResult
      ,[Notes] = @Notes
      ,[CreatedByUserID] = @CreatedByUserID
 WHERE TestID = @TestID
SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", TestResult);
            command.Parameters.AddWithValue("@Notes", Notes);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@TestID", TestID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    TestID = insertedID;
                }

            }
            catch { }
            finally { connection.Close(); }


            return TestID;
        }

        public static bool UpdateTest(int TestID, int TestAppointmentID, bool TestResult,
            string Notes, int CreatedByUserID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"
UPDATE [dbo].[Tests]
   SET [TestAppointmentID] = @TestAppointmentID
      ,[TestResult] = @TestResult
      ,[Notes] = @Notes
      ,[CreatedByUserID] = @CreatedByUserID
 WHERE TestID = @TestID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", TestResult);
            command.Parameters.AddWithValue("@Notes", Notes);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@TestID", TestID);

            try
            {
                connection.Open();
                RowsAffected = command.ExecuteNonQuery();
            }
            catch { }
            finally { connection.Close(); }


            return RowsAffected > 0;
        }

        public static bool DeleteTest(int TestID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"
DELETE FROM [dbo].[Tests]
      WHERE TestID = @TestID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestID", TestID);

            try
            {
                connection.Open();
                RowsAffected = command.ExecuteNonQuery();

            }
            catch { return false; }
            finally { connection.Close(); }

            return RowsAffected > 0;
        }

        public static bool IsPassedThisTest(int TestTypeID, int LocalDrivingLicenseApplicationID)
        {
            bool IsPassed = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT 1 FROM ConductedTests_View
                             WHERE TestResult = 1
                                AND TestTypeID = @TestTypeID 
                                AND LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();
                IsPassed = (command.ExecuteScalar() != null);
            }
            catch { }
            finally { connection.Close(); }


            return IsPassed;
        }
        
        //check if this is a retake test
        public static bool IsFailedThisTestBefore(int TestTypeID, int LocalDrivingLicenseApplicationID)
        {
            bool IsFailed = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT 1 FROM ConductedTests_View
                             WHERE TestResult = 0
                                AND TestTypeID = @TestTypeID 
                                AND LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();
                IsFailed = (command.ExecuteScalar() != null);
            }
            catch { }
            finally { connection.Close(); }


            return IsFailed;
        }


    }
}
