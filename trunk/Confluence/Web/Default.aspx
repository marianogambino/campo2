﻿<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Login</title>
</head>
<body>
    <h1>Login Page</h1>
    <form id="loginForm" runat="server">
    <div id="main">
        <label for="txtName">Nombre:</label>
        <asp:TextBox runat="server" ID="txtName" /><br />
        <label for="txtPass">Password:</label>
        <asp:TextBox runat="server" ID="txtPass" /><br />
        <asp:Button runat="server" ID="btnSubmit" OnClick="doLogin" />
    </div>
    </form>
</body>
</html>
