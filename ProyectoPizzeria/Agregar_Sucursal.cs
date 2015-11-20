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
    public partial class frmAgregar_Sucursal : Form
    {
        DB database;
        String cad = "";
        String id;
        Boolean ban = false;
        public frmAgregar_Sucursal()
        {
            InitializeComponent();
            database = new DB();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmModificar_Sucursal btnModificar = new frmModificar_Sucursal();
            btnModificar.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmEliminar_Sucursal btnEliminar = new frmEliminar_Sucursal();
            btnEliminar.Show();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string[] arreglo;
            cad = txtId_Sucursal.Text;
            String v = database.verificaSucursal(cad);



            if ((txtDireccion.Text == "" && txtTelefono.Text == "" ) || (txtId_Sucursal.Text == ""))
            {
                MessageBox.Show("Favor de rellenar los datos");
            }
            else
            {
                if (v != "1")
                {
                    
                    int id_Sucursal = Convert.ToInt32(txtId_Sucursal.Text);
                    database.agregar_Sucursal(id_Sucursal, txtDireccion.Text, txtTelefono.Text);
                 
                    MessageBox.Show("Sucursal Registrado");
                    txtId_Sucursal.Clear();
                    txtDireccion.Clear();
                    txtTelefono.Clear();
                   
                    MessageBox.Show("Inserción correcta");


                }
                else
                {
                    MessageBox.Show("El id ingresado ya se encuentra en la base");
                }

            }

        }

        private void txtId_Sucursal_KeyPress(object sender, KeyPressEventArgs e)
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

    

