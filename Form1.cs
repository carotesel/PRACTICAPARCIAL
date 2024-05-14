using Microsoft.VisualBasic;
using System.Collections.Immutable;

namespace PRACTICAPARCIAL
{
    public partial class Form1 : Form
    {
        List<Cliente> clientes;
        public Form1()
        {
            InitializeComponent();

            clientes = new List<Cliente>();
            dataGridView1.DataSource = ListarCompleto();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
        }

        public object ListarCompleto()
        {
            var lista = clientes.Select(cliente => new
            {
                Legajo = cliente.Legajo,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                TotalMontoBruto = cliente.ventas.Sum(venta => venta.MontoBruto),
                TotalDescuento = cliente.ventas.Sum(venta => venta.MontoBruto * venta.Descuento),
                TotalFacturado = cliente.ventas.Sum(venta => venta.MontoNeto)
            });

            return lista.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int tipoCliente = int.Parse(Interaction.InputBox("Ingrese 1 si su cliente es nacional o 2 si es internacional: "));
            string legajo = Interaction.InputBox("Ingrese legajo del cliente: ");
            string nombre = Interaction.InputBox("Ingrese nombre del cliente: ");
            if (nombre == "") throw new Exception("Debe ingresar un nombre");
            string apellido = Interaction.InputBox("Ingrese apellido del cliente");
            if (apellido == "") throw new Exception("Debe ingresar un apellido");

            if (tipoCliente == 1)
            {
                ClienteNacional c = new ClienteNacional(Convert.ToInt16(legajo), nombre, apellido);
                clientes.Add(c);

            }
            else if (tipoCliente == 2)
            {
                ClienteInternacional c = new ClienteInternacional(Convert.ToInt16(legajo), nombre, apellido);
                clientes.Add(c);

            }
            else
            {
                MessageBox.Show("Tipo de cliente invalido");
            }

            Mostrar(dataGridView1, ListarCompleto());

        }

        public void Mostrar(DataGridView pDGV, object pO)
        {
            pDGV.DataSource = null;
            pDGV.DataSource = pO;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un cliente primero.");
                return;
            }

            var row = dataGridView1.SelectedRows[0];

            int legajo = Convert.ToInt32(row.Cells["Legajo"].Value);

            var selectedClient = clientes.Find(c => c.Legajo == legajo);


            if (selectedClient == null)
            {
                MessageBox.Show("Cliente seleccionado no válido.");
                return;
            }

            // Solicitando el monto de la venta
            string inputMonto = Interaction.InputBox("Ingrese monto bruto de la venta:");
            if (!decimal.TryParse(inputMonto, out decimal montoBruto) || montoBruto <= 0)
            {
                MessageBox.Show("Por favor, ingrese un monto válido.");
                return;
            }

            // Agregando la venta al cliente seleccionado
            selectedClient.AgregarVenta(montoBruto);

            // Actualizar la visualización
            Mostrar(dataGridView1, ListarCompleto());

        }

       

    }
}
