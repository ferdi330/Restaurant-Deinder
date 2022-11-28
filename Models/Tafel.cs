using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace D_Einder_MVC.Models
{
    public class Tafel
    {
        [Key]
        public int Id { get; set; }

        public string Naam { get; set; }

        public IList<DrinkBestellingen> Drinkbestelling { get; set; }



    }
}
