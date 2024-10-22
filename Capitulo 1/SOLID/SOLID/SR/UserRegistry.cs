using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.SR
{
    public class User {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
    public class UserRegistry
    {
        private List<User> _users = new List<User>();

        public bool Registry(User user)
        {
            return true;
        }
    }
}
