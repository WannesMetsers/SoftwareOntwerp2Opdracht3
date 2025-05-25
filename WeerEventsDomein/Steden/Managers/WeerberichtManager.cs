using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeerEventsDomein.Generators;
using WeerEventsDomein.Model;

namespace WeerEventsDomein.Steden.Managers
{
    public class WeerberichtManager : IWeerberichtManager
    {
        private readonly IWeerberichtGenerator _weerberichtGenerator;

        public WeerberichtManager (IWeerberichtGenerator weerberichtGenerator)
        {
            this._weerberichtGenerator = weerberichtGenerator;
        }
        public Weerbericht GeefWeerbericht()
        {
            return _weerberichtGenerator.GenereerWeerbericht();
        }
    }
}
