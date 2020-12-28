using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void LinkButtonOK_Click(object sender, EventArgs e)
    {
        string UserName = this.TextBoxUserName.Text;
        string Password = this.TextBoxPassword.Text;

        if (!String.IsNullOrEmpty(UserName) && !String.IsNullOrEmpty(Password))
        {
            Session["UserName"] = UserName;
            Session["Password"] = Password;
            Page.Response.Redirect("~/home.aspx");
        }
    }
}