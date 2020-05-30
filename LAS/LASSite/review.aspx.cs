using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class review : System.Web.UI.Page
{
    DBConnectionClass dbCommon = new DBConnectionClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["Suser_type"] == null)
        {
            Response.Redirect("login.aspx");
        }
        if (!IsPostBack)
        {
            if (Request.QueryString.AllKeys.Contains("aid"))
            {
                ViewState["aid"] = Request.QueryString["aid"].ToString();
            }
            fillReview();
        }
    }

    public void fillReview()
    {
        DataTable dt = new DataTable();

        dt=dbCommon.DisplayDataQuery("select * from LAS_review where appointment_id='"+ ViewState["aid"].ToString()  +"'").Tables[0];

        if (dt.Rows.Count <= 0)
        {
            btnSubmit.Text = "Submit";
        }
        else
        {
            btnSubmit.Text = "Update";
            foreach (DataRow dr in dt.Rows)
            {
                txtReview.Text = dr["description"].ToString();
            }
        }

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string sqlStr = "";
        if (btnSubmit.Text == "Submit")
        {
            int maxId = dbCommon.CheckDuplicateByQuery("select IsNUll(Max(review_id),0)+1 from LAS_review");

            sqlStr = "insert into LAS_review (review_id,description,create_date,appointment_id) " + 
                     " values('"+maxId+"','"+txtReview.Text.ToString().Replace("'"," ")+ "',GETDATE(),'"+ViewState["aid"]+"')";

            if (dbCommon.boolInsertData(sqlStr) == true)
            {
                Response.Redirect("view_appointment.aspx");
            }
        }
        else
        {
            sqlStr = "update LAS_review set description='" + txtReview.Text.ToString().Replace("'", " ") + "' where review_id='" + ViewState["aid"].ToString() + "'";
            if (dbCommon.boolInsertData(sqlStr) == true)
            {
                Response.Redirect("view_appointment.aspx");
            }
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string sqlStr = "";
        sqlStr = "delete from LAS_review where review_id='" + ViewState["aid"].ToString() + "'";
        if (dbCommon.boolInsertData(sqlStr) == true)
        {
            Response.Redirect("view_appointment.aspx");
        }
    }
}