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
    public partial class frmMenu_Sucursal : Form
    {
        public frmMenu_Sucursal()
        {
            InitializeComponent();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmEliminar_Sucursal btnEliminar = new frmEliminar_Sucursal();
            btnEliminar.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmModificar_Sucursal btnModificar = new frmModificar_Sucursal();
            btnModificar.Show();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void btnAgregar_Sucursal_Click(object sender, EventArgs e)
        {
            frmAgregar_Sucursal btnSucursal = new frmAgregar_Sucursal();
            btnSucursal.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmMostrar_Sucursal btnBuscar = new frmMostrar_Sucursal();
            btnBuscar.Show();
        }
    }
}
