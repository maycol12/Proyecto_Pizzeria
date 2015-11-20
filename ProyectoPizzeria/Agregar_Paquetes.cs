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
    public partial class frmAgregar_Paquetes : Form
    {
        DB database;
        String cad = "";
        String id;
        Boolean ban = false;
        public frmAgregar_Paquetes()
        {
            InitializeComponent();
            database = new DB();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmModificar_Paquetes btnModificar = new frmModificar_Paquetes();
            btnModificar.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmEliminar_Paquetes btnEliminar = new frmEliminar_Paquetes();
            btnEliminar.Show();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        
            string[] arreglo;
            cad = txtId_Paquetes.Text;
            String v = database.verificaPaquetes(cad);



            if ((txtCategoria.Text == "" && txtNombre.Text == "" && txtPrecio.Text == "" ) || (txtId_Paquetes.Text == ""))
            {
                MessageBox.Show("Favor de rellenar los datos");
            }
            else
            {
                if (v != "1")
                {
                    
                    int id_Paquetes = Convert.ToInt32(txtId_Paquetes.Text);
                    database.agregar_Paquetes(txtId_Paquetes.Text, txtCategoria.Text, txtNombre.Text, txtPrecio.Text);
                    MessageBox.Show("Paquete Registrado");
                    txtId_Paquetes.Clear();
                    txtCategoria.Clear();
                    txtNombre.Clear();
                    txtPrecio.Clear();
                    MessageBox.Show("Inserción correcta");


                }
                else
                {
                    MessageBox.Show("El id ingresado ya se encuentra en la base");
                }

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

        private void txtId_Paquetes_KeyPress(object sender, KeyPressEventArgs e)
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
    

