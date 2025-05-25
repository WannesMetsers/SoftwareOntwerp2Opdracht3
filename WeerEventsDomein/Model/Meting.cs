using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeerEventsDomein.Enums;

namespace WeerEventsDomein.Model
{
    public class Meting
    {
        public DateTime MetingTijd { get; set; }

        public Double Waarde { get; set; }

        public Eenheden Eenheid { get; set; }

        public Stad Locatie { get; set; }

        public Meting(DateTime metingTijd, double waarde, Eenheden eenheid, Stad locatie)
        {
            this.MetingTijd = metingTijd;
            Waarde = waarde;
            this.Eenheid = eenheid;
            Locatie = locatie;
        }

        
    }
}
