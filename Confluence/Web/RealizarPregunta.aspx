<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="RealizarPregunta.aspx.vb" Inherits="RealizarPregunta" title="Untitled Page" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1><asp:Label ID="h1" runat="server" meta:resourcekey="h1Resource1">Realizar Pregunta</asp:Label></h1>
<div id="inputform">
    <asp:HiddenField ID="pid" runat="server" /><br />
    <asp:label CssClass="label" runat="server" ID="Label1" meta:resourcekey="Label1Resource1">Nombre del Proyecto:</asp:label>
    <asp:Label ID="name" runat="server" meta:resourcekey="nameResource1" /><br />
    <asp:label CssClass="label" runat="server" ID="Label2" meta:resourcekey="Label2Resource1">Pregunta:</asp:label>
    <asp:TextBox runat="server" ID="question" TextMode="MultiLine" meta:resourcekey="questionResource1" />
    <asp:RequiredFieldValidator ID="reqQuestion" runat="server" ControlToValidate="question" ErrorMessage="* Pregunta es requerido" meta:resourcekey="reqQuestionResource1" /><br />
</div>
<asp:Button ID="Ask" runat="Server" Text="Preguntar" OnClick="Ask_Click" meta:resourcekey="AskResource1" />
<asp:Button ID="Cancel" runat="Server" Text="Cancelar" CausesValidation="False" OnClick="Cancel_Click" meta:resourcekey="CancelResource1" />
</asp:Content>

