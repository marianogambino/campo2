<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProjectDetails.aspx.cs" Inherits="ProjectDetails" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1>Detalles de Proyecto:</h1>
<div id="inputform">
<asp:HiddenField ID="pid" runat="server" /><br />
<label for="name">Nombre:</label>
<asp:TextBox ID="name" runat="server" />
<asp:RequiredFieldValidator ID="reqName" runat="server" ControlToValidate="name" ErrorMessage="* Nombre es requerido" /><br />
<label for="description">Descripcion:</label>
<asp:TextBox ID="description" runat="server" /><br />
<label for="language">Lenguaje:</label>
<asp:DropDownList ID="lang" runat="server" DataTextField="Name" DataValueField="Id" /><br />
<label for="endDate">Fin estimado:</label>
<asp:Calendar ID="end" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" >
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
<asp:Button ID="Editar" runat="server" Text="Editar" OnClick="Editar_Proyecto" />

</asp:Content>

