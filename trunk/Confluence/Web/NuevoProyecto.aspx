<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="NuevoProyecto.aspx.vb" Inherits="NuevoProyecto" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1>Crear nuevo Proyecto:</h1>
<div id="inputform">
<label for="name">Nombre:</label>
<asp:TextBox ID="name" runat="server" />
<asp:RequiredFieldValidator ID="reqName" runat="server" ControlToValidate="name" ErrorMessage="* Nombre es requerido" /><br />
<label for="description">Descripcion:</label>
<asp:TextBox TextMode="multiline" ID="description" runat="server" />
<asp:RequiredFieldValidator ID="reqDescription" runat="server" ControlToValidate="description" ErrorMessage="* Descripcion es requerida" /><br />
<label for="language">Lenguaje:</label>
<asp:DropDownList ID="lang" runat="server" DataTextField="Name" DataValueField="Id" /><br />
<label for="endDate">Fin estimado:</label>
<asp:Calendar ID="end_cal" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" >
    <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
    <SelectorStyle BackColor="#CCCCCC" />
    <WeekendDayStyle BackColor="#FFFFCC" />
    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
    <OtherMonthDayStyle ForeColor="#808080" />
    <NextPrevStyle VerticalAlign="Bottom" />
    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
</asp:Calendar><br />
</div>

<asp:Button ID="Save" Text="Save" runat="server" OnClick="Save_Click" />
<asp:Button ID="Cancel" Text="Cancel" runat="server" CausesValidation="false" OnClick="Cancel_Click" />
</asp:Content>

