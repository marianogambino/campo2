<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="CambiarPass.aspx.vb" Inherits="CambiarPass" title="Untitled Page" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1><asp:Label ID="h1" runat="server" meta:resourcekey="h1Resource1">Cambio de Contraseña</asp:Label></h1>
<div id="inputform">
<asp:label CssClass="label" runat="server" ID="name_lbl" meta:resourcekey="name_lblResource1">Nombre:</asp:label>
<asp:Label ID="username" runat="server" meta:resourcekey="usernameResource1" /><br />
<asp:label CssClass="label" runat="server" ID="oldpass_lbl" meta:resourcekey="oldpass_lblResource1">Contraseña Anterior:</asp:label>
<asp:TextBox ID="oldpass" runat="server" TextMode="Password" meta:resourcekey="oldpassResource1" />
<asp:RequiredFieldValidator ID="reqOldPass" runat="server" ControlToValidate="oldpass" ErrorMessage="* Contraseña anterior es requerida" meta:resourcekey="reqOldPassResource1" /><br />
<asp:label CssClass="label" runat="server" ID="newpass_lbl" meta:resourcekey="newpass_lblResource1">Contraseña Nueva:</asp:label>
<asp:TextBox ID="newpass" runat="server" TextMode="Password" meta:resourcekey="newpassResource1" />
<asp:RequiredFieldValidator ID="reqNewpass" runat="server" ControlToValidate="newpass" ErrorMessage="* Contraseña nueva es requerida" meta:resourcekey="reqNewpassResource1" /><br />
<asp:label CssClass="label" runat="server" ID="rnewpass_lbl" meta:resourcekey="rnewpass_lblResource1">Repetir Contraseña:</asp:label>
<asp:TextBox ID="rnewpass" runat="server" TextMode="Password" meta:resourcekey="rnewpassResource1" />
<asp:RequiredFieldValidator ID="rRnewpass" runat="server" ControlToValidate="rnewpass" ErrorMessage="* Contraseña nueva es requerida" Display="Dynamic" meta:resourcekey="rRnewpassResource1" />
<asp:CompareValidator ID="cmpRnewpass" runat="server" ControlToValidate="rnewpass" ControlToCompare="newpass" ErrorMessage="* Las contraseñas no coinciden" Display="Dynamic" meta:resourcekey="cmpRnewpassResource1" /><br />
</div>
<asp:Button ID="Cancel" runat="server" Text="Cancel" CausesValidation="False" OnClick="Cancel_Click" meta:resourcekey="CancelResource1" />
<asp:Button ID="Accept" runat="server" Text="Cambiar" OnClick="Accept_Click" meta:resourcekey="AcceptResource1" />
</asp:Content>

