using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_city : System.Web.UI.Page
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
            Fill_Combo_Country();

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
                dt = dbCommon.DisplayDataQuery("select * from LAS_city where city_id='" + id + "'").Tables[0];

                if (dt.Rows.Count == 0) { Response.Redirect("city.aspx"); }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        cmbCountry.SelectedValue = dr["city_id"].ToString();
                        txtCity.Text = dr["city_name"].ToString();
                    }
                }
            }
            else if (Request.QueryString.AllKeys.Length == 1)
            {
                Response.Redirect("../Logout.aspx");
            }
        }
    }

    protected void Fill_Combo_Country()
    {

        DataTable dtCat = new DataTable();
        dtCat = dbCommon.DisplayDataQuery("select * from LAS_country").Tables[0];
        cmbCountry.Items.Clear();
        cmbCountry.Items.Add(new ListItem("Select Country", "select"));
        foreach (DataRow drUserInfo in dtCat.Rows)
        {
            cmbCountry.Items.Add(new ListItem(drUserInfo["Country_name"].ToString(), drUserInfo["country_id"].ToString()));
        }
    }

    public void fillTable()
    {
        DBConnectionClass sp3 = new DBConnectionClass("displayData");
        string sqlP = "select a.city_id,a.city_name,b.country_name from LAS_city a, LAS_country b where a.country_id=b.country_id";

        DataTable dt = new DataTable();
        dt = sp3.DisplayDataQuery(sqlP).Tables[0];
        StringBuilder html = new StringBuilder();
        foreach (DataRow dr in dt.Rows)
        {
            html.Append("<tr>");
            html.Append("<td>" + dr["city_name"] + "</td>");
            html.Append("<td>" + dr["country_name"] + "</td>");
            html.Append("<td align='center' width='4%'><a href='city.aspx?eid=" + dr["city_id"].ToString() + "'><i class='fa fa-1x fa-pencil'></i></a></td>");
            html.Append("<td align='center' width='4%'><a href='Javascript:deletefunction(" + dr["city_id"].ToString() + ");'><i class='fa fa-1x fa-trash-o'></i></a></td>");
            html.Append("</tr>");
        }
        displayCity.InnerHtml = html.ToString();
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
            if (btnSubmit.Text == "Save")
            {
                int maxId = dbCommon.CheckDuplicateByQuery("select IsNUll(Max(city_id),0)+1 from LAS_city");
                bool b = dbCommon.boolInsertData("insert into LAS_city (city_id,city_name,country_id) " +
                                        " values('" + maxId + "', '" + txtCity.Text.ToString().Trim() + "','"+ cmbCountry.SelectedValue.ToString() + "') ");

                if (b == true)
                {
                    Response.Redirect("city.aspx");
                }
            }
            else
            {
                bool b = dbCommon.boolInsertData("update LAS_city set city_name='" + txtCity.Text.ToString().Trim() + "', country_id='"+cmbCountry.SelectedValue.ToString()+"' " +
                                        "  where city_id='" + ViewState["id"].ToString() + "' ");

                if (b == true)
                {
                    Response.Redirect("city.aspx");
                }
            }
    }

    [System.Web.Services.WebMethod]
    public static string Deletecity(string eid)
    {
        try
        {
            DBConnectionClass con = new DBConnectionClass();

            bool i = con.boolInsertData("delete from LAS_city where city_id='" + eid.ToString().Trim() + "'");
            if (i == true) return "true"; else return "false";
        }
        catch (Exception)
        {
            return "false";
        }
    }
}