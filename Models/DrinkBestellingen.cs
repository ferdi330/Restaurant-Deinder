using System.ComponentModel.DataAnnotations;

namespace D_Einder_MVC.Models
{
    public class DrinkBestellingen
    {
        public int TafelId { get; set; }


        public Tafel Tafel { get; set; }


        public int DrinkId { get; set; }


        public Drink Drink { get; set; }


        public int Aantal { get; set; }

    }
}
