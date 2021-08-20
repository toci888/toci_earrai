using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Toci.Earrai.Bll.Interfaces;
using Toci.Earrai.Bll.Models;
using Toci.Earrai.Database.Persistence.Models;
using Toci.Earrai.Microservice;
using Toci.Earrai.Microservice.Exceptions;

namespace Toci.Earrai.Bll
{
    public class UserLogic : Logic<Userrole>, IUserLogic
    {
        private readonly AuthenticationSettings _authenticationSettings;
        protected Logic<User> userLogic = new Logic<User>();
        public UserLogic(AuthenticationSettings authenticationSettings)
        {
            _authenticationSettings = authenticationSettings;
        }

        public int CreateAccount(User user)
        {
            if (isLoginAlreadyInDb(user.Email))
            {
                return 0;
            }

            user.Password = HashPassword(user.Password);

            User newUser = userLogic.Insert(user);

            return newUser.Id;
        }

        public string GenerateJwt(LoginDto user)
        {
            string hash = HashPassword(user.Password);
            Userrole u = Select(u => u.Email == user.Email && u.Password == hash).FirstOrDefault();

            if (u is null)
            {
                //throw new Exception("Invalid username or password");
                //throw new BadRequestException("Invalid username or password");
                return "Invalid username or password";
            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, u.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{u.Firstname} {u.Lastname}"),
                new Claim(ClaimTypes.Role, $"{u.Name}"),
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            SigningCredentials cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            DateTime expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            JwtSecurityToken token = new JwtSecurityToken(_authenticationSettings.JwtIssuer, 
                _authenticationSettings.JwtIssuer, claims, expires: expires, signingCredentials: cred);

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }

        public IQueryable<User> GetAll()
        {
            return userLogic.Select(m => m.Id > 0);
        }

        protected virtual bool isLoginAlreadyInDb(string email)
        {
            return userLogic.Select(x => x.Email == email).Any();
        }

        private string HashPassword(string password)
        {
            SHA256 algorithm = SHA256.Create();
            StringBuilder sb = new StringBuilder();
            foreach (Byte b in algorithm.ComputeHash(Encoding.UTF8.GetBytes(password)))
            {
                sb.Append(b.ToString("X2"));
            }

            return sb.ToString();
        }
    }
}