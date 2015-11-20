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
    public partial class frmModificar_Sucursal : Form
    {
        DB database;
        String cad = "";
        String id;
        public frmModificar_Sucursal()
        {
            InitializeComponent();
            database =  new DB();
        }

        private void btnRegrsar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
             if (txtTelefono.Text == "" && txtDireccion.Text == "" && txtTelefono.Text == "")
            {
                MessageBox.Show("Favor de rellenar todos los campos");
            }
            else
            {
                int id_Sucursal = Convert.ToInt32(txtId_Sucursal.Text);
                database.modificar_Sucursal(id_Sucursal, txtDireccion.Text, txtTelefono.Text);
                MessageBox.Show("Sucursal Actualizados");
                txtId_Sucursal.Clear();
                txtDireccion.Clear();
                txtTelefono.Clear();
                
            }
           
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
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



                //txtId_Paquetes.Text = txtId_Paquetes.Text + arreglo[0] + "\n";
                txtDireccion.Text = txtDireccion.Text + arreglo[1] + "\n";
                txtTelefono.Text = txtTelefono.Text + arreglo[2] + "\n";
               
              
                btnBuscar.Enabled = true;

            }
            else
            {
                MessageBox.Show("Sucursal no disponible");
            }
            
        }

        private void txtId_Sucursal_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

        }

        
        
    }
}
