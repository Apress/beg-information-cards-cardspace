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

public partial class Login : System.Web.UI.UserControl
{
    


#region MemberVariables

    private string _registerUrl;
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
        btnSignIn.Click += new EventHandler(btnSignIn_Click);
        
        if (IsPostBack)
        {


            if (this.Visible == true)
            {
                //Check to see if the user submitted an Information Card
                string xmlToken;
                xmlToken = Request.Params["xmlLoginToken"];

                if (xmlToken == null || xmlToken == "")
                {

                }
                else
                {
                    
                    //The user submitted an Information Card, 
                    //process it.
                    SignInWithInformationCard(xmlToken);

                }


            }
        }
    }

 
    void btnSignIn_Click(object sender, EventArgs e)
    {
        bool isAuthenticated = AuthenticateUser(tbUsername.Text, tbPassword.Text);
        if (isAuthenticated)
        {
            FormsAuthentication.RedirectFromLoginPage(tbUsername.Text, true);
        }
        else
        {
            lblError.Text="The username and password pair provided was invalid.";
        }
    
    }
    void SignInWithInformationCard(string xmlToken)
    {

        RetrieveTokenClaims(xmlToken);
        Response.Write("PPID:" + _ppid);
        Response.Write("Email:" + _email);

        bool isAuthenticated = AuthenticateInformationCardUser(xmlToken, _ppid,  _email);
        if (isAuthenticated)
        {
            FormsAuthentication.RedirectFromLoginPage(_givenName + " " + _surName, true);
        }
        else
        {
            lblError.Text = "The Information Card provided is not associated with an account.";
        }

    
    }
    bool AuthenticateUser(string username, string password)
    {

        return FormsAuthentication.Authenticate(username, password);
    
    }

    bool AuthenticateInformationCardUser(string xmlToken, string ppid, string email)
    {
        //Create a connection to the SQL Server; modify the connection string for your environment.
        RetrieveTokenClaims(xmlToken);
        string connString =
                    ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;
        SqlConnection MyConnection = new SqlConnection(connString);
        MyConnection.Open();
        SqlCommand MyCommand = new SqlCommand("aspnet_Membership_GetUserByInformationCard", MyConnection);
        MyCommand.CommandType = CommandType.StoredProcedure;

        //Create and add a parameter to Parameters collection for the stored procedure.
        MyCommand.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar,256));
        //Assign the UserID value to the parameter.
        MyCommand.Parameters["@Email"].Value = _email;


        //Create and add a parameter to Parameters collection for the stored procedure.
        MyCommand.Parameters.Add(new SqlParameter("@PPID", SqlDbType.Char, 20));
        //Assign the UserID value to the parameter.
        MyCommand.Parameters["@PPID"].Value = _ppid;


        //Create and add a parameter to Parameters collection for the stored procedure.
        MyCommand.Parameters.Add(new SqlParameter("@CurrentTimeUtc", SqlDbType.DateTime));
        //Assign the UserID value to the parameter.
        MyCommand.Parameters["@CurrentTimeUtc"].Value = DateTime.Now;

     //Create and add a parameter to Parameters collection for the stored procedure.
        MyCommand.Parameters.Add(new SqlParameter("@UpdateLastActivity", SqlDbType.Bit));
        //Assign the UserID value to the parameter.
        MyCommand.Parameters["@UpdateLastActivity"].Value = 1;

      

        SqlDataReader reader = MyCommand.ExecuteReader();
        Response.Write(reader.HasRows.ToString());
        
        return reader.HasRows;
        MyConnection.Close(); //Close the connection.
        
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

}
