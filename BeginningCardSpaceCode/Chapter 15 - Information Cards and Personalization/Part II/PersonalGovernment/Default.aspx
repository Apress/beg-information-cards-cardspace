<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default"  validateRequest="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xmlns:ic>
<head id="Head1" runat="server">
    <title>Personal Government</title>
</head>
<body>
    <form id="form1" runat="server" action="PersonalizedHome.aspx" >
     <ic:informationcard 
     name='xmlToken'
     style='behavior: url(#default#informationCard)'
     issuer='http://schemas.xmlsoap.org/ws/2005/05/identity/issuer/self'
     tokenType='urn:oasis:names:tc:SAML:1.0:assertion'>
    <ic:add claimType='http://schemas.xmlsoap.org/ws/2005/05/identity/claims/postalcode' optional='false' />
    
      </ic:informationcard><div>
                &nbsp;<table style="width: 491px">
                    <tr>
                        <td style="width: 159px">
                        </td>
                        <td>
                            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="Medium"
                                Style="z-index: 100; left: 189px; position: absolute; top: 41px" Text="Welcome to Personal Government"
                                Width="305px"></asp:Label>
                            <asp:Label ID="Label3" runat="server" Font-Names="Verdana" Font-Size="Smaller" Style="z-index: 100;
                                left: 195px; position: absolute; top: 78px" Text="Login with your information card" Width="264px"></asp:Label>
                            &nbsp;
                            <asp:Label ID="Label2" runat="server" Font-Names="Verdana" Font-Size="Smaller" Style="z-index: 101;
                                left: 196px; position: absolute; top: 176px" Text="Or Enter Your U.S. Zip Code"
                                Width="219px"></asp:Label>
                            <asp:TextBox ID="tbZipCode" runat="server" Style="z-index: 102; left: 192px; position: absolute;
                                top: 204px" Width="209px"></asp:TextBox>
                            <asp:Button ID="btnNext" runat="server" PostBackUrl="PersonalizedHome.aspx" Style="z-index: 104;
                                left: 414px; position: absolute; top: 202px" Text="Next" Width="50px" />
                        </td>
                    </tr>
                </table>
            </div>
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/login.png" PostBackUrl="PersonalizedHome.aspx"
            Style="z-index: 102; left: 214px; position: absolute; top: 108px" />
    </form>
</body>
</html>
