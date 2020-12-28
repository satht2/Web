using Parish.DB.Modules;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_addDependent : System.Web.UI.UserControl
{
    public int MemberID { get; set; }
    protected StringBuilder msgError = new StringBuilder();

    public void AddDependents()
    {
        GetDependentTypes();
        //GetSex();
        if (MemberID != 0)
        {
            Session["MemberID"] = MemberID;
            //bSave.Text = "Update";
            GetDependents();
        }
        else
        {
            //bSave.Text = "Save";
            ClearDependent();
        }

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetDependentTypes();
            GetSex();

            if (MemberID != 0)
            {
                Session["MemberID"] = MemberID;
                bSave.Text = "Update";
                GetDependents();
            }
            else
            {
                Session["MemberID"] = null;
                bSave.Text = "Save";
                ClearDependent();
            }
        }
    }

    protected void GetDependentTypes()
    {
        DataClients dC = new DataClients();
        DataView dv = dC.GetDependentRelationships();
        DataTable oDataTable = dv.Table;

        ddDependentType.DataSource = oDataTable;
        ddDependentType.DataTextField = "DependentType";
        ddDependentType.DataValueField = "DependentRelationshipID";
        ddDependentType.DataBind();
        ddDependentType.Items.Insert(0, new ListItem("Select one"));
    }
    protected void GetDependents()
    {
        if ((Session["MemberID"] != null) && (Utilities.IsNumeric(Session["MemberID"])))
        {
            MemberID = Convert.ToInt32(Session["MemberID"]);
            DataClients dC = new DataClients();
            DataView dv = dC.GetDependentsByMemberID(MemberID);
            DataTable oDataTable = dv.Table;

            grdDependents.DataSource = oDataTable;
            grdDependents.DataBind();
        }
    }
    private void ClearDependent()
    {
        txtFirstName.Text = "";
        txtLastName.Text = "";
        txtDOB.Text = "";
        ddDependentType.SelectedIndex = 0;
    }
    protected void GetSex()
    {
        ddSex.Items.Insert(0, new ListItem("Select one"));
        ddSex.Items.Insert(1, new ListItem("Male"));
        ddSex.Items.Insert(2, new ListItem("Female"));
    }
    protected void bSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidateClientInfo())
            {
                MemberID = Convert.ToInt32(Session["MemberID"]);
                int UserID = Convert.ToInt32(Session["UserID"]);
                DataClients dC = new DataClients();

                string dv = dC.InsertDependent(MemberID, txtFirstName.Text, txtLastName.Text, Convert.ToDateTime(txtDOB.Text)
                    , ddSex.SelectedValue, ddDependentType.SelectedIndex);
                if (Utilities.IsNumeric(dv) && Convert.ToInt32(dv) == -1)
                {
                    lblError.Text = "DB Error.<br/>";
                }
                else
                {
                    GetDependents();
                    ClearDependent();
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
        int currYear = DateTime.Today.Year;
        DateTime dt = DateTime.Today;

        lblError.Text = "";
        try
        {
            if ((txtFirstName.Text.Trim() == null || txtFirstName.Text.Trim() == ""))
            {
                bValidate = false;
                msgError.AppendFormat("Enter first name.<br/>");
            }
            if ((txtLastName.Text.Trim() == null || txtLastName.Text.Trim() == ""))
            {
                bValidate = false;
                msgError.AppendFormat("Enter last name<br/>");
            }
            if (txtDOB.Text == null || txtDOB.Text == "")
            {
                bValidate = false;
                msgError.AppendFormat("Please select the Date of birth.<br/>");
            }
            else if (Convert.ToDateTime(txtDOB.Text) > dt)
            {
                bValidate = false;
                msgError.AppendFormat("Date of birth cannot be future date.<br/>");
            }

            if (ddSex.SelectedIndex == 0)
            {
                bValidate = false;
                msgError.AppendFormat("Please select the sex.<br/>");
            }

            if (ddDependentType.SelectedIndex == 0)
            {
                bValidate = false;
                msgError.AppendFormat("Please select the dependent relationship.<br/>");
            }
        }
        catch
        {
        }
        return bValidate;
    }
}