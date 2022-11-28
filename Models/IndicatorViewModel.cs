using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;

namespace D_Einder_MVC.Models
{

    [Keyless]
    public class IndicatorViewModel
    {

        public IEnumerable<Reserveringen> Reservaties { get; set; }

        public IEnumerable<Tafel> Tafels { get; set; }

        public int AantalReserveringen { get; set; }


    }
}
