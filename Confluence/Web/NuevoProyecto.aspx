<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="NuevoProyecto.aspx.vb" Inherits="NuevoProyecto" title="Untitled Page" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1><asp:Label ID="h1" runat="server" meta:resourcekey="h1Resource1">Crear Nuevo Proyecto</asp:Label></h1>
<div id="inputform">
<asp:label CssClass="label" runat="server" ID="Label1" meta:resourcekey="Label1Resource1">Nombre:</asp:label>
<asp:TextBox ID="name" runat="server" meta:resourcekey="nameResource1" />
<asp:RequiredFieldValidator ID="reqName" runat="server" ControlToValidate="name" ErrorMessage="* Nombre es requerido" meta:resourcekey="reqNameResource1" /><br />
<asp:label CssClass="label" runat="server" ID="Label2" meta:resourcekey="Label2Resource1">Descripcion:</asp:label>
<asp:TextBox TextMode="MultiLine" ID="description" runat="server" meta:resourcekey="descriptionResource1" />
<asp:RequiredFieldValidator ID="reqDescription" runat="server" ControlToValidate="description" ErrorMessage="* Descripcion es requerida" meta:resourcekey="reqDescriptionResource1" /><br />
<asp:label CssClass="label" runat="server" ID="Label3" meta:resourcekey="Label3Resource1">Lenguaje:</asp:label>
<asp:DropDownList ID="lang" runat="server" DataTextField="Name" DataValueField="Id" meta:resourcekey="langResource1" /><br />
<asp:label CssClass="label" runat="server" ID="Label4" meta:resourcekey="Label4Resource1">Fin Estimado:</asp:label>
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

<asp:Button ID="Save" Text="Save" runat="server" OnClick="Save_Click" meta:resourcekey="SaveResource1" />
<asp:Button ID="Cancel" Text="Cancel" runat="server" CausesValidation="False" OnClick="Cancel_Click" meta:resourcekey="CancelResource1" />
</asp:Content>

