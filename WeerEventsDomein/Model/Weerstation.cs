using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeerEventsDomein.Model
{
    public abstract class Weerstation
    {
        public required Stad Locatie { get; set; }

        public required List<Meting> Metingen { get; set; }

        public IReadOnlyList<Meting> GeefMetingen() => Metingen.AsReadOnly();

        public abstract void DoeMeting();

        //kopie van lijst van gedane metingen teruggeven?

        public List<Meting> GeefKopieMetingen()
        {
            return new List<Meting>(Metingen);
        }
    }
}
