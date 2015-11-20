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
       
    public partial class frmRegistrar : Form
    {
        DB database;
        public frmRegistrar()
        {
            InitializeComponent();
            database = new DB();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            database.Agregar_Empleados(id, txtNombre.Text, txtPassword.Text);
            MessageBox.Show("Usuario Registrado");
            txtId.Text = "";
            txtNombre.Clear();
            txtPassword.Clear();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
    }
}
