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
                HyperLink2.Visible = false;
                HyperLink1.Visible = false;
                HyperLink3.Visible = false;
            }
            else
            {
                lkbSignOut.Text = "Sign out";
                HyperLink2.Visible = true;
                HyperLink1.Visible = true;
                HyperLink3.Visible = true;
            }
        }
    }

    protected void lkbMember_Click(object sender, EventArgs e)
    {
        Session["MemberID"] = null;
        Response.Redirect("~/Member.aspx");
    }
    protected void lkbChurch_Click(object sender, EventArgs e)
    {
        Session["MemberID"] = null;
        Response.Redirect("~/Church.aspx");
    }
    protected void lkbSignOut_Click(object sender, EventArgs e)
    {
        Session["UserName"] = null;
        Session["Password"] = null;
        Session["UserID"] = null;
        Response.Redirect("~/Login.aspx");
    }
}