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
    public partial class frmModificar_Empleados : Form
    {
        DB database;
        String cad = "";
        String id;
        public frmModificar_Empleados()
        {
            InitializeComponent();
            database = new DB();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string[] arreglo;
            cad = txtId_Empleados.Text;
            String v = database.verificaEmpleados(cad);
            if (v == "1")
            {
             
                txtNombre.Text = "";
                txtapPaterno.Text = "";
                txtapMaterno.Text = "";
                txtDomicilio.Text = "";
                txtTelefono.Text = "";
                arreglo = database.consultaEmpleado(cad);
                int n = arreglo.Count();


                //cmbId_Empleados.Text = cmbId_Empleados.Text + arreglo[0] + "\n";
                txtNombre.Text = txtNombre.Text + arreglo[1] + "\n";
                txtapPaterno.Text = txtapPaterno.Text + arreglo[2] + "\n";
                txtapMaterno.Text = txtapMaterno.Text + arreglo[3] + "\n";
                txtDomicilio.Text = txtDomicilio.Text + arreglo[5] + "\n";
                txtTelefono.Text = txtTelefono.Text + arreglo[4] + "\n";

                btnBuscar.Enabled = true;

            }
            else
            {
                MessageBox.Show("Empleado no disponible");
            }
           
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" && txtapPaterno.Text == "" && txtapMaterno.Text == "" && txtDomicilio.Text == "" && txtTelefono.Text == "")
            {
                MessageBox.Show("Favor de rellenar todos los campos");
            }
            else
            {
                int id_Empleados = Convert.ToInt32(txtId_Empleados.Text);
                database.modificar_Empleados(id_Empleados, txtNombre.Text, txtapPaterno.Text, txtapMaterno.Text, txtDomicilio.Text, txtTelefono.Text);
                MessageBox.Show("Empleado Registrado");
                txtId_Empleados.Clear();
                txtNombre.Clear();
                txtapPaterno.Clear();
                txtapMaterno.Clear();
                txtDomicilio.Clear();
                txtTelefono.Clear();

            }
          
            
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmModificar_Empleados_Load(object sender, EventArgs e)
        {

        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            txtId_Empleados.Clear();
            txtNombre.Clear();
            txtapPaterno.Clear();
            txtapMaterno.Clear();
            txtDomicilio.Clear();
            txtTelefono.Clear();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
