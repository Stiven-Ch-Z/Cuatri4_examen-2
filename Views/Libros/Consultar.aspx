<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile= "~/Views/Shared/Site.master" CodeBehind="Consultar.aspx.cs" Inherits="BibliotecaMVC.Views.Libros.Consultar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    
    <h2>Consultar Libros</h2> <!-- Encabezado --> 
    <!-- Campo de filtro por placa --> 
    <asp:Label runat="server" AssociatedControlID="txtFiltro" Text="Filtrar por Codigo:" /> 
    <asp:TextBox ID="txtFiltro" runat="server" /> 

    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" CssClass="btn" /> 
    <asp:Button ID="btnRefrescar" runat="server" Text="Ver todos" OnClick="btnRefrescar_Click" CssClass="btn" />
    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" CssClass="btn" />
 
    <br /><br /> 
 
    <!-- GridView para mostrar los autos --> 
    <asp:GridView ID="gvLibros" runat="server" AutoGenerateColumns="false" CssClass="gv"> 
        <Columns> 
            <asp:BoundField DataField="Codigo" HeaderText="Codigo" /> 
            <asp:BoundField DataField="Titulo" HeaderText="Titulo" /> 
            <asp:BoundField DataField="Autor" HeaderText="Autor" /> 
            <asp:BoundField DataField="FechaIngreso" HeaderText="Fecha Ingreso" DataFormatString="{0:yyyy-MM-dd}" /> 
        </Columns> 
    </asp:GridView> 
   <script src="<%= ResolveUrl("~/JS/consulta.js") %>"></script>
</asp:Content> 
