using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace empleadosCRUD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SGBD sgbd = new SGBD();
            sgbd.openConn();
            sgbd.createEmpleado(new empleado("4654545", "etxt", "asasas", "asassa", 12));
            sgbd.closeConn();
        }
    }
}
