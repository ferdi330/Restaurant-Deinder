using System.ComponentModel.DataAnnotations;

namespace D_Einder_MVC.Models
{
    public class Financie
    {
        [Key]

        public int Id { get; set; }

        public string Name { get; set; }

        public string Maand { get; set; }

        public Drink Drink { get; set; }

        public Reserveringen Reserveringen { get; set; }
     
        public Menu Menus { get; set; }

        public DrinkBestellingen DrinkBestellingen { get; set; }

        public Order Order { get; set; }

        

    }
}
