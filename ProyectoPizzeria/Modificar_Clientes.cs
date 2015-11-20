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
    public partial class frmModificar_Clientes : Form
    {
        DB database;
        String cad = "";
        String id;
        public frmModificar_Clientes()
        {
            InitializeComponent();
            database = new DB();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if( txtNombre.Text=="" && txtapPaterno.Text=="" &&  txtapMaterno.Text=="" &&  txtDomicilio.Text=="" &&  txtTelefono.Text=="" ){
                MessageBox.Show("Favor de rellenar todos los campos");
            }
            else{
                int id_Clientes = Convert.ToInt32(txtId_Clientes.Text);
                database.modificar_Clientes(id_Clientes, txtNombre.Text, txtapPaterno.Text, txtapMaterno.Text, txtDomicilio.Text, txtTelefono.Text);
                MessageBox.Show("Cliente Registrado");
                txtId_Clientes.Clear();
                txtNombre.Clear();
                txtapPaterno.Clear();
                txtapMaterno.Clear();
                txtDomicilio.Clear();
                txtTelefono.Clear();
            }
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


                //txtId_Clientes.Text = txtId_Clientes.Text + arreglo[0] + "\n";
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

        private void txtId_Clientes_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtId_Clientes.Clear();
            txtNombre.Clear(); 
            txtapPaterno.Clear();
            txtapMaterno.Clear();
            txtDomicilio.Clear();
            txtTelefono.Clear();
            
           
        }

        private void frmModificar_Clientes_Load(object sender, EventArgs e)
        {

        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
