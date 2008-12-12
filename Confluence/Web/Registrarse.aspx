<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Registrarse.aspx.vb" Inherits="Registrarse" title="Untitled Page" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1><asp:Label ID="h1" runat="server" meta:resourcekey="h1Resource1">Registro de Nuevo Usuario</asp:Label></h1>
<div id="inputform">
    <asp:label CssClass="label" runat="server" ID="Label2" meta:resourcekey="Label2Resource1">Apodo:</asp:label>
    <asp:TextBox ID="username" runat="server" ValidationGroup="main" meta:resourcekey="usernameResource1" />
    <asp:RequiredFieldValidator ID="reqUsername" runat="server" ControlToValidate="username" ErrorMessage="* Apodo de usuario es requerido" meta:resourcekey="reqUsernameResource1" /><br />
    <asp:label CssClass="label" runat="server" ID="Label3" meta:resourcekey="Label3Resource1">Contraseña:</asp:label>
    <asp:TextBox ID="password" runat="server" TextMode="Password" ValidationGroup="main" meta:resourcekey="passwordResource1" />
    <asp:RequiredFieldValidator ID="reqPassword" runat="server" ControlToValidate="password" ErrorMessage="* Contraseña es requerida" meta:resourcekey="reqPasswordResource1" /><br />
    <asp:label CssClass="label" runat="server" ID="Label1" meta:resourcekey="Label1Resource1">Repetir Contraseña:</asp:label>
    <asp:TextBox ID="passwordR" runat="server" TextMode="Password" ValidationGroup="main" meta:resourcekey="passwordRResource1" />
    <asp:RequiredFieldValidator ID="reqPasswordR" runat="server" ControlToValidate="passwordR" ErrorMessage="* Repetir Contraseña es requerido" Display="Dynamic" meta:resourcekey="reqPasswordRResource1" />
    <asp:CompareValidator ID="comparePassword" runat="server" ControlToValidate="passwordR" ControlToCompare="password" ErrorMessage="* Las contraseñas no son iguales" meta:resourcekey="comparePasswordResource1" /><br />
    <asp:label CssClass="label" runat="server" ID="Label4" meta:resourcekey="Label4Resource1">Correo:</asp:label>
    <asp:TextBox ID="mail" runat="server" ValidationGroup="main" meta:resourcekey="mailResource1" /><br />
    <asp:label CssClass="label" runat="server" ID="Label5" meta:resourcekey="Label5Resource1">Nombre y Apellido:</asp:label>
    <asp:TextBox ID="fullname" runat="server" ValidationGroup="main" meta:resourcekey="fullnameResource1" />
    <asp:RequiredFieldValidator ID="reqFullname" runat="server" ControlToValidate="fullname" ErrorMessage="* Nombre es requerido" meta:resourcekey="reqFullnameResource1" /><br />
    <asp:label CssClass="label" runat="server" ID="Label6" meta:resourcekey="Label6Resource1">Pais:</asp:label>
    <asp:TextBox ID="country" runat="server" ValidationGroup="main" meta:resourcekey="countryResource1" />
    <asp:RequiredFieldValidator ID="reqCountry" runat="server" ControlToValidate="country" ErrorMessage="* Pais es requerido" meta:resourcekey="reqCountryResource1"/><br />
    <asp:label CssClass="label" runat="server" ID="Label7" meta:resourcekey="Label7Resource1">Provincia:</asp:label>
    <asp:TextBox ID="state" runat="server" ValidationGroup="main" meta:resourcekey="stateResource1" /><br />
    <asp:label CssClass="label" runat="server" ID="Label8" meta:resourcekey="Label8Resource1">Telefono:</asp:label>
    <asp:TextBox ID="telephone" runat="server" ValidationGroup="main" meta:resourcekey="telephoneResource1" /><br />
    <br />
    <asp:label CssClass="label" runat="server" ID="Label9" meta:resourcekey="Label9Resource1">Tipo de Usuario:</asp:label>
    <asp:RadioButtonList ID="usertypes" runat="server" CssClass="radiolist" AutoPostBack="True" OnSelectedIndexChanged="usertypes_SelectedIndexChanged" meta:resourcekey="usertypesResource1">
        <asp:ListItem Text="Demandante" Value="D" Selected="True" meta:resourcekey="ListItemResource1"/>
        <asp:ListItem Text="Ofertante"  Value="O" meta:resourcekey="ListItemResource2"/>
    </asp:RadioButtonList><br />
    <asp:Panel ID="education_panel" runat="server" Visible="False" CssClass="registerPanel" meta:resourcekey="education_panelResource1">
        <asp:label CssClass="label" runat="server" ID="Label10" meta:resourcekey="Label10Resource1">Educacion:</asp:label>
        <table>
            <tr>
                <td><asp:label runat="server" ID="Label11" meta:resourcekey="Label11Resource1">Nivel:</asp:label></td>
                <td>
                    <asp:DropDownList ID="education_level" runat="server" ValidationGroup="educ" meta:resourcekey="education_levelResource1">
                        <asp:ListItem Text="Primario" Value="1" Selected="True" meta:resourcekey="ListItemResource3" />
                        <asp:ListItem Text="Secundario" Value="2" meta:resourcekey="ListItemResource4" />
                        <asp:ListItem Text="Terceario" Value="3" meta:resourcekey="ListItemResource5" />
                        <asp:ListItem Text="Universitario" Value="4" meta:resourcekey="ListItemResource6" />
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td><asp:label runat="server" ID="Label12" meta:resourcekey="Label12Resource1">Instituto:</asp:label></td>
                <td><asp:TextBox ID="education_place" runat="server" ValidationGroup="educ" meta:resourcekey="education_placeResource1"/></td>
                <td><asp:RequiredFieldValidator ID="req_education_place" runat="server" ControlToValidate="education_place" ErrorMessage="* Instituto es requerido" ValidationGroup="educ" meta:resourcekey="req_education_placeResource1" /></td>
            </tr>
            <tr>
                <td><asp:label runat="server" ID="Label13" meta:resourcekey="Label13Resource1">Año Inicio:</asp:label></td>
                <td><asp:TextBox ID="education_year_start" runat="server" meta:resourcekey="education_year_startResource1" /></td>
                <td>
                    <asp:RequiredFieldValidator ID="req_education_year_start" runat="server" ControlToValidate="education_year_start" ErrorMessage="* A&#241;o Inicial es requerido" Display="Dynamic" ValidationGroup="educ" meta:resourcekey="req_education_year_startResource1" />
                    <asp:RangeValidator ID="rng_education_year_start" runat="server" ControlToValidate="education_year_start" Type="Integer" MinimumValue="1900" MaximumValue="2008" ErrorMessage="A&#241;o Inicial no v&#225;lido" Display="Dynamic" ValidationGroup="educ" meta:resourcekey="rng_education_year_startResource1" />
                </td>
            </tr>
            <tr>
                <td><asp:label runat="server" ID="Label14" meta:resourcekey="Label14Resource1">Nivel:</asp:label></td>
                <td><asp:TextBox ID="education_year_end" runat="server" ValidationGroup="educ" meta:resourcekey="education_year_endResource1" /></td>
                <td>
                    <asp:RangeValidator ID="rng_education_year_end" runat="server" ControlToValidate="education_year_end" Type="Integer" MinimumValue="1900" MaximumValue="2008" ErrorMessage="A&#241;o de Finalizaci&#243;n no v&#225;lido" Display="Dynamic" ValidationGroup="educ" meta:resourcekey="rng_education_year_endResource1" />
                    <asp:CustomValidator ID="cst_education_year_end" runat="server" ControlToValidate="education_year_end" ErrorMessage="El a&#241;o de finalizaci&#243;n debe ser posterior al de inicio" Display="Dynamic" OnServerValidate="Validate_End_Year" ValidationGroup="educ" meta:resourcekey="cst_education_year_endResource1" />
                </td>
            </tr>
            <tr>
                <td><asp:Button ID="education_add" runat="server" ValidationGroup="educ" OnClick="Education_Submit" Text="Agregar" meta:resourcekey="education_addResource1" /></td>
            </tr>
            <tr>
                <td><asp:ListBox ID="education_list" runat="server" Visible="False" meta:resourcekey="education_listResource1" /></td>
                <td><asp:Button ID="rmv_education_list" runat="server" Text="Borrar" OnClick="Education_Remove" Visible="False" CausesValidation="False" meta:resourcekey="rmv_education_listResource1" /></td>
            </tr>

        </table>        
        
    </asp:Panel>
    
    <asp:Panel ID="work_panel" runat="server" Visible="False" CssClass="registerPanel" meta:resourcekey="work_panelResource1">
        <asp:label CssClass="label" runat="server" ID="Label15" meta:resourcekey="Label15Resource1">Experiencia Laboral:</asp:label>
        <table>
            <tr>
                <td><asp:label runat="server" ID="Label16" meta:resourcekey="Label16Resource1">Lugar:</asp:label></td>
                <td><asp:TextBox ID="work_place" runat="server" ValidationGroup="work" meta:resourcekey="work_placeResource1"/></td>
                <td><asp:RequiredFieldValidator ID="req_work_place" runat="server" ControlToValidate="work_place" ErrorMessage="* Lugar es requerido" ValidationGroup="work" meta:resourcekey="req_work_placeResource1" /></td>
            </tr>
            <tr>
                <td><asp:label runat="server" ID="Label17" meta:resourcekey="Label17Resource1">Año Inicio:</asp:label></td>
                <td><asp:TextBox ID="work_year_start" runat="server" meta:resourcekey="work_year_startResource1" /></td>
                <td>
                    <asp:RequiredFieldValidator ID="req_work_start" runat="server" ControlToValidate="work_year_start" ErrorMessage="* A&#241;o Inicial es requerido" Display="Dynamic" ValidationGroup="work" meta:resourcekey="req_work_startResource1" />
                    <asp:RangeValidator ID="rng_work_start" runat="server" ControlToValidate="work_year_start" Type="Integer" MinimumValue="1900" MaximumValue="2008" ErrorMessage="* A&#241;o Inicial no v&#225;lido" Display="Dynamic" ValidationGroup="work" meta:resourcekey="rng_work_startResource1" />
                </td>
            </tr>
            <tr>
                <td><asp:label runat="server" ID="Label18" meta:resourcekey="Label18Resource1">Año Fin:</asp:label></td>
                <td><asp:TextBox ID="work_year_end" runat="server" ValidationGroup="educ" meta:resourcekey="work_year_endResource1" /></td>
                <td>
                    <asp:RangeValidator ID="rng_work_year_end" runat="server" ControlToValidate="work_year_end" Type="Integer" MinimumValue="1900" MaximumValue="2008" ErrorMessage="* A&#241;o de Finalizaci&#243;n no v&#225;lido" Display="Dynamic" ValidationGroup="work" meta:resourcekey="rng_work_year_endResource1" />
                    <asp:CustomValidator ID="cst_work_year_end" runat="server" ControlToValidate="work_year_end" ErrorMessage="* El a&#241;o de finalizaci&#243;n debe ser posterior al de inicio" Display="Dynamic" OnServerValidate="Validate_End_Year" ValidationGroup="work" meta:resourcekey="cst_work_year_endResource1" />
                </td>
            </tr>
            <tr>
                <td><asp:Button ID="work_add" runat="server" ValidationGroup="work" OnClick="Work_Submit" Text="Agregar" meta:resourcekey="work_addResource1" /></td>
            </tr>
            <tr>
                <td><asp:ListBox ID="work_list" runat="server" Visible="False" meta:resourcekey="work_listResource1" /></td>
                <td><asp:Button ID="rmv_work_list" runat="server" Text="Borrar" OnClick="Work_Remove" Visible="False" CausesValidation="False" meta:resourcekey="rmv_work_listResource1" /></td>
            </tr>

        </table>        
        
    </asp:Panel>
    <label></label>
</div>
<asp:Button ID="Submit" runat="server" Text="Aceptar" OnClick="Submit_Click" meta:resourcekey="SubmitResource1"/>
<asp:Button ID="Cancel" runat="server" Text="Cancel" OnClick="Cancel_Click" CausesValidation="False" meta:resourcekey="CancelResource1" />
</asp:Content>

