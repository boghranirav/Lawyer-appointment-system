using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class profile : System.Web.UI.Page
{
    DBConnectionClass dbCommon = new DBConnectionClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["Suser_type"] == null)
        {
            Response.Redirect("index.aspx");
        }

        if (!IsPostBack)
        {
            fillData();
        }

    }

    public void fillData()
    {
        string sqlStr = "";
        sqlStr = "select a.first_name,a.last_name,a.mobile_no,a.email_id,b.address_line1, b.address_line2,b.address_line3,b.gender,b.date_of_birth " +
                 " from LAS_login a left join LAS_user b on b.login_id=a.login_id " +
                 " where a.login_id='"+Session["Slogin_id"] +"' ";

        DataTable dt = new DataTable();

        dt = dbCommon.DisplayDataQuery(sqlStr).Tables[0];
        foreach(DataRow dr in dt.Rows)
        {
            txtFirstName.Text = dr["first_name"].ToString();
            txtLastName.Text = dr["last_name"].ToString();
            txtMobile.Text = dr["mobile_no"].ToString();
            lblEmai.Text = dr["email_id"].ToString();

            txtAddress1.Text = dr["address_line1"].ToString();
            txtAddress2.Text = dr["address_line2"].ToString();
            txtAddress3.Text = dr["address_line3"].ToString();

            cmbGender.SelectedValue = dr["gender"].ToString();
            if (dr["date_of_birth"].ToString() != "")
            {
                txtDOB.Text = DateTime.Parse(dr["date_of_birth"].ToString()).ToString("yyyy-MM-dd");
            }
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string sqlStr = "";
        sqlStr = "update LAS_login set first_name='" + txtFirstName.Text.ToString() + "', last_name='" + txtLastName.Text.ToString() + "', " +
                " mobile_no='" + txtMobile.Text.ToString() + "' where login_id='" + Session["Slogin_id"].ToString() + "' ";

        if (dbCommon.boolInsertData(sqlStr) == true)
        {
            sqlStr = "delete from LAS_user where login_id='"+ Session["Slogin_id"].ToString() + "' ;";
            sqlStr  = sqlStr  + "insert into LAS_user (login_id, address_line1,address_line2,address_line3,gender,date_of_birth) " + 
                    " Values('"+ Session["Slogin_id"].ToString() + "','" + txtAddress1.Text.ToString()+ "', '"+txtAddress2.Text.ToString()+"', " +
                    " '"+txtAddress3.Text.ToString()+"', '"+cmbGender.SelectedValue.ToString()+"', '"+ DateTime.Parse(txtDOB.Text.ToString()).ToString("yyyy-MM-dd") +"')  ";

            if (dbCommon.boolInsertData(sqlStr) == true)
            {
                Response.Redirect("profile.aspx");
            }
        }
    }
}