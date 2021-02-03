using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaLogica;

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        CL_Productos objetoCL = new CL_Productos();

        private string idProducto = null;
        private bool Editar = false;
        public bool vacio = false;
        public bool resultado = false;

        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e) //Editar
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;
                txtNombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();

                txtMarca.Text = dataGridView1.CurrentRow.Cells["Marca"].Value.ToString();

                txtDesc.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();

                txtPrecio.Text = dataGridView1.CurrentRow.Cells["Precio"].Value.ToString();

                txtStock.Text = dataGridView1.CurrentRow.Cells["Stock"].Value.ToString();

                idProducto = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione un fila por favor");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarProductos();
        }

        private void MostrarProductos()
        {
            try
            {
                CL_Productos objeto = new CL_Productos();
                dataGridView1.DataSource = objeto.MostrarProd();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //INSERTAR
            if (Editar == false)

                try
                {
                    if (Validar(this) == true)
                    {
                        MessageBox.Show("Favor llenar todos los campos");
                    }
                    else
                    {
                        objetoCL.InsertarProd(txtNombre.Text, txtDesc.Text, txtMarca.Text, txtPrecio.Text, txtStock.Text);
                        MessageBox.Show("Se guardó correctamente");

                        MostrarProductos();

                        limpiarForm();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar los datos: " + ex);
                }

            //EDITAR
            if (Editar == true)
            {
                try
                {
                    objetoCL.EditarProd(txtNombre.Text, txtDesc.Text, txtMarca.Text, txtPrecio.Text, txtStock.Text, idProducto);
                    MessageBox.Show("Se edito correctamente");
                    MostrarProductos();
                    limpiarForm();
                    Editar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("no se pudo editar los datos por: " + ex);
                }
            }
        }

        private void limpiarForm()
        {
            txtDesc.Clear();
            txtMarca.Clear();
            txtNombre.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idProducto = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                objetoCL.EliminarPRod(idProducto);

                MessageBox.Show("Eliminado correctamente");

                MostrarProductos();
            }
            else
            {
                MessageBox.Show("Seleccione un fila por favor");
            }
        }

        private bool Validar(Form formulario)
        {
            foreach (Control oControls in formulario.Controls) 
            {
                if (oControls is TextBox & oControls.Text == String.Empty) 
                {
                    vacio = true;
                }
            }
            if (vacio == true)
            {
                resultado = true;
                vacio = false;
            }
            else
            {
                resultado = false;
            }
            return resultado;
            
        }
    }
}
