using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.IdentityModel.Samples;
using System.IdentityModel.Claims;
using System.Data.SqlClient;

public partial class ICRegister : System.Web.UI.UserControl
{

    #region MemberVariables

    private string _ppid = "";
    private string _givenName = "";
    private string _surName = "";
    private string _email = "";
    private string _username = "";
    private ClaimSet _userClaims;
    #endregion

    #region Properties
    public string AssociatedInformationCardPPID
    {
        get { return _ppid; }
        set { _ppid = value; }
    }

    public string AssociatedInformationCardGivenName
    {
        get { return _givenName; }
        set { _givenName = value; }
    }

    public string AssociatedInformationCardSurName
    {
        get { return _surName; }
        set { _surName = value; }
    }

    public string AssociatedInformationCardEmail
    {
        get {return _email;}
        set {_email = value;}
    }

    #endregion
    
    protected void Page_Load(object sender, EventArgs e)
    {
        CreateUserWizard1.CreatedUser += new EventHandler(CreateUserWizard1_CreatedUser);
        
        if (this.IsPostBack)
       {
           if (this.Visible == true)
           {
               //Check to see if the user submitted an Information Card
               string xmlToken;
               xmlToken = Request.Params["xmlRegisterToken"];

               if (xmlToken == null || xmlToken == "")
               {
                   //No Card Provided
               }
               else
               {
                   //The user submitted an Information Card, 
                   //process it.
                   AssociateInformationCard(xmlToken);
                   FormsAuthentication.RedirectFromLoginPage(this.CreateUserWizard1.UserName, false);
               }

           }
        }
    }
    void AssociateInformationCard(string xmlToken)
    {
        //Create a connection to the SQL Server; modify the connection string for your environment.
        RetrieveTokenClaims(xmlToken);
        string connString =
                    ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;
        SqlConnection MyConnection = new SqlConnection(connString);
        MyConnection.Open();
        SqlCommand MyCommand = new SqlCommand("aspnet_Users_AddUserInformationCard", MyConnection);
        MyCommand.CommandType = CommandType.StoredProcedure;
        //Create and add a parameter to Parameters collection for the stored procedure.
        MyCommand.Parameters.Add(new SqlParameter("@UserId", SqlDbType.UniqueIdentifier));
        //Assign the UserID value to the parameter.
        MyCommand.Parameters["@UserId"].Value = RetrieveUserIDByUserName(this.CreateUserWizard1.UserName, this.CreateUserWizard1.Password);
        //Create and add a parameter to Parameters collection for the stored procedure.
        MyCommand.Parameters.Add(new SqlParameter("@PPID", SqlDbType.Char, 20));
        //Assign the UserID value to the parameter.
        MyCommand.Parameters["@PPID"].Value = _ppid;


        MyCommand.ExecuteScalar();        
        MyConnection.Close(); //Close the connection.

    }
    void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
    {
      
    }
    private Guid RetrieveUserIDByUserName(string username, string password)
    {
        //Create a connection to the SQL Server; modify the connection string for your environment.
        string connString =
                    ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;

        
            SqlConnection MyConnection = new SqlConnection(connString);
            MyConnection.Open();    
        SqlCommand MyCommand = new SqlCommand("aspnet_Membership_GetUserIDByUserName", MyConnection);
        MyCommand.CommandType = CommandType.StoredProcedure;
            //Create and add a parameter to Parameters collection for the stored procedure.
            MyCommand.Parameters.Add(new SqlParameter("@UserName", SqlDbType.NVarChar,256));
            //Create and add a parameter to Parameters collection for the stored procedure.
            MyCommand.Parameters["@UserName"].Value = username;


            Guid userId = (Guid) MyCommand.ExecuteScalar();
               MyConnection.Close(); //Close the connection.
               return userId;
    }
    private void RetrieveTokenClaims(string xmlToken)
    {
        TokenHelper tokenHelper = new TokenHelper(xmlToken);

        _userClaims = tokenHelper.IdentityClaims;
     

        foreach (Claim claim in _userClaims)
        {

            switch (claim.ClaimType)
            {
                case "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname":
                    _givenName = claim.Resource.ToString();
                    break;
                case "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname":
                    _surName = claim.Resource.ToString();
                    break;
                case "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/privatepersonalidentifier":
                    _ppid = claim.Resource.ToString();
                    break;
                case "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress":
                    _email = claim.Resource.ToString();
                    break;
            }

        }
    
    
    }

    protected void ContinueButton_Click(object sender, EventArgs e)
    {
        FormsAuthentication.RedirectFromLoginPage(this.CreateUserWizard1.UserName, false);
    }
}
