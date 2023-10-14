using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilites.Helpers.GuideHelper
{
    public class GuidHelper
    {
        public static string CreateGuid()
        {
            return Guid.NewGuid().ToString(); // Bize benzersiz isim vermesi için bu işlemi yapıyoruz.Böylece başka dosya ismi ile çakışmamış olacak. 
        }
    }
}
