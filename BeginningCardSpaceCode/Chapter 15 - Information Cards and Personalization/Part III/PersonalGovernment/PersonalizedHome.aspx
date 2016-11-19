<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PersonalizedHome.aspx.cs" Inherits="PersonalizedHome" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Home</title>
</head>
<body style="font-size: 10pt; color: black; font-family: Arial">
    <form id="form1" runat="server">
        &nbsp;<table style="width: 491px">
            <tr>
                <td style="width: 159px">
                    <img src="Images/government%20building.png" /></td>
                <td colspan="2">
                    <asp:Panel ID="pnlHeader" runat="server" Height="50px" Width="125px">
                    </asp:Panel>
                </td>
            </tr>
        </table>
        <asp:Panel ID="pnlStateInfo" runat="server" Height="189px" Width="490px">
        </asp:Panel>
        <hr />
        <asp:Panel ID="pnlCityInfo" runat="server" Height="103px" Width="487px">
        </asp:Panel><hr />
        <asp:Panel ID="pnlSenatorInfo" runat="server" Height="196px" Width="488px">
        </asp:Panel>
        <hr />
        <asp:Panel ID="pnlCensusInformation" runat="server" Height="154px" Width="487px">
        </asp:Panel>
    

    </form>
</body>
</html>
