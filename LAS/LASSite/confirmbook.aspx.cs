using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class confirmbook : System.Web.UI.Page
{
    DBConnectionClass dbCommon = new DBConnectionClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString.AllKeys.Contains("bdt") && Request.QueryString.AllKeys.Contains("btm") && Request.QueryString.AllKeys.Contains("oid"))
            {
                dbCommon.SetUpdateId("officeId", Request.QueryString["oid"].ToString());
                dbCommon.SetUpdateId("bookTime", Request.QueryString["btm"].ToString());
                dbCommon.SetUpdateId("bookDate", Request.QueryString["bdt"].ToString());
            }
            if (HttpContext.Current.Session["Suser_type"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                if (dbCommon.IsEmptyUpdateId("bookTime") && dbCommon.IsEmptyUpdateId("bookDate") && dbCommon.IsEmptyUpdateId("officeId"))
                {
                    GetDetalis();
                    lblLDate.Text = dbCommon.GetUpdateId("bookDate");
                    lblLTime.Text = DateTime.Parse(dbCommon.GetUpdateId("bookTime")).ToString("H:mm tt");
                }
                else
                {
                    Response.Redirect("index.aspx");
                }
            }
        }
    }

    public void GetDetalis()
    {
        string sqlStr = "";
        sqlStr = "select * from LAS_Login where login_id='" + Session["Slogin_id"].ToString() + "'";

        DataTable dt = new DataTable();
        dt = dbCommon.DisplayDataQuery(sqlStr).Tables[0];
        foreach(DataRow dr in dt.Rows)
        {
            txtEmail.Text = dr["email_id"].ToString();
            txtName.Text = dr["first_name"].ToString() + " " + dr["last_name"].ToString();
        }

        dt.Rows.Clear();

        sqlStr = "Select a.office_name,a.address,a.pincode,c.area_name,d.city_name, " +
                  "  b.first_name,b.last_name " +
                  "  from LAS_office a " +
                  "  Left Join LAS_login b on a.login_id = b.login_id " +
                  "  Left Join LAS_area c on c.area_id = a.area_id " +
                  "  Left Join LAS_city d on d.city_id = c.city_id " +
                  "  where a.office_id = '" + dbCommon.GetUpdateId("officeId").ToString() +"'";

        dt = dbCommon.DisplayDataQuery(sqlStr).Tables[0];
        foreach(DataRow dr in dt.Rows)
        {
            lblLName.Text = dr["first_name"].ToString()+" "+dr["last_name"].ToString();
            lblOffice.InnerHtml = dr["office_name"].ToString() + " <br />" + dr["address"].ToString() + "<br />" + dr["area_name"].ToString() + "<br />" + dr["city_name"].ToString() + " - " + dr["pincode"].ToString();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string sqlStr = "";
        int maxId = dbCommon.CheckDuplicateByQuery("select IsNUll(Max(appointment_id),0)+1 from LAS_appointment");

        sqlStr = "insert into LAS_appointment(appointment_id,office_id,user_login_id,book_date,book_time,book_reason,a_status) " + 
                " values('"+maxId+"','"+dbCommon.GetUpdateId("officeId")+"','"+Session["Slogin_id"].ToString()+"','"+ DateTime.Parse(lblLDate.Text.ToString()).ToString("yyyy-MM-dd") +"','"+DateTime.Parse(lblLTime.Text.ToString()).ToString("H:mm")+"', '"+txtReason.Text.ToString().Replace("'"," ")+"','0') ";

        bool i = dbCommon.boolInsertData(sqlStr);

        if (i == true)
        {
            dbCommon.EmptyUpdateId("officeId");
            dbCommon.EmptyUpdateId("bookTime");
            dbCommon.EmptyUpdateId("bookDate");
            Response.Redirect("view_appointment.aspx");
        }
        else
        {
            Response.Write("<script>");
            Response.Write("alert('Appointment not booked. Try again.');");
            Response.Write("</script>");
        }
    }
}