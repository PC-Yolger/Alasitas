using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alasitas.Model
{
    public class Sector
    {
        public string Inicial { get; set; }
        public string Nombre { get; set; }
        public List<Asociacion> Asociaciones { get; set; }
    }
}
