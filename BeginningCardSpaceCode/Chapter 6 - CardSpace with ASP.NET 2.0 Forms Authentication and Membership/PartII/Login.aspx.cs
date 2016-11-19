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


public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
    {
        //CreateUserWizard1.Visible = false;
    }

    void LinkButton1_Click(object sender, EventArgs e)
    {
        //Login1.Visible = true;
        //CreateUserWizard1.Visible = true;
    }
    protected void LinkButton1_Click1(object sender, EventArgs e)
    {

    }
}
