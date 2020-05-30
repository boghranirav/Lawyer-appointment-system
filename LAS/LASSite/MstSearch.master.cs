using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MstSearch : System.Web.UI.MasterPage
{
    DBConnectionClass dbCommon = new DBConnectionClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.LoadComplete += new EventHandler(Page_LoadComplete);
    }
    void Page_LoadComplete(object sender, EventArgs e)
    {
            if (dbCommon.GetUpdateId("qryStrSearch") != "None")
            {
                searchQuery.Text = dbCommon.GetUpdateId("qryStrSearch");
            }
            else
            {
                searchQuery.Text = "";
            }
    }

    protected void searchQuery_TextChanged(object sender, EventArgs e)
    {
        if (searchQuery.Text != "")
        {
            dbCommon.SetUpdateId("qryStrSearch", searchQuery.Text);
            Response.Redirect("search_lawyer.aspx");
        }
        else
        {
            dbCommon.SetUpdateId("qryStrSearch", "None");
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (searchQuery.Text != "")
        {
            dbCommon.SetUpdateId("qryStrSearch", searchQuery.Text);
            Response.Redirect("search_lawyer.aspx");
        }
        else
        {
            dbCommon.SetUpdateId("qryStrSearch", "None");
        }

    }
}
