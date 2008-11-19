<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="DeliveryDates.aspx.vb" Inherits="DeliveryDates" title="Untitled Page" %>
<%@ Import Namespace="Confluence.Domain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1>Fechas de Entrega:</h1>
<div id="delivery_dates">
<%  For Each p As Project In Projects%>
    <div class="entry">
        <h2><%= p.Name %></h2>
        Fecha de Entrega:<span class="date"><%=p.End.ToShortDateString()%></span>
    </div>
<%  Next p%>
</div>
</asp:Content>

