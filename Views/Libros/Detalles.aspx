<%@ Page Title="Detalle Libro" Language="C#" MasterPageFile= "~/Views/Shared/Site.master" AutoEventWireup="true" CodeBehind="Detalles.aspx.cs" Inherits="BibliotecaMVC.Views.Libros.Detalles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent"
runat="server">
<h1>Detalles del Libro</h1>
<asp:Label runat="server" Text="Codigo:" />
<asp:Label ID="lblCodigo" runat="server" />
<br />
<asp:Label runat="server" Text="Titulo:" />
<asp:Label ID="lblTitulo" runat="server" />
<br />
<asp:Label runat="server" Text="Autor:" />
<asp:Label ID="lblAutor" runat="server" />
</asp:Content>