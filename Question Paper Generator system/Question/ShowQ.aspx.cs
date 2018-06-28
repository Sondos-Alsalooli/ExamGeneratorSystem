using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


public partial class ShowQ : System.Web.UI.Page
{

    public static string Connection_String = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
    SqlConnection con = new SqlConnection(ShowQ.Connection_String);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["fname"] == null || (Session["fname"] != null && !Session["fname"].Equals("Admin") && !Session["fname"].Equals("Teacher")))
        {
            Response.Redirect("Login.aspx", false);
            Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('You can't acces this page before login ');", true);
        }
        if (!IsPostBack)
        {
            if (Session["fname"].Equals("Teacher"))
            {
                SqlDataAdapter da;
                DataSet ds = new DataSet();
                string po = "select distinct Course_Code from Course where Teacher_ID = '" + Session["ID"] + "'";
                da = new SqlDataAdapter(po, con);
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        DropDownList5.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                    }
                }
            }
            else
            {
                SqlDataAdapter da;
                DataSet ds = new DataSet();
                string po = "select distinct Course_Code from Course ";
                da = new SqlDataAdapter(po, con);
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        DropDownList5.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                    }
                }
            }
           }

    }
    protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList2.Items.Clear();
        DropDownList2.Items.Add("--Select--");
        SqlDataAdapter da = new SqlDataAdapter("SELECT distinct Chapter FROM QuestionBank WHERE (Cource_Code = '" + DropDownList5.Text + "')", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        int i = Convert.ToInt32(ds.Tables[0].Rows.Count);
        for (int j = 0; j < i; j++)
        {
            DropDownList2.Items.Add(ds.Tables[0].Rows[j][0].ToString());
        }
        con.Close();
    }
   /* protected void Sem_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList2.Items.Clear();
        DropDownList2.Items.Add("--Select--");
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-SPKCV2J;Initial Catalog=Question;Integrated Security=True");
        SqlDataAdapter da = new SqlDataAdapter("SELECT distinct Subject FROM Ques WHERE (Sem = '" + Sem.Text + "') And (Branch ='"+DropDownList5.Text+"')", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        int i = Convert.ToInt32(ds.Tables[0].Rows.Count);
        for (int j = 0; j < i; j++)
        {
            DropDownList2.Items.Add(ds.Tables[0].Rows[j][0].ToString());
        }
        con.Close();
    }*/
    
    protected void Button2_Click(object sender, EventArgs e)
    {
        /*SqlConnection con = new SqlConnection();
        con.ConnectionString = ShowQ.Connection_String;
        string s = "SELECT * FROM QuestionBank WHERE (Cource_Code='" + DropDownList5.Text + "') And (Chapter='" + DropDownList2.Text + "') Order by Question_ID ASC";
        SqlDataAdapter da = new SqlDataAdapter(s, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();*/
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
       /* SqlConnection con = new SqlConnection();
        con.ConnectionString = ShowQ.Connection_String;
        string s = "SELECT * FROM QuestionBank WHERE (Cource_Code='" + DropDownList5.Text + "') Order by Question_ID ASC";
        SqlDataAdapter da = new SqlDataAdapter(s, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();*/
    }
}