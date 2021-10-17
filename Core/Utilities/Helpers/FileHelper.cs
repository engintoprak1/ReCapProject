using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string Add(IFormFile file)
        {
            if (file.Length > 0)
            {
                string tempPath = Path.GetTempFileName();
                using (FileStream fileStream = new FileStream(tempPath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                string newPath = NewPath(file);
                File.Move(tempPath,Environment.CurrentDirectory + @"\wwwroot\images\" + newPath);
                return newPath;
            }
            return null;
        }


        public static IResult Remove(string path)
        {
            path = Environment.CurrentDirectory + @"\wwwroot\images\" + path;
            if (!File.Exists(path))
            {
                return new ErrorResult("File not found.");
            }
            File.Delete(path);
            return new SuccessResult("File deleted succesfully.");
        }

        public static string Update(string oldPath, IFormFile file)
        {
            Remove(oldPath);
            return Add(file);
        }

        public static string NewPath(IFormFile file)
        {
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileExtension = fileInfo.Extension;
            return Guid.NewGuid() + fileExtension;
        }

    }
}
