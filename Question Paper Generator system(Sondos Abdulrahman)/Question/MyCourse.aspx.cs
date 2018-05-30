using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;
using System.Data;

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
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            string po = "select distinct Course_Code from Course where Teacher_ID = '" + Session["ID"]+ "'";
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
        Label1.Visible = true;
        Label3.Visible = true;
        FileUpload1.Visible = true;
        Button1.Visible = true;
        BindGrid2();
        BindGrid();
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ShowQ.Connection_String;
        string s = "SELECT * FROM Course WHERE (Course_Code='" + DropDownList5.Text + "')";
        SqlDataAdapter da = new SqlDataAdapter(s, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
    private Boolean InsertUpdateData(SqlCommand cmd)
    {

        String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        SqlConnection con = new SqlConnection(strConnString);

        cmd.CommandType = CommandType.Text;

        cmd.Connection = con;

        try
        {

            con.Open();

            cmd.ExecuteNonQuery();

            return true;

        }

        catch (Exception ex)
        {

            Response.Write(ex.Message);

            return false;

        }

        finally
        {

            con.Close();

            con.Dispose();

        }

    }
    private void BindGrid()
    {
        string constr = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select id, Name from tblFiles where Course_Code = '" + DropDownList5.Text + "'";
                cmd.Connection = con;
                con.Open();
                GridView2.DataSource = cmd.ExecuteReader();
                GridView2.DataBind();
                con.Close();
            }
        }
    }

    protected void DownloadFile(object sender, EventArgs e)
    {
        int id = int.Parse((sender as LinkButton).CommandArgument);
        byte[] bytes;
        string fileName, contentType;
        string constr = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select Name, Data, ContentType from tblFiles  where id=@id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    bytes = (byte[])sdr["Data"];
                    contentType = sdr["ContentType"].ToString();
                    fileName = sdr["Name"].ToString();
                }
                con.Close();
            }
        }
        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = contentType;
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
        Response.BinaryWrite(bytes);
        Response.Flush();
        Response.End();
    }

    protected void btnUpload_Click1(object sender, EventArgs e)
    {
        string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
        string contentType = FileUpload1.PostedFile.ContentType;
        //string Course_Code = DropDownList5.Text;
        using (Stream fs = FileUpload1.PostedFile.InputStream)
        {
            using (BinaryReader br = new BinaryReader(fs))
            {
                byte[] bytes = br.ReadBytes((Int32)fs.Length);
                string constr = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = "insert into tblFiles2 values (@Name, @ContentType, @Data, @Course_Code)";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@Name", filename);
                        cmd.Parameters.AddWithValue("@ContentType", contentType);
                        cmd.Parameters.AddWithValue("@Data", bytes);
                        cmd.Parameters.AddWithValue("@Course_Code", DropDownList5.Text);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            
        }
   
        Response.Redirect(Request.Url.AbsoluteUri);
        lblMessage.ForeColor = System.Drawing.Color.Green;
        lblMessage.Text = "File Uploaded Successfully";
    

        // Read the file and convert it to Byte Array

       }




    private void BindGrid2()
    {
        string constr = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select id, Name from tblFiles2 where Course_Code = '" + DropDownList5.Text + "'";
                cmd.Connection = con;
                con.Open();
                GridView3.DataSource = cmd.ExecuteReader();
                GridView3.DataBind();
                con.Close();
            }
        }
    }
    protected void DownloadFile2(object sender, EventArgs e)
    {
        int id = int.Parse((sender as LinkButton).CommandArgument);
        byte[] bytes;
        string fileName, contentType;
        string constr = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select Name, Data, ContentType from tblFiles2  where id=@id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    bytes = (byte[])sdr["Data"];
                    contentType = sdr["ContentType"].ToString();
                    fileName = sdr["Name"].ToString();
                }
                con.Close();
            }
        }
        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = contentType;
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
        Response.BinaryWrite(bytes);
        Response.Flush();
        Response.End();
    }
}