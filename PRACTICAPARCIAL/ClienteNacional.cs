using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRACTICAPARCIAL
{
    public class ClienteNacional : Cliente
    {
        public ClienteNacional(int legajo, string nombre, string apellido) : base(legajo, nombre, apellido)
        {

        }

        public override decimal CalcularDescuento(decimal montoBruto)
        {
            return 0.25m;
        }
    }
}
