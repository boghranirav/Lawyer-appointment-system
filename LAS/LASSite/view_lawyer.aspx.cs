using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class view_lawyer : System.Web.UI.Page
{
    DBConnectionClass dbCommon = new DBConnectionClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString.AllKeys.Contains("eid") && Request.QueryString.AllKeys.Contains("oid"))
            {
                if (Request.QueryString["eid"].ToString().All(char.IsDigit) && Request.QueryString["oid"].ToString().All(char.IsDigit))
                {
                    ViewState["eid"] = Request.QueryString["eid"];
                    ViewState["oid"] = Request.QueryString["oid"];
                }
                else { Response.Redirect("index.aspx"); }
            }
            else { Response.Redirect("index.aspx"); }
            dbCommon.EmptyUpdateId("officeId");
            dbCommon.EmptyUpdateId("bookTime");
            fillInfo();
            fillService();
            fillEducationAndExperience();
            fillOffice();
            addDates();
            fillReview();
        }
    }

    public void fillInfo()
    {
        string sqlStr = "";
        sqlStr = "select a.login_id,a.first_name,a.last_name, " +
                " b.specialization_id,b.profile_photo,b.description as 'lawyerinfo',b.facebook_link,b.website, " +
                " c.address,c.email_id,c.mobile,c.office_name,c.pincode,c.telephone, " +
                " d.area_name,e.city_name,f.description as 'specializationdet' " +
                " from LAS_login a " +
                " Left Join LAS_lawyer_profile b on a.login_id = b.login_id " +
                " Left Join LAS_office c on c.login_id = a.login_id " +
                " Left Join LAS_area d on d.area_id = c.area_id " +
                " Left Join LAS_city e on e.city_id = d.city_id " +
                " Left Join LAS_specialization f on f.specialization_id = b.specialization_id " +
                " where c.office_id='" + ViewState["oid"].ToString() + "'";

        DataTable dt = new DataTable();
        dt = dbCommon.DisplayDataQuery(sqlStr).Tables[0];
        foreach (DataRow dr in dt.Rows)
        {
            lblSpec.InnerHtml = "Specialization : <br />" + dr["specializationdet"].ToString();
            lblLawyerName.InnerText =dr["first_name"].ToString()+" " + dr["last_name"].ToString();
            lblOfficename.InnerHtml = "Office Name : "+ dr["office_name"].ToString() +" <br />"+"Address : <br />" +dr["address"] + ",<br /> " + 
                                      " "+dr["area_name"]+", <br />"+dr["city_name"].ToString() +" - " +dr["pincode"].ToString();
            lblPhone.InnerText = dr["mobile"].ToString();
            lblEmail.InnerText = dr["email_id"].ToString();
            lblSDescription.InnerHtml = dr["lawyerinfo"].ToString();
            byte[] bytes;
            try
            {
                bytes = (byte[])dr["profile_photo"];
                string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                imgLawyer.ImageUrl = "data:image/png;base64," + base64String;

            }
            catch (Exception)
            {
                bytes = null;
            }
            break;
        }

        sqlStr = "select * from LAS_timing where office_id='" + ViewState["oid"].ToString() + "'";
        dt.Rows.Clear();

        dt = dbCommon.DisplayDataQuery(sqlStr).Tables[0];
        StringBuilder html = new StringBuilder();
        foreach (DataRow dr in dt.Rows)
        {
            html.Append("<tr>");
            html.Append("<td>" + char.ToUpper(dr["day_name"].ToString()[0]) + dr["day_name"].ToString().Substring(1) + "</td>");
            if (dr["is_holiday"].ToString() == "0")
            {
                html.Append("<td colspan='2' style='text-align:center;'>Holiday</td>");
            }
            else
            {
                html.Append("<td> From " + DateTime.Parse(dr["morning_from"].ToString()).ToString("h:mm tt") + " To " + DateTime.Parse(dr["morning_to"].ToString()).ToString("h:mm tt") + "</td>");
                html.Append("<td> From " + DateTime.Parse(dr["evening_from"].ToString()).ToString("h:mm tt") + " To " + DateTime.Parse(dr["evening_to"].ToString()).ToString("h:mm tt") + "</td>");
            }
                html.Append("</tr>");
        }
        displayTiming.InnerHtml = html.ToString();
    }

    public void fillOffice()
    {
        string sqlStr = "";
        DataTable dt = new DataTable();
        StringBuilder html = new StringBuilder();
        sqlStr = "select * from LAS_office where office_id!='"+ViewState["oid"].ToString()+"' and login_id='"+ ViewState["eid"].ToString()+"'";
        dt = dbCommon.DisplayDataQuery(sqlStr).Tables[0];
        if (dt.Rows.Count <= 0)
        {
            displayOtherOfffice.Visible = false;
        }
        else
        {
            html.Append("<ul>");
        }
        foreach (DataRow dr in dt.Rows)
        {
            displayOtherOfffice.Visible = true;
            html.Append("<li><a href='view_lawyer.aspx?eid="+dr["login_id"].ToString()+"&oid="+dr["office_id"].ToString()+"'>" + dr["office_name"].ToString() + " - " + dr["address"].ToString() + "</a></li>");

        }

        html.Append("</ul>");
        displayOfficeDetails.InnerHtml = html.ToString();
    }

    public void fillService()
    {
        string sqlStr = "";
        StringBuilder html = new StringBuilder();
        sqlStr = " select * from LAS_service where login_id='" + ViewState["eid"].ToString() + "'";

        DataTable dt = new DataTable();
        dt = dbCommon.DisplayDataQuery(sqlStr).Tables[0];
        foreach (DataRow dr in dt.Rows)
        {
            html.Append("<tr>");
            html.Append("<td>" + dr["description"].ToString() +"</td><td>" + dr["fees"].ToString() + "</td>");
            html.Append("</tr>");                         
        }
        lblServices.InnerHtml = html.ToString();
    }

    public void fillEducationAndExperience()
    {
        string sqlStr = "";
        StringBuilder html = new StringBuilder();
        sqlStr = " select * from LAS_experience where login_id='" + ViewState["eid"].ToString() + "'";

        DataTable dt = new DataTable();
        dt = dbCommon.DisplayDataQuery(sqlStr).Tables[0];
        foreach (DataRow dr in dt.Rows)
        {
            html.Append("<li><strong>From "+DateTime.Parse(dr["from_date"].ToString()).ToString("dd-MM-yyyy")+" to "+ dr["to_date"].ToString() +"</strong> <br /> "+dr["description"].ToString()+"</li>");
        }
        lblEducation.InnerHtml = html.ToString();
    }

    public void addDates()
    {
        int i = 0;
        DateTime dt = new DateTime();
        dt = DateTime.Now.AddDays(1);
        for (; i <= 30; i++)
        {
            cmbDate.Items.Add(new ListItem(dt.ToString("dd-MM-yyyy"), dt.ToString("dd-MM-yyyy")));
            dt = dt.AddDays(1);
        }
    }

    public void fillReview()
    {
        DataTable dt = new DataTable();
        StringBuilder html = new StringBuilder();
        string sqlQry = "";
        sqlQry = "select a.*,c.first_name,c.last_name from LAS_review a " +
                                    " Left Join LAS_appointment b on a.appointment_id = b.appointment_id " +
                                    " Left Join LAS_login c on b.user_login_id = c.login_id " +
                                    " where b.office_id = '" + ViewState["oid"].ToString() + "'";
        dt = dbCommon.DisplayDataQuery(sqlQry).Tables[0];

        foreach (DataRow dr in dt.Rows)
        {
            html.Append("<figure class='rev-thumb'>"+dr["first_name"].ToString() + " "+ dr["last_name"].ToString() + " </figure>");
            html.Append("<div class='rev-content'> <div class='rev-info'>"+DateTime.Parse( dr["create_date"].ToString()).ToString("dd-MM-yyyy h:mm tt")+"</div>");
            html.Append("<div class='rev-text'><p>");
            html.Append(dr["description"].ToString());
            html.Append("</p></div></div>");                                            
        }
        displayReview.InnerHtml = html.ToString();
    }
    protected void cmbDate_SelectedIndexChanged(object sender, EventArgs e)
    {
        string dayName = "", sqlStr = "";
        int minTime = 0;
        DateTime mTimeFrom, mTimeTo, eTimeFrom ,eTimeTo = new DateTime();
        if (cmbDate.SelectedValue.ToString() != "select")
        {
            dayName = DateTime.Parse(cmbDate.SelectedValue).DayOfWeek.ToString().ToLower();

            sqlStr = "select * from LAS_timing where office_id='" + ViewState["oid"].ToString() + "' and day_name='" + dayName + "'";
            DataTable dt = new DataTable();
            DataTable dtCheckTime = new DataTable();
            dt = dbCommon.DisplayDataQuery(sqlStr).Tables[0];
            StringBuilder html = new StringBuilder();
            foreach(DataRow dr in dt.Rows)
            {
                if (dr["is_holiday"].ToString() == "0")
                {
                    html.Append("<h2>Holidy<h2>");
                }
                else
                {
                    mTimeFrom = DateTime.Parse(dr["morning_from"].ToString());
                    mTimeTo = DateTime.Parse(dr["morning_to"].ToString());
                    eTimeFrom = DateTime.Parse(dr["evening_from"].ToString());
                    eTimeTo = DateTime.Parse(dr["evening_to"].ToString());
                    minTime = Int32.Parse(dr["average_time"].ToString());

                    html.Append("<div class='col-md-3 col-3 text-center'>Morning Time");
                    html.Append("<ul class='time_select'>");
                    string sqlTime = "";
                    for (;mTimeFrom<=mTimeTo;) {
                        html.Append("<li>");

                        dtCheckTime.Rows.Clear();

                        sqlTime = "select * from LAS_appointment where book_date='" + DateTime.Parse(cmbDate.SelectedValue.ToString()).ToString("yyyy-MM-dd") + "' and book_time='" + DateTime.Parse(mTimeFrom.ToString()).ToString("H:mm") + "' and office_id='" + ViewState["oid"] + "'";
                        dtCheckTime =dbCommon.DisplayDataQuery(sqlTime).Tables[0];
                        if (dtCheckTime.Rows.Count > 0)
                        {
                            html.Append("<label for='radio1'><strike>" + DateTime.Parse(mTimeFrom.ToString()).ToString("h:mm") + "</strike></label>");
                        }
                        else
                        {
                            html.Append("<label for='radio1'><a href='confirmbook.aspx?bdt="+ DateTime.Parse(cmbDate.SelectedValue.ToString()).ToString("dd-MM-yyyy") + "&btm=" + DateTime.Parse(mTimeFrom.ToString()).ToString("h:mm") + "&oid=" + ViewState["oid"].ToString() + "'>" + DateTime.Parse(mTimeFrom.ToString()).ToString("h:mm tt") + "</a></label>");
                        }
                            html.Append("</li>");

                        mTimeFrom = mTimeFrom.AddMinutes(minTime);
                    }
                    html.Append("</ul>");
                    html.Append("</div>");

                    html.Append("<div class='col-md-3 col-3 text-center'>Evening Time");
                    html.Append("<ul class='time_select'>");
                    for (; eTimeFrom <= eTimeTo;)
                    {
                        html.Append("<li>");
                        dtCheckTime.Rows.Clear();
                        dtCheckTime = dbCommon.DisplayDataQuery("select * from LAS_appointment where book_date='" + DateTime.Parse(cmbDate.SelectedValue.ToString()).ToString("yyyy-MM-dd") + "' and book_time='" + DateTime.Parse(eTimeFrom.ToString()).ToString("H:mm") + "' and office_id='" + ViewState["oid"] + "'").Tables[0];
                        if (dtCheckTime.Rows.Count > 0)
                        {
                            html.Append("<label for='radio1'><strike>" + DateTime.Parse(eTimeFrom.ToString()).ToString("h:mm") + "</strike></label>");
                        }
                        else
                        {
                            html.Append("<label for='radio1'><a href='search_lawyer.aspx?bdt=" + DateTime.Parse(cmbDate.SelectedValue.ToString()).ToString("dd-MM-yyyy") + "btm=" + DateTime.Parse(eTimeFrom.ToString()).ToString("H:mm") + "&oid="+ViewState["oid"]+"'>" + DateTime.Parse(eTimeFrom.ToString()).ToString("h:mm tt") + "</a></label>");
                        }
                        html.Append("</li>");

                        eTimeFrom = eTimeFrom.AddMinutes(minTime);
                    }
                    html.Append("</ul>");
                    html.Append("</div>");
                }
            }
            displayTimeHoliday.InnerHtml = html.ToString();


        }
    }
}