using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace ProyectoPizzeria
{

    class DB
    {
        MySqlConnection connection;
        string stringConnection;

        public DB()
        {
            stringConnection = "Database=pizzeria;Data Source=localhost;User Id=root;Password=";
            connection = new MySqlConnection(stringConnection);
        }
        public bool login(string nombre, string pass)
        {
            string query = "SELECT * FROM login WHERE nombre = '" + nombre + "' AND Pass = SHA1('" + pass + "');";
            bool log;
            MySqlCommand command = new MySqlCommand(query, connection);
            //command.Parameters.Add("?usuario", MySqlDbType.VarChar, 20).Value = usuario;
            Console.WriteLine(command.CommandText);
            MySqlDataReader reader;
            connection.Open();
            reader = command.ExecuteReader();
            log = reader.HasRows;
            reader.Close();
            connection.Close();
            return log;
        }
        public string[] nombre()
        {
            string[] arreglo;
            string query = "SELECT * FROM login;";
            MySqlCommand command = new MySqlCommand(query, connection);
            //command.Parameters.Add("?usuario", MySqlDbType.VarChar, 20).Value = usuario;
            Console.WriteLine(command.CommandText);
            MySqlDataReader reader;
            connection.Open();
            reader = command.ExecuteReader();
            arreglo = new string[3];
            reader.Read();
            string cadena = reader.GetString(1);
            arreglo[0] = cadena;
            reader.Read();
            arreglo[1] = reader.GetString(1);
            reader.Read();
            arreglo[2] = reader.GetString(1);
            connection.Close();
            return arreglo;
        }
        public string[] consultaEmpleado(String cad)
        {

            string[] arreglo;
            string query = "SELECT * FROM Empleados where idEmpleados='" + cad + "';";
            MySqlCommand command = new MySqlCommand(query, connection);
            Console.WriteLine(command.CommandText);
            MySqlDataReader reader;
            connection.Open();
            reader = command.ExecuteReader();
            int n = reader.FieldCount;
            arreglo = new string[n];
            for (int i = 0; i < n; i++)
            {
                reader.Read();
                arreglo[i] = reader.GetString(i);
            }
            connection.Close();
            return arreglo;
        }
        public string verificaEmpleados(String cad)
        {
            String query = "SELECT count(Nombre) FROM empleados where idEmpleados='" + cad + "';";
            MySqlCommand command = new MySqlCommand(query, connection);
            Console.WriteLine(command.CommandText);
            MySqlDataReader reader;
            connection.Open();
            reader = command.ExecuteReader();
            reader.Read();
            String v = reader.GetString(0);
            //MessageBox.Show("" + v);
            connection.Close();
            return v;
        }
        public string[] consultaCliente(String cad)
        {
            string[] arreglo;
            string query = "SELECT * FROM clientes where idClientes='" + cad + "';";
            MySqlCommand command = new MySqlCommand(query, connection);
            Console.WriteLine(command.CommandText);
            MySqlDataReader reader;
            connection.Open();
            reader = command.ExecuteReader();
            int n = reader.FieldCount;

            arreglo = new string[n];
            for (int i = 0; i < n; i++)
            {
                reader.Read();

                arreglo[i] = reader.GetString(i);
            }
            connection.Close();
            return arreglo;
        }

        public string verificaClientes(String cad)
        {
            String query = "SELECT count(Nombre) FROM clientes where idClientes='" + cad + "';";
            MySqlCommand command = new MySqlCommand(query, connection);
            Console.WriteLine(command.CommandText);
            MySqlDataReader reader;
            connection.Open();
            reader = command.ExecuteReader();
            reader.Read();
            String v = reader.GetString(0);
            //MessageBox.Show("" + v);
            connection.Close();
            return v;
        }

        public string[] consultaSucursal(String cad)
        {
            string[] arreglo;
            string query = "SELECT * FROM sucursal where idPizzeria='" + cad + "';";
            MySqlCommand command = new MySqlCommand(query, connection);
            Console.WriteLine(command.CommandText);
            MySqlDataReader reader;
            connection.Open();
            reader = command.ExecuteReader();
            int n = reader.FieldCount;
            arreglo = new string[n];
            for (int i = 0; i < n; i++)
            {
                reader.Read();
                arreglo[i] = reader.GetString(i);
            }
            connection.Close();
            return arreglo;
        }
        public string verificaSucursal(String cad)
        {
            String query = "SELECT count(Direccion) FROM sucursal where idPizzeria='" + cad + "';";
            MySqlCommand command = new MySqlCommand(query, connection);
            Console.WriteLine(command.CommandText);
            MySqlDataReader reader;
            connection.Open();
            reader = command.ExecuteReader();
            reader.Read();
            String v = reader.GetString(0);
            //MessageBox.Show("" + v);
            connection.Close();
            return v;
        }
        public string[] consultaPaquete(String cad)
        {
            string[] arreglo;
            string query = "SELECT * FROM paquetes where idPaquetes='" + cad + "';";
            MySqlCommand command = new MySqlCommand(query, connection);
            Console.WriteLine(command.CommandText);
            MySqlDataReader reader;
            connection.Open();
            reader = command.ExecuteReader();
            int n = reader.FieldCount;


            arreglo = new string[n];

            for (int i = 0; i < n; i++)
            {
                reader.Read();
                arreglo[i] = reader.GetString(i);

            }


            connection.Close();
            return arreglo;
        }
        public string[] Paquete()
        {
            string[] arreglo;
            string query = "SELECT * FROM paquetes;";
            int n = filas("SELECT count(idPaquetes) from paquetes; ");
            MySqlCommand command = new MySqlCommand(query, connection);
            Console.WriteLine(command.CommandText);
            MySqlDataReader reader;
            connection.Open();
            reader = command.ExecuteReader();
            arreglo = new string[n];

            for (int i = 0; i < n; i++)
            {
                reader.Read();
                arreglo[i] = reader.GetString(0);
                // arreglo[i] = cadena;
            }
            connection.Close();
            return arreglo;
        }
        public int filas(string query)
        {
            int n;
            MySqlCommand command = new MySqlCommand(query, connection);
            Console.WriteLine(command.CommandText);
            MySqlDataReader reader;
            connection.Open();
            reader = command.ExecuteReader();
            reader.Read();
            int.TryParse(reader.GetString(0), out n);
            connection.Close();
            return n;
        }
        public string verificaPaquetes(String cad)
        {
            String query = "SELECT count(Nombre) FROM paquetes where idPaquetes='" + cad + "';";
            MySqlCommand command = new MySqlCommand(query, connection);
            Console.WriteLine(command.CommandText);
            MySqlDataReader reader;
            connection.Open();
            reader = command.ExecuteReader();
            reader.Read();
            String v = reader.GetString(0);
            //MessageBox.Show("" + v);
            connection.Close();
            return v;
        }

        public void Agregar_Empleados(int id, string nombre, string pass)
        {
            string query = "INSERT INTO login VALUES (?id,?nombre,SHA1(?pass));";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.Add("?id", MySqlDbType.Int32, 11).Value = id;
            command.Parameters.Add("?nombre", MySqlDbType.VarChar, 20).Value = nombre;
            command.Parameters.Add("?pass", MySqlDbType.VarChar, 100).Value = pass;
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void agregar_Empleados(int idEmpleados, string Nombre, string Apellido_Paterno, string Apellido_Materno, string Domicilio, string Telefono)
        {
            string query = "INSERT INTO empleados VALUES (?idEmpleados,?Nombre,?Apellido_Paterno,?Apellido_Materno,?Domicilio,?Telefono)";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.Add("?idEmpleados", MySqlDbType.Int32, 11).Value = idEmpleados;
            command.Parameters.Add("?Nombre", MySqlDbType.VarChar, 45).Value = Nombre;
            command.Parameters.Add("?Apellido_Paterno", MySqlDbType.VarChar, 45).Value = Apellido_Paterno;
            command.Parameters.Add("?Apellido_Materno", MySqlDbType.VarChar, 45).Value = Apellido_Materno;
            command.Parameters.Add("?Domicilio", MySqlDbType.VarChar, 45).Value = Domicilio;
            command.Parameters.Add("?Telefono", MySqlDbType.VarChar, 20).Value = Telefono;
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void modificar_Empleados(int id_Empleados, string Nombre, string apellido_Paterno, string apellido_Materno, string Domicilio, string Telefono)
        {
            string query = "UPDATE empleados VALUES (?id_Empleados,?Nombre,?apellido_Paterno,?apellido_Materno,?Domicilio,?Telefono, SHA1(?Password));";
            query = "UPDATE  empleados SET  Nombre =  '" + Nombre + "',Apellido_Paterno =  '" + apellido_Paterno + "',Apellido_Materno =  '" + apellido_Materno + "',Telefono =  '" + Telefono + "',Domicilio =  '" + Domicilio + "' WHERE  idEmpleados =" + id_Empleados + ";";

            // MessageBox.Show(query);
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.Add("?id_Empleados", MySqlDbType.Int32, 11).Value = id_Empleados;
            command.Parameters.Add("?Nombre", MySqlDbType.VarChar, 45).Value = Nombre;
            command.Parameters.Add("?apellido_Paterno", MySqlDbType.VarChar, 45).Value = apellido_Paterno;
            command.Parameters.Add("?apellido_Materno", MySqlDbType.VarChar, 45).Value = apellido_Materno;
            command.Parameters.Add("?Domicilio", MySqlDbType.VarChar, 45).Value = Domicilio;
            command.Parameters.Add("?Telefono", MySqlDbType.VarChar, 20).Value = Telefono;
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void eliminar_Empleados(String idEmpleados)
        {
            string query = "DELETE from empleados WHERE idEmpleados = '" + idEmpleados + "';";
            MessageBox.Show(query);
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.Add("?idEmpleados", MySqlDbType.Int32, 11).Value = idEmpleados;
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();



        }

        public string comprobarEmpleados(String idEmpleados)
        {
            String query = "DETELE from count(nombre) FROM empleados where idEmpleados='" + idEmpleados + "';";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.Add("?idEmpleados", MySqlDbType.Int32, 11).Value = idEmpleados;
            Console.WriteLine(command.CommandText);
            MySqlDataReader reader;
            connection.Open();
            reader = command.ExecuteReader();
            reader.Read();
            String v = reader.GetString(0);
            MessageBox.Show("" + v);
            connection.Close();
            return v;


        }
        public string[] MostrarEmpleado(String cad)
        {

            string[] arreglo;
            string query = "SELECT * FROM Empleados where idEmpleados='" + cad + "';";
            MySqlCommand command = new MySqlCommand(query, connection);
            Console.WriteLine(command.CommandText);
            MySqlDataReader reader;
            connection.Open();
            reader = command.ExecuteReader();
            int n = reader.FieldCount;
            arreglo = new string[n];
            for (int i = 0; i < n; i++)
            {
                reader.Read();
                arreglo[i] = reader.GetString(i);
            }
            connection.Close();
            return arreglo;
        }
        public void agregar_Clientes(int id_Clientes, string Nombre, string Apellido_Paterno, string Apellido_Materno, string Domicilio, string Telefono)
        {

            string query = "INSERT INTO clientes VALUES (?idClientes,?Nombre,?Apellido_Paterno,?Apellido_Materno,?Domicilio,?Telefono)";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.Add("?idClientes", MySqlDbType.Int32, 11).Value = id_Clientes;
            command.Parameters.Add("?Nombre", MySqlDbType.VarChar, 45).Value = Nombre;
            command.Parameters.Add("?Apellido_Paterno", MySqlDbType.VarChar, 45).Value = Apellido_Paterno;
            command.Parameters.Add("?Apellido_Materno", MySqlDbType.VarChar, 45).Value = Apellido_Materno;
            command.Parameters.Add("?Domicilio", MySqlDbType.VarChar, 45).Value = Domicilio;
            command.Parameters.Add("?Telefono", MySqlDbType.VarChar, 20).Value = Telefono;
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();


        }
        /* public void agregar_Clientes2(int id_Clientes)
        {
            string query = "INSERT INTO clientes VALUES (?idClientes)";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.Add("?idClientes", MySqlDbType.Int32, 11).Value = id_Clientes;
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }*/
        public void modificar_Clientes(int idClientes, string Nombre, string Apellido_Paterno, string Apellido_Materno, string Domicilio, string Telefono)
        {
            string query = "UPDATE clientes VALUES (?id_Clientes,?Nombre,?Apellido_Paterno,?Apellido_Materno,?Domicilio,?Telefono";
            query = "UPDATE  clientes SET  Nombre =  '" + Nombre + "',Apellido_Paterno =  '" + Apellido_Paterno + "',Apellido_Materno =  '" + Apellido_Materno + "',Telefono =  '" + Telefono + "',Domicilio =  '" + Domicilio + "' WHERE  idClientes =" + idClientes + ";";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.Add("?id_Empleados", MySqlDbType.Int32, 11).Value = idClientes;
            command.Parameters.Add("?Nombre", MySqlDbType.VarChar, 45).Value = Nombre;
            command.Parameters.Add("?Apellido_Paterno", MySqlDbType.VarChar, 45).Value = Apellido_Paterno;
            command.Parameters.Add("?Apellido_Materno", MySqlDbType.VarChar, 45).Value = Apellido_Materno;
            command.Parameters.Add("?Domicilio", MySqlDbType.VarChar, 45).Value = Domicilio;
            command.Parameters.Add("?Telefono", MySqlDbType.VarChar, 20).Value = Telefono;
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void eliminar_Clientes(String idClientes)
        {
            string query = "DELETE from clientes WHERE idClientes = '" + idClientes + "';";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.Add("?idClientes", MySqlDbType.Int32, 11).Value = idClientes;
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();


        }
        public string comprobarClientes(String idClientes)
        {
            String query = "DETELE from count(nombre) FROM clientes where idEmpleados='" + idClientes + "';";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.Add("?idClientes", MySqlDbType.Int32, 11).Value = idClientes;
            Console.WriteLine(command.CommandText);
            MySqlDataReader reader;
            connection.Open();
            reader = command.ExecuteReader();
            reader.Read();
            String v = reader.GetString(0);
            MessageBox.Show("" + v);
            connection.Close();
            return v;


        }
        public void agregar_Sucursal(int idPizzeria, string Direccion, string Telefono)
        {
            string query = "INSERT INTO sucursal VALUES (?idPizzeria,?Direccion,?Telefono)";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.Add("?idPizzeria", MySqlDbType.Int32, 11).Value = idPizzeria;
            command.Parameters.Add("?Direccion", MySqlDbType.VarChar, 45).Value = Direccion;
            command.Parameters.Add("?Telefono", MySqlDbType.VarChar, 20).Value = Telefono;
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void modificar_Sucursal(int idPizzeria, string Direccion, string Telefono)
        {
            string query = "UPDATE INTO sucursal VALUES (?idPizzeria,?Direccion,?Telefono)";
            query = "UPDATE  sucursal SET  Direccion = '" + Direccion + "',Telefono =  '" + Telefono + "' WHERE  idPizzeria =" + idPizzeria + ";";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.Add("?idPizzeria", MySqlDbType.Int32, 11).Value = idPizzeria;
            command.Parameters.Add("?Direccion", MySqlDbType.VarChar, 45).Value = Direccion;
            command.Parameters.Add("?Telefono", MySqlDbType.VarChar, 20).Value = Telefono;
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void eliminar_Sucursal(String idPizzeria)
        {
            string query = "DELETE from sucursal WHERE idPizzeria = '" + idPizzeria + "';";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.Add("?idPizzeria", MySqlDbType.Int32, 11).Value = idPizzeria;
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();


        }
        public void agregar_Paquetes(string idPaquetes, string Categoria, string Nombre, string Precio)
        {
            string query = "INSERT INTO Paquetes VALUES (?idPaquetes,?Categoria,?Precio)";
            query = "INSERT INTO paquetes ( idPaquetes ,Categoria ,Nombre ,Precio )VALUES ( '" + idPaquetes + "', '" + Categoria + "', '" + Nombre + "', '" + Precio + "');";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.Add("?idPaquetes", MySqlDbType.Int32, 11).Value = idPaquetes;
            command.Parameters.Add("?Categoria", MySqlDbType.VarChar, 45).Value = Categoria;
            command.Parameters.Add("?Nombre", MySqlDbType.VarChar, 20).Value = Nombre;
            command.Parameters.Add("?Precio", MySqlDbType.VarChar, 20).Value = Precio;
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void modificar_Paquetes(int idPaquetes, string Categoria, string Nombre, string Precio)
        {
            string query = "UPDATE INTO Paquetes VALUES (?idPaquetes,?Categoria,?Precio)";
            query = "UPDATE  paquetes SET  Categoria = '" + Categoria + "',Nombre = '" + Nombre + "',Precio =  '" + Precio + "' WHERE  idPaquetes =" + idPaquetes + ";";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.Add("?idPaquetes", MySqlDbType.Int32, 11).Value = idPaquetes;
            command.Parameters.Add("?Categoria", MySqlDbType.VarChar, 45).Value = Categoria;
            command.Parameters.Add("?Nombre", MySqlDbType.VarChar, 20).Value = Nombre;
            command.Parameters.Add("?Precio", MySqlDbType.VarChar, 20).Value = Precio;
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void eliminar_Paquetes(String idPaquetes)
        {
            string query = "DELETE from Paquetes WHERE idPaquetes = '" + idPaquetes + "';";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.Add("?idPaquetes", MySqlDbType.Int32, 11).Value = idPaquetes;
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();


        }

        public string[] fechaActual()
        {

            string[] arreglo;
            string query = "SELECT CURDATE();";
            MySqlCommand command = new MySqlCommand(query, connection);
            Console.WriteLine(command.CommandText);
            MySqlDataReader reader;
            connection.Open();
            reader = command.ExecuteReader();
            int n = reader.FieldCount;
            arreglo = new string[n];
            for (int i = 0; i < n; i++)
            {
                reader.Read();
                arreglo[i] = reader.GetString(i);
            }
            connection.Close();
            return arreglo;
        }
        public void agregar_Ventas(string idCliente, string paquetes, string total,string fecha)
        {
            string query = "INSERT INTO ventas VALUES (?idVenta,?idCliente,?paquetes,?total,?fecha)";
            query = "INSERT INTO ventas ( idVenta ,idCliente ,paquetes ,total, fecha )VALUES ( NULL, '" + idCliente + "', '" + paquetes + "', '" + total + "', '" + fecha + "');";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.Add("?idCliente", MySqlDbType.VarChar, 45).Value = idCliente;
            command.Parameters.Add("?paquetes", MySqlDbType.VarChar, 20).Value = paquetes;
            command.Parameters.Add("?total", MySqlDbType.VarChar, 20).Value = total;
            command.Parameters.Add("?fecha", MySqlDbType.VarChar, 20).Value = fecha;
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
