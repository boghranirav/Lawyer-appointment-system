using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class view_appointment : System.Web.UI.Page
{
    DBConnectionClass dbCommon = new DBConnectionClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["Suser_type"] == null)
        {
            Response.Redirect("index.aspx");
        }
        if (!IsPostBack)
        {
            FillDetails();
        }
    }

    public void FillDetails()
    {
        string sqlStr = "";
        DataTable dt = new DataTable();
        StringBuilder html = new StringBuilder();

        sqlStr = "select a.appointment_id,a.book_date,a.book_time,a.book_reason,a.a_status,CONCAT(b.first_name,' ',b.last_name) as 'UserName', " +
                   " c.office_name, CONCAT(d.first_name, ' ', d.last_name) as 'LawyerName' " +
                   " from LAS_appointment a " +
                   " left " +
                   " join LAS_login b on a.user_login_id = b.login_id " +
                   " left " +
                   " join LAS_office c on a.office_id = c.office_id " +
                   " left " +
                   " join LAS_login d on c.login_id = d.login_id " + 
                   " where b.login_id='"+Session["Slogin_id"].ToString()+"' ";

        dt=dbCommon.DisplayDataQuery(sqlStr).Tables[0];

        foreach(DataRow dr in dt.Rows)
        {
            html.Append("<tr>");
            html.Append("<td>"+dr["LawyerName"].ToString()+"</td>");
            html.Append("<td>" + dr["office_name"].ToString() + "</td>");
            html.Append("<td>" + DateTime.Parse(dr["book_date"].ToString()).ToString("dd-MM-yyyy") + "</td>");
            html.Append("<td>" + DateTime.Parse(dr["book_time"].ToString()).ToString("h:mm tt") + "</td>");
            if (dr["a_status"].ToString() == "0")
            {
                html.Append("<td>Active</td>");
                html.Append("<td><a href='Javascript:deletefunction(" + dr["appointment_id"].ToString() + ");'>Cancel</a></td>");
                html.Append("<td></td>");
            }
            else
            if (dr["a_status"].ToString() == "1")
            {
                html.Append("<td>Canceled</td>");
                html.Append("<td></td>");
                html.Append("<td></td>");
            }
            else
            {
                html.Append("<td>Closed</td>");
                html.Append("<td></td>");
                html.Append("<td><a href='review.aspx?aid=" + dr["appointment_id"].ToString() + "'>Review</a></td>");
            }
            
            html.Append("</tr>");
        }

        displayData.InnerHtml = html.ToString();
    }

    [System.Web.Services.WebMethod]
    public static string Deleteappointment(string eid)
    {
        try
        {
            DBConnectionClass con = new DBConnectionClass();

            bool i = con.boolInsertData("update LAS_appointment set a_status='1' where appointment_id='" + eid.ToString().Trim() + "'");
            if (i == true) return "true"; else return "false";
        }
        catch (Exception)
        {
            return "false";
        }
    }

}