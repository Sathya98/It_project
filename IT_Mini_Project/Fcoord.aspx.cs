using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.SessionState;
using System.Data;
using System.Web.ApplicationServices;

public partial class _Default : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    private void Page_PreInit(object sender, EventArgs e)
    {
        Page.Theme = "Admin";
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //if(!IsPostBack)
        if (Request.QueryString["log"] == null)
        {
            //Label1.Text = Request.QueryString["log"];
            Response.Redirect("Login.aspx");
        }
        else
        {
            if (Request.Cookies["name"] != null)
                Label1.Text = "Welcome "+Server.HtmlEncode(Request.Cookies["name"].Value);
            Label1.Text += " Subject:" + Request.QueryString["Subject"];
            //Label1.Text = Request.QueryString["Name"] + "  " + Request.QueryString["Subject"];
            Button2.Visible = false;
            GridView1.Visible = false;
            GridView2.Visible = false;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string subject = Request.QueryString["Subject"];
        //string subject = "Chemistry";
        string connectionString = WebConfigurationManager.ConnectionStrings["Project"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        string selectSql = "select * from " + subject;
        SqlCommand cmd = new SqlCommand(selectSql, con);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        adapter.Fill(ds, "viewpaper");
        GridView1.DataSource = ds;
        GridView1.DataBind();
        GridView1.Visible = true;
        Button2.Visible = true;
        GridView2.Visible = false;
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }



    protected void Button2_Click(object sender, EventArgs e)
    {
        
        string subject = Request.QueryString["Subject"];
        DataTable dt = new DataTable();
        dt.Columns.Add("Id");
        dt.Columns.Add("Question");
        dt.Columns.Add("Marks");
        dt.Columns.Add("Type");
        dt.Columns.Add("OptionA");
        dt.Columns.Add("OptionB");
        dt.Columns.Add("OptionC");
        dt.Columns.Add("OptionD");
        foreach (GridViewRow item in GridView1.Rows)
        {
            if ((item.Cells[0].FindControl("CheckBox1") as CheckBox).Checked)
            {
                DataRow dr = dt.NewRow();
                dr["Id"] = item.Cells[1].Text;
                dr["Question"] = item.Cells[2].Text;
                dr["Marks"] = item.Cells[3].Text;
                dr["Type"] = item.Cells[4].Text;
                if (item.Cells[5].Text != null)
                    dr["OptionA"] = Server.HtmlDecode(item.Cells[5].Text.Trim());
                else dr["OptionA"] = "";
                if (item.Cells[6].Text != null)
                    dr["OptionB"] = Server.HtmlDecode(item.Cells[6].Text.Trim());
                else dr["OptionB"] = "";
                if (item.Cells[7].Text != null)
                    dr["OptionC"] = Server.HtmlDecode(item.Cells[7].Text.Trim());
                else dr["OptionC"] = "";
                if (item.Cells[8].Text != null)
                    dr["OptionD"] = Server.HtmlDecode(item.Cells[8].Text.Trim());
                else dr["OptionD"] = "";
                dt.Rows.Add(dr);
                string connectionString = WebConfigurationManager.ConnectionStrings["Project"].ConnectionString;
                SqlConnection con3 = new SqlConnection(connectionString);
                int marks;
                Int32.TryParse(item.Cells[3].Text, out marks);
                string insertSql = "insert into " + subject + "QP values('" + item.Cells[1].Text + "','" + item.Cells[2].Text + "'," + marks + ",'" + item.Cells[4].Text + "','" + Server.HtmlDecode(item.Cells[5].Text.Trim()) + "','";
                insertSql += Server.HtmlDecode(item.Cells[6].Text.Trim()) + "','" + Server.HtmlDecode(item.Cells[7].Text.Trim()) + "','" + Server.HtmlDecode(item.Cells[8].Text.Trim()) + "')";
                
                SqlCommand cmd = new SqlCommand(insertSql, con3);
                try
                {
                    con3.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception err)
                {
                    Label1.Text = "Question already present in the question paper";
                }
                finally
                {
                    con3.Close();
                }

            }
        }
        //lblMsg.Visible = true;
        /*GridView1.DataSource = dt;
        GridView1.DataBind();*/
        Application[subject] = dt;
        


    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        GridView1.Visible = false;
        Button2.Visible = false;
        string subject = Request.QueryString["Subject"];
        /*GridView2.DataSource = (DataTable)(Application[subject]);
        GridView2.DataBind();*/
        string connectionString = "Data Source=AAYUSHMSI\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True;Pooling=False;MultipleActiveResultSets=True";
        SqlConnection con4 = new SqlConnection(connectionString);
        string selectSql = "select * from " + subject + "QP";
        try
        {
            con4.Open();
            SqlCommand cmd = new SqlCommand(selectSql, con4);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                SqlConnection con5 = new SqlConnection(connectionString);
                SqlCommand cmd2 = new SqlCommand(selectSql, con5);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd2);
                adapter.Fill(ds, "paper");
                GridView2.DataSource = ds;
                GridView2.DataBind();
                GridView2.Visible = true;
                Label4.Text = "";
            }
            else
            {
                Label4.Text = "Question paper not set";
            }
        }
        catch (Exception err)
        {
            Label4.Text = "Question paper not set";
        }
        finally
        {
            con4.Close();
        }
        GridView2.Visible = true;
    }
}