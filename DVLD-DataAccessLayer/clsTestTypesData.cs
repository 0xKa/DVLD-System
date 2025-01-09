using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsTestTypesData
    {
        public static bool GetTestType(int TestTypeID, 
            ref string TestTypeTitle, ref string TestTypeDescription, ref double TestTypeFees)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM TestTypes WHERE TestTypeID = @TestTypeID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
            
                if (reader.Read())
                {
                    TestTypeTitle = (string)reader["TestTypeTitle"];
                    TestTypeDescription = (string)reader["TestTypeDescription"];
                    TestTypeFees = Convert.ToDouble(reader["TestTypeFees"]);
                
                    IsFound = true;
                }
                reader.Close();

            }
            catch { IsFound = false; }
            finally { connection.Close(); }



            return IsFound;
        }

        public static bool UpdateTestType(int TestTypeID, 
            string TestTypeTitle, string TestTypeDescription, double TestTypeFees)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE [dbo].[TestTypes]
                               SET [TestTypeTitle] = @TestTypeTitle
                                  ,[TestTypeDescription] = @TestTypeDescription
                                  ,[TestTypeFees] = @TestTypeFees
                             WHERE TestTypeID = @TestTypeID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
            command.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
            command.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                RowsAffected = command.ExecuteNonQuery();
            }
            catch { }
            finally { connection.Close(); }

            return RowsAffected > 0;

        }

        public static DataTable GetAllTestTypes()
        {
            DataTable dtTestTypes = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM TestTypes";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                
                if (reader.HasRows)
                    dtTestTypes.Load(reader);
            
                reader.Close();
            }
            catch { }
            finally { connection.Close(); }
        

            return dtTestTypes;
        }

        public static bool IsTestTypeExist(int TestTypeID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT 1 FROM TestTypes WHERE TestTypeID = @TestTypeID;";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                IsFound = command.ExecuteScalar() != null;
            }
            catch { IsFound = false; }
            finally { connection.Close(); }

            return IsFound;
        }

    }
}
