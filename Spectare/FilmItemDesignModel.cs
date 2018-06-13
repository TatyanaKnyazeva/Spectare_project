using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spectare
{
    public class FilmItemDesignModel : FilmItemViewModel
    {
        public static FilmItemDesignModel item = new FilmItemDesignModel();

        public FilmItemDesignModel()
        {
            FSname = "Halt and Cath fire";
            Imagepath = "Images/bluebg.png";
        }
    }
}
