using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeerEventsDomein.Model
{
    public class Weerbericht
    {
        public required DateTime MomentCreatie { get; set; }
        
        public required string Tekst { get; set; }
    }
}
