<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ICRegister.ascx.cs" Inherits="ICRegister" %>

<asp:CreateUserWizard ID="CreateUserWizard1" runat="server" Style="position: relative" BackColor="#F7F6F3" BorderColor="#E6E2D8" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" AutoGeneratePassword="True" CreateUserButtonText="Next">
    <WizardSteps>
        <asp:CreateUserWizardStep runat="server">
            <ContentTemplate>
                <table border="0">
                    <tr>
                        <td align="center" colspan="2" style="font-weight: bold; color: white; background-color: #5d7b9d">
                            Sign Up for Your New Account</td>
                    </tr>
                  <tr>
                        <td align="right">
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label></td>
                        <td>
                            <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label></td>
                        <td>
                            <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">Confirm Password:</asp:Label></td>
                        <td>
                            <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword"
                                ErrorMessage="Confirm Password is required." ToolTip="Confirm Password is required."
                                ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail:</asp:Label></td>
                        <td>
                            <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email"
                                ErrorMessage="E-mail is required." ToolTip="E-mail is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="QuestionLabel" runat="server" AssociatedControlID="Question">Security Question:</asp:Label></td>
                        <td>
                            <asp:TextBox ID="Question" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="QuestionRequired" runat="server" ControlToValidate="Question"
                                ErrorMessage="Security question is required." ToolTip="Security question is required."
                                ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer">Security Answer:</asp:Label></td>
                        <td>
                            <asp:TextBox ID="Answer" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" ControlToValidate="Answer"
                                ErrorMessage="Security answer is required." ToolTip="Security answer is required."
                                ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password"
                                ControlToValidate="ConfirmPassword" Display="Dynamic" ErrorMessage="The Password and Confirmation Password must match."
                                ValidationGroup="CreateUserWizard1"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2" style="color: red">
                            <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:CreateUserWizardStep>
        <asp:TemplatedWizardStep runat="server" Title="Associate Information Card" StepType="Step">
            <ContentTemplate>
<div id="InformationCardToRegisterObjectContainer">
  </div> 

                 <script type="text/javascript">
     function requestInformationCard()
      { 
        
        icObject = '<object type="application/x-informationcard" name="xmlRegisterToken">';
        icObject += '<param name="tokenType" value="urn:oasis:names:tc:SAML:1.0:assertion" />';
        icObject += '<param name="issuer" value="http://schemas.xmlsoap.org/ws/2005/05/identity/issuer/self" />';
        icObject += '<param name="requiredClaims" value="http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname http://schemas.xmlsoap.org/ws/2005/05/identity/claims/privatepersonalidentifier" />';
        icObject += '</object>'
       
        
        document.getElementById("InformationCardToRegisterObjectContainer").innerHTML=icObject;
        document.getElementById("form1").submit();
        
     }
</script> 
                <table border="0" style="font-size: 100%; font-family: Verdana">
                    <tr>
                        <td align="right" colspan="2" style="text-align: center;font-weight: bold; color: white; background-color: #5d7b9d">
                            Associate Information Card</td>
                    </tr>
                    <tr>
                        <td align="right" style="text-align: center; width: 126px;">
Select Card<br />
                            (Optional)
                        </td>
                        <td style="width: 166px">
                                              &nbsp;&nbsp;&nbsp;&nbsp;<img id="Img1" src="informationcard.gif" style="position: relative; text-align: center; left: 0px;" onmouseover="this.src='informationcard_gray.gif'" onmouseout="this.src='informationcard.gif'"  alt="Information Card" onclick="requestInformationCard();"/></td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:TemplatedWizardStep>
        <asp:CompleteWizardStep runat="server">
            <ContentTemplate>
                <table border="0" style="font-size: 100%; font-family: Verdana">
                    <tr>
                        <td align="center" colspan="2" style="font-weight: bold; color: white; background-color: #5d7b9d">
                            Complete</td>
                    </tr>
                    <tr>
                        <td>
                            Your account has been successfully created.</td>
                    </tr>
                    <tr>
                        <td align="right" colspan="2">
                            <asp:Button ID="ContinueButton" runat="server" BackColor="#FFFBFF" BorderColor="#CCCCCC"
                                BorderStyle="Solid" BorderWidth="1px" CausesValidation="False" CommandName="Continue"
                                Font-Names="Verdana" ForeColor="#284775" OnClick="ContinueButton_Click" Text="Continue"
                                ValidationGroup="CreateUserWizard1" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:CompleteWizardStep>
    </WizardSteps>
    <SideBarStyle BackColor="#5D7B9D" BorderWidth="0px" Font-Size="0.9em" VerticalAlign="Top" />
    <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <SideBarButtonStyle BorderWidth="0px" Font-Names="Verdana" ForeColor="White" />
    <NavigationButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid"
        BorderWidth="1px" Font-Names="Verdana" ForeColor="#284775" />
    <HeaderStyle BackColor="#5D7B9D" BorderStyle="Solid" Font-Bold="True" Font-Size="0.9em"
        ForeColor="White" HorizontalAlign="Center" />
    <CreateUserButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid"
        BorderWidth="1px" Font-Names="Verdana" ForeColor="#284775" />
    <ContinueButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid"
        BorderWidth="1px" Font-Names="Verdana" ForeColor="#284775" />
    <StepStyle BorderWidth="0px" />
</asp:CreateUserWizard>
