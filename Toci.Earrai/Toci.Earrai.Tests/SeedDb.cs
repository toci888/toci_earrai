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
        private Logic<Area> Area = new Logic<Area>();
        private Logic<Codesdimension> codesdimensions = new Logic<Codesdimension>();
        private Logic<Vendor> Vendor = new Logic<Vendor>();
        private Logic<Quoteandmetric> Quoteandmetric = new Logic<Quoteandmetric>();
        private Logic<Categorygroup> CategoryGroup = new Logic<Categorygroup>();
        private Logic<Category> Categories = new Logic<Category>();
        private Logic<Size> Sizes = new Logic<Size>();
        private Logic<Sizecategory> SizeCategory = new Logic<Sizecategory>();
        private Logic<Quoteandprice> QuotesAndPrice = new Logic<Quoteandprice>();
        private Logic<Product> Product_ = new Logic<Product>();
        private Logic<Productsize> ProductSize = new Logic<Productsize>();
        private Logic<Productoption> ProductOption = new Logic<Productoption>();
        private Logic<Productcategoryoption> ProductCategoryOption = new Logic<Productcategoryoption>();
        private Logic<Productoptionvalue> ProductOptionValue = new Logic<Productoptionvalue>();

        private Random r = new Random();

        [TestMethod]
        public void SeedAllDb()
        {
            Roles();
            Users();
            SeedAreas();
            SeedWlOrSizeCategories();
            Vendors();
            QuotesAndMetrics();
            Workbooks();
            AreaQuantities();
            CategoryGroups();
            Category();
            Size();
            SizeCategories();
            QuotesAndPrices();
            Products();
            ProductSizes();
            ProductOptions();
            ProductCategoryOptions();
            ProductOptionValues();
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
                QM	Quarry Area M
                empty	empty";

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
                codesdimensions.Insert(new Codesdimension() { Code = code.Trim(), Kind = 1 });
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
                codesdimensions.Insert(new Codesdimension() { Code = code.Trim(), Kind = 2 });
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
        public void CategoryGroups()
        {
            string[] values = { "Plt/Sht/Mesh", "Sections & Bars", "Finished Products", "Miscelanneous"};
            for (int i = 0; i < values.Length; i++)
            {
                CategoryGroup.Insert(new Categorygroup()
                {
                    Name = values[i]
                });
            }
        }

        [TestMethod]
        public void ProductOptionValues()
        {
            ProductOptionValue.Insert(new Productoptionvalue()
            {
                Idproductoptions = 1,
                Idproducts = 1,
                Value = "300"
            });
            ProductOptionValue.Insert(new Productoptionvalue()
            {
                Idproductoptions = 2,
                Idproducts = 2,
                Value = "400"
            });
            ProductOptionValue.Insert(new Productoptionvalue()
            {
                Idproductoptions = 3,
                Idproducts = 3,
                Value = "500"
            });
        }

            [TestMethod]
        public void ProductCategoryOptions()
        {
            ProductCategoryOption.Insert(new Productcategoryoption()
            {
                Idcategories = 1,
                Idproductoptions = 1
            });
            ProductCategoryOption.Insert(new Productcategoryoption()
            {
                Idcategories = 2,
                Idproductoptions = 2
            });
            ProductCategoryOption.Insert(new Productcategoryoption()
            {
                Idcategories = 3,
                Idproductoptions = 3
            });
        }

            [TestMethod]
        public void ProductOptions()
        {
            ProductOption.Insert(new Productoption()
            {
                Code = "123",
                Name = "dupa1"
            });
            ProductOption.Insert(new Productoption()
            {
                Code = "1234",
                Name = "dupa12"
            });
            ProductOption.Insert(new Productoption()
            {
                Code = "12345",
                Name = "dupa17"
            });
        }
            [TestMethod]
        public void ProductSizes()
        {
            ProductSize.Insert(new Productsize()
            {
                Idsizes = 1,
                Idproducts = 1,
                Value = "2500"
            });
            ProductSize.Insert(new Productsize()
            {
                Idsizes = 1,
                Idproducts = 2,
                Value = "2500"
            });
            ProductSize.Insert(new Productsize()
            {
                Idsizes = 1,
                Idproducts = 3,
                Value = "3000"
            });
        }

            [TestMethod]
        public void Products()
        {
            Product_.Insert(new Product()
            {
                Idcategories = 1,
                Idworksheet = 4,
                Rowindex = 443,
                Productaccountreference = "ALSH_0.9_2500_1250",
                Description = "0.8mm PLAIN"
            });
            Product_.Insert(new Product()
            {
                Idcategories = 1,
                Idworksheet = 4,
                Rowindex = 445,
                Productaccountreference = "ALSH_2_2500_1250",
                Description = "2mm PLAIN"
            });
            Product_.Insert(new Product()
            {
                Idcategories = 1,
                Idworksheet = 4,
                Rowindex = 444,
                Productaccountreference = "ALSH_2_3000_1500",
                Description = "2mm PLAIN"
            });
        }

            [TestMethod]
        public void QuotesAndPrices()
        {
            QuotesAndPrice.Insert(new Quoteandprice()
            {
                //Idworksheet = 2,
                Rowindex = 34,
                Price = "485.00",
                Idvendor = 2,
                Idquoteandmetric = 1,
                Iduser = 2
            });
            QuotesAndPrice.Insert(new Quoteandprice()
            {
                //Idworksheet = 3,
                Rowindex = 343,
                Price = "48.10",
                Idvendor = 3,
                Idquoteandmetric = 3,
                Iduser = 3
            });
            QuotesAndPrice.Insert(new Quoteandprice()
            {
                //Idworksheet = 6,
                Rowindex = 3234,
                Price = "85.00",
                Idvendor = 1,
                Idquoteandmetric = 2,
                Iduser = 1
            });
        }

            [TestMethod]
        public void Category()
        {
            string[][] prefixes = new string[4][];
            prefixes[0] = new string[] { "PL", "PLCHQ", "HD", "GS", "ALSH", "ALCHQ", "MSH", "EX_MET" };
            prefixes[1] = new string[] { "SHS", "RHS", "PFC", "UB", "UC", "IPE", "EA", "UA", "TS",
                "CHS", "GCHS", "FL", "FLB", "RB_BLK", "RB_BRI", "SQ_BLK", "SQ_BRI", "HB" };
            prefixes[2] = new string[] { "F_BH", "F_PB", "F_TB", "F_PS", "F_LL", "F_TS", "F_LR", "F_CF",
                "F_BT", "F_FT", "F_PL", "F_FLB", "F_YS", "F_SP", "PF_BH", "PF_PB", "PF_TB", "PF_PS",
                "PF_LL", "PF_TS", "PF_LR", "PF_CF", "PF_CA", "PF_BT", "PF_FT", "PF_PL", "PF_FLB", "PF_YS", "PF_SP" };
            prefixes[3] = new string[] { "RAM_", "PAI", "CON" };

            string[][] names = new string[4][];
            names[0] = new string[] { "PL_Plate Mild Steel", "PLCHQ_Chequer Plate Mild Steel", "HD_Hardox Plate", "GS_Galvanised Sheet",
                "ALSH_Aluminium Sheet", "ALCHQ_Aluminium Chequer Plate", "MSH_Wire Weld Mesh", "EX_MET_Expanded Metal" };
            names[1] = new string[] { "SHS_Square Hollow Section", "RHS_Rectangular Hollow Section", "PFC_Parallel Flange Channel", "UB_Universal Beam",
                "UC_Universal Column", "IPE_Continental I Beams (I-Sections)", "EA_Equal Angles", "UA_Unequal Angles", "TS_T-Section T-Bar",
                "CHS_Circular Hollow Section", "GCHS_Galv Cirular Hollow Section", "FL_Flat Bar Mild Steel", "FLB_Flat Bar Bright", "RB_BLK_Black Round Bar",
                "RB_BRI_Bright Round Bar", "SQ_BLK_Square Bar Black", "SQ_BRI_Square Bar Bright", "HB_Hollow Bore Bar" };
            names[2] = new string[] { "F_BH_Finished_Bale Handlers", "F_PB_Finished_Power Boxes", "F_TB_Finished_Transport Boxes", "F_PS_Finished_Power Scoop",
                "F_LL_Finished_Land Leveller", "F_TS_Finished_Tip Skip", "F_LR_Finished_Land Rollers", "F_CF_Finished_Circular Feeders", "F_BT_Finished_Bale Trailer",
                "F_FT_Finished_Feeding Troughs", "F_PL_Finished_Pallet Lifter", "F_FLB_Finished_Fork Lift Bucket", "F_YS_Finished_Yardscraper", 
                "F_SP_Finished_Snow Plough", "PF_BH_Part Finished_Bale Handlers", "PF_PB_Part Finished_Power Boxes", "PF_TB_Part Finished_Transport Boxes",
                "PF_PS_Part Finished_Power Scoop", "PF_LL_Part Finished_Land Leveller", "PF_TS_Part Finished_Tip Skip", "PF_LR_Part Finished_Land Rollers",
                "PF_CF_Part Finished_Circular Feeders", "PF_CA_Part Finished_Crush Assemblies", "PF_BT_Part Finished_Bale Trailer", "PF_FT_Part Finished_Feeding Troughs",
                "PF_PL_Part Finished_Pallet Lifter", "PF_FLB_Part Finished_Fork Lift Bucket", "PF_YS_Part Finished_Yardscraper", "PF_SP_Part Finished_Snow Plough" };
            names[3] = new string[] { "RAM__Rams", "PAI_Paint", "CON_Consumables" };

            string[][] descriptions = new string[4][];
            descriptions[0] = new string[] { "Plate Mild Steel", "Chequer Plate Mild Steel", "Hardox Plate", "Galvanised Sheet", "Aluminium Sheet",
                "Aluminium Chequer Plate", "Wire Weld Mesh", "Expanded Metal" };
            descriptions[1] = new string[] { "Square Hollow Section", "Rectangular Hollow Section", "Parallel Flange Channel", "Universal Beam", "Universal Column",
                "Continental I Beams (I-Sections)", "Equal Angles", "Unequal Angles", "T-Section T-Bar", "Circular Hollow Section", "Galv Cirular Hollow Section",
                "Flat Bar Mild Steel", "Flat Bar Bright", "Black Round Bar", "Bright Round Bar", "Square Bar Black", "Square Bar Bright", "Hollow Bore Bar" };
            descriptions[2] = new string[] { "Bale Handlers", "Power Boxes", "Transport Boxes", "Power Scoop", "Land Leveller", "Tip Skip", "Land Rollers",
                "Circular Feeders","Bale Trailer", "Feeding Troughs", "Pallet Lifter", "Fork Lift Bucket", "Yardscraper", "Snow Plough", "Bale Handlers",
                "Power Boxes", "Transport Boxes", "Power Scoop", "Land Leveller", "Tip Skip", "Land Rollers", "Circular Feeders", "Crush Assemblies", "Bale Trailer",
                "Feeding Troughs", "Pallet Lifter", "Fork Lift Bucket", "Yardscraper", "Snow Plough" };
            descriptions[3] = new string[] { "Rams", "Paint", "Consumables" };

            for(int i = 0; i < 4; i++)
            {
                int jLength = prefixes[i].Length;
                for(int j = 0; j < jLength; j++)
                {
                    string pref = prefixes[i][j];
                    string name = names[i][j];
                    string descr = descriptions[i][j];
                    Categories.Insert(new Category()
                    {
                        Idcategorygroups = i + 1,
                        Name = name,
                        Prefix = pref,
                        Description = descr
                    });
                }
            }
        }

        [TestMethod]
        public void SizeCategories()
        {
            SizeCategory.Insert(new Sizecategory()
            {
                Idsizes = 1,
                Idcategories = 1
            });
            SizeCategory.Insert(new Sizecategory()
            {
                Idsizes = 2,
                Idcategories = 2
            });
            SizeCategory.Insert(new Sizecategory()
            {
                Idsizes = 3,
                Idcategories = 3
            });
        }

            [TestMethod]
        public void Size()
        {
            Sizes.Insert(new Size()
            {
                Name = "Length"
            });
            Sizes.Insert(new Size()
            {
                Name = "CHS Bore"
            });
            Sizes.Insert(new Size()
            {
                Name = "Size"
            });
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

        [TestMethod]
        public void AreaQuantities()
        {
            Console.WriteLine("Lets start");
            var ele = new ObtainRecordsFromContentForAreaQuantity();
            ele.ObtainRecords();
        }

        [TestMethod]
        public void Workbooks()
        {
            Console.WriteLine("Lets start");
            var ele = new SeedWorkBook();
            ele.SeedDBByWorkbook();
        }
    }
}
