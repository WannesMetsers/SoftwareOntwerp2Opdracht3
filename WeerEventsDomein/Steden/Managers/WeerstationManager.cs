using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeerEventsDomein.Factories;
using WeerEventsDomein.Interfaces;
using WeerEventsDomein.Logging.Factories;
using WeerEventsDomein.Model;

namespace WeerEventsDomein.Steden.Managers
{
    public class WeerstationManager : IWeerstationManager
    {

        private readonly IWeerstationFactory _weerstationFactory;
        private List<Weerstation> Weerstations;

        public WeerstationManager(IWeerstationFactory weerstationFactory)
        {
            _weerstationFactory = weerstationFactory; 
            Weerstations = _weerstationFactory.MaakWeerstations(); 
        }

        public void DoeMeting()
        {
            foreach (Weerstation weerstation in Weerstations)
            {
               weerstation.DoeMeting();
                
            }

        }

        public IEnumerable<Meting> GeefKopieMetingen()
        {

            return [.. Weerstations.SelectMany(ws => ws.GeefKopieMetingen())];
        }

        public IEnumerable<Weerstation> GeefWeerStations()
        {
            return Weerstations;
        }
    }
}
