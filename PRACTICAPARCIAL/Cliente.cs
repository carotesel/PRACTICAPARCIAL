using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRACTICAPARCIAL
{
    public abstract class Cliente
    {
        public int Legajo { get; set; }
        public string Nombre { get; set; }  
        public string Apellido { get; set; }


        public List <Venta> ventas {  get; set; }

        protected Cliente(int legajo, string nombre, string apellido)
        {
            Legajo = legajo;
            Nombre = nombre;
            Apellido = apellido;
            ventas = new List<Venta>();
        }

        // devuelve el valor final con el descuento aplicado
        public abstract decimal CalcularDescuento(decimal montoBruto);

        public void AgregarVenta(decimal montoBruto)
        {
            decimal descuento = CalcularDescuento(montoBruto);
            ventas.Add(new Venta(montoBruto, descuento));
        }


    }
}
