using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace D_Einder_MVC.Models
{
    [Keyless]
    public class TafelViewModel
    {
        public List<Tafel> Tafels { get; set; }

        public List<Reserveringen> Reserveringen { get; set; }

        public List<Order> Order { get; set; }

        public List<Drink> Drinken { get; set; }

        public List<DrinkBestellingen> DrinkBestellingen { get; set; }

    }
}
