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
    public partial class frmModificar_Paquetes : Form
    {
        DB database;
        String cad = "";
        String id;
        public frmModificar_Paquetes()
        {
            InitializeComponent();
            database = new DB();
        }

        private void Modificar_Paquetes_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtDomicilio_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnRegrsar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            // if (txtCategoria.Text == "" && txtNombre.Text == "" && txtPrecio.Text == "")
            //{
            //    MessageBox.Show("Favor de rellenar todos los campos");
            //}


            if (txtId_Paquetes.Text.Length == 0)
            {
                MessageBox.Show("Favor de buscar el paquete");

            }
            else
            {


                if (txtCategoria.Text.Length == 0)
                {
                    MessageBox.Show("Favor de buscar el paquete antes de Modificar");
                }
                else
                {


                    if (txtNombre.Text.Length == 0)
                    {
                        MessageBox.Show("Favor de buscar el paquete antes de modificar");
                    }
                    else
                    {


                        if (txtPrecio.Text.Length == 0)
                        {
                            MessageBox.Show("Favor de buscar el paquete antes de Modificar");
                        }
                        else
                        {
                            int id_Paquetes = Convert.ToInt32(txtId_Paquetes.Text);
                            database.modificar_Paquetes(id_Paquetes, txtCategoria.Text, txtNombre.Text, txtPrecio.Text);
                            MessageBox.Show("Paquetes Actualizados");
                            txtId_Paquetes.Clear();
                            txtCategoria.Clear();
                            txtNombre.Clear();
                            txtPrecio.Clear();
                        }

                    }
                }
            }
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



                //txtId_Paquetes.Text = txtId_Paquetes.Text + arreglo[0] + "\n";
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

        private void txtId_Paquetes_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtId_Paquetes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!(char.IsNumber(e.KeyChar))&&(e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros :D ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros :D ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
