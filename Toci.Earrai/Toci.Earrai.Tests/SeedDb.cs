using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toci.Common.Bll;
using Toci.Earrai.Bll;
using Toci.Earrai.Database.Persistence.Models;
using Toci.Earrai.Microservice.Controllers;

namespace Toci.Earrai.Tests
{


    [TestClass]
    public class SeedDb
    {

        protected AccountController Account = new AccountController(new UserLogic());

        private Logic<Role> Role = new Logic<Role>();

        [TestMethod]
        public void SeedAllDb()
        {
            Users();
            Roles();
        }

        [TestMethod]
        public void Users()
        {
            Account.RegisterUser(new User()
            {
                Login = "user",
                Email = "user@wp.pl",
                Password = "12345678",
                Phone = "123513233",
                Token = "Fake-token"
            });
        }

        [TestMethod]
        public void Roles()
        {
            Role.Insert(new Role()
            {
                Name = "User"
            });

            Role.Insert(new Role()
            {
                Name = "OfficeUser"
            });

            Role.Insert(new Role()
            {
                Name = "PcUser"
            });

            Role.Insert(new Role()
            {
                Name = "AdminUser"
            });
        }
    }
}
