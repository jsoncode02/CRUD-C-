using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Productos
    {
        private CDconexion conexion = new CDconexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar()
        {
            comando.Connection = conexion.AbrirConexion();

            comando.CommandText = "MostrarProductos";

            comando.CommandType = CommandType.StoredProcedure;

            leer = comando.ExecuteReader();

            tabla.Load(leer);

            conexion.CerrarConexion();

            return tabla;
        }

        public void Insertar (string nombre, string desc, string marca, double precio, int stock)
        {
            comando.Connection = conexion.AbrirConexion();

            comando.CommandText = "InsertarProductos";

            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@nombre", nombre);

            comando.Parameters.AddWithValue("@descrip", desc);

            comando.Parameters.AddWithValue("@Marca", marca);

            comando.Parameters.AddWithValue("@precio", precio);

            comando.Parameters.AddWithValue("@stock", stock);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();

            conexion.CerrarConexion();
        }

        public void Editar(string nombre, string desc, string marca, double precio, int stock, int id)
        {
            comando.Connection = conexion.AbrirConexion();

            comando.CommandText = "EditarProductos";

            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@nombre", nombre);

            comando.Parameters.AddWithValue("@descrip", desc);

            comando.Parameters.AddWithValue("@Marca", marca);

            comando.Parameters.AddWithValue("@precio", precio);

            comando.Parameters.AddWithValue("@stock", precio);

            comando.Parameters.AddWithValue("@id", id);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();

            conexion.CerrarConexion();
        }

        public void Eliminar(int id)
        {
            comando.Connection = conexion.AbrirConexion();

            comando.CommandText = "EliminarProducto";

            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@idproc", id);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();

            conexion.CerrarConexion();
        }
    }
}
