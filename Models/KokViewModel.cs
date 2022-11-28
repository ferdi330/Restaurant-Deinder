using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;

namespace D_Einder_MVC.Models
{

    [Keyless]
    public class KokViewModel
    {

        public List<Reserveringen> Reservaties { get; set; }

        public List<GerechtenIngredienten> Voorgerecht { get; set; }

        public List<Gerechten> Hoofdgerecht { get; set; }

        public List<MenuGerechten> Desert { get; set; }


        public List<Menu> Menuprijs { get; set; }

        public List<Drink> Drinkprijs { get; set; }

        public int AantalReserveringen { get; set; }


    }
}