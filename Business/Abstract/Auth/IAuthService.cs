using Configurations.Auth;
using Configurations.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.Auth
{
    public interface IAuthService
    {
        CommandResponse VerifyPassword(string email, string password);
        AccessToken Login(string email, string password);
    }
}
