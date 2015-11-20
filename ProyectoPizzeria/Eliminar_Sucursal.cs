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
    public partial class frmEliminar_Sucursal : Form
    {
        DB database;
        String cad = "";
        String id;
        Boolean ban = false;
        public frmEliminar_Sucursal()
        {
            InitializeComponent();
            database = new DB();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*private void btnEliminar_Click(object sender, EventArgs e)
        {
            id = txtId_Sucursal.Text;
            database.eliminar_Sucursal(id);
           // lblSucursal.Text = "Sucursal Eliminado";
        }*/

        private void button1_Click(object sender, EventArgs e)
        {
            string[] arreglo;
            cad = txtId_Sucursal.Text;
            String v = database.verificaSucursal(cad);
            if (v == "1")
            {

                txtDireccion.Text = "";
                txtTelefono.Text = "";
                arreglo = database.consultaSucursal(cad);
                int n = arreglo.Count();


                //cmbId_Empleados.Text = cmbId_Empleados.Text + arreglo[0] + "\n";
                txtDireccion.Text = txtDireccion.Text + arreglo[1] + "\n";
                txtTelefono.Text = txtTelefono.Text + arreglo[2] + "\n";
               
                

                btnBuscar.Enabled = true;

            }
            else
            {
                MessageBox.Show("Sucursal no disponible");

            }
        
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtDireccion.Text == "" && txtTelefono.Text == "" )
            {
                MessageBox.Show("Favor de darle clic a la opcion BUSCAR");
            }
            else
            {
                id = txtId_Sucursal.Text;
                database.eliminar_Sucursal(id);
                txtDireccion.Text = "";
                txtTelefono.Text = "";
                MessageBox.Show("Sucursal eliminado :D");

            }
            
           
            //lblEmpleados.Text = "Paquete";
        }

        private void btnRegresar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
