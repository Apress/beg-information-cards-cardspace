<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ICLogin.ascx.cs" Inherits="Login" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script type="text/javascript">
     function requestInformationCard()
      { 
        icObject = '<object type="application/x-informationcard" name="xmlLoginToken">';
        icObject += '<param name="tokenType" value="urn:oasis:names:tc:SAML:1.0:assertion" />';
        icObject += '<param name="issuer" value="http://schemas.xmlsoap.org/ws/2005/05/identity/issuer/self" />';
        icObject += '<param name="requiredClaims" value="http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname http://schemas.xmlsoap.org/ws/2005/05/identity/claims/privatepersonalidentifier http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress" />';
        icObject += '</object>'
        document.getElementById("InformationCardToLoginObjectContainer").innerHTML=icObject;
        document.getElementById("form1").submit(); 
     }
</script>
<div id="InformationCardToLoginObjectContainer">
  </div> 

 <asp:Panel ID="Panel1" runat="server" Height="381px" Style="position: relative; left: 0px; top: 0px;" Width="376px" BorderStyle="None">
    <asp:Panel ID="Panel2" runat="server" Height="160px" Style="left: 0px; position: relative;
        top: 0px; font-family: Verdana; text-align: center;" Width="384px">
        <table style="width: 384px; position: relative; height: 160px; left: 0px; top: 0px;">
            <tr>
                <td style="font-weight: bold; color: white; background-color: #5d7b9d;font-size:small';" colspan="3">
                    Sign In Using Your Information Card</td>
            </tr>
            <tr>
                <td style="width: 59px">
                </td>
                <td style="width: 31px">
                   <img id="Image1" src="informationcard.gif" style="position: relative; text-align: center;" onclick="requestInformationCard();" onmouseover="this.src='informationcard_gray.gif'" onmouseout="this.src='informationcard.gif'"  alt="Information Card"/><br />
                    &nbsp; &nbsp;
                    <br />
                    &nbsp; &nbsp; &nbsp;&nbsp; or</td>
                   
                <td>
                </td>
            </tr>
            <tr>
                <td style="width: 59px">
                </td>
                <td style="width: 31px">
                    &nbsp; &nbsp; &nbsp;
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
         </asp:Panel>
    <asp:Panel ID="Panel3" runat="server" Height="96px" Style="left: 8px; position: relative;  top:34px;
        font-family: Verdana;" Width="384px">
        <table style="width: 384px; position: relative; left: -6px; top: -46px;">
            <tr>
                <td colspan="2" style="font-weight: bold; color: white; background-color: #5d7b9d;font-size:small'; ">
                    Sign in with your username and password</td>
            </tr>
            <tr>
                <td style="width: 128px">
                    <asp:Label ID="Label1" runat="server" Style="position: relative; font-family: Verdana;" Text="User Name"></asp:Label></td>
                <td>
                    <asp:TextBox ID="tbUsername" runat="server" Style="position: relative"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 128px">
                    <asp:Label ID="Label2" runat="server" Style="position: relative" Text="Password" Font-Names="Verdana"></asp:Label></td>
                <td>
                    <asp:TextBox ID="tbPassword" runat="server" Style="position: relative"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 128px">
                </td>
                <td>
                    <asp:Button ID="btnSignIn" runat="server" Style="position: relative" Text="Sign In" /></td>
            </tr>
            <tr>
                <td colspan="2">
                    </td>
            </tr>
        </table>
        <asp:Label ID="lblError" runat="server" Font-Names="Verdana" ForeColor="DarkRed"
            Style="position: relative; left: 0px; top: -38px;"></asp:Label></asp:Panel>
</asp:Panel>
&nbsp;

