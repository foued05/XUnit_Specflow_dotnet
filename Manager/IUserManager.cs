using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public interface IUserManager
    {
        User GetUser();

        User GetUserByIdAndFullname(int id, string fullname);

        IList<User> GetUsers();
    }
}
