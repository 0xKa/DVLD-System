using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLogicLayer.GlobalClasses
{
    public class clsUtil
    {
        //returns the new image path
        public static string SaveNewImage(string SourceImagePath)
        {
            Directory.CreateDirectory(clsGlobalSettings.PeopleImagesFolder); // Ensure the directory exists

            string UniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(SourceImagePath);
            string NewImagePath = Path.Combine(clsGlobalSettings.PeopleImagesFolder, UniqueFileName);


            try
            {
                File.Copy(SourceImagePath, NewImagePath, true);
                return NewImagePath;
            }
            catch 
            {
                return null; 
            }

        }

    }
}
