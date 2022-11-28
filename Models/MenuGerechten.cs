using System.ComponentModel.DataAnnotations;

namespace D_Einder_MVC.Models
{
    public class MenuGerechten
    {
        [Key]
        public int Id { get; set; }

        public int GerechtenId { get; set; }

        public Gerechten Gerechten { get; set; }

        public int MenuId { get; set; }

        public Menu Menus { get; set; }


    }
}
