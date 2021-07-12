using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_addMemberPhoto : System.Web.UI.UserControl
{
    public int MemberID { get; set; }
    public int ChurchID { get; set; }

    protected StringBuilder msgError = new StringBuilder();
    protected void Page_Load(object sender, EventArgs e)
    {

        MemberID = Convert.ToInt32(Session["MemberID"]);
        ChurchID = (Session["ChurchID"] != null && !string.IsNullOrWhiteSpace(Session["ChurchID"].ToString()))
            ? Convert.ToInt32(Session["ChurchID"]) : 0;

        tPhoto.Visible = true;
        if (MemberID == 0 || ChurchID == 0)
        {
            lblError.Text = "Please contact admin, uploading image has an issue.";
            tPhoto.Visible = false;
        }           
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {
            MemberID = Convert.ToInt32(Session["MemberID"]);

            string strChurchName = Session["ChurchID"].ToString();
            string strFileName = fileMemberPhoto.PostedFile.FileName;
            string strFileEx = Path.GetExtension(strFileName);
            strFileName = MemberID.ToString() + strFileEx;
            string strFilePath;
            string strFolder = "~/MemberPhoto/" + strChurchName + "/";
            strFolder = Server.MapPath(strFolder);
            if (fileMemberPhoto.HasFile)
            {
                if (!Directory.Exists(strFolder))
                    Directory.CreateDirectory(strFolder);
                strFilePath = strFolder + strFileName;
                if (File.Exists(strFilePath))
                    File.Delete(strFilePath);

                fileMemberPhoto.PostedFile.SaveAs(strFilePath);
            }
        }
        catch (Exception ex)
        {
            lblError.Text = "Please contact admin, uploading image has an issue.<br/>" + ex.Message + msgError.ToString();
        }
        //string strFileName = fileMemberPhoto.PostedFile.FileName;
        //strFileName = Path.GetFileName(strFileName);
        //strFileName = AppendTimeStamp(strFileName);
        //string strFilePath;
        //string strFolder = "~/MemberPhoto/Temp/";
        //if(fileMemberPhoto.HasFile)
        //{
        //    if (!Directory.Exists(strFolder))
        //        Directory.CreateDirectory(strFolder);
        //    strFilePath = strFolder + strFileName;
        //    if (File.Exists(strFilePath))
        //        File.Delete(strFilePath);

        //    fileMemberPhoto.PostedFile.SaveAs(Server.MapPath(strFolder) + strFileName);
        //}

    }
}