<%@ Page Title="Detalle Libro" Language="C#" MasterPageFile= "~/Views/Shared/Site.master" AutoEventWireup="true" CodeBehind="Detalles.aspx.cs" Inherits="BibliotecaMVC.Views.Libros.Detalles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent"
runat="server">
<h2>Detalles del Libro</h2>
<br /><br />
    <hr />
    <div class="detalle">
        <asp:Label runat="server" Text="Codigo:" />
        <asp:Label ID="lblCodigo" runat="server" />
        <br /><br /><br />
        <asp:Label runat="server" Text="Titulo:" />
        <asp:Label ID="lblTitulo" runat="server" />
        <br /><br /><br />
        <asp:Label runat="server" Text="Autor:" />
        <asp:Label ID="lblAutor" runat="server" />
    </div>
</asp:Content>