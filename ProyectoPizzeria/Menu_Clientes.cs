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
    public partial class frmMenu_Clientes : Form
    {
        public frmMenu_Clientes()
        {
            InitializeComponent();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
             frmEliminar_Clientes btnEliminar = new frmEliminar_Clientes();
             btnEliminar.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmModificar_Clientes btnModificar = new frmModificar_Clientes();
            btnModificar.Show();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAgregar_Clientes btnClientes = new frmAgregar_Clientes();
            btnClientes.Show();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            frmMostrar_Clientes btnBuscar = new frmMostrar_Clientes();
            btnBuscar.Show();
        }
    }
}
