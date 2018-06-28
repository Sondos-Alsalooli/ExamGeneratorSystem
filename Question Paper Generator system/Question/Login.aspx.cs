using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Check;
using System.Data;
using System.Configuration;
public partial class Login : System.Web.UI.Page
{
    public static string Connection_String =ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
    SqlConnection con = new SqlConnection(Login.Connection_String);

    protected void Page_Load(object sender, EventArgs e)
    {
        #region System Generated . . .
        //Class1 c = new Class1();
        //bool c1 = c.check("F41", con);
        //if (!c1)
        //{
        //    Response.Redirect("Login.aspx");
        //}
        #endregion
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        string s = "select ID, Name,Password,'Admin' as role from Admin1 where Name='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "' union select ID, Name,Password,'Teacher' as role from  Teacher  where Name='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'";
        con.Open();
        SqlCommand cmd = new SqlCommand(s,con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            dr.Read();
            if (dr[3].ToString().Equals("Teacher"))
            {
                Session["ID"] = dr[0];
                Session["fname"] = dr[3];
                Response.Redirect("AddQ.aspx");
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Login Successful');", true);
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
            else
            {
                Session["fname"] = dr[3];
                Response.Redirect("ManageCourse.aspx");
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Login Successful');", true);
                HttpContext.Current.ApplicationInstance.CompleteRequest();  
            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Wrong User ID or Password');", true);
        }
        con.Close();
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default2.aspx");
    }

      protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
      protected void TextBox1_TextChanged(object sender, EventArgs e)
      {

      }
}