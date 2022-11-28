using System.ComponentModel.DataAnnotations;

namespace D_Einder_MVC.Models
{
    public class Gerechten
    {
        [Key]
        public int Id { get; set; }

        public string Naam { get; set; }

        public string GerechtSoort { get; set; }

    }
}
