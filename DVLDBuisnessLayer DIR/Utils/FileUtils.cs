using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_System.Utils
{
    public static class FileUtils
    {
        private static string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD_System"; // Project key path
        private static string CredintialsVarName = "LoginCredintials";

        private static bool FilesExsist(params string[] files)
        {
            foreach (string file in files)
            {
                if (!File.Exists(file)) return false;
            }

            return true;
        }


        public static void RememberUser(string Username, string Password)
        {
            string[] credintials = {Username, Password};

            RegisteryUtils.WriteToReg(keyPath, CredintialsVarName, credintials, Microsoft.Win32.RegistryValueKind.MultiString);
        }

        public static void ClearLogins()
        {
            RegisteryUtils.WriteToReg(keyPath, CredintialsVarName, "", Microsoft.Win32.RegistryValueKind.String);
        }
        
        public static bool HasOldUser()
        {
            object retrievedVal =  RegisteryUtils.ReadFromReg(keyPath, CredintialsVarName);
            return retrievedVal != null && retrievedVal != "";
        }
        
        public static string[] CurrentCredintials()
        {
            return (string[])RegisteryUtils.ReadFromReg(keyPath, CredintialsVarName);
        }

        public static void MoveFile(string filePath, string newPath)
        {
            if (!FilesExsist(filePath)) return;

            string destinationPath = Path.Combine(newPath, Path.GetFileName(filePath));
            File.Move(filePath, newPath);
        }

        public static bool DeleteFile(string filePath)
        {
            if (!File.Exists(filePath)) return false;

            File.Delete(filePath);
            return true;
        }

        public static bool ReplaceFile(string oldFile, string newFile, string directory)
        {
            if(!FilesExsist(oldFile, newFile, directory)) return false;

            File.Delete(oldFile);
            File.Move(newFile, directory);
            return true;
        }

    }
}
