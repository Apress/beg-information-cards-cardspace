<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" ValidateRequest="false"  %>

<%@ Register Src="ICRegister.ascx" TagName="ICRegister" TagPrefix="uc2" %>

<%@ Register Src="ICLogin.ascx" TagName="Login" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:Login ID="Login1" runat="server" />
        <br />
        <br />
        &nbsp;
        <asp:Label ID="Label1" runat="server" Font-Names="Verdana" Font-Size="Small" Style="position: relative"
            Text="Don't have an account? Sign up for one below."></asp:Label>
        <br />
        <br />
        <uc2:ICRegister ID="ICRegister1" runat="server" />
    </div>
    </form>
</body>
</html>
