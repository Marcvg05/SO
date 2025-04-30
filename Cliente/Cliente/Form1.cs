using System;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Cliente
{
    public partial class Form1 : Form
    {
        private TcpClient cliente;
        private NetworkStream stream;

        public Form1()
        {
            InitializeComponent();
        }

        private void Conectar_Click(object sender, EventArgs e)
        {
            try
            {
                cliente = new TcpClient("127.0.0.1", 12345); // Cambia la IP y el puerto según tu servidor
                stream = cliente.GetStream();
                MessageBox.Show("Conectado al servidor.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar: " + ex.Message);
            }
        }

        private void Desconectar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cliente != null)
                {
                    EnviarComando("LOGOUT");
                    stream.Close();
                    cliente.Close();
                    MessageBox.Show("Desconectado del servidor.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al desconectar: " + ex.Message);
            }
        }

        private void Enviar_Nombre_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = Nombre_txtbox.Text; // TextBox para ingresar el nombre
                EnviarComando($"LOGIN {nombre}");
                MessageBox.Show("Nombre enviado al servidor.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar el nombre: " + ex.Message);
            }
        }

        private void Saldo_Click(object sender, EventArgs e)
        {
            try
            {
                EnviarComando("SALDO");
                string respuesta = LeerRespuesta();
                Saldo_txtbox.Text = respuesta; // Mostrar el saldo en el TextBox
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar saldo: " + ex.Message);
            }
        }

        private void Ingresar_enviar_Click(object sender, EventArgs e)
        {
            try
            {
                string cantidad = Ingreso_txtbox.Text; // TextBox para ingresar la cantidad
                EnviarComando($"INGRESO {cantidad}");
                MessageBox.Show("Ingreso realizado.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar ingreso: " + ex.Message);
            }
        }

        private void Comision_Click(object sender, EventArgs e)
        {
            try
            {
                string cantidad = Comision_txtbox.Text; // TextBox para ingresar la cantidad de la comisión
                EnviarComando($"COMISION {cantidad}");
                string respuesta = LeerRespuesta();
                Notilabel.Text = "Respuesta del servidor: " + respuesta; // Mostrar la respuesta en el Label
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al aplicar comisión: " + ex.Message);
            }
        }

        private void EnviarComando(string comando)
        {
            if (stream != null && stream.CanWrite)
            {
                byte[] datos = Encoding.UTF8.GetBytes(comando + "\n");
                stream.Write(datos, 0, datos.Length);
            }
        }

        private string LeerRespuesta()
        {
            if (stream != null && stream.CanRead)
            {
                byte[] buffer = new byte[256];
                int bytesLeidos = stream.Read(buffer, 0, buffer.Length);
                return Encoding.UTF8.GetString(buffer, 0, bytesLeidos).Trim();
            }
            return string.Empty;
        }

        private void Cargo_Click(object sender, EventArgs e)
        {
            try
            {
                string cantidad = Cantidad_txtbox.Text; // TextBox para ingresar la cantidad
                string quien = Quien_txtbox.Text; // TextBox para ingresar el nombre del cliente

                if (string.IsNullOrWhiteSpace(cantidad) || string.IsNullOrWhiteSpace(quien))
                {
                    MessageBox.Show("Por favor, ingrese ambos valores: cantidad y cliente.");
                    return;
                }

                EnviarComando($"CARGO {quien} {cantidad}");
                string respuesta = LeerRespuesta();
                Notilabel.Text = "Respuesta del servidor: " + respuesta; // Mostrar la respuesta en el Label
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar el cargo: " + ex.Message);
            }
        }
    }
}
