using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;

namespace DVLD_BusinessLogicLayer
{
    public class clsPerson
    {
        clsGlobalSettings.enMode _Mode = clsGlobalSettings.enMode.AddNew;

        public int ID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }
        public string ImagePath { get; set; }

        public clsPerson()
        {
            _Mode = clsGlobalSettings.enMode.AddNew;

            ID = -1;
            NationalNo = string.Empty;
            FirstName = string.Empty;
            SecondName = string.Empty;
            ThirdName = string.Empty;
            LastName = string.Empty;
            DateOfBirth = DateTime.MinValue;
            Gender = string.Empty;
            Address = string.Empty;
            Phone = string.Empty;
            Email = string.Empty;
            NationalityCountryID = -1;
            ImagePath = string.Empty;
        }

        private clsPerson(int ID, string NationalNo, string FirstName, string SecondName,
            string ThirdName, string LastName, DateTime DateOfBirth, string Gender,
            string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            _Mode = clsGlobalSettings.enMode.Update;

            this.ID = ID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityCountryID = NationalityCountryID;
            this.ImagePath = ImagePath;
        }

        private bool _AddNewPerson()
        {
            this.ID = clsPersonData.AddNewPerson(NationalNo, FirstName, SecondName, ThirdName, LastName,
                DateOfBirth, Gender, Address, Phone, Email, NationalityCountryID, ImagePath);

            return ID != -1;
        }

        private bool _UpdatePerson()
        {
            return clsPersonData.UpdatePerson(ID, NationalNo, FirstName, SecondName, ThirdName, LastName,
                DateOfBirth, Gender, Address, Phone, Email, NationalityCountryID, ImagePath);
        }

        public static clsPerson Find(int ID)
        {
            string NationalNo = string.Empty;
            string FirstName = string.Empty;
            string SecondName = string.Empty;
            string ThirdName = string.Empty;
            string LastName = string.Empty;
            DateTime DateOfBirth = DateTime.MinValue;
            string Gender = string.Empty;
            string Address = string.Empty;
            string Phone = string.Empty;
            string Email = string.Empty;
            int NationalityCountryID = -1;
            string ImagePath = string.Empty;

            if (clsPersonData.GetPersonInfo(ID, ref NationalNo, ref FirstName, ref SecondName,
                ref ThirdName, ref LastName, ref DateOfBirth, ref Gender, ref Address, ref Phone,
                ref Email, ref NationalityCountryID, ref ImagePath))
                return new clsPerson(ID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth,
                    Gender, Address, Phone, Email, NationalityCountryID, ImagePath);
            else
                return null;
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case clsGlobalSettings.enMode.AddNew:
                    _Mode = clsGlobalSettings.enMode.Update;
                    return _AddNewPerson();

                case clsGlobalSettings.enMode.Update:
                    return _UpdatePerson();

                default:
                    return false;
            }
        }

        public static bool DeletePerson(int ID)
        {
            return clsPersonData.DeletePerson(ID);
        }

        public static DataTable GetAllPeople()
        {
            return clsPersonData.GetAllPeople();
        }

        public static bool IsPersonExist(int ID)
        {
            return clsPersonData.IsPersonExist(ID);
        }
    }

}
