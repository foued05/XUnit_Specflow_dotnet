using FluentAssertions.Execution;
using Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public sealed class UserStepDefinitions
    {
        private UserManager _userManager = new UserManager();
        private User user = new User();
        private int userId;
        private string userFullname;

        [Given("Id of user is (.*)")]
        public void GivenTheFirstNumberIs(int id)
        {
            userId = id;
        }

        [Given(@"Fullname of user is (.*) (.*)")]
        public void GivenTheSecondNumberIs(string fullname, string lastname)
        {
            userFullname = fullname + " " + lastname;
        }

        [When("check in BDD")]
        public void WhenTheTwoNumbersAreAdded()
        {
            user = _userManager.GetUserByIdAndFullname(userId, userFullname);
        }

        [Then("the result should be")]
        public void ThenTheResultShouldBe(Table table)
        {
            //foreach (var row in table.Rows)
            //{
            //    var test = row["Id"];
            //    var test1 = row["Fullname"];
            //}

            var userExpected = new User()
            {
                Id = int.Parse(table.Rows[0]["Id"]),
                Fullname = table.Rows[0]["Fullname"]
            };

            Assert.NotNull(user);
            Assert.IsType<User>(user);
            Assert.Equal(user.Id, userExpected.Id);
        }
    }
}
