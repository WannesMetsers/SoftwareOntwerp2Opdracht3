using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeerEventsDomein.Model;

namespace WeerEventsDomein.Steden.Managers
{
    public interface IWeerberichtManager
    {
        Weerbericht GeefWeerbericht();
    }
}
