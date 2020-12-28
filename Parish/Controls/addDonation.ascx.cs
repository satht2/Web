using Parish.DB.Modules;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_addDonation : System.Web.UI.UserControl
{
    public int MemberID { get; set; }
    protected StringBuilder msgError = new StringBuilder();

    public void AddDonation()
    {
        GetDonationTypes();
        if (MemberID != 0)
        {
            Session["MemberID"] = MemberID;
            //bSave.Text = "Update";
            GetDonations();
        }
        else
        {
            //bSave.Text = "Save";
            ClearDonation();
        }

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetDonationTypes();

            if (MemberID != 0)
            {
                Session["MemberID"] = MemberID;
                bSave.Text = "Update";
                GetDonations();
            }
            else
            {
                Session["MemberID"] = null;
                bSave.Text = "Save";
                ClearDonation();
            }
        }
    }
    protected void GetDonationTypes()
    {
        DataClients dC = new DataClients();
        DataView dv = dC.GetDonationTypes();
        DataTable oDataTable = dv.Table;

        ddDonationType.DataSource = oDataTable;
        ddDonationType.DataTextField = "DonationType";
        ddDonationType.DataValueField = "DonationTypeID";
        ddDonationType.DataBind();
        ddDonationType.Items.Insert(0, new ListItem("Select one"));
        //    cn.Close();
        //}
    }
    protected void GetDonations()
    {
        if ((Session["MemberID"] != null) && (Utilities.IsNumeric(Session["MemberID"])))
        {
            MemberID = Convert.ToInt32(Session["MemberID"]);
            DataClients dC = new DataClients();
            DataView dv = dC.GetDonationsByMemberID(MemberID);
            DataTable oDataTable = dv.Table;

            grdDonations.DataSource = oDataTable;
            grdDonations.DataBind();
        }
    }
    private void ClearDonation()
    {
        txtAmount.Text = "";
        ddDonationType.SelectedIndex = 0;
    }
    protected void bSave_Click(object sender, EventArgs e)
    {
        try
        {
            if(ValidateClientInfo())
            {
                MemberID = Convert.ToInt32(Session["MemberID"]);
                int UserID = Convert.ToInt32(Session["UserID"]);
                DataClients dC = new DataClients();

                string dv = dC.InsertDonation(MemberID, txtAmount.Text, ddDonationType.SelectedIndex, UserID);
                if (Utilities.IsNumeric(dv) && Convert.ToInt32(dv) == -1)
                {
                    lblError.Text = "DB Error.<br/>";
                }
                else
                {
                    GetDonations();
                    ClearDonation();
                    //lblError.Text = "Successfully Saved";
                    //Page.Response.Redirect(Page.ResolveUrl("~/Member.aspx?success=addmember"));
                }
            }
        }
        catch (Exception ex)
        {
            lblError.Text = "Please validate your information.<br/>" + ex.Message + msgError.ToString();
        }
    }
    protected Boolean ValidateClientInfo()
    {
        Boolean bValidate = true;

        lblError.Text = "";
        try
        {
            if ((txtAmount.Text.Trim() == null || txtAmount.Text.Trim() == ""))
            {
                bValidate = false;
                msgError.AppendFormat("Enter the amount<br/>");
            }
            if (!Utilities.IsNumeric(txtAmount.Text.Trim()))
            {
                bValidate = false;
                msgError.AppendFormat("Enter valid amount<br/>");
            }
            if (ddDonationType.SelectedIndex == 0)
            {
                bValidate = false;
                msgError.AppendFormat("Please select the donation type.<br/>");
            }
            if((Session["MemberID"] != null) && (Utilities.IsNumeric(Session["MemberID"])))
            {
                msgError.AppendFormat("Please select the member.<br/>");
            }
            if ((Session["UserID"] != null) && (!Utilities.IsNumeric(Session["UserID"])))
            {
                Response.Redirect(Page.ResolveUrl("~/NotAuthorized.aspx"));
            }
        }
        catch
        {
        }
        return bValidate;
    }
}