using Spectare.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Spectare
{
    public class FilmItemDesignModel : FilmItemViewModel
    {
        public static FilmItemDesignModel Instance => new FilmItemDesignModel();
        DbMethods methods = new DbMethods(); 

        public FilmItemDesignModel()
        {
            FSname = methods.GetAllFilms().First().Title;
            Imagepath = methods.GetAllFilms().First().PosterLink;
        }
    }
}
