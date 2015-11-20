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
    public partial class frmMostrar_Ventas : Form
    {
        public frmMostrar_Ventas()
        {
            InitializeComponent();
            dataGridView1.Rows.Clear();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        MySqlConnection conectar = new MySqlConnection("Database=pizzeria;Data Source=localhost;User Id=root;Password=");
        DataSet ds;
        private void btnMostrar_Click(object sender, EventArgs e)
        {
            conectar.Open();

            MySqlCommand comando = new MySqlCommand("Select * from ventas", conectar);

            MySqlDataAdapter con = new MySqlDataAdapter(comando);
            ds = new DataSet();
            con.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
           
            conectar.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string[] cad;
            int suma = 0;
            
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                suma += Convert.ToInt32(row.Cells[3].Value); //aqui recorre las celdas y las va sumando
            }
            lblTotal_Pagar.Text = Convert.ToString(suma); //aqui se graba el total
            
         
           
            //Convert.ToInt32(dataGridView1.Rows[0].Cells[3].Value);
            
            

            
            
          
             
        }
    }
}
