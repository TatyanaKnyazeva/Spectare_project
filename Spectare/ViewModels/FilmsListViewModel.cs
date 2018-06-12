using Spectare.DesignModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spectare.ViewModels
{
    public class FilmsListViewModel
    {
        public List<FilmItemDesignModel> Items { get; set; }
        public FilmsListViewModel()
        {

        }
    }
}
