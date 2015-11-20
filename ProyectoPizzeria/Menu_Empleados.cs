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
    public partial class frmMenu_Empleados : Form
    {
        public frmMenu_Empleados()
        {
            InitializeComponent();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmModificar_Empleados btnModificar = new frmModificar_Empleados();
            btnModificar.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmEliminar_Empleados btnEliminar = new frmEliminar_Empleados();
            btnEliminar.Show();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAgregar_Empleados btnEmpleados = new frmAgregar_Empleados();
            btnEmpleados.Show();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            frmRegistrar btnRegistrar = new frmRegistrar();
            btnRegistrar.Show();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmMostrar_Empleados btnBuscar = new frmMostrar_Empleados();
            btnBuscar.Show();

        }
    }
}
