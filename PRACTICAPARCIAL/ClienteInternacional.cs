using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRACTICAPARCIAL
{
    public class ClienteInternacional : Cliente
    {
        public ClienteInternacional(int legajo, string nombre, string apellido) : base (legajo, nombre, apellido) 
        {
        }

        public override decimal CalcularDescuento(decimal montoBruto)
        {
            return 0.1m;
        }
    }
}
