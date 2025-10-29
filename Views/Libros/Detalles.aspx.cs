using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaMVC.Controllers;

namespace BibliotecaMVC.Views.Libros
{
    public partial class Detalles : System.Web.UI.Page
    {
        private readonly Bookcontroller _controller = new Bookcontroller();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            // placa viene de {placa} en la ruta
            var codigo = (string)Page.RouteData.Values["codigo"];
            var libro = _controller.ObtenerPorCodigo(codigo);
            if (libro == null)
            {
                lblCodigo.Text = "No encontrado";
                lblTitulo.Text = "-";
                lblAutor.Text = "-";
                return;
            }
            lblCodigo.Text = libro.Codigo;
            lblTitulo.Text = libro.Titulo;
            lblAutor.Text = libro.Autor;
        }
    }
}
        
    