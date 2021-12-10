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
        if (!IsPostBack)
        {
            if (Request.QueryString["log"]==null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (Request.Cookies["name"] != null)
                    Label1.Text = "Welcome "+Server.HtmlEncode(Request.Cookies["name"].Value);
                PlaceHolder1.Visible = false;
                GridView1.Visible = false;
                DropDownList1.Items.Add("Select Subject");
                DropDownList1.Items.Add("Maths");
                DropDownList1.Items.Add("Physics");
                DropDownList1.Items.Add("Chemistry");
                GridView2.Visible = false;

            }
        }
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        GridView1.Visible = true;
        GridView1.Columns[0].Visible = false;
        PlaceHolder1.Visible = false;
        GridView2.Visible = false;
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        GridView1.Visible = true;
        GridView1.Columns[0].Visible = true;
        PlaceHolder1.Visible = false;
        GridView2.Visible = false;
    }

    protected void GridView1_DeleteCommand(object sender, EventArgs e)
    {

    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        GridView1.Visible = false;
        PlaceHolder1.Visible = true;
        
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        if (TextBox3.Text != "Admin")
        {
            string insertSql = "insert into Type values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','";
            insertSql += TextBox4.Text + "','" + TextBox5.Text + "')";
            string selectSql = "select Id from Type where Id='" + TextBox1.Text + "'";
            string connectionString = WebConfigurationManager.ConnectionStrings["Project"].ConnectionString;
            SqlConnection con1 = new SqlConnection(connectionString);
            SqlConnection con2 = new SqlConnection(connectionString);
            SqlCommand cmd1 = new SqlCommand(insertSql, con1);
            SqlCommand cmd2 = new SqlCommand(selectSql, con2);
            string idtemp;
            try
            {
                con1.Open();
                con2.Open();
                SqlDataReader reader = cmd2.ExecuteReader();
                if (!reader.HasRows)
                {
                    cmd1.ExecuteNonQuery();
                    reader.Close();
                }
                else
                {
                    while (reader.Read())
                    {
                        idtemp = (string)reader["Id"];
                    }
                    //Label7.Text = "user already exists with id=" + (string)reader["Id"];
                    reader.Close();
                }
                reader.Close();
            }
            catch (Exception err)
            {
                Label7.Text = err.Message;
            }
            finally
            {
                con1.Close();
                con2.Close();
            }
        }
        else
        {
            Label7.Text = "Cannot add another admin";
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        PlaceHolder1.Visible = false;
        GridView1.Visible = false;
        
        string sub = DropDownList1.SelectedValue;
        string connectionString = "Data Source=AAYUSHMSI\\SQLEXPRESS;Initial Catalog=Project;Integrated Security=True;Pooling=False;MultipleActiveResultSets=True";
        SqlConnection con4 = new SqlConnection(connectionString);
        string selectSql = "select * from " + sub + "QP";
        try
        {
            con4.Open();
            SqlCommand cmd = new SqlCommand(selectSql, con4);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                string subject = DropDownList1.SelectedValue;
                SqlConnection con5 = new SqlConnection(connectionString);
                SqlCommand cmd2 = new SqlCommand(selectSql, con5);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd2);
                adapter.Fill(ds, "paper");
                GridView2.DataSource = ds;
                GridView2.DataBind();
                GridView2.Visible = true;
                Label8.Text = "";
            }
            else
            {
                Label8.Text = "Question paper not set for " + sub;
            }
        }
        catch(Exception err)
        {

        }
        finally
        {
            con4.Close();
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView1.Visible = false;
        GridView2.Visible = false;
        PlaceHolder1.Visible = false;
    }
}