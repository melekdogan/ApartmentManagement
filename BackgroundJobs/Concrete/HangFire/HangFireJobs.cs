using BackgroundJobs.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundJobs.Concrete.HangFire
{
    public class HangFireJobs : IJob
    {
        ISendMailService _sendMailService;

        public HangFireJobs(ISendMailService sendMailService)
        {
            _sendMailService = sendMailService;
        }
      

        public void FireAndForget(string Firstname, string email, string password)//Verilen işi sıraya alır ve bir kez yapar. 
        {
            Hangfire.BackgroundJob.Enqueue(() =>
            _sendMailService.SendPasswordInfoMail(Firstname, email,password)
            );
        }
    }
}
