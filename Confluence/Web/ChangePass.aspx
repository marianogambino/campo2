<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ChangePass.aspx.cs" Inherits="ChangePass" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1>Cambio de Contraseña</h1>
<div id="inputform">
<label for="username">Nombre:</label>
<asp:Label ID="username" runat="server" /><br />
<label for="oldpass">Contraseña anterior:</label>
<asp:TextBox ID="oldpass" runat="server" TextMode="password" />
<asp:RequiredFieldValidator ID="reqOldPass" runat="server" ControlToValidate="oldpass" ErrorMessage="* Contraseña anterior es requerida" /><br />
<label for="newpass">Contraseña nueva:</label>
<asp:TextBox ID="newpass" runat="server" TextMode="password" />
<asp:RequiredFieldValidator ID="reqNewpass" runat="server" ControlToValidate="newpass" ErrorMessage="* Contraseña nueva es requerida" /><br />
<label for="oldpass">Repetir Contraseña nueva:</label>
<asp:TextBox ID="rnewpass" runat="server" TextMode="password" />
<asp:RequiredFieldValidator ID="rRnewpass" runat="server" ControlToValidate="rnewpass" ErrorMessage="* Contraseña nueva es requerida" Display="dynamic" />
<asp:CompareValidator ID="cmpRnewpass" runat="server" ControlToValidate="rnewpass" ControlToCompare="newpass" Type="string" ErrorMessage="* Las contraseñas no coinciden" Display="dynamic" /><br />
</div>
<asp:Button ID="Cancel" runat="server" Text="Cancel" CausesValidation="false" OnClick="Cancel_Click" />
<asp:Button ID="Accept" runat="server" Text="Cambiar" OnClick="Accept_Click" />
</asp:Content>

