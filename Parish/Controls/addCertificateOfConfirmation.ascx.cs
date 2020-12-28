using Parish.DB.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_addCertificateOfConfirmation : System.Web.UI.UserControl
{
    public int MemberID { get; set; }
    public int CertificateTypeID { get; set; }
    protected StringBuilder msgError = new StringBuilder();

    public void AddConfirmations()
    {
        //GetSex();
        if (MemberID != 0)
        {
            Session["MemberID"] = MemberID;
            //bSave.Text = "Update";
        }
        else
        {
            //bSave.Text = "Save";
            ClearCertificate();
        }

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetSex();
            if (MemberID != 0)
            {
                Session["MemberID"] = MemberID;
                bSave.Text = "Update";
            }
            else
            {
                Session["MemberID"] = null;
                bSave.Text = "Save";
                ClearCertificate();
            }
        }
    }
    protected void GetSex()
    {
        ddSex.Items.Insert(0, new ListItem("Select one"));
        ddSex.Items.Insert(1, new ListItem("Male"));
        ddSex.Items.Insert(2, new ListItem("Female"));
    }
    private void ClearCertificate()
    {
        txtName.Text = "";
        chkActive.Checked = true;
        txtParentFatherName.Text = "";
        txtParentMotherName.Text = "";
        txtDOConfirmation.Text = "";
        txtDOBaptism.Text = "";
        txtPlaceOfConfirmation.Text = "";
        txtMinister.Text = "";
        txtDOGiven.Text = "";
        txtParishPriest.Text = "";
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

                string dv = dC.InsertCertifiateOfConfirmation(MemberID, 2, txtName.Text, ddSex.SelectedValue, txtParentFatherName.Text
                    , txtParentMotherName.Text, Convert.ToDateTime(txtDOConfirmation.Text), Convert.ToDateTime(txtDOBaptism.Text)
                    , txtPlaceOfConfirmation.Text, txtMinister.Text, txtParishPriest.Text, Convert.ToDateTime(txtDOGiven.Text), UserID);

                if (Utilities.IsNumeric(dv) && Convert.ToInt32(dv) == -1)
                {
                    lblError.Text = "DB Error.<br/>";
                }
                else
                {
                    ClearCertificate();
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
            if (string.IsNullOrWhiteSpace(txtName.Text.Trim()))
            {
                bValidate = false;
                msgError.AppendFormat("Enter name.<br/>");
            }
            if (ddSex.SelectedIndex == 0)
            {
                bValidate = false;
                msgError.AppendFormat("Please select the sex.<br/>");
            }
            if (string.IsNullOrWhiteSpace(txtParentFatherName.Text.Trim()))
            {
                bValidate = false;
                msgError.AppendFormat("Enter parent father name<br/>");
            }
            if (string.IsNullOrWhiteSpace(txtParentMotherName.Text.Trim()))
            {
                bValidate = false;
                msgError.AppendFormat("Enter parent mother name<br/>");
            }
            if (string.IsNullOrWhiteSpace(txtDOConfirmation.Text.Trim()))
            {
                bValidate = false;
                msgError.AppendFormat("Please select the Date of birth.<br/>");
            }
            else if (Convert.ToDateTime(txtDOConfirmation.Text) > dt)
            {
                bValidate = false;
                msgError.AppendFormat("Date of birth cannot be future date.<br/>");
            }
            if (string.IsNullOrWhiteSpace(txtDOBaptism.Text.Trim()))
            {
                bValidate = false;
                msgError.AppendFormat("Please select the Date of birth.<br/>");
            }
            else if (Convert.ToDateTime(txtDOBaptism.Text) > dt)
            {
                bValidate = false;
                msgError.AppendFormat("Date of birth cannot be future date.<br/>");
            }
            if (string.IsNullOrWhiteSpace(txtPlaceOfConfirmation.Text.Trim()))
            {
                bValidate = false;
                msgError.AppendFormat("Enter sponsor1 name<br/>");
            }
            if (string.IsNullOrWhiteSpace(txtMinister.Text.Trim()))
            {
                bValidate = false;
                msgError.AppendFormat("Enter minister name<br/>");
            }
            if (string.IsNullOrWhiteSpace(txtDOGiven.Text.Trim()))
            {
                bValidate = false;
                msgError.AppendFormat("Please select the Date of given.<br/>");
            }
            else if (Convert.ToDateTime(txtDOGiven.Text) > dt)
            {
                bValidate = false;
                msgError.AppendFormat("Date of birth cannot be future date.<br/>");
            }
            if (string.IsNullOrWhiteSpace(txtParishPriest.Text.Trim()))
            {
                bValidate = false;
                msgError.AppendFormat("Enter parish priest name<br/>");
            }
        }
        catch
        {
        }
        return bValidate;
    }
}