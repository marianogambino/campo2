<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WorkList.ascx.vb" Inherits="WorkList" %>
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
        