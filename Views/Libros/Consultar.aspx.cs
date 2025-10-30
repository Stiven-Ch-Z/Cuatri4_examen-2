using BibliotecaMVC.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BibliotecaMVC.Views.Libros
{
    public partial class Consultar : System.Web.UI.Page
    {
        private readonly Bookcontroller _controller = new Bookcontroller();
        // Instancia Controlador 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // al cargar la pagina por primera vez
            {
                CargarLibros(); // Cargamos todos los libros cuando se carga la pagina
            }
        }

        private void CargarLibros(string filtroCodigo = null) // Método auxiliar 
        {
            var lista = _controller.Listar(filtroCodigo); // Pedimos datos al “controlador” 
            gvLibros.DataSource = lista; // Asignamos al GridView 
            gvLibros.DataBind(); // Enlazamos datos 
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarLibros(txtFiltro.Text.Trim()); // Cargar filtrando por codigo
        }

        protected void btnRefrescar_Click(object sender, EventArgs e)
        {
            txtFiltro.Text = string.Empty; // Limpiamos filtro 
            CargarLibros(); // y se recargan los datos
        }
        protected void gvLibros_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EliminarLibro")
            {
                string codigo = e.CommandArgument.ToString(); //es el código del libro a eliminar
                string mensaje = _controller.Eliminar(codigo);// llamamos al controlador para eliminar

                lblMensaje.Text = mensaje; //nos dara el mensaje de exito o error
                CargarLibros(); // se refresca la tabla después de eliminar
            }
        }
    }
}