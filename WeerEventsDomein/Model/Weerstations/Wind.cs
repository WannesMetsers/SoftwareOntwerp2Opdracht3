using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeerEventsDomein.Model.Weerstations
{
    public class Wind : Weerstation
    {
        public override void DoeMeting()
        {
            var waarde = 2 + Random.Shared.NextDouble() * 33;
            var meting = new Meting(DateTime.UtcNow, waarde, Enums.Eenheden.KilometerPerUur, Locatie);
            Metingen.Add(meting);
         
        }
    }
}
