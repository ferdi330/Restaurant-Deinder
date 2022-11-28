using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace D_Einder_MVC.Models
{
    public class MenuViewModel
    {

        public List<Menu> Menus { get; set; }


        public List<GerechtenIngredienten> Appetizers { get; set; }

        public List<Gerechten> MainDish { get; set; }

        public List<MenuGerechten> Deserts { get; set; }

        public SelectList Landen { get; set; }

        public string LandGenre { get; set; }

        public string SearchString { get; set; }

    }
}
