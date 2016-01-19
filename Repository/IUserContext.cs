using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppService.Repository
{
    public interface IUserContext
    {
        void UserInfo(string username,string name, string email);
        string getUserName(string username);
    }
}
