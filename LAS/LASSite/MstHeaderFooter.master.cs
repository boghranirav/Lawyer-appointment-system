using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MstHeaderFooter : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["Suser_type"] == null)
        {
            lblAction.Visible = true;
            lblLogout.Visible = false;
            lblLogin.Visible = true;
            lblUser.Visible = false;
        }
        else
        if (Session["Suser_type"].ToString() == "user")
        {
            string s = Session["Suser_type"].ToString();
            lblAction.Visible = false;
            lblLogout.Visible = true;
            lblLogin.Visible = false;
            lblUser.Visible = true;
        }

    }
}
