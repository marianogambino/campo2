<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AskQuestion.aspx.cs" Inherits="AskQuestion" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1>Realizar Pregunta:</h1>
<div id="inputform">
    <asp:HiddenField ID="pid" runat="server" /><br />
    <label for="name">Nombre del Proyecto:</label>
    <asp:Label ID="name" runat="server" /><br />
    <label for="question">Pregunta:</label>
    <asp:TextBox runat="server" ID="question" TextMode="multiLine" />
    <asp:RequiredFieldValidator ID="reqQuestion" runat="server" ControlToValidate="question" ErrorMessage="* Pregunta es requerido" /><br />
</div>
<asp:Button ID="Ask" runat="Server" Text="Preguntar" OnClick="Ask_Click" />
<asp:Button ID="Cancel" runat="Server" Text="Cancelar" CausesValidation="false" OnClick="Cancel_Click" />
</asp:Content>


