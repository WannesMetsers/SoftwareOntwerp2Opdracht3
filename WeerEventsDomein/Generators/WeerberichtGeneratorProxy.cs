using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeerEventsDomein.Model;

namespace WeerEventsDomein.Generators
{
    public class WeerberichtGeneratorProxy : IWeerberichtGenerator
    {
        private readonly IWeerberichtGenerator _echteGenerator;
        private Weerbericht? _cached;
        private DateTime _laatsteGeneratie;

        public WeerberichtGeneratorProxy(IWeerberichtGenerator echteGenerator)
        {
            _echteGenerator = echteGenerator;
        }

        public Weerbericht GenereerWeerbericht()
        {
            if (_cached == null || DateTime.UtcNow - _laatsteGeneratie > TimeSpan.FromMinutes(1))
            {
                _cached = _echteGenerator.GenereerWeerbericht();
                _laatsteGeneratie = DateTime.UtcNow;
            }

            return _cached;
        }
    }

}
