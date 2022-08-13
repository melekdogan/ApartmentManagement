using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Configurations.Helper
{
    public static class HashHelper
    {
        #region Creating Password Hash

        //Verilen userPassword bilgisini alıp hashleyerek (kriptolayarak) hem hash, hem de salt halini parametrelerde verilen referansa geri gönderiyoruz. İşlenmiş veriyi bu şekilde gönderdiğimiz için method return type a gerek kalmıyor  
        public static void CreatePasswordHash(string userPassword, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hashMac = new HMACSHA512())
            {
                passwordSalt = hashMac.Key;// şifrenin kendisi 
                passwordHash = hashMac.ComputeHash(Encoding.UTF8.GetBytes(userPassword));//şifrenin kriptolanmış hali -- Hashlenmiş hali 
            }
        }
        #endregion

        #region Verifying Password Hash (Doğrulama)
        //Giriş sırasında gönderilen şifre bilgisi ve yine giriş sırasında gönderilen email bilgisinin ait olduğu kullanıcının veritabanındaki şifresini karşılaştırıp; eşleşiyorsa true, eşleşmiyorsa false döndürür.
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))// buraya veritabanındaki salt password(key) bilgisi geliyor. 
            {
                var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));// dışarıdan gelen şifre verisi hashleniyor. 

                //Dışarıdan gelen şifrenin hashlenmiş hali ile veritabanındaki passwordHash verileri eşleşmezse şifreler aynı değil demektir ve false değeri döndürür. Orada zaten bir değer döndürdüğü için for loop un dışındaki return kodunu görmeyecektir. İşlem orada bitecektir.
                for (int i = 0; i < computeHash.Length; i++)
                {
                    if (computeHash[i] != passwordHash[i])
                        return false;
                }
                //Passwordlerin hash bilgileri eşleşirse döngüden çıktığında true döndürecektir. 
                return true;
            }
        }
        #endregion
    }
}
