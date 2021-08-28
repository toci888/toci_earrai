﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Toci.Earrai.Bll
{
    public class AuthData
    {
        public static string GetAppId()
        {
            return "98a98443-1860-405d-9277-b8bccba724f7";
        }

        public static string GetTenantId()
        {
            return "f9b56296-c8eb-46ed-81e1-5483cb395754";
        }

        public static string GetUserName()
        {
            return "bzapart@tocizapart.onmicrosoft.com";
        }

        public static SecureString GetPassword()
        {
            SecureString password = new SecureString();

            string pass = "Beatka911";

            for (int i = 0; i < pass.Length; i++)
            {
                password.AppendChar(pass[i]);
            }

            return password;
        }

        public static string[] GetScopes()
        {
            return new[] { "https://graph.microsoft.com/User.ReadWrite.All", "https://graph.microsoft.com/Files.ReadWrite.All",
            "https://graph.microsoft.com/Files.Read.All", "https://graph.microsoft.com/Sites.Read.All",
            "https://graph.microsoft.com/Sites.ReadWrite.All" };
        }
    }
}
