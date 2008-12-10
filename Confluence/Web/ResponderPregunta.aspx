<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ResponderPregunta.aspx.vb" Inherits="ResponderPregunta" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1>Detalles de Pregunta:</h1>
<asp:HiddenField ID="qid" runat="server" />
<asp:HiddenField ID="pid" runat="server" />
<div id="inputform">
<label for="question">Pregunta:</label>
<asp:TextBox ID="question" runat="server"  TextMode="MultiLine" Enabled="false"/><br />
<label for="answer">Respuesta:</label>
<asp:TextBox ID="answer" runat="server" TextMode="MultiLine" />
<asp:RequiredFieldValidator ID="reqAnswer" runat="server" ControlToValidate="answer" ErrorMessage="* Respuesta es requerida" /><br />
</div>
<asp:Button ID="Responder" runat="server" Text="Responder" OnClick="Responder_Click" />
<asp:Button ID="Cancel" runat="server" Text="Cancelar" CausesValidation="false" OnClick="Cancel_Click" />
</asp:Content>

