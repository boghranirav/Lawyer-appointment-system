﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_AdminMasterPageHeader : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["Suser_type"] == null)
        {
            Response.Redirect("../LogOut.aspx");
        }
        else
         if (Session["Suser_type"].ToString() != "lawyer")
        {
            Response.Redirect("../logout.aspx");
        }

    }
}
