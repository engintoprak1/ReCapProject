using Business.Abstract;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UploadManager : IUploadService
    {
        public string Add(IFormFile file)
        {
            return FileHelper.Add(file);
        }

        public string AddFromBase64(string base64,string folder="")
        {
            return FileHelper.AddFromBase64(base64,folder);
        }

        public IResult Remove(string path)
        {
            return FileHelper.Remove(path);
        }

        public string Update(string oldPath, IFormFile file)
        {
            return FileHelper.Update(oldPath, file);
        }

        public string UpdateFromBase64(string oldPath, string base64)
        {
            return FileHelper.UpdateBase64(oldPath, base64);
        }
    }
}
