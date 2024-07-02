using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerMecanico.MODEL
{
    public class Mecanico : Trabajo_impl
    {
        public Mecanico(string descripcion, int num_horas) : base(descripcion, num_horas)
        {
            //reutilizo el constructor del padre Trabajo
        }
    }
}
