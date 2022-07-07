using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace Toci.Earrai.Bll.Client.UI
{
    public static class UserRoleManagement
    {
        private const string User = "User";

        private static Dictionary<string, string> UserUnallowedGridColumns = new Dictionary<string, string>()
        {
            { "Stock take value", User },
            { "Price", User },
        };

        private static JwtSecurityToken JwtToken;
        private static Claim Clm;

        public static bool IsColumnAllowed(string columnName)
        {
            return !UserUnallowedGridColumns.ContainsKey(columnName);
        }

        public static void LoadToken(string token)
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            SecurityToken jsonToken = handler.ReadToken(token);
            JwtToken = jsonToken as JwtSecurityToken;

            Clm = JwtToken.Claims.Where(c => c.Value == "User").FirstOrDefault();
        }

        public static string UserClaim()
        {
            return Clm.Value;
        }

        public static bool IsUserForbidden()
        {
            return Clm.Value == "User";
        }
    }
}
