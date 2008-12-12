<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="DeliveryDates.aspx.vb" Inherits="DeliveryDates" title="Untitled Page" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
<%@ Import Namespace="Confluence.Domain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1><asp:Label ID="h1" runat="server" meta:resourcekey="h1Resource1">Fechas de Entrega:</asp:Label></h1>
<div id="delivery_dates">
<%  For Each p As Project In Projects%>
    <div class="entry">
        <h2><%= p.Name %></h2>
        <asp:label runat="server" ID="date_lbl" meta:resourcekey="date_lblResource1">Fecha de Entrega:</asp:label><span class="date"><%=p.End.ToShortDateString()%></span>
    </div>
<%  Next p%>
</div>
</asp:Content>

