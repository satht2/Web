using Parish.DB.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

public partial class Controls_addCertificateOfBaptism : System.Web.UI.UserControl
{
    public int MemberID { get; set; }
    public int CertificateTypeID { get; set; }
    protected StringBuilder msgError = new StringBuilder();

    public void AddBaptism()
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
        txtDOB.Text = "";
        txtDOBaptism.Text = "";
        txtSponsor1.Text = "";
        txtSponsor2.Text = "";
        txtMinister.Text = "";
        //txtFirstHolyCommunion.Text = "";
        //txtConfirmation.Text = "";
        txtDOGiven.Text = "";
        txtParishPriest.Text = "";
    }
    protected void bSave_Click(object sender, EventArgs e)
    {
        try
        {
            lblError.ForeColor = System.Drawing.Color.Red;
            if (ValidateClientInfo())
            {
                MemberID = Convert.ToInt32(Session["MemberID"]);
                int UserID = Convert.ToInt32(Session["UserID"]);
                DataClients dC = new DataClients();

                string dv = dC.InsertCertifiateOfBaptism(MemberID, 1, txtName.Text, ddSex.SelectedValue, txtParentFatherName.Text
                    , txtParentMotherName.Text, Convert.ToDateTime(txtDOB.Text), Convert.ToDateTime(txtDOBaptism.Text), txtSponsor1.Text
                    , txtSponsor2.Text, txtMinister.Text, null, null, Convert.ToDateTime(txtDOGiven.Text)
                    , txtParishPriest.Text, UserID);

                if (Utilities.IsNumeric(dv) && Convert.ToInt32(dv) == -1)
                {
                    lblError.Text = "DB Error.<br/>";
                }
                else
                {
                    ClearCertificate();
                    lblError.Text = "Success: The confirmation certificate added to the system.";
                    lblError.ForeColor = System.Drawing.Color.Green;
                }
            }
            else
                lblError.Text = msgError.ToString();
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

        //DateTime dateOB;
        //DateTime.TryParse(txtDOB.Text, out dateOB);
        //DateTime dateOB;
        //DateTime.TryParse(txtDOB.Text, out dateOB);
        //DateTime dateOB;
        //DateTime.TryParse(txtDOB.Text, out dateOB);

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
            if (string.IsNullOrWhiteSpace(txtDOB.Text.Trim()))
            {
                bValidate = false;
                msgError.AppendFormat("Please select the Date of birth.<br/>");
            }
            else if (DateTime.Parse(txtDOB.Text) > dt)
            {
                bValidate = false;
                msgError.AppendFormat("Date of birth cannot be future date.<br/>");
            }
            if (string.IsNullOrWhiteSpace(txtDOBaptism.Text.Trim()))
            {
                bValidate = false;
                msgError.AppendFormat("Please select the Date of birth.<br/>");
            }
            else if (DateTime.Parse(txtDOBaptism.Text) > dt)
            {
                bValidate = false;
                msgError.AppendFormat("Date of birth cannot be future date.<br/>");
            }
            if (string.IsNullOrWhiteSpace(txtSponsor1.Text.Trim()))
            {
                bValidate = false;
                msgError.AppendFormat("Enter sponsor1 name<br/>");
            }
            if (string.IsNullOrWhiteSpace(txtSponsor2.Text.Trim()))
            {
                bValidate = false;
                msgError.AppendFormat("Enter sponsor2 name<br/>");
            }
            if (string.IsNullOrWhiteSpace(txtMinister.Text.Trim()))
            {
                bValidate = false;
                msgError.AppendFormat("Enter minister name<br/>");
            }
            //if (string.IsNullOrWhiteSpace(txtFirstHolyCommunion.Text.Trim()))
            //{
            //    bValidate = false;
            //    msgError.AppendFormat("Enter first holy communion<br/>");
            //}
            //if (string.IsNullOrWhiteSpace(txtConfirmation.Text.Trim()))
            //{
            //    bValidate = false;
            //    msgError.AppendFormat("Enter confirmation<br/>");
            //}
            if (string.IsNullOrWhiteSpace(txtDOGiven.Text.Trim()))
            {
                bValidate = false;
                msgError.AppendFormat("Please select the Date of given.<br/>");
            }
            else if (DateTime.Parse(txtDOGiven.Text) > dt)
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