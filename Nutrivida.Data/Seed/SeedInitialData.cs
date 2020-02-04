using Newtonsoft.Json;
using Nutrivida.Data.Context;
using Nutrivida.Domain.Entities;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Nutrivida.API.Data
{
    public class SeedInitialData
    {
        private readonly SQLContext _context;
        public SeedInitialData(SQLContext context)
        {
            _context = context;
        }


        public void SeedUsers(){
            var userData = System.IO.File.ReadAllText("Data/SeedBaseUsers.json");
            var users = JsonConvert.DeserializeObject<List<User>>(userData);
            
            foreach (var user in users)
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash("admin", out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.Username = user.Username.ToLower();
                //user.Email = user.Email.ToLower();

                _context.Users.Add(user);
            }

            _context.SaveChanges();
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512()){
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}