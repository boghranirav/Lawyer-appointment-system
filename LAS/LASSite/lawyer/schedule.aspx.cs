using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class lawyer_schedule : System.Web.UI.Page
{
    DateTime dt = DateTime.Parse("00:00");
    DBConnectionClass dbCommon = new DBConnectionClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["Suser_type"] == null)
        {
            Response.Redirect("../LogOut.aspx");
        }
        if (!IsPostBack)
        {
            Fill_Combo_Office();
            setDifaultZero();
            fillData();
        }
    }

    public void fillData()
    {
        if (cmbOffice.SelectedValue != "select")
        {
            string sqlStr = "";

            sqlStr = "Select * from LAS_timing where office_id='"+cmbOffice.SelectedValue.ToString()+"' order by timing_id ";

            DataTable dt = new DataTable();
            dt = dbCommon.DisplayDataQuery(sqlStr).Tables[0];

            if (dt.Rows.Count > 0) {
                btnsubmit.Text = "Update";
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["day_name"].ToString() == "monday")
                    {
                        timepickermo1.Text = DateTime.Parse(dr["morning_from"].ToString()).ToShortTimeString();
                        timepickermo2.Text = DateTime.Parse(dr["morning_to"].ToString()).ToShortTimeString();
                        timepickermo3.Text = DateTime.Parse(dr["evening_from"].ToString()).ToShortTimeString();
                        timepickermo4.Text = DateTime.Parse(dr["evening_to"].ToString()).ToShortTimeString();
                        if (dr["is_holiday"].ToString() == "0")
                        {
                            cb_day1.Checked = true;
                            cb_day1_CheckedChanged(true);
                        }
                        else
                        {
                            cb_day1_CheckedChanged(false);
                            cb_day1.Checked = false;
                        }
                        tb_minutes.Text = dr["average_time"].ToString();
                    }

                    if (dr["day_name"].ToString() == "tuesday")
                    {
                        timepickertu1.Text = DateTime.Parse(dr["morning_from"].ToString()).ToShortTimeString();
                        timepickertu2.Text = DateTime.Parse(dr["morning_to"].ToString()).ToShortTimeString();
                        timepickertu3.Text = DateTime.Parse(dr["evening_from"].ToString()).ToShortTimeString();
                        timepickertu4.Text = DateTime.Parse(dr["evening_to"].ToString()).ToShortTimeString();
                        if (dr["is_holiday"].ToString() == "0")
                        {
                            cb_day2.Checked = true;
                            cb_day2_CheckedChanged(true);
                        }
                        else
                        {
                            cb_day2_CheckedChanged(false);
                            cb_day2.Checked = false;
                        }
                    }

                    if (dr["day_name"].ToString() == "wednesday")
                    {
                        timepickerwe1.Text = DateTime.Parse(dr["morning_from"].ToString()).ToShortTimeString();
                        timepickerwe2.Text = DateTime.Parse(dr["morning_to"].ToString()).ToShortTimeString();
                        timepickerwe3.Text = DateTime.Parse(dr["evening_from"].ToString()).ToShortTimeString();
                        timepickerwe4.Text = DateTime.Parse(dr["evening_to"].ToString()).ToShortTimeString();
                        if (dr["is_holiday"].ToString() == "0")
                        {
                            cb_day3.Checked = true;
                            cb_day3_CheckedChanged(true);
                        }
                        else
                        {
                            cb_day3_CheckedChanged(false);
                            cb_day3.Checked = false;
                        }
                    }

                    if (dr["day_name"].ToString() == "thursday")
                    {
                        timepickerthu1.Text = DateTime.Parse(dr["morning_from"].ToString()).ToShortTimeString();
                        timepickerthu2.Text = DateTime.Parse(dr["morning_to"].ToString()).ToShortTimeString();
                        timepickerthu3.Text = DateTime.Parse(dr["evening_from"].ToString()).ToShortTimeString();
                        timepickerthu4.Text = DateTime.Parse(dr["evening_to"].ToString()).ToShortTimeString();
                        if (dr["is_holiday"].ToString() == "0")
                        {
                            cb_day4.Checked = true;
                            cb_day4_CheckedChanged(true);
                        }
                        else
                        {
                            cb_day4_CheckedChanged(false);
                            cb_day4.Checked = false;
                        }
                    }

                    if (dr["day_name"].ToString() == "friday")
                    {
                        timepickerfri1.Text = DateTime.Parse(dr["morning_from"].ToString()).ToShortTimeString();
                        timepickerfri2.Text = DateTime.Parse(dr["morning_to"].ToString()).ToShortTimeString();
                        timepickerfri3.Text = DateTime.Parse(dr["evening_from"].ToString()).ToShortTimeString();
                        timepickerfri4.Text = DateTime.Parse(dr["evening_to"].ToString()).ToShortTimeString();
                        if (dr["is_holiday"].ToString() == "0")
                        {
                            cb_day5.Checked = true;
                            cb_day5_CheckedChanged(true);
                        }
                        else
                        {
                            cb_day5_CheckedChanged(false);
                            cb_day5.Checked = false;
                        }
                    }

                    if (dr["day_name"].ToString() == "saturday")
                    {
                        timepickersat1.Text = DateTime.Parse(dr["morning_from"].ToString()).ToShortTimeString();
                        timepickersat2.Text = DateTime.Parse(dr["morning_to"].ToString()).ToShortTimeString();
                        timepickersat3.Text = DateTime.Parse(dr["evening_from"].ToString()).ToShortTimeString();
                        timepickersat4.Text = DateTime.Parse(dr["evening_to"].ToString()).ToShortTimeString();
                        if (dr["is_holiday"].ToString() == "0")
                        {
                            cb_day6.Checked = true;
                            cb_day6_CheckedChanged(true);
                        }
                        else
                        {
                            cb_day6_CheckedChanged(false);
                            cb_day6.Checked = false;
                        }
                    }

                    if (dr["day_name"].ToString() == "sunday")
                    {
                        timepickersun1.Text = DateTime.Parse(dr["morning_from"].ToString()).ToShortTimeString();
                        timepickersun2.Text = DateTime.Parse(dr["morning_to"].ToString()).ToShortTimeString();
                        timepickersun3.Text = DateTime.Parse(dr["evening_from"].ToString()).ToShortTimeString();
                        timepickersun4.Text = DateTime.Parse(dr["evening_to"].ToString()).ToShortTimeString();
                        if (dr["is_holiday"].ToString() == "0")
                        {
                            cb_day7.Checked = true;
                            cb_day7_CheckedChanged(true);
                        }
                        else
                        {
                            cb_day7_CheckedChanged(false);
                            cb_day7.Checked = false;
                        }
                    }
                }
            }
            else
            {
                tb_minutes.Text = "";
                cb_day1.Checked = false;
                cb_day2.Checked = false;
                cb_day3.Checked = false;
                cb_day4.Checked = false;
                cb_day5.Checked = false;
                cb_day6.Checked = false;
                cb_day7.Checked = false;
                setDifaultZero();
                cb_day1_CheckedChanged(false);
                cb_day2_CheckedChanged(false);
                cb_day3_CheckedChanged(false);
                cb_day4_CheckedChanged(false);
                cb_day5_CheckedChanged(false);
                cb_day6_CheckedChanged(false);
                cb_day7_CheckedChanged(false);
                btnsubmit.Text = "Submit";
            }

        }
    }

    public void setDifaultZero()
    {
        timepickermo1.Text = dt.ToShortTimeString();
        timepickermo2.Text = dt.ToShortTimeString();
        timepickermo3.Text = dt.ToShortTimeString();
        timepickermo4.Text = dt.ToShortTimeString();

        timepickertu1.Text = dt.ToShortTimeString();
        timepickertu2.Text = dt.ToShortTimeString();
        timepickertu3.Text = dt.ToShortTimeString();
        timepickertu4.Text = dt.ToShortTimeString();

        timepickerwe1.Text = dt.ToShortTimeString();
        timepickerwe2.Text = dt.ToShortTimeString();
        timepickerwe3.Text = dt.ToShortTimeString();
        timepickerwe4.Text = dt.ToShortTimeString();

        timepickerthu1.Text = dt.ToShortTimeString();
        timepickerthu2.Text = dt.ToShortTimeString();
        timepickerthu3.Text = dt.ToShortTimeString();
        timepickerthu4.Text = dt.ToShortTimeString();

        timepickerfri1.Text = dt.ToShortTimeString();
        timepickerfri2.Text = dt.ToShortTimeString();
        timepickerfri3.Text = dt.ToShortTimeString();
        timepickerfri4.Text = dt.ToShortTimeString();

        timepickersat1.Text = dt.ToShortTimeString();
        timepickersat2.Text = dt.ToShortTimeString();
        timepickersat3.Text = dt.ToShortTimeString();
        timepickersat4.Text = dt.ToShortTimeString();

        timepickersun1.Text = dt.ToShortTimeString();
        timepickersun2.Text = dt.ToShortTimeString();
        timepickersun3.Text = dt.ToShortTimeString();
        timepickersun4.Text = dt.ToShortTimeString();
    }

    protected void Fill_Combo_Office()
    {

        DataTable dtCat = new DataTable();
        dtCat = dbCommon.DisplayDataQuery("select office_id, Concat(office_name,'-',address) as office_name from LAS_office where login_id='"+Session["Slogin_id"] +"'").Tables[0];
        cmbOffice.Items.Clear();
        cmbOffice.Items.Add(new ListItem("Select Office", "select"));
        foreach (DataRow drUserInfo in dtCat.Rows)
        {
            cmbOffice.Items.Add(new ListItem(drUserInfo["office_name"].ToString(), drUserInfo["office_id"].ToString()));
        }
    }

    protected void cb_day1_CheckedChanged1(object sender, EventArgs e)
    {
        cb_day1_CheckedChanged(cb_day1.Checked);
    }

    public void cb_day1_CheckedChanged(bool chkVal)
    {
        if (chkVal == true)
        {
            timepickermo1.Enabled = false;
            timepickermo2.Enabled = false;
            timepickermo3.Enabled = false;
            timepickermo4.Enabled = false;
            timepickermo1.Text = dt.ToShortTimeString();
            timepickermo2.Text = dt.ToShortTimeString();
            timepickermo3.Text = dt.ToShortTimeString();
            timepickermo4.Text = dt.ToShortTimeString();
        }
        else
        {
            timepickermo1.Enabled = true;
            timepickermo2.Enabled = true;
            timepickermo3.Enabled = true;
            timepickermo4.Enabled = true;
        }
    }
    protected void cb_day2_CheckedChanged(object sender, EventArgs e)
    {
        cb_day2_CheckedChanged(cb_day2.Checked);
    }

    public void cb_day2_CheckedChanged(bool chkVal)
    {
        if (chkVal == true)
        {
            timepickertu1.Enabled = false;
            timepickertu2.Enabled = false;
            timepickertu3.Enabled = false;
            timepickertu4.Enabled = false;
            timepickertu1.Text = dt.ToShortTimeString();
            timepickertu2.Text = dt.ToShortTimeString();
            timepickertu3.Text = dt.ToShortTimeString();
            timepickertu4.Text = dt.ToShortTimeString();
        }
        else
        {
            timepickertu1.Enabled = true;
            timepickertu2.Enabled = true;
            timepickertu3.Enabled = true;
            timepickertu4.Enabled = true;
        }
    }

        protected void cb_day3_CheckedChanged(object sender, EventArgs e)
    {
        cb_day3_CheckedChanged(cb_day3.Checked);
    }

    public void cb_day3_CheckedChanged(bool chkVal)
    {
        if (chkVal == true)
        {
            timepickerwe1.Enabled = false;
            timepickerwe2.Enabled = false;
            timepickerwe3.Enabled = false;
            timepickerwe4.Enabled = false;
            timepickerwe1.Text = dt.ToShortTimeString();
            timepickerwe2.Text = dt.ToShortTimeString();
            timepickerwe3.Text = dt.ToShortTimeString();
            timepickerwe4.Text = dt.ToShortTimeString();
        }
        else
        {
            timepickerwe1.Enabled = true;
            timepickerwe2.Enabled = true;
            timepickerwe3.Enabled = true;
            timepickerwe4.Enabled = true;
        }
    }

    protected void cb_day4_CheckedChanged(object sender, EventArgs e)
    {
        cb_day4_CheckedChanged(cb_day4.Checked);
    }

    public void cb_day4_CheckedChanged(bool chkVal)
    {
        if (chkVal == true)
        {
            timepickerthu1.Enabled = false;
            timepickerthu2.Enabled = false;
            timepickerthu3.Enabled = false;
            timepickerthu4.Enabled = false;
            timepickerthu1.Text = dt.ToShortTimeString();
            timepickerthu2.Text = dt.ToShortTimeString();
            timepickerthu3.Text = dt.ToShortTimeString();
            timepickerthu4.Text = dt.ToShortTimeString();
        }
        else
        {
            timepickerthu1.Enabled = true;
            timepickerthu2.Enabled = true;
            timepickerthu3.Enabled = true;
            timepickerthu4.Enabled = true;
        }
    }

    protected void cb_day5_CheckedChanged(object sender, EventArgs e)
    {
        cb_day5_CheckedChanged(cb_day5.Checked);
    }

    public void cb_day5_CheckedChanged(bool chkVal)
    {
        if (chkVal== true)
        {
            timepickerfri1.Enabled = false;
            timepickerfri2.Enabled = false;
            timepickerfri3.Enabled = false;
            timepickerfri4.Enabled = false;
            timepickerfri1.Text = dt.ToShortTimeString();
            timepickerfri2.Text = dt.ToShortTimeString();
            timepickerfri3.Text = dt.ToShortTimeString();
            timepickerfri4.Text = dt.ToShortTimeString();
        }
        else
        {
            timepickerfri1.Enabled = true;
            timepickerfri2.Enabled = true;
            timepickerfri3.Enabled = true;
            timepickerfri4.Enabled = true;
        }
    }

    protected void cb_day6_CheckedChanged(object sender, EventArgs e)
    {
        cb_day6_CheckedChanged(cb_day6.Checked);
    }

    public void cb_day6_CheckedChanged(bool chkVal)
    {
        if (chkVal == true)
        {
            timepickersat1.Enabled = false;
            timepickersat2.Enabled = false;
            timepickersat3.Enabled = false;
            timepickersat4.Enabled = false;
            timepickersat1.Text = dt.ToShortTimeString();
            timepickersat2.Text = dt.ToShortTimeString();
            timepickersat3.Text = dt.ToShortTimeString();
            timepickersat4.Text = dt.ToShortTimeString();
        }
        else
        {
            timepickersat1.Enabled = true;
            timepickersat2.Enabled = true;
            timepickersat3.Enabled = true;
            timepickersat4.Enabled = true;
        }
    }

    protected void cb_day7_CheckedChanged(object sender, EventArgs e)
    {
        cb_day7_CheckedChanged(cb_day7.Checked);
    }

    public void cb_day7_CheckedChanged(bool chkVal)
    {
        if (chkVal == true)
        {
            timepickersun1.Enabled = false;
            timepickersun2.Enabled = false;
            timepickersun3.Enabled = false;
            timepickersun4.Enabled = false;
            timepickersun1.Text = dt.ToShortTimeString();
            timepickersun2.Text = dt.ToShortTimeString();
            timepickersun3.Text = dt.ToShortTimeString();
            timepickersun4.Text = dt.ToShortTimeString();
        }
        else
        {
            timepickersun1.Enabled = true;
            timepickersun2.Enabled = true;
            timepickersun3.Enabled = true;
            timepickersun4.Enabled = true;
        }
    }

    protected void cmbOffice_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillData();
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
            AddOfficeTime(btnsubmit.Text);
    }

    public void AddOfficeTime(string tp)
    {

        //int maxId = dbCommon.CheckDuplicateByQuery("select IsNUll(Max(timing_id),0)+1 from LAS_timing");

        string sqlStr = "";
        int isHoliday = 0;

        if (tp == "Update")
        {
            sqlStr = "delete from LAS_timing where office_id='" + cmbOffice.SelectedValue.ToString() + "' ";
            dbCommon.boolInsertData(sqlStr);

        }

        if (cb_day1.Checked == true) { isHoliday = 0; } else { isHoliday = 1; }

        sqlStr += " insert into LAS_timing(timing_id,office_id,day_name,morning_from,morning_to,evening_from,evening_to,average_time,is_holiday) " +
                  " Values((select IsNUll(Max(timing_id),0)+1 from LAS_timing),'" + cmbOffice.SelectedValue.ToString() + "','monday', " +
                  " '" + DateTime.Parse(timepickermo1.Text).ToShortTimeString() + "','" + DateTime.Parse(timepickermo2.Text).ToShortTimeString() + "', " +
                  " '" + DateTime.Parse(timepickermo3.Text).ToShortTimeString() + "','" + DateTime.Parse(timepickermo4.Text).ToShortTimeString() + "', " +
                  " '" + tb_minutes.Text.ToString() + "','" + isHoliday + "') ";

        if (cb_day2.Checked == true) { isHoliday = 0; } else { isHoliday = 1; }

        sqlStr += " insert into LAS_timing(timing_id,office_id,day_name,morning_from,morning_to,evening_from,evening_to,average_time,is_holiday) " +
          " Values((select IsNUll(Max(timing_id),0)+1 from LAS_timing),'" + cmbOffice.SelectedValue.ToString() + "','tuesday', " +
          " '" + DateTime.Parse(timepickertu1.Text).ToShortTimeString() + "','" + DateTime.Parse(timepickertu2.Text).ToShortTimeString() + "', " +
          " '" + DateTime.Parse(timepickertu3.Text).ToShortTimeString() + "','" + DateTime.Parse(timepickertu4.Text).ToShortTimeString() + "', " +
          " '" + tb_minutes.Text.ToString() + "','" + isHoliday + "') ";

        if (cb_day3.Checked == true) { isHoliday = 0; } else { isHoliday = 1; }
        sqlStr += " insert into LAS_timing(timing_id,office_id,day_name,morning_from,morning_to,evening_from,evening_to,average_time,is_holiday) " +
          " Values((select IsNUll(Max(timing_id),0)+1 from LAS_timing),'" + cmbOffice.SelectedValue.ToString() + "','wednesday', " +
          " '" + DateTime.Parse(timepickerwe1.Text).ToShortTimeString() + "','" + DateTime.Parse(timepickerwe2.Text).ToShortTimeString() + "', " +
          " '" + DateTime.Parse(timepickerwe3.Text).ToShortTimeString() + "','" + DateTime.Parse(timepickerwe4.Text).ToShortTimeString() + "', " +
          " '" + tb_minutes.Text.ToString() + "','" + isHoliday + "') ";

        if (cb_day4.Checked == true) { isHoliday = 0; } else { isHoliday = 1; }
        sqlStr += " insert into LAS_timing(timing_id,office_id,day_name,morning_from,morning_to,evening_from,evening_to,average_time,is_holiday) " +
          " Values((select IsNUll(Max(timing_id),0)+1 from LAS_timing),'" + cmbOffice.SelectedValue.ToString() + "','thursday', " +
          " '" + DateTime.Parse(timepickerthu1.Text).ToShortTimeString() + "','" + DateTime.Parse(timepickerthu2.Text).ToShortTimeString() + "', " +
          " '" + DateTime.Parse(timepickerthu3.Text).ToShortTimeString() + "','" + DateTime.Parse(timepickerthu4.Text).ToShortTimeString() + "', " +
          " '" + tb_minutes.Text.ToString() + "','" + isHoliday + "') ";

        if (cb_day5.Checked == true) { isHoliday = 0; } else { isHoliday = 1; }
        sqlStr += " insert into LAS_timing(timing_id,office_id,day_name,morning_from,morning_to,evening_from,evening_to,average_time,is_holiday) " +
          " Values((select IsNUll(Max(timing_id),0)+1 from LAS_timing),'" + cmbOffice.SelectedValue.ToString() + "','friday', " +
          " '" + DateTime.Parse(timepickerfri1.Text).ToShortTimeString() + "','" + DateTime.Parse(timepickerfri2.Text).ToShortTimeString() + "', " +
          " '" + DateTime.Parse(timepickerfri3.Text).ToShortTimeString() + "','" + DateTime.Parse(timepickerfri4.Text).ToShortTimeString() + "', " +
          " '" + tb_minutes.Text.ToString() + "','" + isHoliday + "') ";

        if (cb_day6.Checked == true) { isHoliday = 0; } else { isHoliday = 1; }
        sqlStr += " insert into LAS_timing(timing_id,office_id,day_name,morning_from,morning_to,evening_from,evening_to,average_time,is_holiday) " +
          " Values((select IsNUll(Max(timing_id),0)+1 from LAS_timing),'" + cmbOffice.SelectedValue.ToString() + "','saturday', " +
          " '" + DateTime.Parse(timepickersat1.Text).ToShortTimeString() + "','" + DateTime.Parse(timepickersat2.Text).ToShortTimeString() + "', " +
          " '" + DateTime.Parse(timepickersat3.Text).ToShortTimeString() + "','" + DateTime.Parse(timepickersat4.Text).ToShortTimeString() + "', " +
          " '" + tb_minutes.Text.ToString() + "','" + isHoliday + "') ";

        if (cb_day7.Checked == true) { isHoliday = 0; } else { isHoliday = 1; }
        sqlStr += " insert into LAS_timing(timing_id,office_id,day_name,morning_from,morning_to,evening_from,evening_to,average_time,is_holiday) " +
          " Values((select IsNUll(Max(timing_id),0)+1 from LAS_timing),'" + cmbOffice.SelectedValue.ToString() + "','sunday', " +
          " '" + DateTime.Parse(timepickersun1.Text).ToShortTimeString() + "','" + DateTime.Parse(timepickersun2.Text).ToShortTimeString() + "', " +
          " '" + DateTime.Parse(timepickersun3.Text).ToShortTimeString() + "','" + DateTime.Parse(timepickersun4.Text).ToShortTimeString() + "', " +
          " '" + tb_minutes.Text.ToString() + "','" + isHoliday + "') ";

        bool i= dbCommon.boolInsertData(sqlStr);
        if (i == true)
        {
            Response.Redirect("schedule.aspx");
        }

    }

    protected void btncancel_Click(object sender, EventArgs e)
    {

    }
}