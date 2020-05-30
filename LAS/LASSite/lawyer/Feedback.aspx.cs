using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class lawyer_Feedback : System.Web.UI.Page
{
    DBConnectionClass dbCommon = new DBConnectionClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["Suser_type"] == null)
        {
            Response.Redirect("../LogOut.aspx");
        }
        if (!IsPostBack)
        {
            fillData();
        }
    }

    public void fillData()
    {
        string sqlStr = "";
        sqlStr = "select a.*,b.book_date,b.book_time,c.first_name,c.last_name,c.email_id,c.mobile_no " +
                " from LAS_review a " +
                " left " +
                " join LAS_appointment b on a.appointment_id = b.appointment_id " +
                " left " +
                " join LAS_login c on b.user_login_id = c.login_id " +
                " left join LAS_office d on d.office_id=b.office_id " + 
                " where d.login_id='"+Session["Slogin_id"].ToString()+"' order by create_date ";

        DataTable dt = new DataTable();
        dt = dbCommon.DisplayDataQuery(sqlStr).Tables[0];
        StringBuilder html = new StringBuilder();
        foreach (DataRow dr in dt.Rows)
        {
            html.Append("<tr>");
            html.Append("<td>" + dr["first_name"].ToString() + " " + dr["last_name"].ToString() + "</td>");
            html.Append("<td>"+ dr["email_id"].ToString() +"</td>");
            html.Append("<td>"+dr["mobile_no"]+"</td>");
            html.Append("<td>"+DateTime.Parse(dr["book_date"].ToString()).ToString("dd-MM-yyyy")+" "+ DateTime.Parse(dr["book_time"].ToString()).ToString("H:mm tt")+ "</td>");
            html.Append("<td>"+dr["description"].ToString()+"</td>");
            html.Append("</tr>");
        }
        displayReview.InnerHtml = html.ToString();
        
    }
}