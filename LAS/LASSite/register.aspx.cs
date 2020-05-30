using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class register : System.Web.UI.Page
{
    DBConnectionClass dbCommon = new DBConnectionClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (lblEmail_V.Text == "")
        {
            DBConnectionClass con = new DBConnectionClass("createNewUser");
            List<SqlParameter> sqlp = new List<SqlParameter>();
            sqlp.Add(new SqlParameter("@first_name", txtFName.Text.ToString().Trim()));
            sqlp.Add(new SqlParameter("@last_name", txtLName.Text.ToString().Trim()));
            sqlp.Add(new SqlParameter("@email_id", txtEmail.Text.ToString().Trim()));
            sqlp.Add(new SqlParameter("@mobile_no", txtMobile.Text.ToString().Trim()));
            sqlp.Add(new SqlParameter("@password", con.HashId(txtPassword.Text.ToString())));
            sqlp.Add(new SqlParameter("@user_type", cmbUserType.SelectedValue.ToString()));

            if (con.SaveData(sqlp) == true)
            {
                Response.Redirect("login.aspx");
            }
            else
            {

            }
        }

    }

    protected void txtEmail_TextChanged(object sender, EventArgs e)
    {
        int i = 0;
        string sqlQuery = "";

        sqlQuery = "select Count(login_id) from LAS_Login " +
                   " where email_id='" + txtEmail.Text.Trim() + "'";

        i = dbCommon.CheckDuplicateByQuery(sqlQuery);

        if (i >= 1)
        {
            lblEmail_V.Text = "*Email Id Exist.";
        }
        else
        {
            lblEmail_V.Text = "";
        }
        
    }
}