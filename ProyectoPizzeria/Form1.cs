using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ProyectoPizzeria
{
    public partial class Form1 : Form
    {
        DB dataBase; 
        public Form1()
        {
            InitializeComponent();
            dataBase = new DB();
        }

        private void lblUsuario_Click(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            bool aceptado = dataBase.login(txtUsuario.Text, txtPassword.Text);
            string[] arreglo;
            if (aceptado)
            {
                MessageBox.Show("Bienvenido Pizzeria Bianni Sicaru");
                arreglo = dataBase.nombre();
                //lblUsuario.Text = arreglo[0];
                //lblPassword.Text = arreglo[1];
                frmMenu btnEmpleados = new frmMenu();
                btnEmpleados.Show();
                txtUsuario.Clear();
                txtPassword.Clear();
                this.Hide();
                
            }
            else
                MessageBox.Show("Usuario Incorrecto");
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            frmRegistrar btnRegistrar = new frmRegistrar();
            btnRegistrar.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            frmMenu btnEmpleados = new frmMenu();
            btnEmpleados.Show();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool aceptado = dataBase.login(txtUsuario.Text, txtPassword.Text);
            string[] arreglo;
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (aceptado)
                {
                    MessageBox.Show("Bienvenido Pizzeria Bianni Sicaru");
                    arreglo = dataBase.nombre();
                    //lblUsuario.Text = arreglo[0];
                    //lblPassword.Text = arreglo[1];
                    frmMenu btnEmpleados = new frmMenu();
                    btnEmpleados.Show();
                    txtUsuario.Clear();
                    txtPassword.Clear();
                    this.Hide();

                }
                else
                    MessageBox.Show("Usuario incorrecto");


            }
            
        }
    }
}
