using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class lawyer_profile : System.Web.UI.Page
{
    DBConnectionClass dbCommon = new DBConnectionClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["Suser_type"] == null)
        {
            Response.Redirect("../LogOut.aspx");
        }

        if (!IsPostBack)
        {
            Fill_Combo_area();
            fillData();
        }
    }

    protected void Fill_Combo_area()
    {

        DataTable dtCat = new DataTable();
        dtCat = dbCommon.DisplayDataQuery("select * from LAS_specialization").Tables[0];
        cmbSpec.Items.Clear();
        cmbSpec.Items.Add(new ListItem("Select Specialization", "select"));
        foreach (DataRow drUserInfo in dtCat.Rows)
        {
            cmbSpec.Items.Add(new ListItem(drUserInfo["description"].ToString(), drUserInfo["specialization_id"].ToString()));
        }
    }

    public void fillData()
    {
        string sqlP = "select a.mobile_no,a.email_id ,a.first_name,a.last_name, " + 
                     "   b.address_line1,b.address_line2,b.address_line3,b.date_of_birth,b.description,  " +
                     "   b.issued_on,b.license_no,b.specialization_id,b.profile_photo " +
                     "   from LAS_login a " +
                     "   left join LAS_lawyer_profile b on a.login_id = b.login_id" +
                     " where a.login_id='" + Session["Slogin_id"].ToString() + "'";
        DataTable dt = new DataTable();
        dt = dbCommon.DisplayDataQuery(sqlP).Tables[0];

        if (dt.Rows.Count >= 0)
        {
            btnsubmit.Text = "Update";
            foreach (DataRow dr in dt.Rows)
            {
                txtFirstName.Text = dr["first_name"].ToString();
                txtLastName.Text = dr["last_name"].ToString();
                txtMobile.Text = dr["mobile_no"].ToString();
                txtEmail.Text = dr["email_id"].ToString();
                if (dr["address_line1"].ToString() == "") { btnsubmit.Text = "Submit"; }
                txtaddress1.Text = dr["address_line1"].ToString();
                txtaddress2.Text = dr["address_line2"].ToString();
                txtaddress3.Text = dr["address_line3"].ToString();
                cmbSpec.SelectedValue = dr["specialization_id"].ToString();
                txtDescription.Text = dr["description"].ToString();
                txtLicenseNo.Text = dr["license_no"].ToString();
                if (dr["date_of_birth"].ToString() != "")
                {
                    txtbirthdate.Text = Convert.ToDateTime(dr["date_of_birth"].ToString()).ToString("yyyy-MM-dd");
                }
                if (dr["issued_on"].ToString() != "")
                {
                    txtIssuedOn.Text = Convert.ToDateTime(dr["issued_on"].ToString()).ToString("yyyy-MM-dd"); 
                }
                byte[] bytes;
                try
                {
                    bytes = (byte[])dr["profile_photo"];
                    Session["imageupdate"] = bytes;
                    string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                    displayImg.ImageUrl = "data:image/png;base64," + base64String;

                }
                catch (Exception)
                {
                    bytes = null;
                }
            }
            
        }
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {

        Byte[] bytes = null;
        String ext = imgCategoryImage.PostedFile.ContentType;

        try
        {
            if (ext.ToLower() == "image/jpeg" || ext.ToLower() == "image/jpg" || ext.ToLower() == "image/png")
            {

                if (imgCategoryImage.PostedFile.ContentLength > 0)
                {
                    Stream fs = imgCategoryImage.PostedFile.InputStream;
                    BinaryReader br = new BinaryReader(fs);
                    bytes = br.ReadBytes((Int32)fs.Length);


                }
            }
            else
            if (Session["imageupdate"] != null)
            {
                bytes = (Byte[])Session["imageupdate"];
            }
            else
            {
                bytes = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
            }

            List<SqlParameter> sqlp = new List<SqlParameter>();
            sqlp.Add(new SqlParameter("@profie_photo", bytes));
            sqlp.Add(new SqlParameter("@description", txtDescription.Text.ToString()));
            sqlp.Add(new SqlParameter("@speci_id", cmbSpec.SelectedValue.ToString()));
            sqlp.Add(new SqlParameter("@license_no", txtLicenseNo.Text.ToString()));
            sqlp.Add(new SqlParameter("@issued_on", DateTime.Parse(txtIssuedOn.Text.ToString()).ToString("yyyy-MM-dd")));
            sqlp.Add(new SqlParameter("@date_of_birth", DateTime.Parse(txtbirthdate.Text.ToString()).ToString("yyyy-MM-dd")));
            sqlp.Add(new SqlParameter("@address_line1", txtaddress1.Text.ToString().Trim()));
            sqlp.Add(new SqlParameter("@address_line2", txtaddress2.Text.ToString().Trim()));
            sqlp.Add(new SqlParameter("@address_line3", txtaddress3.Text.ToString().Trim()));
            sqlp.Add(new SqlParameter("@login_id", Session["Slogin_id"].ToString()));

            if (dbCommon.boolInsertData("Update LAS_login set first_name='" + txtFirstName.Text.ToString().Trim() + "', " +
                                        " last_name='" + txtLastName.Text.ToString().Trim() + "', mobile_no='" + txtMobile.Text.ToString().Trim() + "' " +
                                        " where login_id='" + Session["Slogin_id"].ToString() + "' ") == true)
            {
                if (btnsubmit.Text == "Submit")
                {
                    DBConnectionClass dbSp = new DBConnectionClass("insertLawyerProfile");
                    if (dbSp.SaveData(sqlp) == true)
                    {
                        Response.Redirect("profile.aspx");
                    }
                }
                else
                {
                    DBConnectionClass dbSp = new DBConnectionClass("updateLawyerProfile");

                    if (dbSp.SaveData(sqlp) == true)
                    {
                        Response.Redirect("profile.aspx");
                    }
                }
            }
        }
        catch (Exception) { }
    }
}