﻿using DVLD_BusinessLogicLayer.GlobalClasses;
using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DVLD_BusinessLogicLayer
{
    public class clsUser
    {
        clsGlobalSettings.enMode _Mode = clsGlobalSettings.enMode.AddNew;

        public int ID { get; set; }
        public int PersonID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public clsPerson PersonInfo = null;

        public clsUser()
        {
            _Mode = clsGlobalSettings.enMode.AddNew;

            ID = -1;
            PersonID = -1;
            Username = string.Empty;
            Password = string.Empty;
            IsActive = true;
        }

        private clsUser(int ID, int PersonID, string Username, string Password, bool IsActive)
        {
            _Mode = clsGlobalSettings.enMode.Update;

            this.ID = ID;
            this.PersonID = PersonID;
            this.Username = Username;
            this.Password = Password;
            this.IsActive = IsActive;
            this.PersonInfo = clsPerson.Find(PersonID);
        }

        private bool _AddNewUser()
        {
            
            this.ID = clsUserData.AddNewUser(PersonID, Username, GlobalClasses.clsUtil.ComputeSHA256(Password), IsActive);

            return ID != -1;
        }

        private bool _UpdateUser()
        {
            return clsUserData.UpdateUser(ID, PersonID, Username, GlobalClasses.clsUtil.ComputeSHA256(Password), IsActive);
        }

        public static clsUser Find(int ID)
        {
            int PersonID = -1;
            string Username = string.Empty;
            string Password = string.Empty;
            bool IsActive = true;

            if (clsUserData.GetUserInfo(ID, ref PersonID, ref Username, ref Password, ref IsActive))
                return new clsUser(ID, PersonID, Username, Password, IsActive);
            else
                return null;
        }
        public static clsUser FindByPersonID(int PersonID)
        {
            int ID = -1;
            string Username = string.Empty;
            string Password = string.Empty;
            bool IsActive = true;

            if (clsUserData.GetUserInfoByPersonID(PersonID, ref ID, ref Username, ref Password, ref IsActive))
                return new clsUser(ID, PersonID, Username, Password, IsActive);
            else
                return null;
        }
        public static clsUser FindByUsernameAndPassword(string Username, string Password)
        {
            int ID = -1;
            int PersonID = -1;
            bool IsActive = true;

            if (clsUserData.GetUserInfoByUsernameAndPassword(Username, clsUtil.ComputeSHA256(Password), ref ID, ref PersonID, ref IsActive))
                return new clsUser(ID, PersonID, Username, Password, IsActive);
            else
                return null;
        }
        

        public bool Save()
        {
            switch (_Mode)
            {
                case clsGlobalSettings.enMode.AddNew:
                    _Mode = clsGlobalSettings.enMode.Update;
                    return _AddNewUser();

                case clsGlobalSettings.enMode.Update:
                    return _UpdateUser();

                default:
                    return false;
            }
        }

        public static bool DeleteUser(int ID)
        {
            return clsUserData.DeleteUser(ID);
        }

        public static DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();
        }

        public static bool IsUserExist(int ID)
        {
            return clsUserData.IsUserExist(ID);
        }

        public static bool IsPersonAUser(int PersonID)
        {
            return clsUserData.IsPersonAUser(PersonID);
        }

        public bool ChangePassword(string NewPassword)
        {
            return clsUserData.ChangePassword(this.Username, clsUtil.ComputeSHA256(NewPassword));
        }
        public static bool ChangePassword(string Username, string Password)
        {
            return clsUserData.ChangePassword(Username, clsUtil.ComputeSHA256(Password));
        }
    }

}
