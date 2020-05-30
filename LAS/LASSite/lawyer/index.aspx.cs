using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_index : System.Web.UI.Page
{
    DBConnectionClass dbCommon = new DBConnectionClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["Suser_type"] == null)
        {
            Response.Redirect("../LogOut.aspx");
        }
        if (HttpContext.Current.Session["Suser_type"] == null)
        {
            Response.Redirect("../LogOut.aspx");
        }

        if (!IsPostBack)
        {
            Fill_Combo_Office();
        }
    }

    protected void Fill_Combo_Office()
    {

        DataTable dtCat = new DataTable();
        dtCat = dbCommon.DisplayDataQuery("select office_id, Concat(office_name,'-',address) as office_name from LAS_office where login_id='" + Session["Slogin_id"] + "'").Tables[0];
        cmbOffice.Items.Clear();
        cmbOffice.Items.Add(new ListItem("Select Office", "select"));
        foreach (DataRow drUserInfo in dtCat.Rows)
        {
            cmbOffice.Items.Add(new ListItem(drUserInfo["office_name"].ToString(), drUserInfo["office_id"].ToString()));
        }
    }

    public void fillAppointment()
    {
        string sqlStr = "";
        DataTable dt = new DataTable();
        StringBuilder html = new StringBuilder();

        sqlStr = " select a.*, b.first_name,b.last_name,b.email_id,b.mobile_no from LAS_appointment a " +
                " Left Join LAS_login b on a.user_login_id = b.login_id " +
                " where a.office_id = '" + cmbOffice.SelectedValue.ToString() + "' " + 
                " and a.book_date='"+ DateTime.Parse(DateTime.Now.ToString()).ToString("yyyy-MM-dd") +"' " +
                " order by book_date,book_time ";

        dt = dbCommon.DisplayDataQuery(sqlStr).Tables[0];
        foreach (DataRow dr in dt.Rows)
        {
            html.Append("<tr>");
            html.Append("<td>" + dr["first_name"].ToString() + " " + dr["last_name"].ToString() + "</td>");
            html.Append("<td>" + dr["email_id"].ToString() + "</td>");
            html.Append("<td>" + dr["mobile_no"].ToString() + "</td>");
            html.Append("<td>" + DateTime.Parse(dr["book_date"].ToString()).ToString("dd-MM-yyyy") + " " + DateTime.Parse(dr["book_time"].ToString()).ToString("H:mm tt") + "</td>");
            if (dr["a_status"].ToString() == "0")
            {
                html.Append("<td>Active</td>");
                html.Append("<td><a href='Javascript:deletefunction(" + dr["appointment_id"].ToString() + ");'>Cancel</a></td>");
            }
            else
            if (dr["a_status"].ToString() == "1")
            {
                html.Append("<td>Cancel</td>");
                html.Append("<td></td>");
            }
            else
            {
                html.Append("<td>Closed</td>");
                html.Append("<td></td>");
            }


            html.Append("</tr>");
        }
        displayLawyer.InnerHtml = html.ToString();
    }

    protected void cmbOffice_TextChanged(object sender, EventArgs e)
    {
        if (cmbOffice.SelectedValue.ToString() != "select")
        {
            fillAppointment();
        }
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