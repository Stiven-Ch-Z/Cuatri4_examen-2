<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile= "~/Views/Shared/Site.master" Inherits="BibliotecaMVC.Views.Libros.Registrar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Contenido que se inyecta en el placeholder de la Master -->

    <h2>Registrar Libro</h2>
    <!-- Encabezado de la vista -->

    <!-- Campos de entrada para registrar un auto -->
    <asp:Label runat="server" AssociatedControlID="txtCodigo" Text="Codigo del libro:" />
    <asp:TextBox ID="txtCodigo" runat="server" />

    <asp:Label runat="server" AssociatedControlID="txtTitulo" Text="Titulo del libro:" />
    <asp:TextBox ID="txtTitulo" runat="server" />

    <asp:Label runat="server" AssociatedControlID="txtAutor" Text="Autor del libro:" />
    <asp:TextBox ID="txtAutor" runat="server" />

    <asp:Label runat="server" AssociatedControlID="txtFecha" Text="Fecha ingreso del libro (yyyy-mm-dd):" />
    <asp:TextBox ID="txtFecha" runat="server" />

    <br />
    <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" OnClick="btnRegistrar_Click" CssClass="btn" />
    <!-- Botón que ejecuta la acción de registro -->

    <br />
    <br />
    <asp:Label ID="lblMensaje" runat="server" />
    <!-- Etiqueta para mostrar mensajes de éxito o error -->
</asp:Content>

