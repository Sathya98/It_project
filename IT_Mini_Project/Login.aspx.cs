using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.SessionState;


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label3.Visible = false;
        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            Label3.Visible = true;
            string userid = TextBox1.Text;
            string password = TextBox2.Text;
            string selectSQL = "SELECT * FROM Type WHERE Id='" + userid + "' AND password='" + password + "'";
            string connectionString = WebConfigurationManager.ConnectionStrings["Project"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(selectSQL, con);
            SqlDataReader reader;
            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                if (reader == null || !reader.HasRows)
                {
                    Label3.Text = "Invalid UserID or Password";
                    TextBox1.Text = "";
                    TextBox2.Text = "";

                }
                else
                {
                    while (reader.Read())
                    {
                        Session["name"] = (string)reader["name"];
                        Session["role"] = (string)reader["role"];
                        if((string)reader["role"]!="admin"  )
                            Session["subject"] = (string)reader["subject"];
                    }
                    string role1 = (string)Session["role"];
                    string name1 = (string)Session["name"];
                    if (role1 == "admin")
                    {
                        string log = "1";
                        Session["adminlog"] = log;
                        Response.Cookies["name"].Value = name1;
                        Response.Cookies["name"].Expires = DateTime.Now.AddDays(1);
                        string url = "~/Admin.aspx?Name=" + name1+"&log=1";
                        Response.Redirect(url);
                    }
                    else if (role1 == "fcoord")
                    {
                        string subject1 = (string)Session["subject"];
                        Response.Cookies["name"].Value = name1;
                        Response.Cookies["name"].Expires = DateTime.Now.AddDays(1);
                        string url = "Fcoord.aspx?Name=" + name1 + "&" + "Subject=" + subject1+"&log=2";
                        Response.Redirect(url);
                    }
                    else if (role1 == "faculty")
                    {
                        string log = "3";
                        Session["faclog"] = log;
                        Response.Cookies["name"].Value = name1;
                        Response.Cookies["name"].Expires = DateTime.Now.AddDays(1);
                        string subject1 = (string)Session["subject"];
                        string url = "Fac.aspx?Name=" + name1 + "&" + "Subject=" + subject1+"&log=3";
                        Response.Redirect(url);
                    }
                    else
                    {
                        Label3.Text += "no such user type";
                    }
                }
            }
            catch (Exception err)
            {
                Label3.Text += err.Message;
            }
            finally
            {
                Session.Clear();
                con.Close();
            }
        }
    }
}