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

public partial class _Default : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    private void Page_PreInit(object sender, EventArgs e)
    {
        Page.Theme = "Admin";
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        /*if (Request.QueryString.["Subject"] == null)
        {
            Label1.Text = "please Login";
        }*/
        if (Request.QueryString["log"] == null)
        {
            //Label1.Text = Request.QueryString["log"];
            Response.Redirect("Login.aspx");
        }
        else
        {
            if (Request.Cookies["name"] != null)
                Label1.Text ="Welcome "+ Server.HtmlEncode(Request.Cookies["name"].Value);
            //Label1.Text = Request.QueryString["Name"] + "  " + Request.QueryString["Subject"] ;
            //TextBox1.Text = Request.QueryString["Subject"];
            Label1.Text += " Subject:" + Request.QueryString["Subject"];
            Label8.Visible = false;
            Label9.Visible = false;
            Label4.Visible = false;
            Label5.Visible = false;
            Label6.Visible = false;
            Label7.Visible = false;
            TextBox2.Visible = false;
            TextBox3.Visible = false;
            TextBox4.Visible = false;
            TextBox5.Visible = false;
            TextBox6.Visible = false;
            TextBox7.Visible = false;
            Button3.Visible = false;
            Label10.Visible = true;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Label8.Visible = true;
        Label9.Visible = true;
        Label4.Visible = true;
        Label5.Visible = true;
        Label6.Visible = true;
        Label7.Visible = true;
        TextBox2.Visible = true;
        TextBox3.Visible = true;
        TextBox4.Visible = true;
        TextBox5.Visible = true;
        TextBox6.Visible = true;
        TextBox7.Visible = true;
        Button3.Visible = true;
        string subject = Request.QueryString["Subject"];
        //string subject = "Chemistry";
        string connectionString = "Data Source=AAYUSHMSI\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True;Pooling=False;MultipleActiveResultSets=True";
        SqlConnection con = new SqlConnection(connectionString);
        string selectSql = "select Id,Question,Marks,OptionA,OptionB,OptionC,OptionD from " + subject + " where "+subject+".Type='Objective'";
        SqlCommand cmd = new SqlCommand(selectSql, con);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        adapter.Fill(ds, "objective");
        GridView1.DataSource = ds;
        GridView1.DataBind();
        int nrows=GridView1.Rows.Count;
        Session["nrowsobj"] = nrows;
        Session["type"] = "Objective";
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Label4.Visible = true;
        Label9.Visible = true;
        TextBox2.Visible = true;
        TextBox3.Visible = true;
        TextBox2.Text = "";
        TextBox3.Text = "";
        Button3.Visible = true;
        string subject = Request.QueryString["Subject"];
        //string subject = "Chemistry";
        string connectionString = "Data Source=AAYUSHMSI\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True;Pooling=False;MultipleActiveResultSets=True";
        SqlConnection con = new SqlConnection(connectionString);
        string selectSql = "select Id,Question,Marks from " + subject + " where " + subject + ".Type='Subjective'";
        SqlCommand cmd = new SqlCommand(selectSql, con);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        adapter.Fill(ds, "subjective");
        GridView1.DataSource = ds;
        GridView1.DataBind();
        int nrows = GridView1.Rows.Count;
        Session["nrowssbj"] = nrows;
        Session["type"] = "Subjective";
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (Page.IsValid==true)
        {
            Button3.Visible = false;
            string subject = Request.QueryString["Subject"];
            //string subject = "Chemistry";
            string type = Session["type"].ToString();
            if (type == "Objective")
            {
                int c = (int)Session["nrowsobj"];
                c = c + 1;
                string id = "O" + c.ToString();
                int marks;
                Int32.TryParse(TextBox3.Text, out marks);
                string insertSql = "insert into " + subject + " values('" + id + "','" + TextBox2.Text + "'," + marks + "," + "'Objective'" + ",'" + TextBox4.Text + "','";
                insertSql += TextBox5.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "')";
                //string selectSql = "select Id from Type where Id='" + TextBox1.Text + "'";
                string connectionString = WebConfigurationManager.ConnectionStrings["Project"].ConnectionString;
                SqlConnection con1 = new SqlConnection(connectionString);
                SqlCommand cmd1 = new SqlCommand(insertSql, con1);
                try
                {
                    con1.Open();
                    cmd1.ExecuteNonQuery();
                }
                catch (Exception err)
                {
                    Label10.Text = err.Message + "gsd  objective" + Session["nrowsobj"].ToString();
                }
                finally
                {
                    con1.Close();
                }
            }
            //SqlCommand cmd2 = new SqlCommand(selectSql, con2);

            else
            {
                int c = (int)Session["nrowssbj"];
                c = c + 1;
                string id = "S" + c.ToString();
                int marks;
                Int32.TryParse(TextBox3.Text, out marks);
                string insertSql = "insert into " + subject + "(Id, Question, Marks,Type) values('" + id + "','" + TextBox2.Text + "'," + marks + "," + "'Subjective')";
                //string selectSql = "select Id from Type where Id='" + TextBox1.Text + "'";
                string connectionString = WebConfigurationManager.ConnectionStrings["Project"].ConnectionString;
                SqlConnection con2 = new SqlConnection(connectionString);
                SqlCommand cmd2 = new SqlCommand(insertSql, con2);
                try
                {
                    con2.Open();
                    cmd2.ExecuteNonQuery();
                }
                catch (Exception err)
                {
                    Label10.Text = err.Message;
                }
                finally
                {
                    con2.Close();
                }
            }
            GridView1.Visible = false;
        }
        else
        {
            Label10.Text = "Please enter the required fields";
        }
    }


    protected void Button4_Click(object sender, EventArgs e)
    {
        string subject = Request.QueryString["Subject"];
        //string subject = "Chemistry";
        string connectionString = WebConfigurationManager.ConnectionStrings["Project"].ConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        string selectSql = "select * from " + subject;
        SqlCommand cmd = new SqlCommand(selectSql, con);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        adapter.Fill(ds, "questions");
        GridView1.DataSource = ds;
        GridView1.DataBind();
        GridView1.Visible = true;
    }
}