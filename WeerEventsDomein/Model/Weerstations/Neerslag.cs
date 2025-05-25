using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeerEventsDomein.Model.Weerstations
{
    public class Neerslag : Weerstation
    {
        public override void DoeMeting()
        {
            var waarde = 700 + Random.Shared.NextDouble() * 700;
            var meting = new Meting(DateTime.UtcNow, waarde, Enums.Eenheden.MillimeterPerVierkanteMeterPerUur, Locatie);
            Metingen.Add(meting);
            
        }
    }
}
