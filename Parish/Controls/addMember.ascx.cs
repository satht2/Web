using System;
using System.Web.UI.WebControls;
using Parish.DB.Modules;
using System.Data;
using System.Text;

public partial class Controls_addMember : System.Web.UI.UserControl
{
    public int MemberID { get; set; }
    protected StringBuilder msgError = new StringBuilder();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetMaritalStatus();
            GetChurches();
            GetSex();

            if (MemberID != 0)
            {
                Session["MemberID"] = MemberID;
                bSave.Text = "Update";
                GetClientInfo();
            }
            else
            {
                Session["MemberID"] = null;
                bSave.Text = "Save";
                ClearMember();
            }
        }
    }

    public void EditMember()
    {
        GetMaritalStatus();
        GetChurches();
        //GetSex();
        if (MemberID != 0)
        {
            Session["MemberID"] = MemberID;
            bSave.Text = "Update";
            GetClientInfo();
        }
        else
        {
            Session["MemberID"] = null;
            bSave.Text = "Save";
            ClearMember();
        }

    }
    public static bool IsNumeric(object ValueToCheck)
    {
        double Dummy = 0;
        return double.TryParse(ValueToCheck.ToString(), System.Globalization.NumberStyles.Any, null, out Dummy);
    }

    private void ClearMember()
    {
        txtFirstName.Text = "";
        txtLastName.Text = "";
        txtDOB.Text = ""; ;
        ddSex.SelectedIndex = 0;
        txtNotes.Text = "";
        txtAddress.Text = "";
        txtCity.Text = "";
        txtPostalCode.Text = "";
        txtHomePhone.Text = "";
        txtCellPhone.Text = "";
        txtPreContact.Text = "";
        ddMaritalStatus.SelectedValue = "1";
        txtEmail.Text = "";
        txtFamilyBookNumber.Text = "";
        txtFreeToMarry.Text = "";
        chkActive.Checked = true;
    }
    protected void bSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidateClientInfo())
            {
                DateTime? FreeToMarry = null;
                //int? FamilyBookNumber = null;
                if (!string.IsNullOrWhiteSpace(txtFreeToMarry.Text.Trim()))
                {
                    FreeToMarry = Convert.ToDateTime(txtFreeToMarry.Text);
                }
                //if (!string.IsNullOrWhiteSpace(txtFamilyBookNumber.Text.Trim()))
                //{
                //    FamilyBookNumber = Convert.ToInt32(txtFamilyBookNumber.Text);
                //}
                if ((Session["MemberID"] != null) && (IsNumeric(Session["MemberID"])))
                {
                    MemberID = Convert.ToInt32(Session["MemberID"]);

                    DataClients dC = new DataClients();
                    int updateValue = dC.UpdateMember(MemberID, txtFirstName.Text, txtLastName.Text, Convert.ToDateTime(txtDOB.Text), ddSex.SelectedValue,
                                txtNotes.Text, txtAddress.Text, txtCity.Text, txtPostalCode.Text, txtHomePhone.Text,
                                txtCellPhone.Text, txtPreContact.Text, ddMaritalStatus.SelectedIndex, txtEmail.Text,
                                txtFamilyBookNumber.Text, chkActive.Checked, FreeToMarry);
                    if (updateValue == -1)
                    {
                        lblError.Text = "DB Error.<br/>";
                    }
                    else if (updateValue == -2)
                        lblError.Text = "Family book number exist in the system.<br/>";
                    else
                    {
                        Page.Response.Redirect(Page.ResolveUrl("~/Member.aspx?success=addmember"));
                    }
                }
                else if (bSave.Text == "Save" && Session["MemberID"] == null)
                {
                    DataClients dC = new DataClients();

                    string dv = dC.InsertMember(txtFirstName.Text, txtLastName.Text, Convert.ToDateTime(txtDOB.Text), ddSex.SelectedValue,
                                txtNotes.Text, txtAddress.Text, txtCity.Text, txtPostalCode.Text, txtHomePhone.Text,
                                txtCellPhone.Text, txtPreContact.Text, ddMaritalStatus.SelectedIndex, txtEmail.Text,
                                txtFamilyBookNumber.Text, chkActive.Checked, FreeToMarry);
                    if (IsNumeric(dv) && Convert.ToInt32(dv) == -1)
                    {
                        lblError.Text = "DB Error.<br/>";
                    }
                    else if (IsNumeric(dv) && Convert.ToInt32(dv) == -2)
                        lblError.Text = "Family book number exist in the system.<br/>";
                    else
                    {
                        //lblError.Text = "Successfully Saved";
                        Page.Response.Redirect(Page.ResolveUrl("~/Member.aspx?success=addmember"));
                    }
                }

            }
            else
                lblError.Text = "Please validate your information.<br/>" + msgError.ToString();
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
            if ((txtHomePhone.Text.Trim() == null || txtHomePhone.Text.Trim() == ""))
            {
                bValidate = false;
                msgError.AppendFormat("Enter Home phone #<br/>");
            }
            if ((txtCellPhone.Text.Trim() == null || txtCellPhone.Text.Trim() == ""))
            {
                bValidate = false;
                msgError.AppendFormat("Enter Cell phone #<br/>");
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

            if (ddMaritalStatus.SelectedIndex == 0)
            {
                bValidate = false;
                msgError.AppendFormat("Please select the Marital Status.<br/>");
            }
            if (!string.IsNullOrWhiteSpace(txtFamilyBookNumber.Text.Trim()))
            {
                if (!Utilities.IsNumeric(txtFamilyBookNumber.Text))
                {
                    bValidate = false;
                    msgError.AppendFormat("Enter number only for Family Book #<br/>");
                }
            }
        }
        catch
        {
        }
        return bValidate;
    }

    protected void GetClientInfo()
    {
        DataClients dC = new DataClients();
        DataView dv = dC.GetMemberByMemberID(MemberID);
        DataTable oDataTable = dv.Table;

        txtFirstName.Text = oDataTable.Rows[0]["firstName"].ToString();
        txtLastName.Text = oDataTable.Rows[0]["lastName"].ToString();
        if ((oDataTable.Rows[0]["DOB"] != null) && (oDataTable.Rows[0]["DOB"].ToString().Trim() != ""))
        {
            DateTime dt = Convert.ToDateTime(oDataTable.Rows[0]["DOB"]);
            txtDOB.Text = dt.ToString("MM/dd/yyyy");
        }
        ddSex.SelectedValue = oDataTable.Rows[0]["sex"].ToString();
        txtNotes.Text = oDataTable.Rows[0]["Notes"].ToString();
        txtAddress.Text = oDataTable.Rows[0]["address1"].ToString();
        txtCity.Text = oDataTable.Rows[0]["city"].ToString();
        txtPostalCode.Text = oDataTable.Rows[0]["postalCode"].ToString();
        txtHomePhone.Text = oDataTable.Rows[0]["homePhone"].ToString();
        txtCellPhone.Text = oDataTable.Rows[0]["cellPhone"].ToString();
        txtPreContact.Text = oDataTable.Rows[0]["preferredMethodContact"].ToString();
        ddMaritalStatus.SelectedValue = oDataTable.Rows[0]["MaritalStatusID"].ToString();
        txtEmail.Text = oDataTable.Rows[0]["email"].ToString();
        if (!string.IsNullOrWhiteSpace(oDataTable.Rows[0]["FamilyBookNumber"].ToString()))
        {
            txtFamilyBookNumber.Text = oDataTable.Rows[0]["FamilyBookNumber"].ToString();
            txtFamilyBookNumber.Enabled = false;
        }
        else
        {
            txtFamilyBookNumber.Text = string.Empty;
            txtFamilyBookNumber.Enabled = true;
        }

        if (!string.IsNullOrWhiteSpace(oDataTable.Rows[0]["FreeToMarry"].ToString()))
        {
            DateTime dt = Convert.ToDateTime(oDataTable.Rows[0]["FreeToMarry"]);
            txtFreeToMarry.Text = dt.ToString("MM/dd/yyyy");
        }
        chkActive.Checked = Convert.ToBoolean(oDataTable.Rows[0]["Active"]);
    }
    protected void GetSex()
    {
        ddSex.Items.Insert(0, new ListItem("Select one"));
        ddSex.Items.Insert(1, new ListItem("Male"));
        ddSex.Items.Insert(2, new ListItem("Female"));
    }

    protected void GetMaritalStatus()
    {
        DataClients dC = new DataClients();
        DataView dv = dC.GetMaritalStatus();
        DataTable oDataTable = dv.Table;

        ddMaritalStatus.DataSource = oDataTable;
        ddMaritalStatus.DataTextField = "maritalText";
        ddMaritalStatus.DataValueField = "maritalStatusID";
        ddMaritalStatus.DataBind();
        ddMaritalStatus.Items.Insert(0, new ListItem("Select one"));
        //    cn.Close();
        //}
    }
    protected void GetChurches()
    {
        if ((Session["UserID"] != null) && (IsNumeric(Session["UserID"])))
        {
            int UserID = Convert.ToInt32(Session["UserID"]);
            DataClients dC = new DataClients();
            DataView dv = dC.GetChurchByUserID(UserID);
            DataTable oDataTable = dv.Table;

            ddChurch.DataSource = oDataTable;
            ddChurch.DataTextField = "ChurchName";
            ddChurch.DataValueField = "ChurchID";
            ddChurch.DataBind();
            ddChurch.Items.Insert(0, new ListItem("Select one"));
        }
        //    cn.Close();
        //}
    }
    //protected void GetEducation()
    //{
    //    DataClients dC = new DataClients();
    //    DataView dv = dC.GetClientEducation();
    //    DataTable oDataTable = dv.Table;

    //    ddEducation.DataSource = oDataTable;
    //    ddEducation.DataTextField = "educationText";
    //    ddEducation.DataValueField = "educationID";
    //    ddEducation.DataBind();
    //    ddEducation.Items.Insert(0, new ListItem("Select one"));
    //}
}