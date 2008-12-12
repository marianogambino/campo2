<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ResourceDetail.aspx.vb" Inherits="ResourceDetail" title="Untitled Page" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
<%@ Import Namespace="Confluence.Domain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1><asp:Label ID="h1" runat="server" meta:resourcekey="h1Resource1">Detalles del Recurso</asp:Label></h1>
<div id="inputform">
    <asp:HiddenField ID="rid" runat="server" /><br />
    <asp:label CssClass="label" runat="server" ID="Label1" meta:resourcekey="Label1Resource1">Nombre:</asp:label>
    <asp:Label ID="name" runat="server" meta:resourcekey="nameResource1"></asp:Label><br />
    <asp:label CssClass="label" runat="server" ID="Label2" meta:resourcekey="Label2Resource1">Pais:</asp:label>
    <asp:Label ID="country" runat="server" meta:resourcekey="countryResource1"></asp:Label><br />
    <asp:label CssClass="label" runat="server" ID="Label3" meta:resourcekey="Label3Resource1">Estado:</asp:label>
    <asp:Label ID="state" runat="server" meta:resourcekey="stateResource1"></asp:Label><br />
    <table border="0">
    <tr>
        <td valign="top"><asp:label CssClass="label" runat="server" ID="Label4" style="text-decoration:underline;" meta:resourcekey="Label4Resource1"><b>Estudios:</b></asp:label></td>
        <td>
            <dl>
                <% If (SelectedResource.Study.Count > 0) Then %>
                    <% For Each study As Study In SelectedResource.Study%>
                       <dt>Lugar:<%=study.Institute%></dt><dd>Nivel: <%=study.StringLevel %></dd>
                       <dd>Desde: <%=study.YearStart %></dd>
                       <dd>Hasta: <%=study.YearEnd %></dd>
                    <% Next%>
                <% Else %>
                    <dt> <asp:label runat="server" ID="Label5" meta:resourcekey="Label5Resource1">Ninguno</asp:label> </dt>
                <% End If %>
            </dl>
        </td>
    </tr>
    <tr>
        <td valign="top"><asp:label CssClass="label" runat="server" ID="Label6" style="text-decoration:underline;" meta:resourcekey="Label6Resource1"><b>Exp. Laboral:</b></asp:label></td>
        <td>
            <dl>
                <% If (SelectedResource.WorkXP.Count > 0) Then %>
                    <% For Each work As WorkXP In SelectedResource.WorkXP%>
                        <dt>Lugar: <%=work.Place%></dt>
                        <dd>Desde: <%=work.YearStart %></dd>
                        <dd>Hasta: <%=work.YearEnd %></dd>
                    <% Next %>
                <% Else %>
                    <dt> <asp:label runat="server" ID="Label7" meta:resourcekey="Label7Resource1">Ninguna</asp:label> </dt>
                <% End If %>
            </dl>
        </td>
    </tr>
    </table>

</div>
    <asp:Button ID="MakeOffer" runat="server" Text="Realizar Oferta" OnClick="Make_Offer" meta:resourcekey="MakeOfferResource1" />
<asp:Button ID="Cancel" runat="server" Text="Cancelar" OnClick="Cancel_Click" meta:resourcekey="CancelResource1" />
</asp:Content>

