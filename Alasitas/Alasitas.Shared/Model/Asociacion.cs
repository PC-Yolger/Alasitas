using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alasitas.Model
{
    public class Asociacion
    {
        public string Nombre { get; set; }
        public string NroExpositores { get; set; }
        public List<string> Productos { get; set; }
    }
}
