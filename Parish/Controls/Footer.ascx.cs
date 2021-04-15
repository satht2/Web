using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_Footer : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<div class='footer_right'>");

            sb.AppendFormat("<a href='{0}' title=''>Privacy Policy</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a href='{1}' title=''>Terms and Conditions</a>&nbsp;&nbsp;|&nbsp;&nbsp; <span>© 2021</span>", Page.ResolveUrl("~/privacypolicy.aspx"), Page.ResolveUrl("~/termsconditions.aspx"));

            sb.AppendFormat("</div>");


            ltlContent.Text = sb.ToString();
        }
    }
}