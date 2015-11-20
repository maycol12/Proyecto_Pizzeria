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
    public partial class frmEliminar_Paquetes : Form
    {
        DB database;
        String cad = "";
        String id;
        Boolean ban = false;
        public frmEliminar_Paquetes()
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
            id = txtId_Paquetes.Text;
            database.eliminar_Paquetes(id);
            lblPaquetes.Text = "Paquete eliminado";
        }*/

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (txtCategoria.Text == "" && txtNombre.Text == "" && txtPrecio.Text == "" )
            {
                MessageBox.Show("Favor de darle clic a la opcion BUSCAR");
            }
            else
            {
                id = txtId_Paquetes.Text;
                database.eliminar_Paquetes(id);
                txtCategoria.Text = "";
                txtNombre.Text = "";
                txtPrecio.Text = "";
                MessageBox.Show("Paquete eliminado :D");
               
            }
            
            //lblEmpleados.Text = "Paquete";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string[] arreglo;
            cad = txtId_Paquetes.Text;
            String v = database.verificaPaquetes(cad);
            if (v == "1")
            {

                txtCategoria.Text = "";
                txtNombre.Text = "";
                txtPrecio.Text = "";
                
                arreglo = database.consultaPaquete(cad);
                int n = arreglo.Count();


                //cmbId_Empleados.Text = cmbId_Empleados.Text + arreglo[0] + "\n";
                txtCategoria.Text = txtCategoria.Text + arreglo[1] + "\n";
                txtNombre.Text = txtNombre.Text + arreglo[2] + "\n";
                txtPrecio.Text = txtPrecio.Text + arreglo[3] + "\n";
                

                btnBuscar.Enabled = true;

            }
            else
            {
                MessageBox.Show("Paquete no disponible");

            }
        }

        private void btnRegresar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEliminar_Paquetes_Load(object sender, EventArgs e)
        {

        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
