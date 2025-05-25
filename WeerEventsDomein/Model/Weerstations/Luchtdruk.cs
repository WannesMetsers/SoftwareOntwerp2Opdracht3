using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeerEventsDomein.Model.Weerstations
{
    public class Luchtdruk : Weerstation
    {
        public override void DoeMeting()
        {
            var waarde = Random.Shared.NextDouble() * 980 - 1050;
            var meting = new Meting(DateTime.UtcNow, waarde, Enums.Eenheden.KilometerPerUur, Locatie);
            Metingen.Add(meting);
            
        }
    }
}
