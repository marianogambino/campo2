<%@ Control Language="VB" AutoEventWireup="false" CodeFile="StudyList.ascx.vb" Inherits="StudyList" %>
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
