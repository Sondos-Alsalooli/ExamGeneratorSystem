﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {   
        
        /*if (Session["fname"] == "admin")
        {
            Panel2.Visible = false;
            Panel1.Visible = true;
            Panel3.Visible = false;
        }
        else if (Session["fname"] == "Teacher")
        {
            Panel1.Visible = false;
            Panel2.Visible = true;
            Panel3.Visible = false;

        }
        else
        {
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = true;
        }*/
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
      
    }
}
