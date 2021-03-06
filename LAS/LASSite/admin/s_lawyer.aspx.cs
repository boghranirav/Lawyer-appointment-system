﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_s_lawyer : System.Web.UI.Page
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
        string sqlP = "select a.login_id,a.user_type,a.first_name,a.last_name,a.email_id,a.active_flag,a.mobile_no, c.description " +
                       " from LAS_Login a, LAS_lawyer_profile b " +
                       " Left Join LAS_specialization c On c.specialization_id = b.specialization_id " +
                       " where a.login_id = b.login_id order by a.create_date desc   ";

        DataTable dt = new DataTable();
        dt = sp3.DisplayDataQuery(sqlP).Tables[0];
        StringBuilder html = new StringBuilder();
        foreach (DataRow dr in dt.Rows)
        {
            if (dr["user_type"].ToString() != "ADMIN")
            {

                html.Append("<tr>");
                html.Append("<td>" + dr["first_name"] + " " + dr["last_name"] + "</td>");
                html.Append("<td>" + dr["email_id"] + "</td>");
                html.Append("<td>" + dr["mobile_no"] + "</td>");
                html.Append("<td>" + dr["description"] + "</td>");
                if (dr["active_flag"].ToString() == "0")
                {
                    html.Append("<td align='center' width='4%'>Active</td>");
                }
                else
                {
                    html.Append("<td align='center' width='4%'>Deactive</td>");
                }

                if (dr["active_flag"].ToString() == "0")
                {
                    html.Append("<td align='center' width='4%'><a href='Javascript:deletefunction(1," + dr["login_id"].ToString() + ");'>Deactive</a></td>");
                }
                else
                {
                    html.Append("<td align='center' width='4%'><a href='Javascript:deletefunction(0," + dr["login_id"].ToString() + ");'>Active</a></td>");
                }
                html.Append("</tr>");
            }

        }
        displayLawyer.InnerHtml = html.ToString();
    }

    [System.Web.Services.WebMethod]
    public static string UserActiveDeActive(string eid, string uid)
    {
        try
        {
            DBConnectionClass con = new DBConnectionClass();
            bool i;
            if (eid.ToString() == "0")
            {
                i = con.boolInsertData("update LAS_login set active_flag=0 where login_id='" + uid.ToString().Trim() + "'");
            }
            else
            {
                i = con.boolInsertData("update LAS_login set active_flag=1 where login_id='" + uid.ToString().Trim() + "'");
            }
            if (i == true) return "true"; else return "false";
        }
        catch (Exception)
        {
            return "false";
        }
    }
}