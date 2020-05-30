using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class lawyer_services : System.Web.UI.Page
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
                dt = dbCommon.DisplayDataQuery("select * from LAS_service where service_id='" + id + "'").Tables[0];

                if (dt.Rows.Count == 0) { Response.Redirect("services.aspx"); }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ViewState["description"] = dr["description"].ToString();
                        txtService.Text = dr["description"].ToString();
                        txtCharge.Text = dr["fees"].ToString();
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
        string sqlP = "select * from LAS_service where login_id='"+Session["Slogin_id"].ToString()+"' ";

        DataTable dt = new DataTable();
        dt = dbCommon.DisplayDataQuery(sqlP).Tables[0];
        StringBuilder html = new StringBuilder();
        foreach (DataRow dr in dt.Rows)
        {
            html.Append("<tr>");
            html.Append("<td>" + dr["description"] + "</td>");
            html.Append("<td>" + dr["fees"] + "</td>");
            html.Append("<td align='center' width='4%'><a href='services.aspx?eid=" + dr["service_id"].ToString() + "'><i class='fa fa-1x fa-pencil'></i></a></td>");
            html.Append("<td align='center' width='4%'><a href='Javascript:deletefunction(" + dr["service_id"].ToString() + ");'><i class='fa fa-1x fa-trash-o'></i></a></td>");
            html.Append("</tr>");
        }
        displayService.InnerHtml = html.ToString();
    }

    protected void txtService_TextChanged(object sender, EventArgs e)
    {
        int i = 0;
        DBConnectionClass conD = new DBConnectionClass("CheckDuplicateData");
        //List<SqlParameter> sqlp = new List<SqlParameter>();
        //sqlp.Clear();
        //sqlp.Add(new SqlParameter("@TableName", "LAS_service"));
        //sqlp.Add(new SqlParameter("@FieldName", "description"));
        //sqlp.Add(new SqlParameter("@FieldValue", txtService.Text.ToString().Trim()));
        string sqlStr = "";
        sqlStr = "select * from LAS_service where description='"+txtService.Text.ToString().Trim()+"' and login_id='"+ Session["Slogin_id"].ToString() + "' ";

        if(btnSubmit.Text == "Update")
        {
            sqlStr = sqlStr + " and  service_id!='" + ViewState["id"].ToString() + "' ";
        }
        i = conD.CheckDuplicateByQuery(sqlStr);

        if (i >= 1)
        {
            if (btnSubmit.Text == "Update")
            {
                lblDErrorMsg.Text = "* This service exist.";
            }
            else
            {
                lblDErrorMsg.Text = "";
            }
            if (btnSubmit.Text == "Submit")
            {
                lblDErrorMsg.Text = "* This service exist.";
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
            if (btnSubmit.Text == "Submit")
            {
                int maxId = dbCommon.CheckDuplicateByQuery("select IsNUll(Max(service_id),0)+1 from LAS_service");
                bool b = dbCommon.boolInsertData("insert into LAS_service (service_id,login_id,description,fees) " +
                                        " values('" + maxId + "', '"+Session["Slogin_id"].ToString()+"', " + 
                                        " '" + txtService.Text.ToString().Trim() + "','"+txtCharge.Text.ToString().Trim()+"') ");

                if (b == true)
                {
                    Response.Redirect("services.aspx");
                }
            }
            else
            {
                bool b = dbCommon.boolInsertData("update LAS_service set description='" + txtService.Text.ToString().Trim() + "', fees='" + txtCharge.Text.ToString().Trim() + "' " +
                                        "  where service_id='" + ViewState["id"].ToString() + "' ");

                if (b == true)
                {
                    Response.Redirect("services.aspx");
                }
            }
        }
    }

    [System.Web.Services.WebMethod]
    public static string Deleteservice(string eid)
    {
        try
        {
            DBConnectionClass con = new DBConnectionClass();

            bool i = con.boolInsertData("delete from LAS_service where service_id='" + eid.ToString().Trim() + "'");
            if (i == true) return "true"; else return "false";
        }
        catch (Exception)
        {
            return "false";
        }
    }


    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtCharge.Text = "";
        txtService.Text = "";
        btnSubmit.Text = "Submit";
        Response.Redirect("services.aspx");
    }

   
}