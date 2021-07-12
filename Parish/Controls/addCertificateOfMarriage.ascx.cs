using Parish.DB.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_addCertificateOfMarriage : System.Web.UI.UserControl
{
    public int MemberID { get; set; }
    public int CertificateTypeID { get; set; }
    protected StringBuilder msgError = new StringBuilder();

    public void AddMarriage()
    {
        if (MemberID != 0)
        {
            Session["MemberID"] = MemberID;
        }
        else
        {
            ClearCertificate();
        }

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
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

    private void ClearCertificate()
    {
        txtNameOfBride.Text = "";
        txtNameOfGroom.Text = "";
        chkActive.Checked = true;
        txtGroomFatherName.Text = "";
        txtGroomMotherName.Text = "";
        txtBrideFatherName.Text = "";
        txtBrideMotherName.Text = "";
        txtDOMarriage.Text = "";
        txtWitness1.Text = "";
        txtWitness2.Text = "";
        txtSigned.Text = "";
        txtDOGivenOnDate.Text = "";
        txtParishPriest.Text = "";
        txtGivenPlace.Text = "";
        txtBridegroomDOB.Text = "";
        txtBrideDOB.Text = "";
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

                string dv = dC.InsertCertifiateOfMarriage(MemberID, 4, txtNameOfGroom.Text, txtNameOfBride.Text, txtGroomFatherName.Text
                    , txtGroomMotherName.Text, txtBrideFatherName.Text, txtBrideMotherName.Text, Convert.ToDateTime(txtDOMarriage.Text) 
                    ,txtWitness1.Text
                    , txtWitness2.Text, txtSigned.Text, txtParishPriest.Text, txtGivenPlace.Text, Convert.ToDateTime(txtDOGivenOnDate.Text)
                    , UserID, Convert.ToDateTime(txtBridegroomDOB.Text), Convert.ToDateTime(txtBrideDOB));

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

        lblError.Text = "";
        try
        {
            if (string.IsNullOrWhiteSpace(txtNameOfBride.Text.Trim()))
            {
                bValidate = false;
                msgError.AppendFormat("Enter bride name.<br/>");
            }
            if (string.IsNullOrWhiteSpace(txtNameOfGroom.Text.Trim()))
            {
                bValidate = false;
                msgError.AppendFormat("Enter groom name.<br/>");
            }
            if (string.IsNullOrWhiteSpace(txtGroomFatherName.Text.Trim()))
            {
                bValidate = false;
                msgError.AppendFormat("Enter groom father name<br/>");
            }
            if (string.IsNullOrWhiteSpace(txtGroomMotherName.Text.Trim()))
            {
                bValidate = false;
                msgError.AppendFormat("Enter groom mother name<br/>");
            }
            if (string.IsNullOrWhiteSpace(txtBrideFatherName.Text.Trim()))
            {
                bValidate = false;
                msgError.AppendFormat("Enter bride father name<br/>");
            }
            if (string.IsNullOrWhiteSpace(txtBrideMotherName.Text.Trim()))
            {
                bValidate = false;
                msgError.AppendFormat("Enter bride mother name<br/>");
            }
            if (string.IsNullOrWhiteSpace(txtDOMarriage.Text.Trim()))
            {
                bValidate = false;
                msgError.AppendFormat("Please select the Date of marriage.<br/>");
            }
            else if (DateTime.Parse(txtDOMarriage.Text) > dt)
            {
                bValidate = false;
                msgError.AppendFormat("Date of marriage cannot be future date.<br/>");
            }
            if (string.IsNullOrWhiteSpace(txtDOGivenOnDate.Text.Trim()))
            {
                bValidate = false;
                msgError.AppendFormat("Please select the Date of given.<br/>");
            }
            else if (DateTime.Parse(txtDOGivenOnDate.Text) > dt)
            {
                bValidate = false;
                msgError.AppendFormat("Date of given cannot be future date.<br/>");
            }
            if (string.IsNullOrWhiteSpace(txtWitness1.Text.Trim()))
            {
                bValidate = false;
                msgError.AppendFormat("Enter witness1 name<br/>");
            }
            if (string.IsNullOrWhiteSpace(txtWitness2.Text.Trim()))
            {
                bValidate = false;
                msgError.AppendFormat("Enter witness2 name<br/>");
            }
            if (string.IsNullOrWhiteSpace(txtSigned.Text.Trim()))
            {
                bValidate = false;
                msgError.AppendFormat("Enter signed by name<br/>");
            }
            if (string.IsNullOrWhiteSpace(txtParishPriest.Text.Trim()))
            {
                bValidate = false;
                msgError.AppendFormat("Enter parish priest name<br/>");
            }
            if (string.IsNullOrWhiteSpace(txtGivenPlace.Text.Trim()))
            {
                bValidate = false;
                msgError.AppendFormat("Enter given place<br/>");
            }
            if (string.IsNullOrWhiteSpace(txtBridegroomDOB.Text.Trim()))
            {
                bValidate = false;
                msgError.AppendFormat("Please select bride groom Date of birth.<br/>");
            }
            if (string.IsNullOrWhiteSpace(txtBrideDOB.Text.Trim()))
            {
                bValidate = false;
                msgError.AppendFormat("Please select bride Date of birth.<br/>");
            }
        }
        catch
        {
        }
        return bValidate;
    }
}