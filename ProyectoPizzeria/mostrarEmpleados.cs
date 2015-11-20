using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProyectoPizzeria
{
    public partial class frmMostrar_Empleados : Form
    {
        DB database;
        String cad = "";
        String id;
        public frmMostrar_Empleados()
        {
            InitializeComponent();
            database = new DB();
        }
        MySqlConnection conectar = new MySqlConnection("Database=pizzeria;Data Source=localhost;User Id=root;Password=");
        DataSet ds;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

       // private void btnBuscar_Click(object sender, EventArgs e)
        //{
          /*  string[] arreglo;
            cad = txtId_Empleados.Text;
            String v = database.verificaEmpleados(cad);
            if (v == "1")
            {

                arreglo = database.consultaEmpleado(cad);
                int n = arreglo.Count();

                string[] filaNueva = { "idEmpleado", "Nombre", "Memelas", "Verdes", "esquina", "858575748", "Modificar", "Eliminar" };
                dataGridView1.Rows.Add(filaNueva);

                btnBuscar.Enabled = true;

            }
            else
            {
                MessageBox.Show("Empleado no disponible");
            }
        }*/

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            conectar.Open();

            MySqlCommand comando = new MySqlCommand("Select * from empleados", conectar);

            MySqlDataAdapter con = new MySqlDataAdapter(comando);
            ds = new DataSet();
            con.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            conectar.Close();


        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
