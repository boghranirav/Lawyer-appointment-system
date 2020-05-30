using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class search_lawyer : System.Web.UI.Page
{
    DBConnectionClass dbCommon = new DBConnectionClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Fill_Combo_City();
            Fill_Combo_specialization();
            if (Request.QueryString.AllKeys.Contains("speId"))
            {
                cmbSpecialization.SelectedValue = Request.QueryString["speId"].ToString();
            }
            searchLawyers();
            
        }
    }

    protected void searchLawyers()
    {
        
        string sqlStr = "", sqlSerach="", imgString = "", strData="";



        if (cmbCity.SelectedValue != "select")
        {
            sqlSerach += " and f.city_id='"+cmbCity.SelectedValue.ToString()+"' ";
        }
        if (cmbArea.SelectedValue != "select")
        {
            sqlSerach += " and c.area_id='" + cmbArea.SelectedValue.ToString() + "' ";
        }

        if (cmbSpecialization.SelectedValue != "select")
        {
            sqlSerach += " and d.specialization_id='" + cmbSpecialization.SelectedValue.ToString() + "' ";
        }

        if (dbCommon.IsEmptyUpdateId("qryStrSearch")) {
            strData = dbCommon.GetUpdateId("qryStrSearch").ToString();
            }

        sqlStr = "select a.login_id,a.first_name,a.last_name,b.profile_photo,b.description,d.description as 'Specialization',c.office_name,c.office_id  " +
                 " from LAS_login a " +
                 " Left Join LAS_lawyer_profile b on b.login_id = a.login_id " +
                 " Left Join LAS_office c on c.login_id = a.login_id " +
                 " Left Join LAS_specialization d on d.specialization_id = b.specialization_id " +
                 " Left Join LAS_area e on c.area_id=e.area_id " +
                 " Left Join LAS_city f On f.city_id = e.city_id " +
                 " where a.user_type = 'lawyer' and a.active_flag='0' and " +
                 " (a.first_name like '%" + strData + "%' Or a.last_name like '%" + strData + "%' Or " +
                 " d.description like '%" + strData + "%' Or c.office_name like '%" + strData + "%' Or " +
                 " Concat(a.first_name,' ',a.last_name) like '%" + strData + "%') " + sqlSerach + " ";

        DataTable dt = new DataTable();
        dt=dbCommon.DisplayDataQuery(sqlStr).Tables[0];
        StringBuilder htmlStr = new StringBuilder();

        displayLawyers.InnerHtml = "";
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {

                byte[] bytes;
                try
                {
                    bytes = (byte[])dr["profile_photo"];
                    string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                    imgString = "data:image/png;base64," + base64String;
                }
                catch (Exception)
                {
                    bytes = null;
                }

                htmlStr.Append("<div class='col-md-6'>");
                htmlStr.Append("<div class='box_list wow fadeIn'>");
                htmlStr.Append("<figure>");
                htmlStr.Append("<img src='"+imgString+"' class='img-fluid' alt=''>");
                htmlStr.Append("</figure>");
                htmlStr.Append("<div class='wrapper'>");
                htmlStr.Append("<h3>"+dr["first_name"]+ " "+ dr["last_name"].ToString()+"</h3>");

                htmlStr.Append("<small>"+dr["Specialization"] +" <br /> Office Name : "+ dr["office_name"] + "</small>");
                htmlStr.Append("<p align = 'justify' > "+dr["description"].ToString()+"</p>");
                htmlStr.Append("</div>");
                htmlStr.Append("<ul>");
                htmlStr.Append("<li></li>");
                htmlStr.Append("<li></li>");
                htmlStr.Append("<li><a href = 'view_lawyer.aspx?eid="+ dr["login_id"].ToString() + "&oid="+dr["office_id"]+"' > Book now</a></li>");
                htmlStr.Append("</ul>");
                htmlStr.Append("</div>");
                htmlStr.Append("</div>");

            }

            displayLawyers.InnerHtml = htmlStr.ToString();
        }
    }

    protected void Fill_Combo_City()
    {

        DataTable dtCat = new DataTable();
        dtCat = dbCommon.DisplayDataQuery("select * from LAS_city order by city_name").Tables[0];
        cmbCity.Items.Clear();
        cmbCity.Items.Add(new ListItem("Select City", "select"));
        foreach (DataRow drUserInfo in dtCat.Rows)
        {
            cmbCity.Items.Add(new ListItem(drUserInfo["city_name"].ToString(), drUserInfo["city_id"].ToString()));
        }
    }

    protected void Fill_Combo_Area()
    {

        if (cmbCity.SelectedValue.ToString() != "select")
        {
            DataTable dtCat = new DataTable();
            dtCat = dbCommon.DisplayDataQuery("select * from LAS_area where city_id='" + cmbCity.SelectedValue.ToString() + "' order by area_name").Tables[0];
            cmbArea.Items.Clear();
            cmbArea.Items.Add(new ListItem("Select Area", "select"));
            foreach (DataRow drUserInfo in dtCat.Rows)
            {
                cmbArea.Items.Add(new ListItem(drUserInfo["area_name"].ToString(), drUserInfo["area_id"].ToString()));
            }
        }
    }

    protected void Fill_Combo_specialization()
    {

        DataTable dtCat = new DataTable();
        dtCat = dbCommon.DisplayDataQuery("select * from LAS_specialization order by description").Tables[0];
        cmbSpecialization.Items.Clear();
        cmbSpecialization.Items.Add(new ListItem("Select specialization", "select"));
        foreach (DataRow drUserInfo in dtCat.Rows)
        {
            cmbSpecialization.Items.Add(new ListItem(drUserInfo["description"].ToString(), drUserInfo["specialization_id"].ToString()));
        }
    }


    protected void cmbCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        Fill_Combo_Area();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        searchLawyers();
    }
}