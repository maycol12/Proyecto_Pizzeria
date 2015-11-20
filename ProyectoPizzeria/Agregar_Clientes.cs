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
    public partial class frmAgregar_Clientes : Form
    {
        DB database;
        String cad = "";
        String id;
        Boolean ban = false;
        public frmAgregar_Clientes()
        {
            InitializeComponent();
            database= new DB();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmModificar_Clientes btnModificar = new frmModificar_Clientes();
            btnModificar.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmEliminar_Clientes btnEliminar = new frmEliminar_Clientes();
            btnEliminar.Show();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string[] arreglo;
            cad = txtId_Clientes.Text;
            String v = database.verificaClientes(cad);
            

            
            if (( txtNombre.Text == "" && txtapPaterno.Text == "" && txtapMaterno.Text == "" && txtDomicilio.Text == "" && txtTelefono.Text == "") || (txtId_Clientes.Text==""))
            {
                MessageBox.Show("Favor de rellenar los datos");
            }
            else
            {
                if (v != "1")
                {
                    //arreglo = database.consultaCliente(cad);
                    //int n = arreglo.Count();
                    int id_Clientes = Convert.ToInt32(txtId_Clientes.Text);
                    database.agregar_Clientes(id_Clientes, txtNombre.Text, txtapPaterno.Text, txtapMaterno.Text, txtDomicilio.Text, txtTelefono.Text);
                    MessageBox.Show("Usuario Registrado");
                    txtId_Clientes.Clear();
                    txtNombre.Clear();
                    txtapPaterno.Clear();
                    txtapMaterno.Clear();
                    txtDomicilio.Clear();
                    txtTelefono.Clear();
                    MessageBox.Show("Inserción correcta");


                }
                else
                {
                    MessageBox.Show("El id ingresado ya se encuentra en la base");
                }
               
            }
          
        }

        private void txtId_Clientes_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtId_Clientes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros :D ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros :D ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
