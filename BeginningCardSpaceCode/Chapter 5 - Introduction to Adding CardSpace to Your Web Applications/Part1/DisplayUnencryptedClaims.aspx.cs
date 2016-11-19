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

public partial class EncrypredToken : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string xmlToken;
        xmlToken = Request.Params["xmlToken"];

        if (xmlToken == null || xmlToken == "")
        {
            xmlToken = "N/A. No token was provided.";
        }
        else
        {
            TokenHelper tokenHelper = new TokenHelper(xmlToken);
            
            foreach(Claim claim in tokenHelper.IdentityClaims)
            {
                tbClaims.Text += "------------------------------------\n";
                tbClaims.Text += "Claim Type:" + claim.ClaimType + "\n";
                tbClaims.Text += "Right:" + claim.Right + "\n";
                tbClaims.Text += "Resource:" + claim.Resource.ToString() + "\n";
               
            }
            
        }
        
    
    }
}
