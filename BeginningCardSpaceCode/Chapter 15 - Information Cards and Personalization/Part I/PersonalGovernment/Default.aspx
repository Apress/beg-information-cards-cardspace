<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Personal Government</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            &nbsp;<table style="width: 491px">
                <tr>
                    <td style="width: 159px">
                        </td>
                    <td >
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="Medium"
                            Style="z-index: 100; left: 189px; position: absolute; top: 41px" Text="Welcome to Personal Government"
                            Width="305px"></asp:Label>
                        <asp:Label ID="Label2" runat="server" Font-Names="Verdana" Font-Size="Smaller" Style="z-index: 101;
                            left: 194px; position: absolute; top: 89px" Text="Please enter your U.S. Zip Code"
                            Width="219px"></asp:Label>
                        <asp:TextBox ID="tbZipCode" runat="server" Style="z-index: 102; left: 195px; position: absolute;
                            top: 111px" Width="209px"></asp:TextBox>
                        <asp:Button ID="btnNext" runat="server" PostBackUrl="PersonalizedHome.aspx" Style="z-index: 104;
                            left: 421px; position: absolute; top: 109px" Text="Next" Width="50px" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
