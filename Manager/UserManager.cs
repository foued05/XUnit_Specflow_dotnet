namespace Manager
{
    public class UserManager : IUserManager
    {
        private readonly IList<User> users = new List<User>()
        {
            new User()
            {
                Id = 1,
                Fullname = "Foued Amami",
            },
            new User()
            {
                Id = 2,
                Fullname = "Test"
            }
        };

        public User GetUser()
        {
            return new User()
            {
                Id = 1,
                Fullname = "Foued Amami"
            };
        }

        public User GetUserByIdAndFullname(int id, string fullname)
        {
            var user = users.Where(x => x.Id == id && x.Fullname == fullname).FirstOrDefault();
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return user;
        }

        public IList<User> GetUsers()
        {
            return users;
        }
    }
}