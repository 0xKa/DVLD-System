using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccessLayer
{
    public class clsPersonData
    {
        
        public static bool GetPersonInfoByID(int PersonID, ref string NationalNumber
            , ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName
            , ref DateTime DateOfBirth, ref byte Gender, ref string Address, ref string Phone
            , ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM People WHERE PersonID = @PersonID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    //fill the ByRef struct
                    NationalNumber = (string)reader["NationalNo"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    ThirdName = Convert.ToString( reader["ThirdName"] ); //nullable
                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gender = (byte)reader["Gender"];
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];
                    Email = Convert.ToString( reader["Email"] ); //nullable
                    NationalityCountryID = (int)reader["NationalityCountryID"];
                    ImagePath = Convert.ToString( reader["ImagePath"] ); //nullable
                }
                reader.Close();
            }
            catch 
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }


            return isFound;
        }


        public static bool GetPersonInfoByNationalNo(string NationalNumber, ref int PersonID
            , ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName
            , ref DateTime DateOfBirth, ref byte Gender, ref string Address, ref string Phone
            , ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM People WHERE NationalNo = @NationalNo;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNumber);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    //fill the ByRef struct
                    PersonID = (int)reader["PersonID"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    ThirdName = Convert.ToString(reader["ThirdName"]); //nullable
                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gender = (byte)reader["Gender"];
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];
                    Email = Convert.ToString(reader["Email"]); //nullable
                    NationalityCountryID = (int)reader["NationalityCountryID"];
                    ImagePath = Convert.ToString(reader["ImagePath"]); //nullable
                }
                reader.Close();
            }
            catch
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }


            return isFound;
        }


        //add the contact to the db, and returns the ID AutoNumber, if failed will return -1
        public static int AddNewPerson(string NationalNumber
            , string FirstName, string SecondName, string ThirdName, string LastName
            , DateTime DateOfBirth, byte Gender, string Address, string Phone
            , string Email, int NationalityCountryID, string ImagePath)
        {
            int PersonID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO [dbo].[People]
                                               ([NationalNo],[FirstName],[SecondName],[ThirdName],[LastName],[DateOfBirth],[Gender],[Address],[Phone],[Email],[NationalityCountryID],[ImagePath])
                                        VALUES (@NationalNo, @FirstName, @SecondName, @ThirdName, @LastName, @DateOfBirth, @Gender, @Address, @Phone, @Email, @NationalityCountryID, @ImagePath)
                                        SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNumber);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@ThirdName", string.IsNullOrEmpty(ThirdName) ? (object)DBNull.Value : ThirdName); //handling null string using short-hand if 
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(Email) ? (object)DBNull.Value : Email);
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            command.Parameters.AddWithValue("@ImagePath", string.IsNullOrEmpty(ImagePath) ? (object)DBNull.Value : ImagePath);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                // Check if the result is not null and can be converted to an int
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    PersonID = insertedID; //get the AutoNumber from database SELECT SCOPE_IDENTITY()
                }

            }
            catch 
            { }
            finally
            { connection.Close(); }


            return PersonID;
        }

        public static bool UpdatePerson(int PersonID, string NationalNumber
            , string FirstName, string SecondName, string ThirdName, string LastName
            , DateTime DateOfBirth, byte Gender, string Address, string Phone
            , string Email, int NationalityCountryID, string ImagePath)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE [dbo].[People]
                               SET [NationalNo] = @NationalNo
                                  ,[FirstName] = @FirstName
                                  ,[SecondName] = @SecondName
                                  ,[ThirdName] = @ThirdName
                                  ,[LastName] = @LastName
                                  ,[DateOfBirth] = @DateOfBirth
                                  ,[Gender] = @Gender
                                  ,[Address] = @Address
                                  ,[Phone] = @Phone
                                  ,[Email] = @Email
                                  ,[NationalityCountryID] = @NationalityCountryID
                                  ,[ImagePath] = @ImagePath
                             WHERE PersonID = @PersonID; ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNumber);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);
            command.Parameters.AddWithValue("@ThirdName", string.IsNullOrEmpty(ThirdName) ? (object)DBNull.Value : ThirdName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(Email) ? (object)DBNull.Value : Email);
            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            command.Parameters.AddWithValue("@ImagePath", string.IsNullOrEmpty(ImagePath) ? (object)DBNull.Value : ImagePath);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                RowsAffected = command.ExecuteNonQuery();
            
            }
            catch  { return false; }
            finally { connection.Close(); }



            return RowsAffected > 0;
        }

        public static bool DeletePerson(int PersonID)
        {
            int RowsAffected = 0;

            SqlConnection connection  = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"DELETE FROM [dbo].[People]
                              WHERE PersonID = @PersonID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                RowsAffected = command.ExecuteNonQuery();

            }
            catch  { return false; }
            finally { connection.Close(); }

            return RowsAffected > 0;
        }

        public static DataTable GetAllPeople()
        {
            DataTable dtPeople = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM People;";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    dtPeople.Load(reader);

                reader.Close();
            }
            catch {  }
            finally { connection.Close(); }

            return dtPeople;
        }
        public static DataTable GetAllPeopleFullName()
        {
            DataTable dtFullName = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT PersonID, FirstName + ' ' + SecondName + ' ' + COALESCE(ThirdName, '') + ' ' + LastName AS FullName FROM People;";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    dtFullName.Load(reader);

                reader.Close();
            }
            catch { }
            finally { connection.Close(); }

            return dtFullName;
        }

        public static bool IsPersonExist(int PersonID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT 1 FROM People WHERE PersonID = @PersonID; ";

            SqlCommand command  = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                isFound = (command.ExecuteScalar() != null);
            }
            catch { }
            finally { connection.Close(); }


            return isFound;
        }
        
        public static bool IsPersonExist(string NationalNo)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT 1 FROM People WHERE NationalNo = @NationalNo; ";

            SqlCommand command  = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                connection.Open();
                isFound = (command.ExecuteScalar() != null);
            }
            catch { }
            finally { connection.Close(); }


            return isFound;
        }


    }
}
