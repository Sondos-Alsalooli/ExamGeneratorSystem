using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Data;


public partial class Register : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["fname"] != null && Session["fname"].Equals("Teacher"))
            Response.Redirect("addQ.aspx", false);
        else if (Session["fname"] == null)
            Response.Redirect("Login.aspx", false);  
    }

    public string check()
    {
        if (TextBox1.Text == "")
        {
            return "Please Enter Course_Code";
        }
        else if (TextBox2.Text == "")
        {
            return "Please Enter Course_Title";
        }

        else if (DropDownList1.Text == "")
        {
            return "Please Enter Level";
        }
        else if (DropDownList2.Text == "")
        {
            return "Please Enter Teacher ID";
        }
        return "OK";
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        string s = check();
        if (s == "OK")
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            con.Open();
            //string si = "SET IDENTITY_INSERT Course ON";
            //SqlCommand cmd1 = new SqlCommand(si, con);
            //cmd1.ExecuteNonQuery();
            SqlCommand cmd = new SqlCommand("Insert into Course (Course_Code,Course_Title,Level,Teacher_ID) values (@Course_Code,@Course_Title,@Level,@Teacher_ID)", con);
            cmd.Parameters.AddWithValue("@Course_Code", TextBox1.Text);
            cmd.Parameters.AddWithValue("@Course_Title", TextBox2.Text);
            cmd.Parameters.AddWithValue("@Level", DropDownList1.Text);
            cmd.Parameters.AddWithValue("@Teacher_ID", DropDownList2.Text);
            cmd.ExecuteReader();
            con.Close();
            Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert(' New Course Added ');", true);
            //Response.Redirect("ManageCourse.aspx");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('" + s + "');", true);
        }
    }

    
}