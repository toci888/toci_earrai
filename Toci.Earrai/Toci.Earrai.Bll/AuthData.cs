using System;
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
            return "431aa131-7ff7-4aee-8c9c-e2f1a36cb55c";
        }

        public static string GetTenantId()
        {
            return "f9b56296-c8eb-46ed-81e1-5483cb395754";
        } //ea844b49-bd9a-442f-a46e-8eabe9eaa08a

        public static string GetUserName()
        {
            return "Earrai@gormleysengineering.com"; //
        }

        public static SecureString GetPassword()
        {
            SecureString password = new SecureString();

            string pass = "Duvo5755";

            for (int i = 0; i < pass.Length; i++)
            {
                password.AppendChar(pass[i]);
            }

            return password;
        }

        public static string[] GetScopes()
        {
            return new string[] { }; // { "https://graph.microsoft.com/User.ReadWrite.All", "https://graph.microsoft.com/Files.ReadWrite.All",
            //"https://graph.microsoft.com/Files.Read.All", "https://graph.microsoft.com/Sites.Read.All",
            //"https://graph.microsoft.com/Sites.ReadWrite.All" };
        }
    }
}
