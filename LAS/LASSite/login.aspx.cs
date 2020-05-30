using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    DBConnectionClass dbCommon = new DBConnectionClass();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string sql = "";

        sql = "select login_id,active_flag,user_type,first_name,last_name from LAS_Login where email_id='"+ txtEmail.Text.ToString().Trim()+"' and Password='"+ dbCommon.HashId(txtPassword.Text.ToString())+"' ";

        DataTable dt = new DataTable();
        dt=dbCommon.DisplayDataQuery(sql).Tables[0];
        if (dt.Rows.Count <= 0)
        {
            lblLogin.Visible = true;
            lblLogin.Text = "Invalid Login Id or Password.";
        }
        else
        {
            foreach (DataRow dr in dt.Rows)
            {
                switch (dr["active_flag"].ToString())
                {
                    case "1":
                        lblLogin.Visible = true;
                        lblLogin.Text = "Your account is deactivated. Contact admin to activate.";
                        break;
                    //case "0":
                    case  "0":
                        lblLogin.Visible = false;
                        Session["Slogin_id"] = dr["login_id"].ToString();
                        Session["Suser_type"] = dr["user_type"].ToString();
                        Session["Sfirst_name"] = dr["first_name"].ToString();
                        Session["Slast_name"] = dr["last_name"].ToString();
                        switch (dr["user_type"].ToString())
                        {
                            case "user":
                                if (dbCommon.IsEmptyUpdateId("bookTime") && dbCommon.IsEmptyUpdateId("officeId"))
                                {
                                    Response.Redirect("confirmbook.aspx");
                                }
                                else
                                {
                                    Response.Redirect("index.aspx");
                                }
                                break;
                            case "admin":
                                Response.Redirect("admin/s_lawyer.aspx");
                                break;
                            case "lawyer":
                                Response.Redirect("lawyer/index.aspx");
                                break;
                        }
                        break;
                }

            }
        }
    }
}