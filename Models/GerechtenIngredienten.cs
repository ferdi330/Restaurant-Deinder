using System.ComponentModel.DataAnnotations;

namespace D_Einder_MVC.Models
{
    public class GerechtenIngredienten
    {
        [Key]
        public int Id { get; set; }

        public int GerechtenId { get; set; }

        public Gerechten Gerechten { get; set; }

        public int IngredientenId { get; set; }

        public Ingredienten Ingredienten { get; set; }

        public int Hoeveelheid { get; set; }

    }
}
