using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaMVC.Controllers;
using BibliotecaMVC.Models;

namespace BibliotecaMVC.Views.Libros
{
    public partial class Registrar : System.Web.UI.Page
    {
        private readonly Bookcontroller _controller = new Bookcontroller();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                // 1) Construimos el modelo libro desde los textbox 
                var libro = new Libro
                {
                    Codigo = txtCodigo.Text.Trim(),  
                    Titulo = txtTitulo.Text.Trim(),
                    Autor = txtAutor.Text.Trim(), 
                    FechaPublicacion = DateTime.Parse(txtFecha.Text.Trim()), 
                };

                // 2) Llamamos a la “acción” del controlador para registrar 
                _controller.Registrar(libro); // Intenta registrar 

                string mensaje = _controller.Registrar(libro);// obtiene el mensaje de resultado
                lblMensaje.Text = mensaje;// muestra el mensaje en la etiqueta
                lblMensaje.ForeColor = mensaje.StartsWith("Errores") ? System.Drawing.Color.DarkRed : System.Drawing.Color.Green;// da rojo si es error, verde si es exito

                // 4) Limpiamos campos 
                txtCodigo.Text = txtTitulo.Text = txtAutor.Text =
                txtFecha.Text = string.Empty;

            }
            catch (Exception ex)
            {
                // Si algo falla generamos un mensaje de color rojo
                lblMensaje.Text = "Error: " + ex.Message; 
                lblMensaje.ForeColor = System.Drawing.Color.DarkRed; 
            }
        }
    }
}
