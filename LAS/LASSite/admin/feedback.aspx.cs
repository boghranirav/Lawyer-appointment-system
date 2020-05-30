using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_feedback : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["Suser_type"] == null)
        {
            Response.Redirect("../logout.aspx");
        }
        if (!IsPostBack)
        {
            fillTable();
        }
    }

    public void fillTable()
    {
        DBConnectionClass sp3 = new DBConnectionClass("displayData");
        string sqlP = "select a.review_id,a.description, CONCAT(CONCAT(e.first_name,' '),e.last_name) as 'LName', " +
                       " CONCAT(CONCAT(c.first_name, ' '), c.last_name) as 'UName' " +
                       " from LAS_review a " +
                       " Left Join LAS_appointment b on a.appointment_id = b.appointment_id " +
                       " Left Join LAS_login c on c.login_id = b.user_login_id " +
                       " Left Join LAS_office d on d.office_id = b.office_id " +
                       " Left Join LAS_login e on e.login_id = d.login_id order by a.create_date desc ";

        DataTable dt = new DataTable();
        dt = sp3.DisplayDataQuery(sqlP).Tables[0];
        StringBuilder html = new StringBuilder();
        foreach (DataRow dr in dt.Rows)
        {
            html.Append("<tr>");
            html.Append("<td>" + dr["LName"] +  "</td>");
            html.Append("<td>" + dr["UName"] + "</td>");
            html.Append("<td>" + dr["description"] + "</td>");
            html.Append("<td align='center' width='4%'><a href='Javascript:deletefunction(" + dr["review_id"].ToString() + ");'><i class='fa fa-1x fa-trash-o'></i></a></td>");
            html.Append("</tr>");
        }
        displayReview.InnerHtml = html.ToString();
    }

    [System.Web.Services.WebMethod]
    public static string Deletefeedback(string eid)
    {
        try
        {
            DBConnectionClass con = new DBConnectionClass();

            bool i = con.boolInsertData("delete from LAS_review where review_id='" + eid.ToString().Trim() + "'");
            if (i == true) return "true"; else return "false";
        }
        catch (Exception)
        {
            return "false";
        }
    }
}