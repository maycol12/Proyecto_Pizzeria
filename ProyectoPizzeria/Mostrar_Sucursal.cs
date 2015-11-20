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
    public partial class frmMostrar_Sucursal : Form
    {
        public frmMostrar_Sucursal()
        {
            InitializeComponent();
        }
        MySqlConnection conectar = new MySqlConnection("Database=pizzeria;Data Source=localhost;User Id=root;Password=");
        DataSet ds;

        private void btnMostrar_Click(object sender, EventArgs e)
        {

            conectar.Open();

            MySqlCommand comando = new MySqlCommand("Select * from sucursal", conectar);

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
