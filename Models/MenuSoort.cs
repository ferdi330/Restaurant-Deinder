using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace D_Einder_MVC.Models
{
    public class MenuSoort
    {
        [Key]
        public int Id { get; set; }

        public string Naam { get; set; }

        public ICollection<Menu> Menus { get; set; }


    }
}
