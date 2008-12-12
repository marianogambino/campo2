<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="DetallesProyecto.aspx.vb" Inherits="DetallesProyecto" title="Untitled Page" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<script type="text/javascript">
    function confirmDelete(){
        return confirm("Desea realmente Borrar el Proyecto?");
    }
</script>
<h1><asp:Label ID="h1" runat="server" meta:resourcekey="h1Resource1">Detalles de Proyecto</asp:Label></h1>
<div id="inputform">
<asp:HiddenField ID="pid" runat="server" /><br />
<asp:label CssClass="label" runat="server" ID="Label1" meta:resourcekey="Label1Resource1">Nombre:</asp:label>
<asp:TextBox ID="name" runat="server" meta:resourcekey="nameResource1" />
<asp:RequiredFieldValidator ID="reqName" runat="server" ControlToValidate="name" ErrorMessage="* Nombre es requerido" meta:resourcekey="reqNameResource1" /><br />
<asp:label CssClass="label" runat="server" ID="Label2" meta:resourcekey="Label2Resource1">Descripcion:</asp:label>
<asp:TextBox ID="description" runat="server" meta:resourcekey="descriptionResource1" /><br />
<asp:label CssClass="label" runat="server" ID="Label3" meta:resourcekey="Label3Resource1">Estado:</asp:label>
<asp:TextBox ID="state" Enabled="False" runat="server" meta:resourcekey="stateResource1" /><br />
<asp:label CssClass="label" runat="server" ID="Label4" meta:resourcekey="Label4Resource1">Publicacion:</asp:label>
<asp:TextBox ID="publication" Enabled="False" runat="server" meta:resourcekey="publicationResource1" /><br />
<asp:label CssClass="label" runat="server" ID="Label5" meta:resourcekey="Label5Resource1">Lenguaje:</asp:label>
<asp:DropDownList ID="lang" runat="server" DataTextField="Name" DataValueField="Id" meta:resourcekey="langResource1" /><br />
<asp:label CssClass="label" runat="server" ID="Label6" meta:resourcekey="Label6Resource1">Fin Estimado:</asp:label>
<asp:Calendar ID="end_cal" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" meta:resourcekey="end_calResource1" >
    <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
    <SelectorStyle BackColor="#CCCCCC" />
    <WeekendDayStyle BackColor="#FFFFCC" />
    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
    <OtherMonthDayStyle ForeColor="Gray" />
    <NextPrevStyle VerticalAlign="Bottom" />
    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
</asp:Calendar><br />
</div>
<asp:Button ID="Editar" runat="server" Text="Editar" OnClick="Editar_Proyecto" meta:resourcekey="EditarResource1" />
<asp:Button ID="Eliminar" runat="server" Text="Eliminar" OnClientClick="return confirmDelete();" OnClick="Eliminar_Proyecto" meta:resourcekey="EliminarResource1" />
<asp:Button ID="Cancel" runat="server" Text="Cancel" OnClick="Cancel_Click" meta:resourcekey="CancelResource1" />
</asp:Content>

