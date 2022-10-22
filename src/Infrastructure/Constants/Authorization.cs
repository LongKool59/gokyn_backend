using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Constants
{
    public class Authorization
    {
        public enum Roles
        {
            Administrator = 0,
            Moderator = 1,
            User = 2
        }
        public const string default_username = "user";
        public const string default_firstname = "Long";
        public const string default_lastname = "Nguyen";
        public const string default_email = "user@gmail.com";
        public const string default_password = "Pa$$w0rd.";
        public const Roles default_role = Roles.User;
    }
}
