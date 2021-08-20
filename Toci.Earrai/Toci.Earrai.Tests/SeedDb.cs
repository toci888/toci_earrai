using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toci.Common.Bll;
using Toci.Earrai.Bll;
using Toci.Earrai.Bll.Models;
using Toci.Earrai.Database.Persistence.Models;
using Toci.Earrai.Microservice;
using Toci.Earrai.Microservice.Controllers;

namespace Toci.Earrai.Tests
{


    [TestClass]
    public class SeedDb
    {
        protected AccountController Account = new AccountController(new UserLogic(new AuthenticationSettings()));

        //protected AccountController Account = new AccountController(new UserLogic());

        //private Logic<Role> Role = new Logic<Role>();

        [TestMethod]
        public void SeedAllDb()
        {
            Roles();
            Users();
        }

        [TestMethod]
        public void Users()
        {
            Account.RegisterUser(new User()
            {
                Firstname = "User",
                Lastname = "User",
                Email = "user@wp.pl",
                Password = "12345678",
                Idrole = 1
            });

            Account.RegisterUser(new User()
            {
                Firstname = "Office",
                Lastname = "Office",
                Email = "office@wp.pl",
                Password = "12345678",
                Idrole = 2
            });

            Account.RegisterUser(new User()
            {
                Firstname = "Pc",
                Lastname = "Pc",
                Email = "pc@wp.pl",
                Password = "12345678",
                Idrole = 3
            });

            Account.RegisterUser(new User()
            {
                Firstname = "Admin",
                Lastname = "Admin",
                Email = "admin@wp.pl",
                Password = "12345678",
                Idrole = 4
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
                Name = "Office"
            });

            Role.Insert(new Role()
            {
                Name = "Pc"
            });

            Role.Insert(new Role()
            {
                Name = "Admin"
            });
        }
    }
}
