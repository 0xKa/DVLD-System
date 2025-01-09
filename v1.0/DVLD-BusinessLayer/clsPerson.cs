using System;
using System.Data;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode = enMode.AddNew;


        public int ID { get; set; }
        public string NationalNumber { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }
        public string ImagePath { get; set; }

        public string GetFullName()
        {
            return FirstName + " " + SecondName + " " + LastName;
        }

        public clsPerson() 
        {
            _Mode = enMode.AddNew;

            ID = -1;
            NationalNumber = string.Empty;
            FirstName = string.Empty;
            SecondName = string.Empty;
            ThirdName = string.Empty;
            LastName = string.Empty;
            DateOfBirth = DateTime.Now;
            Gender = 0;
            Address = string.Empty;
            Phone = string.Empty;
            Email = string.Empty;
            NationalityCountryID = -1;
            ImagePath = string.Empty;
        }

        private clsPerson(int personID, string nationalNumber, string firstName, string secondName, string thirdName, string lastName, DateTime dateOfBirth, byte gender, string address, string phone, string email, int nationalityCountryID, string imagePath)
        {
            _Mode = enMode.Update;

            ID = personID;
            NationalNumber = nationalNumber;
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Address = address;
            Phone = phone;
            Email = email;
            NationalityCountryID = nationalityCountryID;
            ImagePath = imagePath;
        }
    
        private bool _AddNewPerson()
        {
            ID = clsPersonData.AddNewPerson(NationalNumber, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gender, Address, Phone, Email, NationalityCountryID, ImagePath);

            return ID != -1;
        }
        private bool _UpdatePerson()
        {
            return clsPersonData.UpdatePerson(ID, NationalNumber, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gender, Address, Phone, Email, NationalityCountryID, ImagePath);
        }

        public static clsPerson Find(int PersonID)
        {
            string nationalNumber = string.Empty;
            string firstName = string.Empty;
            string secondName = string.Empty;
            string thirdName = string.Empty;
            string lastName = string.Empty;
            DateTime dateOfBirth = DateTime.Now;
            byte gender = 0;
            string address = string.Empty;
            string phone = string.Empty;
            string email = string.Empty;
            int nationalityCountryID = -1;
            string imagePath = string.Empty;

            if (clsPersonData.GetPersonInfoByID(PersonID, ref nationalNumber, ref firstName,
                ref secondName, ref thirdName, ref lastName, ref dateOfBirth, ref gender,
                ref address, ref phone, ref email, ref nationalityCountryID, ref imagePath))
            {
                return new clsPerson(PersonID, nationalNumber, firstName, secondName,
                    thirdName, lastName, dateOfBirth, gender, address, phone, email,
                    nationalityCountryID, imagePath);
            }
            else
                return null;


        }
        public static clsPerson Find(string NationalNo)
        {
            int personID = -1;
            string firstName = string.Empty;
            string secondName = string.Empty;
            string thirdName = string.Empty;
            string lastName = string.Empty;
            DateTime dateOfBirth = DateTime.Now;
            byte gender = 0;
            string address = string.Empty;
            string phone = string.Empty;
            string email = string.Empty;
            int nationalityCountryID = -1;
            string imagePath = string.Empty;

            if (clsPersonData.GetPersonInfoByNationalNo(NationalNo, ref personID, ref firstName,
                ref secondName, ref thirdName, ref lastName, ref dateOfBirth, ref gender,
                ref address, ref phone, ref email, ref nationalityCountryID, ref imagePath))
            {
                return new clsPerson(personID, NationalNo, firstName, secondName,
                    thirdName, lastName, dateOfBirth, gender, address, phone, email,
                    nationalityCountryID, imagePath);
            }
            else
                return null;


        }

        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.AddNew:
                    _Mode = enMode.Update;
                    return _AddNewPerson();

                case enMode.Update:
                    return _UpdatePerson();
         
                default:
                    return false;
            }
        }

        public static bool DeletePerson(int id)
        {
            return clsPersonData.DeletePerson(id);

        }

        public static DataTable GetAllPeople()
        {
            return clsPersonData.GetAllPeople();
        }
        public static DataTable GetAllPeopleFullName()
        {
            return clsPersonData.GetAllPeopleFullName();
        }

        public static bool IsPersonExist(int ID)
        {
            return clsPersonData.IsPersonExist(ID);
        }

        public static bool IsPersonExist(string NationalNo)
        {
            return clsPersonData.IsPersonExist(NationalNo);
        }



    }
}
