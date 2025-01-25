using DVLD_DataAccessLayer;
using System;
using System.Data;

namespace DVLD_BusinessLayer
{
    public class clsUser
    {
        public enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode = enMode.AddNew;

        public int ID { get; set; }
        public int PersonID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public clsUser()
        {
            _Mode = enMode.AddNew;

            ID = -1;
            PersonID = -1;
            Username = string.Empty;
            Password = string.Empty;
            IsActive = false;
        }
        
        private clsUser(int ID, int PersonID, string Username, string Password, bool IsActive)
        {
            _Mode = enMode.Update;

            this.ID = ID;
            this.PersonID = PersonID;
            this.Username = Username;
            this.Password = Password;
            this.IsActive = IsActive;
        }

        private bool _AddNewUser()
        {
            this.ID = clsUserData.AddNewUser(PersonID, Username, Password,IsActive);

            return ID != -1;
        }
        private bool _UpdateUser()
        {
            return clsUserData.UpdateUser(ID, PersonID, Username, Password, IsActive);
        }

        public static clsUser Find(int UserID)
        {
            int PersonID = -1;
            string Username = string.Empty;
            string Password = string.Empty;
            bool IsActive = false;

            if (clsUserData.GetUserInfo(UserID, ref PersonID, ref Username, ref Password, ref IsActive))
                return new clsUser(UserID, PersonID, Username, Password, IsActive);
            else
                return null;
        }
        public static clsUser Find(string Username)
        {
            int UserID = -1;
            int PersonID = -1;
            string Password = string.Empty;
            bool IsActive = false;

            if (clsUserData.GetUserInfo(Username, ref UserID, ref PersonID, ref Password, ref IsActive))
                return new clsUser(UserID, PersonID, Username, Password, IsActive);
            else
                return null;
        }


        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    _Mode = enMode.Update;
                    return _AddNewUser();

                case enMode.Update:
                    return _UpdateUser();

                default:
                    return false;
            }
        }

        public static bool DeleteUser(int UserID)
        {
            return clsUserData.DeleteUser(UserID);
        }

        public static DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();
        }
        public static DataTable GetPublicUsersList()
        {
            return clsUserData.GetPublicUsersList();
        }

        public static bool IsUserExist(int UserID)
        {
            return clsUserData.IsUserExist(UserID);
        }
        
        public static bool IsUserExist(string Username)
        {
            return clsUserData.IsUserExist(Username);
        }

    }
}
