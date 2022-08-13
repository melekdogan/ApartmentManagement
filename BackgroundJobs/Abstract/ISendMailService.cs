using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundJobs.Abstract
{
    public interface ISendMailService
    {
        void SendPasswordInfoMail(string Firstname, string email, string password);
    }
}
