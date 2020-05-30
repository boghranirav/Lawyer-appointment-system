using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class lawyer_experience : System.Web.UI.Page
{
    DBConnectionClass dbCommon = new DBConnectionClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["Suser_type"] == null)
        {
            Response.Redirect("../LogOut.aspx");
        }

        if (Request.QueryString.AllKeys.Length > 1)
        {
            Response.Redirect("../logout.aspx");
        }


        if (!IsPostBack)
        {
            fillTable();

            if (Request.QueryString.AllKeys.Contains("eid"))
            {
                if (!Request.QueryString["eid"].ToString().All(char.IsDigit))
                {
                    Response.Redirect("../logout.aspx");
                }
                btnSubmit.Text = "Update";

                string id = Request.QueryString["eid"];

                ViewState["id"] = Request.QueryString["eid"];

                DataTable dt = new DataTable();
                dt = dbCommon.DisplayDataQuery("select * from LAS_experience where experience_id='" + id + "'").Tables[0];

                if (dt.Rows.Count == 0) { Response.Redirect("experience.aspx"); }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        txtfrom.Text = Convert.ToDateTime(dr["from_date"].ToString()).ToString("yyyy-MM-dd");
                        txttodate.Text = Convert.ToDateTime(dr["to_date"].ToString()).ToString("yyyy-MM-dd");
                        txtdescription.Text = dr["description"].ToString();
                    }
                }
            }
            else if (Request.QueryString.AllKeys.Length == 1)
            {
                Response.Redirect("../Logout.aspx");
            }
        }
    }

    public void fillTable()
    {
        string sqlP = "select * from LAS_experience where login_id='" + Session["Slogin_id"].ToString() + "' ";

        DataTable dt = new DataTable();
        dt = dbCommon.DisplayDataQuery(sqlP).Tables[0];
        StringBuilder html = new StringBuilder();
        foreach (DataRow dr in dt.Rows)
        {
            html.Append("<tr>");
            html.Append("<td>" + Convert.ToDateTime(dr["from_date"].ToString()).ToString("yyyy-MM-dd")+ "</td>");
            html.Append("<td>" + Convert.ToDateTime(dr["to_date"].ToString()).ToString("yyyy-MM-dd") + "</td>");
            html.Append("<td>" + dr["description"] + "</td>");
            html.Append("<td align='center' width='4%'><a href='experience.aspx?eid=" + dr["experience_id"].ToString() + "'><i class='fa fa-1x fa-pencil'></i></a></td>");
            html.Append("<td align='center' width='4%'><a href='Javascript:deletefunction(" + dr["experience_id"].ToString() + ");'><i class='fa fa-1x fa-trash-o'></i></a></td>");
            html.Append("</tr>");
        }
        displayService.InnerHtml = html.ToString();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
            if (btnSubmit.Text == "Submit")
            {
                int maxId = dbCommon.CheckDuplicateByQuery("select IsNUll(Max(experience_id),0)+1 from LAS_experience");
                bool b = dbCommon.boolInsertData("insert into LAS_experience (experience_id,login_id,from_date,to_date,description) " +
                                        " values('" + maxId + "', '" + Session["Slogin_id"].ToString() + "', " +
                                        " '" + DateTime.Parse(txtfrom.Text.ToString()).ToString("yyyy-MM-dd") + "','" + DateTime.Parse(txttodate.Text.ToString()).ToString("yyyy-MM-dd") + "', " + 
                                        " '"+txtdescription.Text.ToString().Trim()+"') ");

                if (b == true)
                {
                    Response.Redirect("experience.aspx");
                }
            }
            else
            {
                bool b = dbCommon.boolInsertData("update LAS_experience set description='" + txtdescription.Text.ToString().Trim() + "', from_date='" + DateTime.Parse(txtfrom.Text.ToString()).ToString("yyyy-MM-dd") + "', " + 
                                                "  to_date='"+ DateTime.Parse(txttodate.Text.ToString()).ToString("yyyy-MM-dd") + "' " +
                                                "  where experience_id='" + ViewState["id"].ToString() + "' ");

                if (b == true)
                {
                    Response.Redirect("experience.aspx");
                }
            }
    }

    [System.Web.Services.WebMethod]
    public static string Deleteexperience(string eid)
    {
        try
        {
            DBConnectionClass con = new DBConnectionClass();

            bool i = con.boolInsertData("delete from LAS_experience where experience_id='" + eid.ToString().Trim() + "'");
            if (i == true) return "true"; else return "false";
        }
        catch (Exception)
        {
            return "false";
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
}