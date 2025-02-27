using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

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

        public static void SaveLoginCredentialsToFile(string username, string password)
        {
            File.WriteAllLines(clsGlobalSettings.RememberMeFilePath, new string[] { username, password });
        }
        public static void ClearLoginCredentialsFromFile()
        {
            if (File.Exists(clsGlobalSettings.RememberMeFilePath))
                File.Delete(clsGlobalSettings.RememberMeFilePath);
        }


        public static void WritetoRegistry(string keyPath, string valueName, string valueData)
        {

            try
            {
                Registry.SetValue(keyPath, valueName, valueData, RegistryValueKind.String);

                Console.WriteLine($"Value {valueName} successfully written to the Registry.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

        }
        public static string ReadFromRegistry(string keyPath, string valueName)
        {

            string result = null;

            try
            {
                result = Registry.GetValue(keyPath, valueName, null) as string;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return result;

        }
        public static void DeleteFromRegistry(string keyPath, string valueName)
        {
            try
            {
                // Ensure we're using a relative path under HKCU
                string relativeKeyPath = keyPath.Replace(@"HKEY_CURRENT_USER\", "");

                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(relativeKeyPath, writable: true))
                {
                    if (key != null)
                    {
                        key.DeleteValue(valueName, throwOnMissingValue: false);
                        Console.WriteLine($"Value '{valueName}' deleted successfully from '{keyPath}'.");
                    }
                    else
                    {
                        Console.WriteLine($"Registry key '{keyPath}' not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }


        public static void SaveLoginCredentialsToWinRegistry(string username, string password)
        {
            WritetoRegistry(clsGlobalSettings.RememberMeWinRegistryPath, "username", username);
            WritetoRegistry(clsGlobalSettings.RememberMeWinRegistryPath, "password", password);
        }
        public static void ClearLoginCredentialsFromWinRegistry()
        {
            DeleteFromRegistry(clsGlobalSettings.RememberMeWinRegistryPath, "username");
            DeleteFromRegistry(clsGlobalSettings.RememberMeWinRegistryPath, "password");
        }
        public static string GetUsernameFromWinRegistry()
        {
            return ReadFromRegistry(clsGlobalSettings.RememberMeWinRegistryPath, "username");
        }
        public static string GetPasswordFromWinRegistry()
        {
            return ReadFromRegistry(clsGlobalSettings.RememberMeWinRegistryPath, "password");

        }

        //logs error in windows event viewer
        public static void LogError(string message, EventLogEntryType LogType)
        {
            string SourceName = "DVLD";

            if (!EventLog.SourceExists(SourceName))
                EventLog.CreateEventSource(SourceName, "Application"); //save in application log

            EventLog.WriteEntry(SourceName, message, LogType);

        }

    }
}
