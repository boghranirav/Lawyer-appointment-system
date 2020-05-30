using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_specialization : System.Web.UI.Page
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
                dt = dbCommon.DisplayDataQuery("select * from LAS_specialization where specialization_id='" + id + "'").Tables[0];

                if (dt.Rows.Count == 0) { Response.Redirect("specialization.aspx"); }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ViewState["description"] = dr["description"].ToString();
                        txtSpecilization.Text = dr["description"].ToString();
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
        string sqlP = "select * from LAS_specialization ";

        DataTable dt = new DataTable();
        dt = sp3.DisplayDataQuery(sqlP).Tables[0];
        StringBuilder html = new StringBuilder();
        foreach (DataRow dr in dt.Rows)
        {
            html.Append("<tr>");
            html.Append("<td>" + dr["description"] + "</td>");
            html.Append("<td align='center' width='4%'><a href='specialization.aspx?eid="+ dr["specialization_id"].ToString() + "'><i class='fa fa-1x fa-pencil'></i></a></td>");
            html.Append("<td align='center' width='4%'><a href='Javascript:deletefunction("+dr["specialization_id"].ToString() +");'><i class='fa fa-1x fa-trash-o'></i></a></td>");
            html.Append("</tr>");
        }
        displaySpe.InnerHtml = html.ToString();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (lblDErrorMsg.Text == "")
        {
            if (btnSubmit.Text == "Save")
            {
                int maxId = dbCommon.CheckDuplicateByQuery("select IsNUll(Max(specialization_id),0)+1 from LAS_specialization");
                bool b = dbCommon.boolInsertData("insert into LAS_specialization (specialization_id,description) " +
                                        " values('" + maxId + "', '" + txtSpecilization.Text.ToString().Trim() + "') ");

                if (b == true)
                {
                    Response.Redirect("specialization.aspx");
                }
            }
            else
            {
                bool b = dbCommon.boolInsertData("update LAS_specialization set description='" + txtSpecilization.Text.ToString().Trim() + "' " +
                                        "  where specialization_id='" + ViewState["id"].ToString() + "' ");

                if (b == true)
                {
                    Response.Redirect("specialization.aspx");
                }
            }
        }
    }

    [System.Web.Services.WebMethod]
    public static string Deletespecialization(string eid)
    {
        try
        {
            DBConnectionClass con = new DBConnectionClass();
            
            bool i = con.boolInsertData("delete from LAS_specialization where specialization_id='"+eid.ToString().Trim()+"'");
            if (i == true) return "true"; else return "false";
        }
        catch (Exception)
        {
            return "false";
        }
    }


    protected void txtSpecilization_TextChanged(object sender, EventArgs e)
    {
        int i = 0;
        DBConnectionClass conD = new DBConnectionClass("CheckDuplicateData");
        List<SqlParameter> sqlp = new List<SqlParameter>();
        sqlp.Clear();
        sqlp.Add(new SqlParameter("@TableName", "LAS_specialization"));
        sqlp.Add(new SqlParameter("@FieldName", "description"));
        sqlp.Add(new SqlParameter("@FieldValue", txtSpecilization.Text.ToString().Trim()));
        i = conD.CheckDuplicate(sqlp);
        if (i >= 1)
        {
            if (btnSubmit.Text == "Update" && txtSpecilization.Text.ToUpper().Trim() != ViewState["description"].ToString().ToUpper().Trim())
            {
                lblDErrorMsg.Text = "* This Specialization Exist.";
            }
            else
            {
                lblDErrorMsg.Text = "";
            }
            if (btnSubmit.Text == "Save")
            {
                lblDErrorMsg.Text = "* This Specialization Exist.";
            }
        }
        else
        {
            lblDErrorMsg.Text = "";
        }
    }
}