using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_TopNav : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if ((Session["UserName"] == null) || (Session["Password"] == null))
            {
                lkbSignOut.Text = "Sign in";
            }
            else
            {
                lkbSignOut.Text = "Sign out";
            }
        }
    }

    protected void lkbSignOut_Click(object sender, EventArgs e)
    {
        Session["UserName"] = null;
        Session["Password"] = null;
        Session["UserID"] = null;
        Response.Redirect("~/Login.aspx");
    }
}