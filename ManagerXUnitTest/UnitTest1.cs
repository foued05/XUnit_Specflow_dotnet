using dotnetNUnitSpecFlow.Controllers;
using Manager;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace ManagerXUnitTest
{
    public class UnitTest1
    {
        private readonly UserManager _userManager = new UserManager();
        private readonly Mock<IUserManager> _mockIUserManager = new Mock<IUserManager>();

        private SqliteConnection _connection = null;
        private UserContext _context;

        public UnitTest1()
        {
            _connection = new SqliteConnection("DataSource=:memory:");
            _connection.Open();

            var optionBuilder = new DbContextOptionsBuilder<UserContext>();
            optionBuilder = optionBuilder.UseSqlite(_connection);

            _context = new UserContext(optionBuilder.Options);

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            _context.ChangeTracker.Clear();
        }

        [Fact]
        public void GetUser_ShouldReturnUser()
        {
            var result = _userManager.GetUser();

            Assert.NotNull(result);
            Assert.IsType<User>(result);

            _context.Users.Add(result);
            _context.SaveChanges();

            _mockIUserManager.Setup(x => x.GetUser()).Returns(result);
            _mockIUserManager.Setup(x => x.GetUserByIdAndFullname(result.Id, result.Fullname)).Returns(result);

            var userController = new UserController(_mockIUserManager.Object);

            var test = userController.GetUser();

            var userBDD = _context.Users.FirstOrDefault();

            Assert.NotNull(userBDD);
            Assert.IsType<User>(userBDD);
        }

        [Theory]
        [InlineData(1, "Foued Amami")]
        public void GetUserByIdAndFullname_ShouldReturnUser(int id, string fullname)
        {
            var result = _userManager.GetUserByIdAndFullname(id, fullname);

            Assert.NotNull(result);
            Assert.IsType<User>(result);

            var users = _userManager.GetUsers();

            Assert.NotNull(users);
            Assert.Equal(2, users.Count);
            Assert.NotEmpty(users);
        }

        [Theory]
        [MemberData(nameof(getObjectUser))]
        public void GetUserByIdAndFullname_ShouldReturnUser_MemberData(User user, Person person)
        {
            var result = _userManager.GetUserByIdAndFullname(user.Id, user.Fullname);

            Assert.NotNull(result);
            Assert.IsType<User>(result);

            Assert.NotNull(person);
            Assert.IsType<Person>(person);
        }

        public static IEnumerable<object[]> getObjectUser()
        {
            return new List<object[]>()
            {
                new object[]
                {
                    new User()
                    {
                        Id = 1,
                        Fullname = "Foued Amami"
                    },
                    new Person()
                    {
                        Id = 1,
                        Firstname = "Foued",
                        Lastname = "Amami"
                    }
                }
            };
        }
    }
}