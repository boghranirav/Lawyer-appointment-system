using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_area : System.Web.UI.Page
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
                dt = dbCommon.DisplayDataQuery("select a.area_id,a.area_name,b.city_id,b.country_id from LAS_area a, LAS_city b where a.city_id=b.city_id and a.area_id='" + id + "'").Tables[0];

                if (dt.Rows.Count == 0) { Response.Redirect("city.aspx"); }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ViewState["description"] = dr["area_name"].ToString();
                        cmbCountry.SelectedValue = dr["country_id"].ToString();
                        Fill_Combo_City();
                        cmbCity.SelectedValue = dr["city_id"].ToString();
                        txtArea.Text = dr["area_name"].ToString();
                        
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
        string sqlP = "select a.area_id,a.area_name,b.city_name from LAS_area a, LAS_city b where a.city_id=b.city_id";

        DataTable dt = new DataTable();
        dt = sp3.DisplayDataQuery(sqlP).Tables[0];
        StringBuilder html = new StringBuilder();
        foreach (DataRow dr in dt.Rows)
        {
            html.Append("<tr>");
            html.Append("<td>" + dr["area_name"] + "</td>");
            html.Append("<td>" + dr["city_name"] + "</td>");
            html.Append("<td align='center' width='4%'><a href='area.aspx?eid=" + dr["area_id"].ToString() + "'><i class='fa fa-1x fa-pencil'></i></a></td>");
            html.Append("<td align='center' width='4%'><a href='Javascript:deletefunction(" + dr["area_id"].ToString() + ");'><i class='fa fa-1x fa-trash-o'></i></a></td>");
            html.Append("</tr>");
        }
        displayArea.InnerHtml = html.ToString();
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


    protected void Fill_Combo_City()
    {

        if (cmbCountry.SelectedValue.ToString() != "select")
        {
            DataTable dtCat = new DataTable();
            dtCat = dbCommon.DisplayDataQuery("select * from LAS_city where country_id='" + cmbCountry.SelectedValue.ToString() + "'").Tables[0];
            cmbCity.Items.Clear();
            cmbCity.Items.Add(new ListItem("Select City", "select"));
            foreach (DataRow drUserInfo in dtCat.Rows)
            {
                cmbCity.Items.Add(new ListItem(drUserInfo["city_name"].ToString(), drUserInfo["city_id"].ToString()));
            }
        }
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (lblDErrorMsg.Text == "")
        {
            if (btnSubmit.Text == "Save")
            {
                int maxId = dbCommon.CheckDuplicateByQuery("select IsNUll(Max(area_id),0)+1 from LAS_area");
                bool b = dbCommon.boolInsertData("insert into LAS_area (area_id,area_name,city_id) " +
                                        " values('" + maxId + "', '" + txtArea.Text.ToString().Trim() + "','" + cmbCity.SelectedValue.ToString() + "') ");

                if (b == true)
                {
                    Response.Redirect("area.aspx");
                }
            }
            else
            {
                bool b = dbCommon.boolInsertData("update LAS_area set area_name='" + txtArea.Text.ToString().Trim() + "', city_id='" + cmbCity.SelectedValue.ToString() + "' " +
                                        "  where area_id='" + ViewState["id"].ToString() + "' ");

                if (b == true)
                {
                    Response.Redirect("area.aspx");
                }
            }
        }
    }

    protected void cmbCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        Fill_Combo_City();
    }

    [System.Web.Services.WebMethod]
    public static string Deletearea(string eid)
    {
        try
        {
            DBConnectionClass con = new DBConnectionClass();

            bool i = con.boolInsertData("delete from LAS_area where area_id='" + eid.ToString().Trim() + "'");
            if (i == true) return "true"; else return "false";
        }
        catch (Exception)
        {
            return "false";
        }
    }

    protected void txtArea_TextChanged(object sender, EventArgs e)
    {
        int i = 0;
        DBConnectionClass conD = new DBConnectionClass("CheckDuplicateData");
        List<SqlParameter> sqlp = new List<SqlParameter>();
        sqlp.Clear();
        sqlp.Add(new SqlParameter("@TableName", "LAS_area"));
        sqlp.Add(new SqlParameter("@FieldName", "area_name"));
        sqlp.Add(new SqlParameter("@FieldValue", txtArea.Text.ToString().Trim()));
        i = conD.CheckDuplicate(sqlp);
        if (i >= 1)
        {
            if (btnSubmit.Text == "Update" && txtArea.Text.ToUpper().Trim() != ViewState["description"].ToString().ToUpper().Trim())
            {
                lblDErrorMsg.Text = "* This Area Exist.";
            }
            else
            {
                lblDErrorMsg.Text = "";
            }
            if (btnSubmit.Text == "Save")
            {
                lblDErrorMsg.Text = "* This Area Exist.";
            }
        }
        else
        {
            lblDErrorMsg.Text = "";
        }
    }
}