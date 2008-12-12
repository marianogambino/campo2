<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ResponderPregunta.aspx.vb" Inherits="ResponderPregunta" title="Untitled Page" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1><asp:Label ID="h1" runat="server" meta:resourcekey="h1Resource1">Detalles de Pregunta</asp:Label></h1>
<asp:HiddenField ID="qid" runat="server" />
<asp:HiddenField ID="pid" runat="server" />
<div id="inputform">
<asp:label CssClass="label" runat="server" ID="Label1" meta:resourcekey="Label1Resource1">Pregunta:</asp:label>
<asp:TextBox ID="question" runat="server"  TextMode="MultiLine" Enabled="False" meta:resourcekey="questionResource1"/><br />
<asp:label CssClass="label" runat="server" ID="Label2" meta:resourcekey="Label2Resource1">Respuesta:</asp:label>
<asp:TextBox ID="answer" runat="server" TextMode="MultiLine" meta:resourcekey="answerResource1" />
<asp:RequiredFieldValidator ID="reqAnswer" runat="server" ControlToValidate="answer" ErrorMessage="* Respuesta es requerida" meta:resourcekey="reqAnswerResource1" /><br />
</div>
<asp:Button ID="Responder" runat="server" Text="Responder" OnClick="Responder_Click" meta:resourcekey="ResponderResource1" />
<asp:Button ID="Cancel" runat="server" Text="Cancelar" CausesValidation="False" OnClick="Cancel_Click" meta:resourcekey="CancelResource1" />
</asp:Content>

