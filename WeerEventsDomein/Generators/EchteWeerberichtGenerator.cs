using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeerEvents.Dto;
using WeerEventsDomein.Model;

namespace WeerEventsDomein.Generators
{
    public class EchteWeerberichtGenerator : IWeerberichtGenerator
    {
        private readonly Func<IEnumerable<Meting>> _metingenProvider;

        public EchteWeerberichtGenerator(Func<IEnumerable<Meting>> metingenProvider)
        {
            _metingenProvider = metingenProvider;
        }

        public Weerbericht GenereerWeerbericht()
        {
            Thread.Sleep(5000); // Simuleer zware bewerking

            var metingen = _metingenProvider().ToList();
            var inhoud = $"Op basis van {metingen.Count} metingen en mijn diepzinnig computermodel kan ik zeggen dat er kans is op {(metingen.Count % 2 == 0 ? "goed" : "slecht")} weer.";

            return new Weerbericht
            {
                MomentCreatie = DateTime.UtcNow,
                Tekst = inhoud
            };
        }
    }

}
