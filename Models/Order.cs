using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace D_Einder_MVC.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public string MenuNaam { get; set; }

        public Menu Menu { get; set; }

        public int ReserveringenId { get; set; }

        public Reserveringen Reserveringen { get; set; }

        public int Hoeveelheid { get; set; }


    }
}
