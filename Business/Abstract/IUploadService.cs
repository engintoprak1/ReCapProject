using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUploadService
    {
        string Add(IFormFile file);
        string AddFromBase64(string base64,string folder="");
        IResult Remove(string path);
        string Update(string oldPath,IFormFile file);
        string UpdateFromBase64(string oldPath, string base64);

    }
}
