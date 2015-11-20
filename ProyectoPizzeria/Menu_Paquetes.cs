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
    public partial class frmMenu_Paquetes : Form
    {
        public frmMenu_Paquetes()
        {
            InitializeComponent();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmModificar_Paquetes btnModificar = new frmModificar_Paquetes();
            btnModificar.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmEliminar_Paquetes btnEliminar = new frmEliminar_Paquetes();
            btnEliminar.Show();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Paquetes_Click(object sender, EventArgs e)
        {
            frmAgregar_Paquetes btnPaquetes = new frmAgregar_Paquetes();
            btnPaquetes.Show();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            frmMostrar_Paquetes btnBuscar = new frmMostrar_Paquetes();
            btnBuscar.Show();
        }
    }
}
