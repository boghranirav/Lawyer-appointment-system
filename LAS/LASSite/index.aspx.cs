using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class index : System.Web.UI.Page
{
    DBConnectionClass dbCommon = new DBConnectionClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dbCommon.SetUpdateId("qryStrSearch", "None");
            fillTable();
        }
    }

    public void fillTable()
    {
        string sqlP = "select a.specialization_id, a.description,IsNull(temp.countLawyer,0) as countLawyer from LAS_specialization a " +
                    " left Join " +
                    " (select count(b.login_id) as 'countLawyer',b.specialization_id  " +
                    " from LAS_lawyer_profile b , LAS_login c where c.login_id=b.login_id and c.user_type='lawyer' and c.active_flag='0' group by b.specialization_id) temp on temp.specialization_id = a.specialization_id ";

        DataTable dt = new DataTable();
        dt = dbCommon.DisplayDataQuery(sqlP).Tables[0];

        string div_add = "";
        foreach (DataRow dr in dt.Rows)
        {
            div_add +="<div class='col-lg-3 col-md-6'>";
            div_add += "<a href = 'search_lawyer.aspx?speId="+dr["specialization_id"].ToString()+"' class='box_cat_home'>";
            div_add += "<i class='icon-info-4'></i>";
            div_add += "<h3><font size='5' color='blue' face='arial'>" + dr["description"].ToString()+"</font></h3>";
            div_add += "<ul class='clearfix'>";
            div_add += "<li><strong>"+dr["countLawyer"].ToString()+"</strong> Lawyer in "+ dr["description"].ToString() + "</li>";
            div_add += "</ul>";
            div_add += "</a>";
            div_add += "</div>";
        }

        displaySpec.InnerHtml = div_add;
    }


    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> GetCompletionList(string prefixText)
    {
        
        List<string> CompliteList = new List<string>();
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["SqlConStr"].ToString());
        con.Open();
        SqlCommand cmd = new SqlCommand("select distinct office_name from LAS_Office where office_name like @Name+'%'", con);
        cmd.Parameters.AddWithValue("@Name", prefixText);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            CompliteList.Add(dt.Rows[i]["office_name"].ToString());
        }
        con.Close();

        con.Open();
        SqlCommand cmd2 = new SqlCommand("select distinct first_name, last_name from LAS_login where (first_name like @Name+'%' or last_name like @Name+'%') and user_type='lawyer'", con);
        cmd2.Parameters.AddWithValue("@Name", "%" + prefixText + "%");
        SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
        DataTable dt2 = new DataTable();
        da2.Fill(dt2);

        for (int i = 0; i < dt2.Rows.Count; i++)
        {
            CompliteList.Add(dt2.Rows[i][0].ToString() + " "+ dt2.Rows[i][1].ToString());
        }
        con.Close();
        con.Open();
        SqlCommand cmd3 = new SqlCommand("select description from LAS_specialization where description like @Name+'%'", con);
        cmd3.Parameters.AddWithValue("@Name", prefixText);
        SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
        DataTable dt3 = new DataTable();
        da3.Fill(dt3);

        for (int i = 0; i < dt3.Rows.Count; i++)
        {
            CompliteList.Add(dt3.Rows[i]["description"].ToString());
        }
        con.Close();

        return CompliteList;
    }
}