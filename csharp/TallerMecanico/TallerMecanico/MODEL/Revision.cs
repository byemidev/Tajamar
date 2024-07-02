using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerMecanico.MODEL
{
    public class Revision : Mecanico
    {
        public Revision(string desc, int num) : base(desc, num)
        {
            //reutilizo el constructor del padre Mecanico
        }
    }

}
