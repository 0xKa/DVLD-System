using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLogicLayer
{
    public class clsLicenseClass
    {
        clsGlobalSettings.enMode _Mode = clsGlobalSettings.enMode.AddNew;
        public enum enLicenseClass { 
            SmallMotorcycle = 1,
            HeavyMotorcycle = 2,
            OrdinaryDrivingLicense = 3,
            Commercial = 4,
            Agricultural = 5,
            SmallAndMediumBus = 6,
            TruckAndHeavyVehicle = 7
        }

        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte MinimumAge { get; set; }
        public byte ValidityYears { get; set; }
        public decimal Fees { get; set; }

        public enLicenseClass LicenseClass { get { return (enLicenseClass)ID; } }

        public clsLicenseClass()
        {
            _Mode = clsGlobalSettings.enMode.AddNew;

            ID = -1;
            Title = string.Empty;
            Description = string.Empty;
            MinimumAge = 0;
            ValidityYears = 0;
            Fees = 0m;
        }

        private clsLicenseClass(int ID, string Title, string Description, byte MinimumAge, byte ValidityYears, decimal Fees)
        {
            _Mode = clsGlobalSettings.enMode.Update;

            this.ID = ID;
            this.Title = Title;
            this.Description = Description;
            this.MinimumAge = MinimumAge;
            this.ValidityYears = ValidityYears;
            this.Fees = Fees;
        }

        private bool _AddNewLicenseClass()
        {
            this.ID = clsLicenseClassData.AddNewLicenseClass(Title, Description, MinimumAge, ValidityYears, Fees);
            return ID != -1;
        }

        private bool _UpdateLicenseClass()
        {
            return clsLicenseClassData.UpdateLicenseClass(ID, Title, Description, MinimumAge, ValidityYears, Fees);
        }

        public static clsLicenseClass Find(int ID)
        {
            string Title = string.Empty, Description = string.Empty;
            byte MinimumAge = 0, ValidityYears = 0;
            decimal Fees = 0m;

            if (clsLicenseClassData.GetLicenseClassInfo(ID, ref Title, ref Description, ref MinimumAge, ref ValidityYears, ref Fees))
                return new clsLicenseClass(ID, Title, Description, MinimumAge, ValidityYears, Fees);
            else
                return null;
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case clsGlobalSettings.enMode.AddNew:
                    _Mode = clsGlobalSettings.enMode.Update;
                    return _AddNewLicenseClass();

                case clsGlobalSettings.enMode.Update:
                    return _UpdateLicenseClass();

                default:
                    return false;
            }
        }

        public static bool DeleteLicenseClass(int ID)
        {
            return clsLicenseClassData.DeleteLicenseClass(ID);
        }

        public static DataTable GetAllLicenseClasses()
        {
            return clsLicenseClassData.GetAllLicenseClasses();
        }
    }

}
