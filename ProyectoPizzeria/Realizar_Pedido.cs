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
    public partial class frmRealizar_Pedido : Form
    {
        DB database;
        String cad = "";
        String id;
        Boolean ban = false;
        int[] array = new int[1000];
        int n = 0;
        public frmRealizar_Pedido()
        {
            InitializeComponent();
            database = new DB();
        }
        MySqlConnection conectar = new MySqlConnection("Database=pizzeria;Data Source=localhost;User Id=root;Password=");
        DataSet ds;

        private void lblTotal_A_Pagar_Click(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        private void Realizar_Pedido_Load(object sender, EventArgs e)
        {

        }

        private void cmbPaquetes_SelectedIndexChanged(object sender, EventArgs e)
        {
            cad = "" + cmbPaquetes.SelectedItem;
            string[] arreglo;
            arreglo = database.consultaPaquete(cad);
            id = arreglo[0];
            btnAceptar.Enabled = true;

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string[] arreglo;
           // cad = cmbPaquetes.SelectedText;
            //String v = database.verificaPaquetes(cad);
          
            //if (v == "1")
            //{
            if(cmbPaquetes.SelectedIndex==-1)
            {
                MessageBox.Show("Selecciona el pedido");
            }
            else
            {
                txtCategoria.Text = "";
                txtNombre.Text = "";
                txtPrecio.Text = "";


                arreglo = database.consultaPaquete(cad);
                int n = arreglo.Count();
                txtCategoria.Text = txtCategoria.Text + arreglo[1];
                txtNombre.Text = txtNombre.Text + arreglo[2];
                txtPrecio.Text = txtPrecio.Text + arreglo[3];

            }
                
            //}
            //else
            //{
                //MessageBox.Show("Favor de buscar el paquete :D");
            }
            //arreglo = database.consultaPaquete(cad);
                
        

        private void cmbPaquetes_MouseClick(object sender, MouseEventArgs e)
        {
            string[] arreglo;
            arreglo = database.Paquete();
            cmbPaquetes.Items.Clear();
            arreglo = database.Paquete();
            int n = arreglo.Count();
            for (int i = 0; i < n; i++)
            {
                cmbPaquetes.Items.Add(arreglo[i]);
            }
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            if ((txtCategoria.Text == "" && txtNombre.Text == "" && txtPrecio.Text == ""))
            {
                MessageBox.Show("Favor de selecionar el paquete :D");
            }
            else
            {
                array[n] =  Int32.Parse(txtPrecio.Text);
                n++;
                listBox1.Items.Add(txtNombre.Text + "," + txtCategoria.Text + "," + txtPrecio.Text);
            }

        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            int suma = 0;
           int j;
            /*int i;
            for (i = 0; i < n; i++)
                {
                    suma = suma + array[i];
                }
            
                txtTotal_Pagar.Text = (suma).ToString();
               
         }*/
           
        
            string[] cad;
            
            foreach (object item in listBox1.Items)
            {
                int val = Convert.ToInt32(txtPrecio.Text);
                cad=item.ToString().Split(',');
               /* for (j = 0; j < 3; j++)
                {
                    MessageBox.Show(cad[j]);     
                }*/
                val = Convert.ToInt32(cad[2]);


                suma = suma + val;
                lblTotal_Pagar.Text = (suma).ToString();
            }
                
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (txtId_Clientes.Text.Length == 0)
            {
                MessageBox.Show("Favor de ingresar la id de cliente");
            }
            else
            {
                if (txtRecibio.Text.Length == 0)
                {
                    MessageBox.Show("Favor de ingresar la cantidad Recibida");
                }
                else
                {
                    if (lblTotal_Pagar.Text.Length == 0)
                    {
                        MessageBox.Show("Favor de calcular el costo de la venta");
                    }
                    else
                    {
                        int Resul = 0;
                        int Recibio = 0;
                        int.TryParse(txtRecibio.Text, out Recibio);
                        int Total_Pagar = 0;
                        int.TryParse(lblTotal_Pagar.Text, out Total_Pagar);
                        Resul = Recibio - Total_Pagar;
                        lblCambio.Text = Resul.ToString();
                        string[] fecha = database.fechaActual();
                        string paquete = "";
                        string[] cad;
                        int j;
                        foreach (object item in listBox1.Items)
                        {
                            cad = item.ToString().Split(',');
                            for (j = 0; j < 3; j++)
                            {
                                switch (j)
                                {
                                    case 0: paquete += "Categoria: " + cad[j] + " "; break;
                                    case 1: paquete += "Nombre: " + cad[j] + " "; break;
                                    case 2: paquete += "Precio: " + cad[j] + " "; break;
                                }
                            }
                            paquete += "\n";
                        }
                        database.agregar_Ventas(txtId_Clientes.Text, paquete, lblTotal_Pagar.Text, fecha[0]);
                        MessageBox.Show("Venta exitosa");
                        //txtId_Clientes.Clear();
                        //txtRecibio.Clear();
                        //txtTotal_Pagar.Clear();

                    }
                }
            }
          

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex!=-1)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Favor de selecionar el pedido a eliminar :D");  

            }
            //MessageBox.Show(listBox1.SelectedIndex.ToString());
            
            
                
                
            
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
       

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            conectar.Open();

            MySqlCommand comando = new MySqlCommand("Select * from paquetes", conectar);

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

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            txtNombre.Clear();
            txtCategoria.Clear();
            txtPrecio.Clear();
            txtRecibio.Clear();
            txtId_Clientes.Clear();
            //lblTotal_Pagar.Clear();
            //lblCambio.Clear();
        }

        private void txtTotal_Pagar_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
    


