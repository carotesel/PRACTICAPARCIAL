using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRACTICAPARCIAL
{
    public class Venta
    {
        public decimal MontoBruto { get; set; }
        public decimal MontoNeto { get; set;} // monto con desc aplicado

        public decimal Descuento { get; set; }

        public Venta(decimal pMontoBruto, decimal pDescuento)
        {
            MontoBruto = pMontoBruto;
            Descuento = pDescuento;
            MontoNeto = pMontoBruto - pDescuento * pMontoBruto;
        }
    }
}
