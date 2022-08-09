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

        public void DelayedJob(int userId, string userName,TimeSpan timeSpan)// verilen işi belli(parametrede verilen) zamanda yapar. 
        {
            Hangfire.BackgroundJob.Schedule(() =>
            _sendMailService.SendMail(userId,userName), timeSpan
            ) ;
        }

        public void FireAndForget(int userId, string userName)//Verilen işi sıraya alır ve bir kez yapar. 
        {
            Hangfire.BackgroundJob.Enqueue(() =>
            _sendMailService.SendMail(userId,userName)
            );
        }
    }
}
