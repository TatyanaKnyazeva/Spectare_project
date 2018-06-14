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
        public User User { get; set; }

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
                Password = GetHash(password),
                FavFilms = new List<Film>(),
            };

            using (Context context = new Context())
            {
                context.Users.Add(NewUser);
                context.SaveChanges();
            }
        }

        public bool Authorization(string email, string password)
        {
            using (var context = new Context())
            {
                password = GetHash(password);
                var user = context.Users.Include("FavFilms").Include("FavFilms.Actors").Include("FavFilms.Types").FirstOrDefault(u => u.Email == email && u.Password == password);
                if (user != null)
                {
                    User = user;
                    return true;
                }
                return false;
            }
        }

        public void AddToFavorites(User user, Film film)
        {
            using (var context = new Context())
            {
                context.Users.Include("FavFilms").FirstOrDefault(u => u.Name == user.Name).FavFilms.Add(film);
                User.FavFilms.Add(film);
                context.SaveChanges();
            }
        }

        public void RemoveFromFavorites(User user, Film film)
        {
            using (var context = new Context())
            {
                context.Users.Include("FavFilms").FirstOrDefault(u => u.Name == user.Name).FavFilms.Remove(film);
                User.FavFilms.Remove(film);
                context.SaveChanges();
            }
        }

        public List<Film> GetAllFilms()
        {
            using (var context = new Context())
            {
                var films = context.Films.Include("Actors").Include("Types").ToList();
                return films;
            }
        }

        public Film GetFilmByName(string Name)
        {
            using (var context = new Context())
            {
                var film = context.Films.Include("Actors").Include("Types").FirstOrDefault(f => f.Title == Name);
                return film;
            }
        }
    }
}
