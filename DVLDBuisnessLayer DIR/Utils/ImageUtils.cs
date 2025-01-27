using System ;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace DVLD_System.Utils
{
    public class ImageUtils
    {
        public static FileInfo PeopleImagesPath = new FileInfo(@"D:\Study\Programming\Projects\DVLD System Project\DVLD System DIR\People_Photos");

        public static string AddPersonImage(string ImagePath)
        {
            if (ImagePath == "") return "";

            // Get the new name
            FileInfo imgFile = new FileInfo(ImagePath);
            string newPath = Path.Combine(PeopleImagesPath.FullName, Guid.NewGuid().ToString());

            // Move person image to people images dir
            File.Move(ImagePath, newPath) ;

            return newPath; 
            
        }

        public static bool RemovePersonImage(string ImagePath)
        {
            if (ImagePath == "") return true;
            return FileUtils.DeleteFile(ImagePath);
        }

        public static string ReplacePersonImage(string oldPath, string newPath)
        {
            // Handle edge cases
            if(oldPath == "")return AddPersonImage(newPath);
            if (newPath == "") return "";

            FileInfo oldFile = new FileInfo(oldPath);
            FileInfo newFile = new FileInfo(newPath);

            // copy image to file and delete the original one 
            newPath = AddPersonImage(newFile.FullName);
            RemovePersonImage(oldFile.FullName);
            return newPath;
        }

    }
}
