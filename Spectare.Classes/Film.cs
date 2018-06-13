using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spectare.Classes
{
    public class Film
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PosterLink { get; set; }
        public string TrailerLink { get; set; }
        public string WebLink { get; set; }
        public List<FilmType> Types { get; set; }
        public List<Actor> Actors { get; set; }
        public List<User> Users { get; set; }
        public string PhotoLink1 { get; set; }
        public string PhotoLink2 { get; set; }
        public string PhotoLink3 { get; set; }
    }
}
