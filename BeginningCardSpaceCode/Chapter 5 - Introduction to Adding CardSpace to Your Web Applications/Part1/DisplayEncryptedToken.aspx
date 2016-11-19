<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DisplayEncryptedToken.aspx.cs" Inherits="EncrypredToken" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Display Encrypted Token</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <span style="font-size: 12pt; font-family: 'Times New Roman','serif'; mso-bidi-font-size: 10.0pt;
            mso-fareast-font-family: 'Times New Roman'; mso-ansi-language: EN-US; mso-fareast-language: EN-US;
            mso-bidi-language: AR-SA">This is your encrypted token:
            <asp:Label ID="lblEncryptedToken" runat="server" Style="position: relative"></asp:Label></span></div>
    </form>
</body>
</html>
