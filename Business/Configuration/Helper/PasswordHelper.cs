using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Business.Configuration.Helper
{
    public static class PasswordHelper
    {
        public static string CreateRandomPassword()
        {
           // int lengthOfPassword = 8;
           // string valid = "abcdefghijklmnozABCDEFGHIJKLMNOZ1234567890";
           // StringBuilder stringBuilder = new StringBuilder(100);
           // Random random = new Random();
           // while (0 < lengthOfPassword--)
           // {
           //     stringBuilder.Append(valid[random.Next(valid.Length)]);
           // }
            int lengthOfPassword = 8;
            string guid = Guid.NewGuid().ToString();
            
            string password = guid.Substring(0, lengthOfPassword);
            return password;
            //stringBuilder.ToString();
        }   

    }
}
