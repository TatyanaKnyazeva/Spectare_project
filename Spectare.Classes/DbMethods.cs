using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Spectare.Classes
{
    public class DbMethods
    {
        public static string GetHash(string password)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hash);
        }

        public void Registration(string name, string email, string password)
        {
            User NewUser = new User
            {
                Name = name,
                Email = email,
                Password = GetHash(password)
            };

            using (Context context = new Context())
            {
                context.Users.Add(NewUser);
                context.SaveChanges();
            }
        }
    }
}
