using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilites.Helpers.FileHelper
{
    public interface IFileHelperService
    {
        string Upload(IFormFile file, string root);//Dosya ve uzantısı
        void Delete(string filePath); // filepath:Dosya yolu
        string Update(IFormFile file, string filePath, string root);//dosya - dosya yolu ve uzantısı
    }
}
