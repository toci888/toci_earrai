using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toci.Earrai.Bll;
using Toci.Earrai.Database.Persistence.Models;
using Toci.Earrai.Microservice;
using Toci.Earrai.Microservice.Controllers;
using Worksheet = Toci.Earrai.Database.Persistence.Models.Worksheet;

namespace Toci.Earrai.Tests
{


    [TestClass]
    public class SeedDb
    {
        protected AccountController Account = new AccountController(new UserLogic(new AuthenticationSettings()));

        //protected AccountController Account = new AccountController(new UserLogic());

        private Logic<Role> Role = new Logic<Role>();
        private Logic<Workbook> Workbook = new Logic<Workbook>();
        private Logic<Worksheet> Worksheet = new Logic<Worksheet>();
        private Logic<Worksheetcontent> WorksheetContent = new Logic<Worksheetcontent>();

        private Random r = new Random();

        [TestMethod]
        public void SeedAllDb()
        {
            Roles();
            Users();
            Workbooks();
            Worksheets();
            WorksheetContents();
        }

        [TestMethod]
        public void SeedUsersAndRoles()
        {
            Roles();
            Users();
        }

        [TestMethod]
        public void SeedWorksheets()
        {
            Workbooks();
            Worksheets();
            WorksheetContents();
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

        [TestMethod]
        public void Workbooks()
        {
            string[] ids = {"IUYG13IG214HSABGIY123", "1J3G2U124G12UYHVGB4H", "HJG123HGVB21HJ4", "H2J1G3H421GB4HV35" };
            string[] filenames = {"excel", "onedrive", "powerpoint", "powershell" };

            for (int i = 0; i < 4; i++)
            {
                Workbook.Insert(new Workbook()
                {
                    Idoffile = ids[r.Next(0, ids.Length)],
                    Filename = filenames[r.Next(0, filenames.Length)],
                    Createdat = DateTime.Today.AddDays(r.Next(-100, 20)),
                    Updatedat = DateTime.Today.AddDays(r.Next(-100, 20))
                });
            }
        }

        [TestMethod]
        public void Worksheets()
        {
            for (int i = 0; i < 30; i++)
            {
                Worksheet.Insert(new Worksheet()
                {
                    Idworkbook = r.Next(1, 4),
                    Sheetname = "Arkusz" + r.Next(1, 20),
                    Createdat = DateTime.Today.AddDays(r.Next(-100, 20)),
                    Updatedat = DateTime.Today.AddDays(r.Next(-100, 20))
                });
            }
        }


        [TestMethod]
        public void WorksheetContents()
        {
            string[] values = {"sad", "zxc", "qwe", "123", "sdafa", "asdda", "asdasd", "zxczx", "123123asdf", "123asd", "zxcvadqw"};
            for (int i = 0; i < 100; i++)
            {
                WorksheetContent.Insert(new Worksheetcontent()
                {
                    Idworksheet = r.Next(1, 20),
                    Columnindex = r.Next(0, 20),
                    Rowindex = r.Next(0, 20),
                    Value = values[r.Next(0, values.Length)],
                    Createdat = DateTime.Today.AddDays(r.Next(-100, 20)),
                    Updatedat = DateTime.Today.AddDays(r.Next(-100, 20))
                });
            }
        }

        [TestMethod]
        public void SeedAreas()
        {
            string items = @"RH	Rack House
CO	Compound
BW	Bottom Workshop
TS	Top Shed
BY	Back Yard
FY	Front Yard
BP	Big Press
PO	Porch
BS	Bolt Store
LO	Loft
GY	Garages
BG	Behind Garages
81	81 Dwelling House
QA	Quarry Left of Main Route
QB	Quarry Front Shed
QC	Quarry Back Shed
QD	Quarry Concrete
QE	Quarry Area E
QF	Quarry Area F
QG	Quarry Area G
QH	Quarry Area H
QI	Quarry Area I
QJ	Quarry Area J
QK	Quarry Area K
QL	Quarry Area L
QM	Quarry Area M";

            string[] elements = items.Split(new string[] { "\n"} , StringSplitOptions.None);

            //list<string>
        }
    }
}
