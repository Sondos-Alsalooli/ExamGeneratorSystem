using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Check;

public partial class _Default : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Sondos\Downloads\For the project\suz\ExamGenerationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");

    protected void Page_Load(object sender, EventArgs e)
    { 

        #region System Generated . . .
        //Class1 c = new Class1();
        //bool c1 = c.check("F41", con);
       // if (!c1)
        //{
           // Response.Redirect("Login.aspx");
        //}
        #endregion
    }

    
}