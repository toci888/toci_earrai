using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toci.Earrai.Bll;
using Toci.Earrai.Database.Persistence.Models;
using Toci.Earrai.Microservice;
using Toci.Earrai.Microservice.Controllers;
using Toci.Earrai.Tests.Import.Excel;
using Action = Toci.Earrai.Database.Persistence.Models.Action;
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
        private Logic<Action> Action = new Logic<Action>();
        private Logic<Rolesaction> RoleAction = new Logic<Rolesaction>();

        private Random r = new Random();

        [TestMethod]
        public void Feilim()
        {
            Account.RegisterUser(new User()
            {
                Firstname = "Feilim",
                Lastname = "Gormley",
                Initials = "FG",
                Email = "feilim@gormleyseng.com",
                Password = "beatka",
                Token = "empty token",
                Idrole = 1
            });

            Account.RegisterUser(new User()
            {
                Firstname = "Eoin",
                Lastname = "Gormley",
                Initials = "EG",
                Email = "eoin@gormleyseng.com",
                Password = "beatka",
                Token = "empty token",
                Idrole = 1
            });
        }

            [TestMethod]
        public void SeedAllDb()
        {
            Roles();
            Users();
            Actions();
            RolesAction();
            SeedAreas();
            SeedWlOrSizeCategories();
            Vendors();
            QuotesAndMetrics();
           // Workbooks();
           // AreaQuantities();
            CategoryGroups();
            //Category();
            Size();
           // SizeCategories();
          //  QuotesAndPrices();
//            Products();
           // ProductSizes();
            ProductOptions();
           // ProductCategoryOptions();
           // ProductOptionValues();
        }

        [TestMethod]
        public void newImport() {

            ExcelEx client1 = new ExcelEx();

            client1.RequestWorkbooksEx();

            //Logic<Quoteandprice> quotesAndPrice = new Logic<Quoteandprice>();

            //quoteandprice.
    

        }
        
        [TestMethod]
        public void Actions()
        {
            string[] actions = new[]
            {
                "Smart Browsing Product Records by Category",
                "View Historic dated and Current Record Balance Levels per area",
                "Modify Stock Level Per Sub Area",
                "Cause a Stock Update in Sage",
                "Process Updates to Sage",
                "View Cost related information",
                "Modify Cost Related Information",
                "Create New Products",
                "Assign New Users",
                "Special Category Plate Stock",
                "Suggest New Product Record / Item - Plate & Sheet",
                "Suggest New Product Record / Item - General",
                "Create New Product Record / Item",
                "Approve New Product Record / Item",
            };

            foreach (string action in actions)
            {
                Action.Insert(new Action()
                {
                    Action1 = action
                });
            }
        }

        [TestMethod]
        public void RolesAction()
        {
            int[] role1 = new[] { 1, 2, 3, 11, 12 }; // User
            int[] role2 = new[] { 1, 2, 3, 6, 7, 11, 12 }; // Office
            int[] role3 = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 11, 12 }; // Pc
            int[] role4 = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 11, 12, 13, 14 }; // Admin

            foreach (var action in role1)
            {
                RoleAction.Insert(new Rolesaction()
                {
                    Idrole = 1,
                    Idaction = action
                });
            }

            foreach (var action in role2)
            {
                RoleAction.Insert(new Rolesaction()
                {
                    Idrole = 2,
                    Idaction = action
                });
            }

            foreach (var action in role3)
            {
                RoleAction.Insert(new Rolesaction()
                {
                    Idrole = 3,
                    Idaction = action
                });
            }

            foreach (var action in role4)
            {
                RoleAction.Insert(new Rolesaction()
                {
                    Idrole = 4,
                    Idaction = action
                });
            }
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
        public void ProductOptions()
        {
            // TODO, set proper names and codes

            ProductOption.Insert(new Productoption() { Code = "SizeMetric", Name = "Metric" });
            ProductOption.Insert(new Productoption() { Code = "SheetSize", Name = "SheetSize" });
            ProductOption.Insert(new Productoption() { Code = "KgM", Name = "KgM" });
            ProductOption.Insert(new Productoption() { Code = "ChsOd", Name = "ChsOd" });
            ProductOption.Insert(new Productoption() { Code = "ChsBore", Name = "ChsBore" });
            ProductOption.Insert(new Productoption() { Code = "Type", Name = "Type" });
            ProductOption.Insert(new Productoption() { Code = "Dia", Name = "Dia" });
            ProductOption.Insert(new Productoption() { Code = "Id", Name = "Id" });
            ProductOption.Insert(new Productoption() { Code = "ProductCodeShort", Name = "Product Code Short" });
            ProductOption.Insert(new Productoption() { Code = "KgM2", Name = "KgM2" });
            ProductOption.Insert(new Productoption() { Code = "KgSheet", Name = "KgSheet" });

        }

        [TestMethod]
        public void Size()
        {
            Sizes.Insert(new Size()
            {
                Id = 1,
                Name = "Length"
            });
            Sizes.Insert(new Size()
            {
                Id = 2,
                Name = "Width"
            });
            Sizes.Insert(new Size()
            {
                Id = 3,
                Name = "Thickness"
            });
            Sizes.Insert(new Size()
            {
                Id = 4,
                Name = "CHS Bore"
            });
            Sizes.Insert(new Size() {
                Id = 5,
                Name = "SizeA"
            });
            Sizes.Insert(new Size() {
                Id = 6,
                Name = "SizeB"
            });
            Sizes.Insert(new Size()
            {
                Id = 7,
                Name = "Size"
            });
        }

        [TestMethod]
        public void QuotesAndMetrics() 
        {
            string[] values = { "£/Tonne", "£/Length", "£/meter", "£/Sheet", "£/meter2" };
            string[] names = { "PoundsPerTonne", "PoundsPerLength", "PoundsPerMeter", "PoundsPerSheet", "PoundsPerMeterSquared" };
            for (int i = 0; i < values.Length; i++)
            {
                Quoteandmetric.Insert(new Quoteandmetric()
                {
                    Valuation = values[i],
                    Name = names[i],
                });
            }
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

            for (int i = 0; i < 4; i++)
            {
                int jLength = prefixes[i].Length;
                for (int j = 0; j < jLength; j++)
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

            Categories.Insert(new Category()
            {
                Name = "DUMMY",
                Prefix = "DUMMY",
                Description = "DUMMY"
            });
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
            //var ele = new SeedWorkBook();
            //ele.SeedDBByWorkbook();
        }

        [TestMethod]
        public void SeedCategoriesEx()
        {
            string koopa = @"
1,PL_Plate Mild Steel,Plt/Sht/Mesh,PL,PL_Plate Mild Steel,Plate Mild Steel
2,PLCHQ_Chequer Plate Mild Steel,Plt/Sht/Mesh,PLCHQ,PLCHQ_Chequer Plate Mild Steel,Chequer Plate Mild Steel
3,HD_Hardox Plate,Plt/Sht/Mesh,HD,HD_Hardox Plate,Hardox Plate
4,GS_Galvanised Sheet,Plt/Sht/Mesh,GS,GS_Galvanised Sheet,Galvanised Sheet
5,ALSH_Aluminium Sheet,Plt/Sht/Mesh,ALSH,ALSH_Aluminium Sheet,Aluminium Sheet
6,ALCHQ_Aluminium Chequer Plate,Plt/Sht/Mesh,ALCHQ,ALCHQ_Aluminium Chequer Plate,Aluminium Chequer Plate
25,MSH_Wire Weld Mesh,Plt/Sht/Mesh,MSH,MSH_Wire Weld Mesh,Wire Weld Mesh
26,EX_MET_Expanded Metal,Plt/Sht/Mesh,EX_MET,EX_MET_Expanded Metal,Expanded Metal
7,SHS_Square Hollow Section,Sections & Bars,SHS,SHS_Square Hollow Section,Square Hollow Section
8,RHS_Rectangular Hollow Section,Sections & Bars,RHS,RHS_Rectangular Hollow Section,Rectangular Hollow Section
9,PFC_Parallel Flange Channel,Sections & Bars,PFC,PFC_Parallel Flange Channel,Parallel Flange Channel
10,UB_Universal Beam,Sections & Bars,UB,UB_Universal Beam,Universal Beam
11,UC_Universal Column,Sections & Bars,UC,UC_Universal Column,Universal Column
12,IPE_Continental I Beams (I-Sections),Sections & Bars,IPE,IPE_Continental I Beams (I-Sections),Continental I Beams (I-Sections)
13,EA_Equal Angles,Sections & Bars,EA,EA_Equal Angles,Equal Angles
14,UA_Unequal Angles,Sections & Bars,UA,UA_Unequal Angles,Unequal Angles
15,TS_T-Section T-Bar,Sections & Bars,TS,TS_T-Section T-Bar,T-Section T-Bar
16,CHS_Circular Hollow Section,Sections & Bars,CHS,CHS_Circular Hollow Section,Circular Hollow Section
17,GCHS_Galv Cirular Hollow Section,Sections & Bars,GCHS,GCHS_Galv Cirular Hollow Section,Galv Cirular Hollow Section
18,FL_Flat Bar Mild Steel,Sections & Bars,FL,FL_Flat Bar Mild Steel,Flat Bar Mild Steel
19,FLB_Flat Bar Bright,Sections & Bars,FLB,FLB_Flat Bar Bright,Flat Bar Bright
20,RB_BLK_Black Round Bar,Sections & Bars,RB_BLK,RB_BLK_Black Round Bar,Black Round Bar
21,RB_BRI_Bright Round Bar,Sections & Bars,RB_BRI,RB_BRI_Bright Round Bar,Bright Round Bar
22,SQ_BLK_Square Bar Black,Sections & Bars,SQ_BLK,SQ_BLK_Square Bar Black,Square Bar Black
23,SQ_BRI_Square Bar Bright,Sections & Bars,SQ_BRI,SQ_BRI_Square Bar Bright,Square Bar Bright
24,HB_Hollow Bore Bar,Sections & Bars,HB,HB_Hollow Bore Bar,Hollow Bore Bar
101,F_BH_Finished_Bale Handlers,Finished Products,F_BH,F_BH_Finished_Bale Handlers,Bale Handlers
102,F_PB_Finished_Power Boxes,Finished Products,F_PB,F_PB_Finished_Power Boxes,Power Boxes
103,F_TB_Finished_Transport Boxes,Finished Products,F_TB,F_TB_Finished_Transport Boxes,Transport Boxes
104,F_PS_Finished_Power Scoop,Finished Products,F_PS,F_PS_Finished_Power Scoop,Power Scoop
105,F_LL_Finished_Land Leveller,Finished Products,F_LL,F_LL_Finished_Land Leveller,Land Leveller
106,F_TS_Finished_Tip Skip,Finished Products,F_TS,F_TS_Finished_Tip Skip,Tip Skip
107,F_LR_Finished_Land Rollers,Finished Products,F_LR,F_LR_Finished_Land Rollers,Land Rollers
108,F_CF_Finished_Circular Feeders,Finished Products,F_CF,F_CF_Finished_Circular Feeders,Circular Feeders
110,F_BT_Finished_Bale Trailer,Finished Products,F_BT,F_BT_Finished_Bale Trailer,Bale Trailer
111,F_FT_Finished_Feeding Troughs,Finished Products,F_FT,F_FT_Finished_Feeding Troughs,Feeding Troughs
112,F_PL_Finished_Pallet Lifter,Finished Products,F_PL,F_PL_Finished_Pallet Lifter,Pallet Lifter
113,F_FLB_Finished_Fork Lift Bucket,Finished Products,F_FLB,F_FLB_Finished_Fork Lift Bucket,Fork Lift Bucket
114,F_YS_Finished_Yardscraper,Finished Products,F_YS,F_YS_Finished_Yardscraper,Yardscraper
115,F_SP_Finished_Snow Plough,Finished Products,F_SP,F_SP_Finished_Snow Plough,Snow Plough
201,PF_BH_Part Finished_Bale Handlers,Finished Products,PF_BH,PF_BH_Part Finished_Bale Handlers,Bale Handlers
202,PF_PB_Part Finished_Power Boxes,Finished Products,PF_PB,PF_PB_Part Finished_Power Boxes,Power Boxes
203,PF_TB_Part Finished_Transport Boxes,Finished Products,PF_TB,PF_TB_Part Finished_Transport Boxes,Transport Boxes
204,PF_PS_Part Finished_Power Scoop,Finished Products,PF_PS,PF_PS_Part Finished_Power Scoop,Power Scoop
205,PF_LL_Part Finished_Land Leveller,Finished Products,PF_LL,PF_LL_Part Finished_Land Leveller,Land Leveller
206,PF_TS_Part Finished_Tip Skip,Finished Products,PF_TS,PF_TS_Part Finished_Tip Skip,Tip Skip
207,PF_LR_Part Finished_Land Rollers,Finished Products,PF_LR,PF_LR_Part Finished_Land Rollers,Land Rollers
208,PF_CF_Part Finished_Circular Feeders,Finished Products,PF_CF,PF_CF_Part Finished_Circular Feeders,Circular Feeders
209,PF_CA_Part Finished_Crush Assemblies,Finished Products,PF_CA,PF_CA_Part Finished_Crush Assemblies,Crush Assemblies
210,PF_BT_Part Finished_Bale Trailer,Finished Products,PF_BT,PF_BT_Part Finished_Bale Trailer,Bale Trailer
211,PF_FT_Part Finished_Feeding Troughs,Finished Products,PF_FT,PF_FT_Part Finished_Feeding Troughs,Feeding Troughs
212,PF_PL_Part Finished_Pallet Lifter,Finished Products,PF_PL,PF_PL_Part Finished_Pallet Lifter,Pallet Lifter
213,PF_FLB_Part Finished_Fork Lift Bucket,Finished Products,PF_FLB,PF_FLB_Part Finished_Fork Lift Bucket,Fork Lift Bucket
214,PF_YS_Part Finished_Yardscraper,Finished Products,PF_YS,PF_YS_Part Finished_Yardscraper,Yardscraper
215,PF_SP_Part Finished_Snow Plough,Finished Products,PF_SP,PF_SP_Part Finished_Snow Plough,Snow Plough
301,RAM_Rams,Miscelanneous,RAM_,RAM__Rams,Rams
302,PAI_Paint,Miscelanneous,PAI,PAI_Paint,Paint
303,CON_Consumables,Miscelanneous,CON,CON_Consumables,Consumables";

            List<string> list = koopa.Split("\n", StringSplitOptions.None).ToList();

            //List<string[]> posiekane = new List<string[]>();

            List< CategoryEntity > znormalizowane = new List<CategoryEntity>();

            foreach (string s in list)
            {
                string[] posiekane = (s.Split(","));
                if (posiekane.Length == 6)
                {
                    znormalizowane.Add(new CategoryEntity() { Id = posiekane[0], Name = posiekane[1], Group = posiekane[2], Prefix = posiekane[3], Code = posiekane[4], Description = posiekane[5]});
                }
            }

            foreach (CategoryEntity item in znormalizowane)
            {
                Categorygroup group = CategoryGroup.Select(m => m.Name == item.Group).FirstOrDefault();
                Categories.Insert(new Category() {Code  = item.Code, Name = item.Name, Description = item.Description, Idcategorygroups = group.Id, Prefix = item.Prefix});
            }
        }

        class CategoryEntity
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Prefix { get; set; }
            public string Group { get; set; }
            public string Description { get; set; }
            public string Code { get; set; }
        }
    }
}
