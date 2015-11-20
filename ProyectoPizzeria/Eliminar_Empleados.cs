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
    public partial class frmEliminar_Empleados : Form
    {
        DB database;
        String cad = "";
        String id;
        Boolean ban = false;
        public frmEliminar_Empleados()
        {
            InitializeComponent();
            database = new DB();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {


            if (txtNombre.Text == "" && txtapPaterno.Text == "" && txtapMaterno.Text == "" && txtDomicilio.Text == "" && txtTelefono.Text == "")
            {
                MessageBox.Show("Favor de darle clic a la opcion BUSCAR");
            }
            else
            {
                id = txtId_Empleados.Text;
                database.eliminar_Empleados(id);
                txtNombre.Text = "";
                txtapPaterno.Text = "";
                txtapMaterno.Text = "";
                txtDomicilio.Text = "";
                txtTelefono.Text = "";
                MessageBox.Show("Empleado eliminado :D");
            }


            
        }

        private void btnRegresar_Click(object sender, EventArgs e)
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
                txtDomicilio.Text = txtDomicilio.Text + arreglo[4] + "\n";
                txtTelefono.Text = txtTelefono.Text + arreglo[5] + "\n";

                btnBuscar.Enabled = true;

            }
            else
            {
                MessageBox.Show("Empleado no disponible");
                
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
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

        private void btnRegresar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
