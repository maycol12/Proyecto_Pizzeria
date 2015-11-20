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
    public partial class frmAgregar_Empleados : Form
    {
        DB database;
        String cad = "";
        String id;
        Boolean ban = false;
//DB database;  
        public frmAgregar_Empleados()
        {
            InitializeComponent();
            database = new DB();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string[] arreglo;
            cad = txtId_Empleados.Text;
            String v = database.verificaEmpleados(cad);



            if((txtNombre.Text == "" && txtapPaterno.Text == "" && txtapMaterno.Text == "" && txtDomicilio.Text == "" && txtTelefono.Text == "") || (txtId_Empleados.Text==""))
            {
                MessageBox.Show("Favor de rellenar los datos");
            }
            else
            {
                if (v != "1")
                {
                    //arreglo = database.consultaCliente(cad);
                    //int n = arreglo.Count();
                    int id_Empleados = Convert.ToInt32(txtId_Empleados.Text);
                    database.agregar_Empleados(id_Empleados, txtNombre.Text, txtapPaterno.Text, txtapMaterno.Text, txtDomicilio.Text, txtTelefono.Text);
                    MessageBox.Show("Usuario Registrado");
                    txtId_Empleados.Clear();
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmEliminar_Empleados btnEliminar = new frmEliminar_Empleados();
            btnEliminar.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmModificar_Empleados btnModificar = new frmModificar_Empleados();
            btnModificar.Show();
        }

        private void txtId_Empleados_KeyPress(object sender, KeyPressEventArgs e)
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
