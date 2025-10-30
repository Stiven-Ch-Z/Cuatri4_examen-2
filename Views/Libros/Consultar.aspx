<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile= "~/Views/Shared/Site.master" CodeBehind="Consultar.aspx.cs" Inherits="BibliotecaMVC.Views.Libros.Consultar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    
    <h2>Consultar Libros</h2> <!-- Encabezado --> 
    <!-- Campo de filtro por placa --> 
    <hr />
    <asp:Label runat="server" AssociatedControlID="txtFiltro" Text="Filtrar por Codigo:" /> 
    <asp:TextBox ID="txtFiltro" runat="server" /> 

    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" CssClass="btn" /> 
    <asp:Button ID="btnRefrescar" runat="server" Text="Ver todos" OnClick="btnRefrescar_Click" CssClass="btn" />
 
    <br /><br /> 
 
    <!-- GridView para mostrar los autos --> 
    <asp:GridView ID="gvLibros" runat="server" AutoGenerateColumns="false" CssClass="gv" OnRowCommand="gvLibros_RowCommand"> 
        <Columns> 
            <asp:BoundField DataField="Codigo" HeaderText="Codigo" /> 
            <asp:BoundField DataField="Titulo" HeaderText="Titulo" /> 
            <asp:BoundField DataField="Autor" HeaderText="Autor" /> 
            <asp:BoundField DataField="FechaPublicacion" HeaderText="Fecha de Publicacion" DataFormatString="{0:yyyy-MM-dd}" /> 
            <asp:HyperLinkField HeaderText="Detalles del Libro" Text="Ver" DataNavigateUrlFields="Codigo" DataNavigateUrlFormatString="~/Libros/detalles/{0}" />
             <asp:TemplateField HeaderText="Eliminar Libro">
            <ItemTemplate>
                <asp:Button ID="btnEliminar" runat="server" 
                    Text="Eliminar" 
                    CommandName="EliminarLibro"
                    CommandArgument='<%# Eval("Codigo") %>'
                    OnClientClick="return confirm('¿Desea eliminar este libro?');" />
            </ItemTemplate>
        </asp:TemplateField>
        </Columns> 
    </asp:GridView> 
<br />
<asp:Label ID="lblMensaje" runat="server" CssClass="lbl" ForeColor="DarkRed"></asp:Label>

</asp:Content> 

