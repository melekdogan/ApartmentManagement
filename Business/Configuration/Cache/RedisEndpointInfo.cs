using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Configuration.Cache
{
    public class RedisEndpointInfo
    {
        public string EndPoint { get; set; }
        public int Port { get; set; } //Redis Sunucusuna ait port bilgisi
        public string UserName { get; set; }// redis kullanıcı adı 
        public string Password { get; set; }// redis şifre 
    }
}
