<%@ Register TagPrefix="confluence" TagName="DoubleList" Src="~/DoubleList.ascx" %>
<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="DetalleFamilia.aspx.vb" Inherits="DetalleFamilia" title="Untitled Page" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1><asp:Label ID="h1" runat="server" meta:resourcekey="h1Resource1">Modificar Familia:</asp:Label></h1>
<div id="inputform">
<asp:HiddenField ID="fid" runat="server" /><br />
<asp:label CssClass="label" runat="server" ID="name_lbl" meta:resourcekey="name_lblResource1">Nombre:</asp:label>
<asp:TextBox Enabled="False" ID="name" runat="server" meta:resourcekey="nameResource1" /><br />
<asp:label CssClass="label" runat="server" ID="desc_lbl" meta:resourcekey="desc_lblResource1">Descripcion:</asp:label>
<asp:TextBox TextMode="MultiLine" ID="description" runat="server" meta:resourcekey="descriptionResource1" />
<asp:RequiredFieldValidator ID="reqDescription" runat="server" ControlToValidate="description" ErrorMessage="* Descripcion es requerida" meta:resourcekey="reqDescriptionResource1" /><br />
<confluence:DoubleList ID="dblList" runat="server" ItemName="Patentes" meta:resourcekey="doublelist" />
</div>

<asp:Button ID="Save" Text="Save" runat="server" OnClick="Save_Click" meta:resourcekey="SaveResource1" />
<asp:Button ID="Cancel" Text="Cancel" runat="server" CausesValidation="False" OnClick="Cancel_Click" meta:resourcekey="CancelResource1" />
</asp:Content>

