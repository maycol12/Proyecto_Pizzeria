using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoPizzeria
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void menu_Load(object sender, EventArgs e)
        {
            Text = "frmMenu";
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            frmMenu_Empleados btnEmpleados = new frmMenu_Empleados();
            btnEmpleados.Show();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            frmMenu_Clientes btnClientes= new frmMenu_Clientes();
            btnClientes.Show();
        }

        private void btnSucursal_Click(object sender, EventArgs e)
        {
            frmMenu_Sucursal btnSucursal = new frmMenu_Sucursal();
            btnSucursal.Show();
        }

        private void btnPaquetes_Click(object sender, EventArgs e)
        {
            frmMenu_Paquetes btnPaquetes = new frmMenu_Paquetes();
            btnPaquetes.Show();
        }

        private void btnCerrar_Seccion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmRealizar_Pedido btnPedido = new frmRealizar_Pedido();
            btnPedido.Show();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            frmMostrar_Ventas btnPedido = new frmMostrar_Ventas();
            btnPedido.Show();
        }
    }
}
