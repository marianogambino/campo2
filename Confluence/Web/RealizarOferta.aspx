<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="RealizarOferta.aspx.vb" Inherits="RealizarOferta" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1>Realizar oferta:</h1>
<div id="inputform">
    <asp:HiddenField ID="pid" runat="server" /><br />
    <label for="amount">Monto:</label>
    <asp:TextBox ID="amount" runat="server" />
    <asp:RequiredFieldValidator ID="reqAmount" runat="server" ControlToValidate="amount" ErrorMessage="* Monto es requerido"  Display="dynamic"/>
    <asp:CompareValidator ID="cmpAmount" runat="server" ControlToValidate="amount" ErrorMessage="* Monto debe ser numerico" Type="Double" Display="dynamic" /><br />
    <label for="release_date">Fecha de Entrega:</label>
    <asp:Calendar ID="release_date" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" >
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
<asp:Button ID="Offer" runat="server" Text="Ofertar" OnClick="Offer_Click" />
<asp:Button ID="Cancel" runat="server" Text="Cancelar" OnClick="Cancel_Click" CausesValidation="false" />
</asp:Content>

