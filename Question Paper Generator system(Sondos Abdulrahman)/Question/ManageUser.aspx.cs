using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Register : System.Web.UI.Page
{

    public static string Name
    {
        get
        {
            if (HttpContext.Current.Session["fname"] != null)
                return HttpContext.Current.Session["fname"].ToString();
            else return "";
        }
        set
        {
            HttpContext.Current.Session["fname"] = value;
        }
    }
   
  protected void Page_Load(object sender, EventArgs e)
   {
       if (Session["fname"] != null && Session["fname"].Equals("Teacher"))
           Response.Redirect("addQ.aspx", false);
       else if (Session["fname"] == null)
           Response.Redirect("Login.aspx", false);
      
    /*if (DropDownList1.SelectedItem.Text != "Teacher")
    {
        Label9.Visible = false;
        TextBox7.Visible = false;
    }
    else
    {
        Label9.Visible = true;
        TextBox7.Visible = true;
    }*/
}
        
   
    /*protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

        SqlConnection con = new SqlConnection();
        con.ConnectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Sondos\Downloads\For the project\suz\ExamGenerationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
        string s = "select top 1 ID From '" + DropDownList1.Text + "' ORDER BY ID Desc";
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
    }*/


    /*protected void Button3_Click(object sender, EventArgs e)
   {
       
      if (s == "OK")
       {
           SqlConnection con = new SqlConnection();
           con.ConnectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
           con.Open();

           if(DropDownList1.SelectedItem.Text == "Teacher")
           {
               SqlCommand cmd = new SqlCommand("Insert into Teacher (ID,Name,Password, Department) values (@ID,@Name,@Password,@Department)", con);
               cmd.Parameters.AddWithValue("@ID", TextBox1.Text);
               cmd.Parameters.AddWithValue("@Name", TextBox2.Text);
               cmd.Parameters.AddWithValue("@Password", TextBox5.Text);
               cmd.Parameters.AddWithValue("@Department", TextBox7.Text);
               //cmd.ExecuteNonQuery();
               cmd.ExecuteReader();
               Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert(' New Teacher Added ');", true);
           }

           else if (DropDownList1.SelectedItem.Text == "Admin")
           {
               SqlCommand cmd = new SqlCommand("Insert into Admin (ID,Name,Password) values (@ID,@Name,@Password)", con);
               cmd.Parameters.AddWithValue("@ID", TextBox1.Text);
               cmd.Parameters.AddWithValue("@Name", TextBox2.Text);
               cmd.Parameters.AddWithValue("@Password", TextBox5.Text);
               //cmd.ExecuteNonQuery();
               cmd.ExecuteReader();
               Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert(' New Admin Added ');", true);
           }
           con.Close();
       }
       else
       {
           Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('"+s+"');", true);
       }
   }*/


    
}