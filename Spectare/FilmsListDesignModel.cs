using Spectare.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spectare
{
    class FilmsListDesignModel : FilmsListViewModel
    {
        public static FilmsListDesignModel Instance => new FilmsListDesignModel();
        DbMethods methods = new DbMethods();

        public FilmsListDesignModel()
        {
            foreach(var f in methods.GetAllFilms())
            {
                Items.Add(new FilmItemViewModel { FSname = f.Title, Imagepath = f.PosterLink });
            }
        }
    }
}
