using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class AddQ : System.Web.UI.Page
{



    public static string Connection_String = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
    SqlConnection con = new SqlConnection(AddQ.Connection_String);


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["fname"] != null && Session["fname"].Equals("Admin"))
            Response.Redirect("ManageUser.aspx", false);
        else if (Session["fname"] == null)
            Response.Redirect("Login.aspx", false);

        if (Session["add"] == "add")
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert(' New Question Saved');", true);
            Session["add"] = "";
        }
        SqlConnection con = new SqlConnection();
        con.ConnectionString = AddQ.Connection_String;
        string s = "select top 1 Question_ID From QuestionBank ORDER BY Question_ID Desc";
        con.Open();
        SqlCommand cmd = new SqlCommand(s, con);
        object count = cmd.ExecuteScalar();
        if (count != null)
        {
            int i = Convert.ToInt32(count);
            i++;
            TextBox1.Text = i.ToString();
        }
        else
        {
            TextBox1.Text = "1";
        }
        con.Close();

        if (!IsPostBack)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            string po = "select distinct Course_Code from Course where Teacher_ID = '" + Session["ID"]+ "'";
            da = new SqlDataAdapter(po, con);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DropDownList1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                }
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = AddQ.Connection_String;
        con.Open();
        string s = "SET IDENTITY_INSERT QuestionBank ON";
        SqlCommand cmd1 = new SqlCommand(s, con);
        cmd1.ExecuteNonQuery();
        SqlCommand cmd = new SqlCommand("Insert into QuestionBank (Question_ID,Cource_Code, Question,Chapter,Question_Type,Mark,CLO,Answer) values (@Question_ID,@Cource_Code, @Question,@Chapter, @Question_Type,@Mark,@CLO,@Answer)", con);
        cmd.Parameters.AddWithValue("@Question_ID", TextBox1.Text);
        cmd.Parameters.AddWithValue("@Cource_Code", DropDownList1.Text);
        cmd.Parameters.AddWithValue("@Question", TextBox2.Text);
        cmd.Parameters.AddWithValue("@Chapter", DropDownList5.Text);
        cmd.Parameters.AddWithValue("@Question_Type", DropDownList4.Text);
        cmd.Parameters.AddWithValue("@Mark", DropDownList6.Text);
        cmd.Parameters.AddWithValue("@CLO", DropDownList7.Text);
        cmd.Parameters.AddWithValue("@Answer", TextBox4.Text);
        cmd.ExecuteNonQuery();
        con.Close();
        Session["add"] = "add";
        Response.Redirect("AddQ.aspx");

    }



    /*protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.Text != " ")
        {
            DropDownList5.Items.Clear();
            DropDownList5.Items.Add("--Select--");
            SqlDataAdapter da = new SqlDataAdapter("SELECT distinct Chapter FROM QuestionBank WHERE (Cource_Code = '" + DropDownList5.Text + "')", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            int i = Convert.ToInt32(ds.Tables[0].Rows.Count);
            for (int j = 0; j < i; j++)
            {
                DropDownList5.Items.Add(ds.Tables[0].Rows[j][0].ToString());
            }
            con.Close();
        }
        if (DropDownList1.Text != " ")
        {
            DropDownList7.Items.Clear();
            DropDownList7.Items.Add("--Select--");
            SqlConnection con = new SqlConnection(AddQ.Connection_String);
            SqlDataAdapter da = new SqlDataAdapter("SELECT distinct CLO_Code FROM CLO WHERE (Cource_Code = '" + DropDownList7.Text + "')", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            int b = Convert.ToInt32(ds.Tables[0].Rows.Count);
            for (int x = 0; x < b; x++)
            {
                DropDownList7.Items.Add(ds.Tables[0].Rows[x][0].ToString());
            }
            con.Close();
        }
    }*/

   protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
     /*  
        DropDownList7.Items.Clear();
        DropDownList7.Items.Add("--Select--");
       SqlConnection con = new SqlConnection();
        con.ConnectionString = AddQ.Connection_String;
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        string po = "SELECT distinct CLO_Code FROM CLO WHERE Course_Code = '" + DropDownList5.Text + "'";
        da = new SqlDataAdapter(po, con);
        da.Fill(ds);
        int i = Convert.ToInt32(ds.Tables[0].Rows.Count);
        for (int j = 0; j < i; j++)
        {
            DropDownList7.Items.Add(ds.Tables[0].Rows[j][0].ToString());
        }
        con.Close();
   */
    }
  
}