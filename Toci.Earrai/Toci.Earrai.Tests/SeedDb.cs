using System;
using System.Collections.Generic;
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

        private Logic<Role> Role = new Logic<Role>();
        private Logic<Workbook> Workbook = new Logic<Workbook>();
        private Logic<Worksheet> Worksheet = new Logic<Worksheet>();
        private Logic<Worksheetcontent> WorksheetContent = new Logic<Worksheetcontent>();
        private Logic<Area> Area = new Logic<Area>();
        private Logic<Codesdimension> codesdimensions = new Logic<Codesdimension>();
        private Logic<Vendor> Vendor = new Logic<Vendor>();
        private Logic<Quoteandmetric> Quoteandmetric = new Logic<Quoteandmetric>();

        private Random r = new Random();

        [TestMethod]
        public void SeedAllDb()
        {
            SeedUsersAndRoles();
            SeedWorksheets();
            SeedAreas();
            SeedWlOrSizeCategories();
            Vendors();
            QuotesAndMetrics();
            Roles();
            Users();
            Workbooks();
            Worksheets();
            WorksheetContents();
            SeedAreas();
            SeedWlOrSizeCategories();
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
                Initials = "UU",
                Email = "user@wp.pl",
                Password = "123456789",
                Token = "empty token",
                Idrole = 1
            });

            Account.RegisterUser(new User()
            {
                Firstname = "Office",
                Lastname = "Office",
                Initials = "OO",
                Email = "office@wp.pl",
                Password = "123456785",
                Token = "empty token",
                Idrole = 2
            });

            Account.RegisterUser(new User()
            {
                Firstname = "Pc",
                Lastname = "Pc",
                Initials = "PP",
                Email = "pc@wp.pl",
                Password = "123456784",
                Token = "empty token",
                Idrole = 3
            });

            Account.RegisterUser(new User()
            {
                Firstname = "Admin",
                Lastname = "Admin",
                Initials = "AA",
                Email = "admin@wp.pl",
                Password = "123456783",
                Token = "empty token",
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

            
            foreach (string element in elements)
            {
                string[] pieces = element.Split("\t", StringSplitOptions.None);
                Area.Insert(new Area() { Code = pieces[0].Trim(), Name = pieces[1] });
            }
        }

        [TestMethod]
        public void SeedWlOrSizeCategories() 
        {
            //wl - width, length
            // size - size
            string[] wl = @"PL
PLCHQ
HD
GS
ALSH
ALCHQ
MSH
EX_MET".Split("\n", StringSplitOptions.None);

            foreach (string code in wl)
            {
                codesdimensions.Insert(new Codesdimension() { Code = code, Kind = 1 });
            }

            string[] size = @"SHS
RHS
PFC
UB
UC
IPE
EA
UA
TS
CHS
GCHS
FL
FLB
RB_BLK
RB_BRI
SQ_BLK
SQ_BRI
HB
F_BH
F_PB
F_TB
F_PS
F_LL
F_TS
F_LR
F_CF
F_BT
F_FT
F_PL
F_FLB
F_YS
F_SP
PF_BH
PF_PB
PF_TB
PF_PS
PF_LL
PF_TS
PF_LR
PF_CF
PF_CA
PF_BT
PF_FT
PF_PL
PF_FLB
PF_YS
PF_SP
RAM_
PAI
CON".Split("\n", StringSplitOptions.None);

            foreach (string code in size)
            {
                codesdimensions.Insert(new Codesdimension() { Code = code, Kind = 2 });
            }
        }

        [TestMethod]
        public void Vendors()  
        {
            string[] values = { "McCance", "Wwatson", "McArdle", "Hannon", "RFL"};
            for (int i = 0; i < values.Length; i++)
            {
                Vendor.Insert(new Vendor()
                {
                    Name = values[i]
                });
            }
        }

        [TestMethod]
        public void QuotesAndMetrics() 
        {
            string[] values = { "£/T", "£/L", "£/m", "£/Sht" };
            for (int i = 0; i < values.Length; i++)
            {
                Quoteandmetric.Insert(new Quoteandmetric()
                {
                    Valuation = values[i]
                });
            }
        }
    }
}
