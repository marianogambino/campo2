<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="RealizarOferta.aspx.vb" Inherits="RealizarOferta" title="Untitled Page" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1><asp:Label ID="h1" runat="server" meta:resourcekey="h1Resource1">Realizar Oferta</asp:Label></h1>
<div id="inputform">
    <asp:HiddenField ID="pid" runat="server" /><br />
    <asp:label CssClass="label" runat="server" ID="Label1" meta:resourcekey="Label1Resource1">Monto:</asp:label>
    <asp:TextBox ID="amount" runat="server" meta:resourcekey="amountResource1" />
    <asp:RequiredFieldValidator ID="reqAmount" runat="server" ControlToValidate="amount" ErrorMessage="* Monto es requerido"  Display="Dynamic" meta:resourcekey="reqAmountResource1"/>
    <asp:CompareValidator ID="cmpAmount" runat="server" ControlToValidate="amount" ErrorMessage="* Monto debe ser numerico" Type="Double" Display="Dynamic" meta:resourcekey="cmpAmountResource1" /><br />
    <asp:label CssClass="label" runat="server" ID="Label2" meta:resourcekey="Label2Resource1">Fecha de Entrega:</asp:label>
    <asp:Calendar ID="release_date" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" meta:resourcekey="release_dateResource1" >
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
<asp:Button ID="Offer" runat="server" Text="Ofertar" OnClick="Offer_Click" meta:resourcekey="OfferResource1" />
<asp:Button ID="Cancel" runat="server" Text="Cancelar" OnClick="Cancel_Click" CausesValidation="False" meta:resourcekey="CancelResource1" />
</asp:Content>

