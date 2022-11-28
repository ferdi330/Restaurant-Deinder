using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;

namespace D_Einder_MVC.Models
{

    [Keyless]
    public class OmzetViewModel
    {

        public IEnumerable<Tafel> Tafels { get; set; }

        public IEnumerable<Reserveringen> Reservaties { get; set; }

        public IEnumerable<Menu> Menuprijs { get; set; }

        public IEnumerable<Order> BesteldeMenu { get; set; }

        public IEnumerable<DrinkBestellingen> BesteldeDrinken { get; set; }

        public IEnumerable<Drink> Drinkprijs { get; set; }

        public int AantalReserveringen { get; set; }


    }
}