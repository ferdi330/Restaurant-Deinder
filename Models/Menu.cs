using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace D_Einder_MVC.Models
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }

        public string Naam { get; set; }

        public int Prijs { get; set; }

        public IList<Order> Order { get; set; }

        public int MenuSoortId { get; set; }

        public MenuSoort MenuSoort { get; set; }

        public IList<MenuGerechten> MenuGerechten { get; set; }


    }
}
