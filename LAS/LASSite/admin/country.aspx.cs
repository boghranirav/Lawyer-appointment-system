using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_country : System.Web.UI.Page
{
    DBConnectionClass dbCommon = new DBConnectionClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["Suser_type"] == null)
        {
            Response.Redirect("../logout.aspx");
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
                dt = dbCommon.DisplayDataQuery("select * from LAS_country where country_id='" + id + "'").Tables[0];

                if (dt.Rows.Count == 0) { Response.Redirect("country.aspx"); }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ViewState["description"] = dr["country_name"].ToString();
                        txtCountry.Text = dr["country_name"].ToString();
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
        DBConnectionClass sp3 = new DBConnectionClass("displayData");
        string sqlP = "select * from LAS_country ";

        DataTable dt = new DataTable();
        dt = sp3.DisplayDataQuery(sqlP).Tables[0];
        StringBuilder html = new StringBuilder();
        foreach (DataRow dr in dt.Rows)
        {
            html.Append("<tr>");
            html.Append("<td>" + dr["country_name"] + "</td>");
            html.Append("<td align='center' width='4%'><a href='country.aspx?eid=" + dr["country_id"].ToString() + "'><i class='fa fa-1x fa-pencil'></i></a></td>");
            html.Append("<td align='center' width='4%'><a href='Javascript:deletefunction(" + dr["country_id"].ToString() + ");'><i class='fa fa-1x fa-trash-o'></i></a></td>");
            html.Append("</tr>");
        }
        displayCountry.InnerHtml = html.ToString();
    }

    protected void txtCountry_TextChanged(object sender, EventArgs e)
    {
        int i = 0;
        DBConnectionClass conD = new DBConnectionClass("CheckDuplicateData");
        List<SqlParameter> sqlp = new List<SqlParameter>();
        sqlp.Clear();
        sqlp.Add(new SqlParameter("@TableName", "LAS_country"));
        sqlp.Add(new SqlParameter("@FieldName", "country_name"));
        sqlp.Add(new SqlParameter("@FieldValue", txtCountry.Text.ToString().Trim()));
        i = conD.CheckDuplicate(sqlp);
        if (i >= 1)
        {
            if (btnSubmit.Text == "Update" && txtCountry.Text.ToUpper().Trim() != ViewState["description"].ToString().ToUpper().Trim())
            {
                lblDErrorMsg.Text = "* This country exist.";
            }
            else
            {
                lblDErrorMsg.Text = "";
            }
            if (btnSubmit.Text == "Save")
            {
                lblDErrorMsg.Text = "* This country exist.";
            }
        }
        else
        {
            lblDErrorMsg.Text = "";
        }

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (lblDErrorMsg.Text == "")
        {
            if (btnSubmit.Text == "Save")
            {
                int maxId = dbCommon.CheckDuplicateByQuery("select IsNUll(Max(country_id),0)+1 from LAS_Country");
                bool b = dbCommon.boolInsertData("insert into LAS_country (country_id,country_name) " +
                                        " values('" + maxId + "', '" + txtCountry.Text.ToString().Trim() + "') ");

                if (b == true)
                {
                    Response.Redirect("country.aspx");
                }
            }
            else
            {
                bool b = dbCommon.boolInsertData("update LAS_country set country_name='" + txtCountry.Text.ToString().Trim() + "' " +
                                        "  where country_id='" + ViewState["id"].ToString() + "' ");

                if (b == true)
                {
                    Response.Redirect("country.aspx");
                }
            }
        }
    }

    [System.Web.Services.WebMethod]
    public static string Deletecountry(string eid)
    {
        try
        {
            DBConnectionClass con = new DBConnectionClass();

            bool i = con.boolInsertData("delete from LAS_country where country_id='" + eid.ToString().Trim() + "'");
            if (i == true) return "true"; else return "false";
        }
        catch (Exception)
        {
            return "false";
        }
    }
}