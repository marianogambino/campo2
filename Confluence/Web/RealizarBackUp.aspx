<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="RealizarBackUp.aspx.vb" Inherits="RealizarBackUp" title="Untitled Page" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1><asp:Label ID="h1" runat="server" meta:resourcekey="h1Resource1" Text="Copia de Seguridad"></asp:Label></h1>
<div id="inputform">
<asp:label CssClass="label" runat="server" ID="Label1" meta:resourcekey="Label1Resource1" Text="Tipo:"></asp:label>
<asp:DropDownList ID="backuptype" runat="server" meta:resourcekey="backuptypeResource1">
    <asp:ListItem Text="Completo" Value="C" meta:resourcekey="ListItemResource1" />
    <asp:ListItem Text="Diferencial" Value="D" meta:resourcekey="ListItemResource2" />
</asp:DropDownList><br />
<asp:label CssClass="label" runat="server" ID="Label2" meta:resourcekey="Label2Resource1">Cuando Realizarlo:</asp:label>
<asp:DropDownList id="date_list" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ChangeType" meta:resourcekey="date_listResource1" >
    <asp:ListItem Text="Ahora" Value="A" meta:resourcekey="ListItemResource3" />
    <asp:ListItem Text="Mas Adelante" Value="B" meta:resourcekey="ListItemResource4" />
</asp:DropDownList><br />
<asp:Panel ID="backup_date" runat="server" meta:resourcekey="backup_dateResource1">
    <asp:label CssClass="label" runat="server" ID="Label4" meta:resourcekey="Label4Resource1" >Fecha Backup:</asp:label>
    <asp:Calendar ID="schedule_date" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" meta:resourcekey="schedule_dateResource1" >
        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
        <SelectorStyle BackColor="#CCCCCC" />
        <WeekendDayStyle BackColor="#FFFFCC" />
        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
        <OtherMonthDayStyle ForeColor="Gray" />
        <NextPrevStyle VerticalAlign="Bottom" />
        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
    </asp:Calendar><br />
</asp:Panel>
</div>
<asp:Button ID="backupBtn" runat="server" OnClick="BackUp_Click" Text="Backup" meta:resourcekey="backupBtnResource1" /><br />
</asp:Content>

