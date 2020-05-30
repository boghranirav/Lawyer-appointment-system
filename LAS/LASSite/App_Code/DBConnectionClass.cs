using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// Summary description for DBConnectionClass
/// </summary>
public class DBConnectionClass
{
    SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["SqlConStr"].ConnectionString);

    public string s_p_Name1 = "";
    public DBConnectionClass()
    {

    }

    public DBConnectionClass(string pro_name)
    {
        this.s_p_Name1 = pro_name;
    }

    SqlTransaction sqlT;
    public bool SaveData(List<SqlParameter> str)
    {
        con.Open();
        sqlT = con.BeginTransaction();
        try
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.Transaction = sqlT;
            cmd.CommandText = s_p_Name1;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            str.ToArray();
            for (int i = 0; i < str.Count; i += 1)
            {
                cmd.Parameters.Add(str[i]);
            }
            cmd.ExecuteNonQuery();
            sqlT.Commit();
            con.Close();
            return true;
        }
        catch (Exception)
        {
            sqlT.Rollback();
            con.Close();
            return false;
        }
    }

    public string HashId(string Password)
    {
        byte[] bytes = Encoding.Unicode.GetBytes(Password);
        byte[] inArray = HashAlgorithm.Create("SHA256").ComputeHash(bytes);
        return Convert.ToBase64String(inArray);
    }

    public void SetUpdateId(string valueId, string id)
    {
        WebConfigurationManager.AppSettings[valueId] = id;
    }

    public string GetUpdateId(string valueId)
    {
        return WebConfigurationManager.AppSettings[valueId].ToString();
    }

    public void EmptyUpdateId(string valueId)
    {
        WebConfigurationManager.AppSettings[valueId] = string.Empty;
    }

    public bool IsEmptyUpdateId(string valueId)
    {
        if (WebConfigurationManager.AppSettings[valueId].ToString() != string.Empty && WebConfigurationManager.AppSettings[valueId].ToString() != "None")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public DataSet DisplayDataQuery(string str)
    {
        try
        {
            string chStr = str.Substring(0, 6);
                SqlCommand command = new SqlCommand();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommandBuilder cb = new SqlCommandBuilder();
                DataSet ds = new DataSet();
                con.Open();
                command.Connection = con;
                command.CommandText = str;
                adapter.SelectCommand = command;
                cb.DataAdapter = adapter;
                adapter.Fill(ds);
                con.Close();
                return ds;
        }
        catch (Exception)
        {
            con.Close();
            DataSet empty = new DataSet();
            return empty;
        }
    }

    public int CheckDuplicateByQuery(string sqlStr)
    {
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommandBuilder cb = new SqlCommandBuilder();
            cmd.Connection = con;
            cmd.CommandText = sqlStr;
            adapter.SelectCommand = cmd;
            cb.DataAdapter = adapter;
            string s = cmd.ExecuteScalar().ToString();

            con.Close();
            if (s == null || s == "" || Convert.ToInt32(s) == 0)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(s);
            }
        }
        catch (Exception)
        {
            con.Close();
            return 0;
        }
    }

    public bool boolInsertData(string sqlQry)
    {
        con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandText = sqlQry;
        int i = cmd.ExecuteNonQuery();
        con.Close();
        if (i > 0)
            return true;
        else
            return false;
    }

    public int CheckDuplicate(List<SqlParameter> str)
    {
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = s_p_Name1;
            SqlParameter p1 = new SqlParameter();
            str.ToArray();
            for (int i = 0; i < str.Count; i += 1)
            {
                cmd.Parameters.Add(str[i]);
            }

            string s = cmd.ExecuteScalar().ToString();

            con.Close();
            if (s == null || s == "" || Convert.ToInt32(s) == 0)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(s);
            }
        }
        catch (Exception) { return 0; }
    }
}