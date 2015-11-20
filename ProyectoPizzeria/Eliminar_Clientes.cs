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
    public partial class frmEliminar_Clientes : Form
    {
        DB database;
        String cad = "";
        String id;
        Boolean ban = false;
        public frmEliminar_Clientes()
        {
            InitializeComponent();
            database = new DB();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            id = txtId_Clientes.Text;
            database.eliminar_Clientes(id);
            lblClientes.Text = "Cliente eliminado";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string[] arreglo;
            cad = txtId_Clientes.Text;
            String v = database.verificaClientes(cad);
            if (v == "1")
            {
                
                txtNombre.Text = "";
                txtapPaterno.Text = ""; 
                txtapMaterno.Text = ""; 
                txtDomicilio.Text = "";
                txtTelefono.Text = "";
                arreglo = database.consultaCliente(cad);
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
                MessageBox.Show("Cliente no disponible");
                
            }
        
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" && txtapPaterno.Text == "" && txtapMaterno.Text == "" && txtDomicilio.Text == "" && txtTelefono.Text == "")
            {
                MessageBox.Show("Favor de darle clic a la opcion BUSCAR");
            }
            else
            {
                id = txtId_Clientes.Text;
                database.eliminar_Clientes(id);
                txtNombre.Text = "";
                txtapPaterno.Text = "";
                txtapMaterno.Text = "";
                txtDomicilio.Text = "";
                txtTelefono.Text = "";
                MessageBox.Show("Cliente eliminado :D");
            }

            
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEliminar_Clientes_Load(object sender, EventArgs e)
        {

        }
    }
}
