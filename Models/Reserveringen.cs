using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace D_Einder_MVC.Models
{
    public class Reserveringen
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public string  Tijd { get; set; }

        public string Naam { get; set; }

        public string Adress { get; set; }

        public string Woonplaats { get; set; }
      
        public int TafelId { get; set; }

        [ForeignKey("TafelId")]
        public Tafel Tafel { get; set; }

        public IList<Order> Order { get; set; }


    }
}