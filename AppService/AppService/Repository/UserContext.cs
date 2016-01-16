using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AppService.Repository
{
    public class UserContext:DbContext,IUserContext
    {
        public UserContext()
            :base("DefaultConnection")
        {

        }

        public DbSet<UserProfile> UserProfiles { get; set; }

        public void UserInfo(string username,string name, string email)
        {
            try
            {
                var exist = this.UserProfiles.FirstOrDefault(m => m.UserName == username);
                exist.email = email;
                exist.Name = name;
                SaveChanges();
            }
            catch(Exception ex)
            {

            }
        }

        public string getUserName(string name)
        {
            var exist = UserProfiles.FirstOrDefault(m=>m.UserName == name);
            return exist.Name;
        }
    }
}