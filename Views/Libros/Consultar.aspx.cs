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
            if (!IsPostBack) // Solo la primera vez 
            {
                CargarLibros(); // Cargamos todos los autos 
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
            CargarLibros(txtFiltro.Text.Trim()); // Cargar filtrando por placa
        }

        protected void btnRefrescar_Click(object sender, EventArgs e)
        {
            txtFiltro.Text = string.Empty; // Limpiamos filtro 
            CargarLibros(); // Cargamos todos 
        }
    }
}