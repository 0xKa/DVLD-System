using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using static DVLD_BusinessLogicLayer.clsGlobalSettings;

namespace DVLD_BusinessLogicLayer
{
    public class clsPerson
    {
        enMode _Mode = enMode.AddNew;
        public enum enumGender { Female = 0, Male = 1 }

        //table props
        public int ID { get; set; }
        public string NationalNo { get; set; }
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

        //extra props
        public clsCountry CountryInfo = null;
        public string FullName
        {
            get {
                return string.IsNullOrEmpty(ThirdName) ? FirstName + " " + SecondName + " " + LastName
                    : FirstName + " " + SecondName + " " + ThirdName + " " + LastName;
            }
        }
        public enumGender enGender { 
            get { 
                return Gender == 1 ? enumGender.Male : enumGender.Female;
            } 
        }
        public string GenderText
        {
            get
            {
                return Gender == 1 ? "Male" : "Female";
            }
        }

        public clsPerson()
        {
            _Mode = enMode.AddNew;

            ID = -1;
            NationalNo = string.Empty;
            FirstName = string.Empty;
            SecondName = string.Empty;
            ThirdName = string.Empty;
            LastName = string.Empty;
            DateOfBirth = DateTime.MinValue;
            Gender = 1;
            Address = string.Empty;
            Phone = string.Empty;
            Email = string.Empty;
            NationalityCountryID = -1;
            ImagePath = string.Empty;
        }

        private clsPerson(int ID, string NationalNo, string FirstName, string SecondName,
            string ThirdName, string LastName, DateTime DateOfBirth, byte Gender,
            string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            _Mode = enMode.Update;

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
            this.CountryInfo = clsCountry.Find(NationalityCountryID);
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
            byte Gender = 1;
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

        public static clsPerson Find(string NationalNo)
        {
            int ID = -1;
            string FirstName = string.Empty;
            string SecondName = string.Empty;
            string ThirdName = string.Empty;
            string LastName = string.Empty;
            DateTime DateOfBirth = DateTime.MinValue;
            byte Gender = 1;
            string Address = string.Empty;
            string Phone = string.Empty;
            string Email = string.Empty;
            int NationalityCountryID = -1;
            string ImagePath = string.Empty;

            if (clsPersonData.GetPersonInfoByNationalNo(NationalNo, ref ID, ref FirstName, ref SecondName,
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
                case enMode.AddNew:
                    _Mode = enMode.Update;
                    return _AddNewPerson();

                case enMode.Update:
                    return _UpdatePerson();

                default:
                    return false;
            }
        }

        public static bool DeletePerson(int ID)
        {
            string ImagePath = Find(ID).ImagePath;

            if (File.Exists(ImagePath))
                File.Delete(ImagePath);
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
        public static bool IsPersonExist(string NationalNo)
        {
            return clsPersonData.IsPersonExist(NationalNo);
        }
    }

}
