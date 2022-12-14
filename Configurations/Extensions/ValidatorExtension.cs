using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurations.Extensions
{
    public static class ValidatorExtension//Validasyonun başarılı ya da başarısız olduğunu kontrol ettiğim sınıf ve metodu. Static sınıfı, o sınıftan nesne oluşturmadan kullanabiliriz. 
    {
        //Validasyon hatalı ise, hata mesajlarını aralarına ',' koyarak birleştirip tek bir hata mesajı halinde geri döndürecek. 
        public static void ThrowIfException(this FluentValidation.Results.ValidationResult validationResult)
        {
            if (validationResult.IsValid) return;

            var message = string.Join(',', validationResult.Errors.Select(x => x.ErrorMessage));
            throw new ValidationException(message);

        }
    }
}
