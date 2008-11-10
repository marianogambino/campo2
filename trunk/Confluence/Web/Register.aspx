<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Registro" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" Runat="Server">
<h1>Registro de nuevo Usuario</h1>
<div id="inputform">
    <label for="username">Apodo de Usuario:</label>
    <asp:TextBox ID="username" runat="server" ValidationGroup="main" />
    <asp:RequiredFieldValidator ID="reqUsername" runat="server" ControlToValidate="username" ErrorMessage="* Apodo de usuario es requerido" /><br />
    <label for="password">Contraseña:</label>
    <asp:TextBox ID="password" runat="server" TextMode="Password" ValidationGroup="main" />
    <asp:RequiredFieldValidator ID="reqPassword" runat="server" ControlToValidate="password" ErrorMessage="* Contraseña es requerida" EnableViewState="true" /><br />
    <label for="passwordR" runat="server">Repetir Contraseña:</label>
    <asp:TextBox ID="passwordR" runat="server" TextMode="password" EnableViewState="true" ValidationGroup="main" />
    <asp:RequiredFieldValidator ID="reqPasswordR" runat="server" ControlToValidate="passwordR" ErrorMessage="* Repetir Contraseña es requerido" Display="dynamic" />
    <asp:CompareValidator ID="comparePassword" runat="server" ControlToValidate="passwordR" ControlToCompare="password" Operator="Equal" ErrorMessage="* Las contraseñas no son iguales" /><br />
    <label for="mail">Mail:</label>
    <asp:TextBox ID="mail" runat="server" ValidationGroup="main" /><br />
    <label for="name">Nombre y Apellido:</label>
    <asp:TextBox ID="fullname" runat="server" ValidationGroup="main" />
    <asp:RequiredFieldValidator ID="reqFullname" runat="server" ControlToValidate="fullname" ErrorMessage="* Nombre es requerido" /><br />
    <label for="country">Pais:</label>
    <asp:TextBox ID="country" runat="server" ValidationGroup="main" />
    <asp:RequiredFieldValidator ID="reqCountry" runat="server" ControlToValidate="country" ErrorMessage="* Pais es requerido"/><br />
    <label for="state">Provincia:</label>
    <asp:TextBox ID="state" runat="server" ValidationGroup="main" /><br />
    <label for="telephone">Telefono:</label>
    <asp:TextBox ID="telephone" runat="server" ValidationGroup="main" /><br />
    <br />
    <label for="usertypes">Tipo de Usuario:</label>
    <asp:RadioButtonList ID="usertypes" runat="server" CssClass="radiolist" AutoPostBack="true" OnSelectedIndexChanged="usertypes_SelectedIndexChanged">
        <asp:ListItem Text="Demandante" Value="D" Selected="true"/>
        <asp:ListItem Text="Ofertante"  Value="O"/>
    </asp:RadioButtonList><br />
    <asp:Panel ID="education_panel" runat="server" Visible="false" CssClass="registerPanel">
        <label for="education">Educación:</label>
        <table>
            <tr>
                <td>Nivel:</td>
                <td>
                    <asp:DropDownList ID="education_level" runat="server" ValidationGroup="educ">
                        <asp:ListItem Text="Primario" Value="1" Selected="True" />
                        <asp:ListItem Text="Secundario" Value="2" />
                        <asp:ListItem Text="Terceario" Value="3" />
                        <asp:ListItem Text="Universitario" Value="4" />
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Instituto:</td>
                <td><asp:TextBox ID="education_place" runat="server" ValidationGroup="educ"/></td>
                <td><asp:RequiredFieldValidator ID="req_education_place" runat="server" ControlToValidate="education_place" ErrorMessage="Instituto es requerido" ValidationGroup="educ" /></td>
            </tr>
            <tr>
                <td>Año Inicio:</td>
                <td><asp:TextBox ID="education_year_start" runat="server" /></td>
                <td>
                    <asp:RequiredFieldValidator ID="req_education_year_start" runat="server" ControlToValidate="education_year_start" ErrorMessage="Año Inicial es requerido" Display="Dynamic" ValidationGroup="educ" />
                    <asp:RangeValidator ID="rng_education_year_start" runat="server" ControlToValidate="education_year_start" Type="Integer" MinimumValue="1900" MaximumValue="2008" ErrorMessage="Año Inicial no válido" Display="dynamic" ValidationGroup="educ" />
                </td>
            </tr>
            <tr>
                <td>Año Fin:</td>
                <td><asp:TextBox ID="education_year_end" runat="server" ValidationGroup="educ" /></td>
                <td>
                    <asp:RangeValidator ID="rng_education_year_end" runat="server" ControlToValidate="education_year_end" Type="Integer" MinimumValue="1900" MaximumValue="2008" ErrorMessage="Año de Finalización no válido" Display="dynamic" ValidationGroup="educ" />
                    <asp:CustomValidator ID="cst_education_year_end" runat="server" ControlToValidate="education_year_end" ErrorMessage="El año de finalización debe ser posterior al de inicio" Display="dynamic" OnServerValidate="Validate_End_Year" ValidationGroup="educ" />
                </td>
            </tr>
            <tr>
                <td><asp:Button ID="education_add" runat="server" ValidationGroup="educ" OnClick="Education_Submit" Text="Agregar" /></td>
            </tr>
            <tr>
                <td><asp:ListBox ID="education_list" runat="server" Visible="false" /></td>
                <td><asp:Button ID="rmv_education_list" runat="server" Text="Borrar" OnClick="Education_Remove" Visible="false" CausesValidation="false" /></td>
            </tr>

        </table>        
        
    </asp:Panel>
    
    <asp:Panel ID="work_panel" runat="server" Visible="false" CssClass="registerPanel">
        <label for="work">Experiencia Laboral:</label>
        <table>
            <tr>
                <td>Lugar:</td>
                <td><asp:TextBox ID="work_place" runat="server" ValidationGroup="work"/></td>
                <td><asp:RequiredFieldValidator ID="req_work_place" runat="server" ControlToValidate="work_place" ErrorMessage="Lugar es requerido" ValidationGroup="work" /></td>
            </tr>
            <tr>
                <td>Año Inicio:</td>
                <td><asp:TextBox ID="work_year_start" runat="server" /></td>
                <td>
                    <asp:RequiredFieldValidator ID="req_work_start" runat="server" ControlToValidate="work_year_start" ErrorMessage="Año Inicial es requerido" Display="Dynamic" ValidationGroup="work" />
                    <asp:RangeValidator ID="rng_work_start" runat="server" ControlToValidate="work_year_start" Type="Integer" MinimumValue="1900" MaximumValue="2008" ErrorMessage="Año Inicial no válido" Display="dynamic" ValidationGroup="work" />
                </td>
            </tr>
            <tr>
                <td>Año Fin:</td>
                <td><asp:TextBox ID="work_year_end" runat="server" ValidationGroup="educ" /></td>
                <td>
                    <asp:RangeValidator ID="rng_work_year_end" runat="server" ControlToValidate="work_year_end" Type="Integer" MinimumValue="1900" MaximumValue="2008" ErrorMessage="Año de Finalización no válido" Display="dynamic" ValidationGroup="work" />
                    <asp:CustomValidator ID="cst_work_year_end" runat="server" ControlToValidate="work_year_end" ErrorMessage="El año de finalización debe ser posterior al de inicio" Display="dynamic" OnServerValidate="Validate_End_Year" ValidationGroup="work" />
                </td>
            </tr>
            <tr>
                <td><asp:Button ID="work_add" runat="server" ValidationGroup="work" OnClick="Work_Submit" Text="Agregar" /></td>
            </tr>
            <tr>
                <td><asp:ListBox ID="work_list" runat="server" Visible="false" /></td>
                <td><asp:Button ID="rmv_work_list" runat="server" Text="Borrar" OnClick="Work_Remove" Visible="false" CausesValidation="false" /></td>
            </tr>

        </table>        
        
    </asp:Panel>
    <label></label>
</div>
<asp:Button ID="Submit" runat="server" Text="Aceptar" OnClick="Submit_Click"/>
<asp:Button ID="Cancel" runat="server" Text="Cancel" OnClick="Cancel_Click" CausesValidation="false" />
</asp:Content>

