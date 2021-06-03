using Parish.DB.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_addCertificateOfDeath : System.Web.UI.UserControl
{
    public int MemberID { get; set; }
    public int CertificateTypeID { get; set; }
    protected StringBuilder msgError = new StringBuilder();

    public void AddDeath()
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
        txtAddress.Text = "";
        txtAge.Text = "";
        txtDODeath.Text = "";
        txtDOBurial.Text = "";
        txtPlaceOfBurial.Text = "";
        //txtDOGiven.Text = "";
        txtDeed.Text = "";
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

                string dv = dC.InsertCertifiateOfDeath(MemberID, 3, txtName.Text, ddSex.SelectedValue, Convert.ToInt32(txtAge.Text)
                    , txtAddress.Text, Convert.ToDateTime(txtDODeath.Text), Convert.ToDateTime(txtDOBurial.Text), txtPlaceOfBurial.Text
                    , Convert.ToDateTime(txtDOGiven.Text), txtParishPriest.Text, UserID, txtDeed.Text);

                if (Utilities.IsNumeric(dv) && Convert.ToInt32(dv) == -1)
                {
                    lblError.Text = "DB Error.<br/>";
                }
                else
                {
                    ClearCertificate();
                    lblError.Text = "Success: The death certificate added to the system.";
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
            if (string.IsNullOrWhiteSpace(txtAddress.Text.Trim()))
            {
                bValidate = false;
                msgError.AppendFormat("Enter address<br/>");
            }
            if (string.IsNullOrWhiteSpace(txtAge.Text.Trim()))
            {
                bValidate = false;
                msgError.AppendFormat("Enter age<br/>");
            }
            if (!Utilities.IsNumeric(txtAge.Text) && Convert.ToInt32(txtAge.Text) < 0)
            {
                bValidate = false;
                msgError.AppendFormat("Please number that greater than 0<br/>");
            }            
            if (string.IsNullOrWhiteSpace(txtDODeath.Text.Trim()))
            {
                bValidate = false;
                msgError.AppendFormat("Please select the Date of death.<br/>");
            }
            else if (DateTime.Parse(txtDODeath.Text) > dt)
            {
                bValidate = false;
                msgError.AppendFormat("Date of death cannot be future date.<br/>");
            }
            if (DateTime.Parse(txtDOBurial.Text) > dt)
            {
                bValidate = false;
                msgError.AppendFormat("Date of burial cannot be future date.<br/>");
            }
            else if(string.IsNullOrWhiteSpace(txtDOBurial.Text.Trim()))
            {
                bValidate = false;
                msgError.AppendFormat("Please select the Date of burial.<br/>");
            }                        
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
            if (string.IsNullOrWhiteSpace(txtPlaceOfBurial.Text.Trim()))
            {
                bValidate = false;
                msgError.AppendFormat("Enter place of burial.<br/>");
            }
        }
        catch
        {
        }
        return bValidate;
    }
}