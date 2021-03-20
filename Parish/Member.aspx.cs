using MacSS.UI.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Parish.DB.Modules;
using System.Data;
using System.Globalization;
using System.Threading;

public partial class Member : PageBase
{
    private int _memberID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Request.Params["success"] != null))
        {
            string Msg = Request.Params["success"];
            if (Msg.ToLower() == "addmember")
                lblError.Text = "Successfully Saved";
        }
        if (!Page.IsPostBack)
        {
            GetMembers();
            GetCertificateTypes();
            if ((Session["MemberID"] != null) && (Utilities.IsNumeric(Session["MemberID"])))
            {
                _memberID = Convert.ToInt32(Session["MemberID"]);
                //ddClient.SelectedIndex = _memberID;
                GetSelectedMember();
                divSelectedMember.Visible = true;
                divClientinfo.Visible = false;
                divMembers.Visible = false;
            }
        }
    }
    protected override void InitializeCulture()
    {
        CultureInfo ci = new CultureInfo("ta-IN");
        ci.NumberFormat.CurrencySymbol = "Rs";
        Thread.CurrentThread.CurrentCulture = ci;

        base.InitializeCulture();
    }
    //not using
    protected void GetMember_Selected(object sender, EventArgs e)
    {
        GetSelectedMember();
        GetCertificateTypes();
    }

    protected void btnAddMember_Click(object sender, EventArgs e)
    {
        //ddClient.SelectedIndex = 0;
        Session["MemberID"] = null;
        this.addMember.MemberID = 0;
        addMember.EditMember();
        divClientinfo.Visible = true;
        divSelectedMember.Visible = false;
        divMembers.Visible = false;
        divSelectedMemberAction.Visible = false;
    }

    protected void btnDependent_Click(object sender, EventArgs e)
    {
        _memberID = Convert.ToInt32(Session["MemberID"]);
        SetDivNotVisible();
        divDependent.Visible = true;
        divSelectedMemberAction.Visible = true;
        divSelectedMember.Visible = false;
        addDependent.MemberID = _memberID;
        addDependent.AddDependents();
    }
    protected void btnDonation_Click(object sender, EventArgs e)
    {
        _memberID = Convert.ToInt32(Session["MemberID"]);
        SetDivNotVisible();
        divDonation.Visible = true;
        divSelectedMemberAction.Visible = true;
        divSelectedMember.Visible = false;
        addDonation.MemberID = _memberID;
        addDonation.AddDonation();
    }
    protected void btnCertificate_Click(object sender, EventArgs e)
    {
        _memberID = Convert.ToInt32(Session["MemberID"]);
        SetDivNotVisible();
        divSelectedMemberAction.Visible = true;
        divSelectedMember.Visible = false;
        if (ddCertificateType.SelectedItem.Text == "Baptism")
        {
            divBaptism.Visible = true;
            addCertificateOfBaptism.MemberID = _memberID;
            addCertificateOfBaptism.AddBaptism();
        }
        if (ddCertificateType.SelectedItem.Text == "Confirmation")
        {
            divConfirmation.Visible = true;
            addCertificateOfConfirmation.MemberID = _memberID;
            addCertificateOfConfirmation.AddConfirmations();
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        GetSelectedMember();
        divSelectedMember.Visible = false;
        divClientinfo.Visible = false;
        divMembers.Visible = false;
        //Session["MemberID"] = null;
        SetDivNotVisible();
        divSelectedMember.Visible = true;
        divSelectedMemberAction.Visible = true;
    }

    protected void lnkEdit_Command(object sender, CommandEventArgs e)
    {
        int memberID = Convert.ToInt32(e.CommandArgument);
        addMember.MemberID = memberID;
        addMember.EditMember();
        divClientinfo.Visible = true;
        divSelectedMemberAction.Visible = true;
        divSelectedMember.Visible = false;
    }
    protected void lnkEditCertificate_Command(object sender, CommandEventArgs e)
    {
        //int memberID = Convert.ToInt32(e.CommandArgument);
        //addMember.MemberID = memberID;
        //addMember.EditMember();
        //divClientinfo.Visible = true;
    }
    
    protected void lnkSelect_Command(object sender, CommandEventArgs e)
    {
        int memberID = Convert.ToInt32(e.CommandArgument);
        Session["MemberID"] = memberID;
        GetSelectedMember();
        GetCertificateTypes();        
        //SetDivNotVisible();
        //addMember.MemberID = memberID;
        //addMember.EditMember();
        //divClientinfo.Visible = true;
    }
    
    protected void lnkRemove_Click(object sender, EventArgs e)
    {

    }
    protected void grdMembers_OnPaging(object sender, GridViewPageEventArgs e)
    {
        grdMembers.PageIndex = e.NewPageIndex;
        GetMembers();
    }
    protected void Search(object sender, EventArgs e)
    {
        GetMembers();
    }
    protected void GetSelectedMember()
    {
        //if (Utilities.IsNumeric(ddClient.SelectedItem.Value))
        //{
        //    int memberID = Convert.ToInt32(ddClient.SelectedItem.Value);
        //    Session["MemberID"] = ddClient.SelectedItem.Value;
        //    DataClients dC = new DataClients();
        //    DataView dv = dC.GetMemberByMemberID(memberID);
        //    DataTable oDataTable = dv.Table;

        //    grdSelectedMember.DataSource = oDataTable;
        //    grdSelectedMember.DataBind();

        //    divSelectedMember.Visible = true;
        //    divClientinfo.Visible = false;
        //}
        if ((Session["MemberID"] != null) && (Utilities.IsNumeric(Session["MemberID"])))
        {
            int memberID = Convert.ToInt32(Session["MemberID"]);
            DataClients dC = new DataClients();
            DataView dv = dC.GetMemberByMemberID(memberID);
            DataTable oDataTable = dv.Table;
            
            DataRow dr = oDataTable.Rows[0];
            lblmemberName.Text = dr["FirstName"].ToString() + " " + dr["LastName"].ToString();


            grdSelectedMember.DataSource = oDataTable;
            grdSelectedMember.DataBind();

            SetDivNotVisible();
            divSelectedMember.Visible = true;
            divSelectedMemberAction.Visible = true;
            divClientinfo.Visible = false;
            divMembers.Visible = false;

            GetDependents();
            GetDonations();
            GetCertificates();
        }
        else
        {
            _memberID = 0;
            Session["MemberID"] = null;
            divClientinfo.Visible = false;
            divSelectedMember.Visible = false;
            divMembers.Visible = true;
        }
    }

    protected void SetDivNotVisible()
    {
        divDonation.Visible = false;
        divDependent.Visible = false;
        divClientinfo.Visible = false;
        divBaptism.Visible = false;
        divConfirmation.Visible = false;
        divDeath.Visible = false;
        divMarriage.Visible = false;

        //divMembers.Visible = false;
        //divClientinfo.Visible = false;
        //divSelectedMemberAction.Visible = true;
        //divSelectedMember.Visible = false;
    }
    protected void GetMembers()
    {
        DataClients dC = new DataClients();
        DataView dv = dC.GetMembersFirstLastName();
        DataTable oDataTable = dv.Table;

        //ddClient.DataSource = oDataTable;
        //ddClient.DataTextField = "name";
        //ddClient.DataValueField = "MemberID";
        //ddClient.DataBind();
        //ddClient.Items.Insert(0, new ListItem("Select one"));

        DataView dvm = dC.GetMembers(txtSearch.Text.Trim());
        DataTable oDataTableMembers = dvm.Table;
        grdMembers.DataSource = oDataTableMembers;
        grdMembers.DataBind();
        //}
    }
    protected void GetCertificateTypes()
    {
        DataClients dC = new DataClients();
        DataView dv = dC.GetCertificateTypes();
        DataTable oDataTable = dv.Table;

        ddCertificateType.DataSource = oDataTable;
        ddCertificateType.DataTextField = "CertificateType";
        ddCertificateType.DataValueField = "CertificateTypeID";
        ddCertificateType.DataBind();
        ddCertificateType.Items.Insert(0, new ListItem("Select one"));
        //}
    }

    protected void GetDependents()
    {
        if ((Session["MemberID"] != null) && (Utilities.IsNumeric(Session["MemberID"])))
        {
            _memberID = Convert.ToInt32(Session["MemberID"]);
            DataClients dC = new DataClients();
            DataView dv = dC.GetDependentsByMemberID(_memberID);
            DataTable oDataTable = dv.Table;

            grdDependents.DataSource = oDataTable;
            grdDependents.DataBind();
        }
    }
    protected void GetDonations()
    {
        if ((Session["MemberID"] != null) && (Utilities.IsNumeric(Session["MemberID"])))
        {
            _memberID = Convert.ToInt32(Session["MemberID"]);
            DataClients dC = new DataClients();
            DataView dv = dC.GetDonationsByMemberID(_memberID);
            DataTable oDataTable = dv.Table;

            grdDonations.DataSource = oDataTable;
            grdDonations.DataBind();
        }
    }

    protected void GetCertificates()
    {
        if ((Session["MemberID"] != null) && (Utilities.IsNumeric(Session["MemberID"])))
        {
            _memberID = Convert.ToInt32(Session["MemberID"]);
            DataClients dC = new DataClients();
            DataView dv = dC.GetCertificatesByMemberID(_memberID);
            DataTable oDataTable = dv.Table;

            grdCertificates.DataSource = oDataTable;
            grdCertificates.DataBind();
        }
    }
}