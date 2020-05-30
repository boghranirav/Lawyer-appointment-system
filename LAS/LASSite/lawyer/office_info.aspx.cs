using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class lawyer_office_info : System.Web.UI.Page
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
            fillTable();
            Fill_Combo_area();

            if (Request.QueryString.AllKeys.Contains("eid"))
            {
                if (!Request.QueryString["eid"].ToString().All(char.IsDigit))
                {
                    Response.Redirect("../logout.aspx");
                }
                btnsubmit.Text = "Update";

                string id = Request.QueryString["eid"];

                ViewState["id"] = Request.QueryString["eid"];

                DataTable dt = new DataTable();
                dt = dbCommon.DisplayDataQuery("select * from LAS_office where office_id='" + id + "'").Tables[0];

                if (dt.Rows.Count == 0) { Response.Redirect("office_info.aspx"); }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        txtname.Text = dr["office_name"].ToString();
                        txtaddress.Text = dr["address"].ToString();
                        txtpostalcode.Text = dr["pincode"].ToString();
                        txtemail.Text = dr["email_id"].ToString();
                        cmbarea.SelectedValue= dr["area_id"].ToString();
                        txtmobile.Text = dr["mobile"].ToString();
                    }
                }
            }
            else if (Request.QueryString.AllKeys.Length == 1)
            {
                Response.Redirect("../Logout.aspx");
            }
        }
    }

    protected void Fill_Combo_area()
    {

        DataTable dtCat = new DataTable();
        dtCat = dbCommon.DisplayDataQuery("select * from LAS_area").Tables[0];
        cmbarea.Items.Clear();
        cmbarea.Items.Add(new ListItem("Select Area", "select"));
        foreach (DataRow drUserInfo in dtCat.Rows)
        {
            cmbarea.Items.Add(new ListItem(drUserInfo["area_name"].ToString(), drUserInfo["area_id"].ToString()));
        }
    }


    public void fillTable()
    {
        DBConnectionClass sp3 = new DBConnectionClass("displayData");
        string sqlP = "select * from LAS_office where login_id='"+Session["Slogin_id"].ToString()+"'";

        DataTable dt = new DataTable();
        dt = sp3.DisplayDataQuery(sqlP).Tables[0];
        StringBuilder html = new StringBuilder();
        foreach (DataRow dr in dt.Rows)
        {
            html.Append("<tr>");
            html.Append("<td>" + dr["office_name"] + "</td>");
            html.Append("<td>" + dr["address"] + "</td>");
            html.Append("<td>" + dr["email_id"] + "</td>");
            html.Append("<td align='center' width='4%'><a href='office_info.aspx?eid=" + dr["office_id"].ToString() + "'><i class='fa fa-1x fa-pencil'></i></a></td>");
            html.Append("<td align='center' width='4%'><a href='Javascript:deletefunction(" + dr["office_id"].ToString() + ");'><i class='fa fa-1x fa-trash-o'></i></a></td>");
            html.Append("</tr>");
        }
        displayOffice.InnerHtml = html.ToString();
    }


    protected void btnsubmit_Click(object sender, EventArgs e)
    {
            if (btnsubmit.Text == "Submit")
            {
           
                int maxId = dbCommon.CheckDuplicateByQuery("select IsNUll(Max(office_id),0)+1 from LAS_office");
                bool b = dbCommon.boolInsertData("insert into LAS_office (office_id,login_id,office_name,address,pincode,mobile,email_id,area_id) " +
                                        " values('" + maxId + "', '" + Session["Slogin_id"].ToString().Trim() + "','"+ txtname.Text.ToString().Trim() + "', " + 
                                        " '"+txtaddress.Text.ToString().Trim() +"','"+txtpostalcode.Text.ToString().Trim() + "','"+txtmobile.Text.ToString().Trim() + "', " + 
                                        " '"+txtemail.Text.ToString().Trim() + "', '"+cmbarea.SelectedValue.ToString().Trim() + "' ) ");

                if (b == true)
                {
                    Response.Redirect("office_info.aspx");
                }
            }
            else
            {
                bool b = dbCommon.boolInsertData("update LAS_office set office_name='" + txtname.Text.ToString().Trim() + "'," + 
                                        " address='"+txtaddress.Text.ToString().Trim() + "',pincode='"+txtpostalcode.Text.ToString().Trim() + "', " + 
                                        " mobile='"+txtmobile.Text.ToString().Trim() + "',email_id='"+txtemail.Text.ToString().Trim() + "', " + 
                                        " area_id='"+ cmbarea.SelectedValue.ToString().Trim() + "'  " +
                                        "  where office_id='" + ViewState["id"].ToString() + "' ");

                if (b == true)
                {
                    Response.Redirect("office_info.aspx");
                }
            }
    }

    [System.Web.Services.WebMethod]
    public static string Deleteoffice(string eid)
    {
        try
        {
            DBConnectionClass con = new DBConnectionClass();

            bool i = con.boolInsertData("delete from LAS_office where office_id='" + eid.ToString().Trim() + "'");
            if (i == true) return "true"; else return "false";
        }
        catch (Exception)
        {
            return "false";
        }
    }

    protected void btncancel_Click(object sender, EventArgs e)
    {

    }
}