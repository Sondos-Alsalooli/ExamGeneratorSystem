using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Configuration;
//using Microsoft.Office.Interop.Word;
using System.Diagnostics;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.Net.Mail;


public partial class Create : System.Web.UI.Page
{

    //////////////////////////  variables declaration ////////////////////////////////


    //int numCharsPerText = 15000;
    //Text targetText;
    //Text bestText;
    List<Gene> bestPaper, bestFitnessPaper, numGenerationsPaper;
    private GeneticAlgorithm<Gene> ga;
    private System.Random randome;
    // make list of type Gene
    static List<Gene> SQuestionList = new List<Gene>(), QuestionList;
    public int TotalLength, total, populationSize = 20, elitism = 5, o = 0;
    public static List<Gene> SQuestionList1
    {
        get { return SQuestionList; }
        set { SQuestionList = value; }
    }
    List<string> CLOSum = new List<string>();
    public List<string> CLOCourse = new List<string>();
    static List<Qtype> SQuestionTList = new List<Qtype>(), QuestionTList;
    public static string Connection_String = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
    SqlConnection con = new SqlConnection(Create.Connection_String);
    ///////////////////////////////////////////////////////////////////////////////// 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["fname"] == null || (Session["fname"] != null && !Session["fname"].Equals("Admin") && !Session["fname"].Equals("Teacher")))
        {
            Response.Redirect("Login.aspx", false);
            Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('You can't acces this page before login ');", true);
        }
        if (!IsPostBack)
        {
            if (Session["fname"] != null && Session["fname"].Equals("Teacher"))
            {
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection(Create.Connection_String);
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
                SqlConnection con = new SqlConnection(Create.Connection_String);
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

    }
    public bool LoadQuestionList(int total, string selected_type)
    {
        string sub = DropDownList5.Text;

        SqlConnection con = new SqlConnection(Connection_String);

        string s3 = "select count(*) Question_ID From QuestionBank WHERE Cource_Code = '" + DropDownList5.SelectedValue + "' and chapter in(" + TextBox8.Text + ") and Question_Type in (" + selected_type + ") ";
        con.Open();
        SqlCommand cmd3 = new SqlCommand(s3, con);
        int storedquestion = int.Parse(cmd3.ExecuteScalar().ToString());
        if (storedquestion < total)
        {
            con.Close();
            Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('the selected number of question is bigger than stored questions');", true);
            return false;
        }
        con.Close();
        // bring all question from database from selected course and store in instances off class gene then add them to list
        string s = "select * FROM QuestionBank WHERE Cource_Code = '" + DropDownList5.SelectedValue + "' and chapter in(" + TextBox8.Text + ")  ORDER BY RAND()";
        SqlCommand cmd = new SqlCommand(s, con);
        SqlDataReader dr;
        con.Open();
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            //Response.Write("<script>alert('" + dr["Question"].ToString() + "');</script>");
            string ques = dr["Question"].ToString();
            string questype = dr["Question_Type"].ToString();
            string quesCLO = dr["CLO"].ToString();
            string quesAnswer = dr["Answer"].ToString();
            string quesMark = dr["Mark"].ToString();
            string quesChapter = dr["Chapter"].ToString();
            SQuestionList1.Add(new Gene(ques, questype, quesCLO, quesAnswer, quesMark, quesChapter));
        }
        con.Close();

        SqlDataAdapter da;
        DataSet ds = new DataSet();
        da = new SqlDataAdapter("SELECT distinct CLO_Code FROM CLO WHERE (Course_Code = '" + DropDownList5.Text + "')", con);
        con.Open();
        ds = new DataSet();
        da.Fill(ds);
        int j = Convert.ToInt32(ds.Tables[0].Rows.Count);
        for (int y = 0; y < j; y++)
        {
            CLOCourse.Add(ds.Tables[0].Rows[y][0].ToString());
        }
        con.Close();
        return true;
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        //Button2.Visible = false;
        //DropDownList5_SelectedIndexChanged(sender, e);
        sample1();

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        sample2();
    }
    //Gene[] s;
    // make array  QuestionPool of type gene, convert QuestionList ToArray
    void Start()
    {
        randome = new System.Random();
        //make instance  ga of getiticalgorithm class
        ga = new GeneticAlgorithm<Gene>(populationSize, total, randome, GetRandomQuestion, FitnessFunction, elitism);
    }
    public List<Gene> update()
    {
        int repeat = 5;
        while (ga.BestFitness < (float)CLOCourse.Count / 2 && repeat > 0)
        {
            ga.NewGeneration();
            repeat--;
        }

        UpdatePaper(ga.BestGenes, ga.BestFitness, ga.Generation, ga.Population.Count, (j) => ga.Population[j].Genes);
        return bestPaper;

    }
    // get randome quesyion get elemnt from questionpool randomly 
    private Gene GetRandomQuestion(int GIndex)
    {
        if (GIndex == 0)
        {
            QuestionTList = new List<Qtype>(SQuestionTList);
            QuestionList = new List<Gene>(SQuestionList1);
            foreach (Qtype qt in QuestionTList)
                qt.numquestion = qt.numOfType;
        }
        foreach (Qtype qt in QuestionTList)
        {
            if (qt.numquestion <= 0)
                QuestionList.RemoveAll(x => x.type.Equals(qt.name));
        }

        //Response.Write("<script>alert('"+(QuestionList1.Count - 1)+"')</script>");
        randome = new System.Random();
        // int i = randome.Next(QuestionList.Count);
        //return QuestionList[i];
        int l = QuestionList.Count - 1;
        int i = randome.Next(l);
        Gene qst = (Gene)(QuestionList[i].Clone());
        QuestionTList.Find(x => x.name.Equals(qst.type)).numquestion--;
        QuestionList.RemoveAt(i);
        //Response.Write(qst.Answer + "    " + i + "\r\n");
        return qst;
        // return QuestionPool[randome.Next(QuestionPool.Length - 1)];
    }

    public float FitnessFunction(GenerateQP<Gene> dna)
    {
        float score = 0;
        for (int i = 0; i < CLOCourse.Count; i++)
        {
            for (int j = 0; j < dna.Genes.Length; j++)
            {

                //foreach (string i in QuestionPool.Gene)
                //{

                // for (int j = 0; j <dna.Genes.Length; j++)
                //{
                if (CLOCourse[i].Equals(dna.Genes[j].CLO))
                {
                    score++;
                    i++; j = -1;
                }
                //}
            }
            //score /= CLOSum.Count;
        }

        return score;
    }

    private void UpdatePaper(Gene[] bestGenes, float bestFitness, int generation, int populationSize, Func<int, Gene[]> getGenes)
    {
        bestPaper = bestGenes.ToList<Gene>();
        //= CharArrayToString(bestGenes);
        //var bestPaper = barValues.Select(values => new Portfolio(values)).ToList();
        //var recs = (from data in cmRateResults select data).ToList();
        //var recs = cmRateResults.Select(data => data)).ToList()

        //bestFitnessPaper.text = bestFitness.ToString();

        //numGenerationsText.text = generation.ToString();

        //for (int i = 0; i < textList.Count; i++)
        {
            //var sb = new StringBuilder();
            //int endIndex = i == textList.Count - 1 ? populationSize : (i + 1) * numCharsPerTextObj;
            //for (int j = i * numCharsPerTextObj; j < endIndex; j++)
            {
                //	foreach (var c in getGenes(j))
                {
                    //	sb.Append(c);
                }
                //if (j < endIndex - 1) sb.AppendLine();
            }

            //textList[i].text = sb.ToString();
        }
    }








    public void sample2()
    {

        int marks = Convert.ToInt32(DropDownList2.Text);
        string sub = DropDownList5.Text;

        bool flag;
        int Short = Convert.ToInt32(TextBox11.Text);
        int Long = Convert.ToInt32(TextBox10.Text);
        int choose = Convert.ToInt32(TextBox4.Text);
        int TorF = Convert.ToInt32(TextBox3.Text);
        int fill = Convert.ToInt32(TextBox9.Text);
        total = Short + Long + choose + TorF + fill;
        double tmarks = ((fill * 0.5) + (choose * 0.5) + (TorF * 0.5) + (Short * 2) + (Long * 5));


        SQuestionTList.Add(new Qtype("fill", fill, fill * 0.5));
        SQuestionTList.Add(new Qtype("choose", choose, choose * 0.5));
        SQuestionTList.Add(new Qtype("TorF", TorF, TorF * 0.5));
        SQuestionTList.Add(new Qtype("short", Short, Short * 2));
        SQuestionTList.Add(new Qtype("long", Long, Long * 5));
        string selected_type = "";
        foreach (Qtype item in SQuestionTList)
            if (item.numOfType > 0)
                if (selected_type == "")
                    selected_type += "'" + item.name + "'";
                else
                    selected_type += ",'" + item.name + "'";
        {

        }

        if (marks == tmarks)
        {
            flag = true;
        }
        else
        {
            flag = false;
            Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert(' Total Sum of Marks Does Not Equal Required Mark');", true);
            return;
        }

        flag = LoadQuestionList(total, selected_type);
        //for (int j = 0; j < total; j++)
        //{
        //  foreach (Qtype qt in QuestionTList)
        // {
        if (flag)
        {

            Start();
            List<Gene> OurPaper = update();
            //List<String> r = OurPaper.Select(o => OurPaper.question).ToList();

            Response.Write("<script>alert('ok');</script>");
            List<string> OurQuestions = OurPaper.Select(Gene => Gene.question).OrderBy(questype => questype).ToList();


            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Charset = "utf8";

            HttpContext.Current.Response.ContentType = "application/msword";

            string strFileName = TextBox2.Text + "- Answer key.doc";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "inline;filename=" + strFileName);

            
            StringBuilder strHTMLContent = new StringBuilder();
            strHTMLContent.Append("<p align='right' style='font-family: Arial, Helvetica, sans-serif; font-size: 12px'> &nbsp;&nbsp;&nbsp; <h4> King Khaled University <br/> College of Computer Science </h4>  </p><br/> ".ToString());
           
            strHTMLContent.Append("<table align='Center'>".ToString());
            strHTMLContent.Append("<tr><td><h2>" + TextBox2.Text + " &nbsp; Answer Key &nbsp;&nbsp;&nbsp;&nbsp;  </h2></td></tr>".ToString());
            strHTMLContent.Append("</table>".ToString());
            strHTMLContent.Append("<p align='center'>".ToString());
            strHTMLContent.Append("<strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</strong><em>Time allowed : " + DropDownList7.Text + "&nbsp;hours&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Maximum Marks : " + marks + "</em></p>".ToString());
            strHTMLContent.Append("<hr />".ToString());
            strHTMLContent.Append("<p>".ToString());
            strHTMLContent.Append("<strong><em>Note :</em></strong></p>".ToString());
            strHTMLContent.Append("<p>".ToString());
            strHTMLContent.Append("<span style='font-size:12px;'><span style='font-family:arial,helvetica,sans-serif;'>(i) All questions are compulsory.</span></span></p>".ToString());
            strHTMLContent.Append("<p>".ToString());
            strHTMLContent.Append("<span style='font-size:12px;'><span style='font-family:arial,helvetica,sans-serif;'>(ii) Answer the questions after carefully reading the text.</span></span></p>".ToString());
            strHTMLContent.Append("<p>".ToString());
            strHTMLContent.Append("&nbsp;</p>".ToString());
            SqlDataReader dr2;
            int x = 0, p = 1, i = 0, c = 0;
            string[] qu = new string[total];


            foreach (Qtype qt in SQuestionTList)
            {
                // string prev = qt.name;
                if (qt.numOfType > 0)
                {
                    strHTMLContent.Append("<p>".ToString());
                    i++;
                    strHTMLContent.Append("<strong>Q" + (i) + ". &nbsp; &nbsp; </strong><strong>Answer the following questions type " + qt.name + ": &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; " + qt.numOfType + "</strong></p>");
                    foreach (Gene question in OurPaper.FindAll(sds => sds.type.Equals(qt.name)))
                    {

                        strHTMLContent.Append("<p>");
                        strHTMLContent.Append("<span style='font-size: 14px;'>&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</span><span style='font-size: 14px;'>(" + (p) + ") &nbsp;" + question.question + "</span> <b> (" + question.CLO + ") </b> <span> </span></p> <p> <b> Answer: </b>  &nbsp; &nbsp; &nbsp; &nbsp; (" + question.Answer + ")  </p>");
                        x++;
                        p++;
                        c++;
                        if (c == qt.numOfType) { p = 1; c = 0; }
                        con.Close();
                    }
                    strHTMLContent.Append("<p>");
                    strHTMLContent.Append("&nbsp;</p>");
                }
            }

            /*while(p<q)
            {
                dr1 = random(fq[x]);
                qu[p] = dr1[0].ToString();
                for (int k = 0; k < qu.Length; k++)
                {
                    if (qu[k] == qu[p])
                    {
                        dr1 = random(fq[x]);
                    }
                }*/

            strHTMLContent.Append("<div>");
            strHTMLContent.Append("<span style='font-family:times new roman,times,serif;'>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;X-X- All The Best -X-X</span></div>");
            strHTMLContent.Append("</div>");
            strHTMLContent.Append("<p>");
            strHTMLContent.Append("&nbsp;</p>");
            HttpContext.Current.Response.Write(strHTMLContent);
            HttpContext.Current.Response.End();
            HttpContext.Current.Response.Flush();
        }
    }

    public void sample1()
    {

        int marks = Convert.ToInt32(DropDownList2.Text);
        string sub = DropDownList5.Text;

        bool flag;
        int Short = Convert.ToInt32(TextBox11.Text);
        int Long = Convert.ToInt32(TextBox10.Text);
        int choose = Convert.ToInt32(TextBox4.Text);
        int TorF = Convert.ToInt32(TextBox3.Text);
        int fill = Convert.ToInt32(TextBox9.Text);
        total = Short + Long + choose + TorF + fill;
        double tmarks = ((fill * 0.5) + (choose * 0.5) + (TorF * 0.5) + (Short * 2) + (Long * 5));

        SQuestionTList.Add(new Qtype("fill", fill, fill * 0.5));
        SQuestionTList.Add(new Qtype("choose", choose, choose * 0.5));
        SQuestionTList.Add(new Qtype("TorF", TorF, TorF * 0.5));
        SQuestionTList.Add(new Qtype("short", Short, Short * 2));
        SQuestionTList.Add(new Qtype("long", Long, Long * 5));
        string selected_type = "";
        foreach (Qtype item in SQuestionTList)
            if (item.numOfType > 0)
                if (selected_type == "")
                    selected_type += "'" + item.name + "'";
                else
                    selected_type += ",'" + item.name + "'";
        {

        }

        if (marks == tmarks)
        {
            flag = true;
        }
        else
        {
            flag = false;
            //Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert(' Total Sum of Marks Does Not Equal Required Mark');", true);
            //return;
        }

        flag = LoadQuestionList(total, selected_type);
        //for (int j = 0; j < total; j++)
        //{
        //  foreach (Qtype qt in QuestionTList)
        // {
        if (flag)
        {

            Start();
            List<Gene> OurPaper = update();
            //List<String> r = OurPaper.Select(o => OurPaper.question).ToList();

            Response.Write("<script>alert('ok');</script>");
            List<string> OurQuestions = OurPaper.Select(Gene => Gene.question).OrderBy(questype => questype).ToList();


            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentEncoding = Encoding.Default;
            HttpContext.Current.Response.Charset = "";
            HttpContext.Current.Response.ContentType = "application/msword";

            string strFileName = TextBox2.Text + ".doc";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "inline;filename=" + strFileName);

            StringBuilder strHTMLContent = new StringBuilder();
            strHTMLContent.Append("<p align='right' style='font-family: Arial, Helvetica, sans-serif; font-size: 12px'> &nbsp;&nbsp;&nbsp; <h4> King Khaled University <br/> College of Computer Science </h4>  </p><br/> ".ToString());
           
            strHTMLContent.Append("<table align='Center'>".ToString());
            strHTMLContent.Append("<tr><td><h2>" + TextBox2.Text + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; QR : </h2></td></tr>".ToString());
            strHTMLContent.Append("</table>".ToString());
            strHTMLContent.Append("<p align='center'>".ToString());
            strHTMLContent.Append("<strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</strong><em>Time allowed : " + DropDownList7.Text + "&nbsp;hours&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Maximum Marks : " + marks + "</em></p>".ToString());
            strHTMLContent.Append("<hr />".ToString());
            strHTMLContent.Append("<p>".ToString());
            strHTMLContent.Append("<strong><em>Note :</em></strong></p>".ToString());
            strHTMLContent.Append("<p>".ToString());
            strHTMLContent.Append("<span style='font-size:12px;'><span style='font-family:arial,helvetica,sans-serif;'>(i) All questions are compulsory.</span></span></p>".ToString());
            strHTMLContent.Append("<p>".ToString());
            strHTMLContent.Append("<span style='font-size:12px;'><span style='font-family:arial,helvetica,sans-serif;'>(ii) Answer the questions after carefully reading the text.</span></span></p>".ToString());
            strHTMLContent.Append("<p>".ToString());
            strHTMLContent.Append("&nbsp;</p>".ToString());
            SqlDataReader dr2;
            int x = 0, p = 1, i = 0, c = 0;
            string[] qu = new string[total];


            foreach (Qtype qt in SQuestionTList)
            {
                // string prev = qt.name;
                if (qt.numOfType > 0)
                {
                    strHTMLContent.Append("<p>".ToString());
                    i++;
                    strHTMLContent.Append("<strong>Q" + (i) + ". &nbsp; &nbsp; </strong><strong>Answer the following questions type " + qt.name + ": &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; " + qt.numOfType + "</strong></p>");
                    foreach (Gene question in OurPaper.FindAll(sds => sds.type.Equals(qt.name)))
                    {

                        strHTMLContent.Append("<p>");
                        strHTMLContent.Append("<span style='font-size: 14px;'>&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</span><span style='font-size: 14px;'>(" + (p) + ") &nbsp;" + question.question + "</span></p>");
                        x++;
                        p++;
                        c++;
                        if (c == qt.numOfType) { p = 1; c = 0; }
                        con.Close();
                    }
                    strHTMLContent.Append("<p>");
                    strHTMLContent.Append("&nbsp;</p>");
                }
            }

            /*while(p<q)
            {
                dr1 = random(fq[x]);
                qu[p] = dr1[0].ToString();
                for (int k = 0; k < qu.Length; k++)
                {
                    if (qu[k] == qu[p])
                    {
                        dr1 = random(fq[x]);
                    }
                }*/

            strHTMLContent.Append("<div>");
            strHTMLContent.Append("<span style='font-family:times new roman,times,serif;'>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;X-X- All The Best -X-X</span></div>");
            strHTMLContent.Append("</div>");
            strHTMLContent.Append("<p>");
            strHTMLContent.Append("&nbsp;</p>");
            HttpContext.Current.Response.Write(strHTMLContent);
            HttpContext.Current.Response.End();
            HttpContext.Current.Response.Flush();
        }
    }


    /*   protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
       {
           if (DropDownList5.Text != "--Select--")
           {
               Sem.Items.Clear();
               Sem.Items.Add("--Select--");
               SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-SPKCV2J;Initial Catalog=Question;Integrated Security=True");
               SqlDataAdapter da = new SqlDataAdapter("SELECT distinct Sem FROM Ques WHERE (Branch = '" + DropDownList5.Text + "')", con);
               DataSet ds = new DataSet();
               da.Fill(ds);
               int i = Convert.ToInt32(ds.Tables[0].Rows.Count);
               for (int j = 0; j < i; j++)
               {
                   Sem.Items.Add(ds.Tables[0].Rows[j][0].ToString());
               }
               con.Close();
           }
       }*/
    /*protected void Sem_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Sem.Text != "--Select--")
        {
            DropDownList2.Items.Clear();
            DropDownList2.Items.Add("--Select--");
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-SPKCV2J;Initial Catalog=Question;Integrated Security=True");
            SqlDataAdapter da = new SqlDataAdapter("SELECT distinct Subject FROM Ques WHERE (Sem = '" + Sem.Text + "') And (Branch ='" + DropDownList5.Text + "')", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            int i = Convert.ToInt32(ds.Tables[0].Rows.Count);
            for (int j = 0; j < i; j++)
            {
                DropDownList2.Items.Add(ds.Tables[0].Rows[j][0].ToString());
            }
            con.Close();
        }
    }*/

    public SqlDataReader random(int m)
    {

        if (o != 0)
            con.Close();

        string chapter = TextBox8.Text, sub = DropDownList5.Text;
        string s = "SELECT TOP 1 Ques FROM Ques WHERE ( Course_Code = '" + sub + "') AND (chapter = '" + chapter + "')  ORDER BY NEWID()";
        SqlCommand cmd = new SqlCommand(s, con);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        dr.Read();
        o++;
        return dr;
    }
    /*protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }*/
    /*protected void Button3_Click(object sender, EventArgs e)
    {

        if (Session["Email"].ToString() == TextBox5.Text)
        {
            try
            {
                email_send();
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Mail Sent Successfully');", true);
            }
            catch (Exception rp)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Mail Not Sent');", true);
            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Invalid User');", true);
        }
        

    }*/

    /* public void email_send()
     {
         MailMessage mail = new MailMessage();
         SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
         mail.From = new MailAddress(TextBox5.Text);
         mail.To.Add(TextBox7.Text);
         mail.Subject = "New Question Paper";
         mail.Body = "Question Paper";

         System.Net.Mail.Attachment attachment;
         attachment = new System.Net.Mail.Attachment("Paper\\" + TextBox2.Text + " " + TextBox3.Text + ".doc");
         mail.Attachments.Add(attachment);

         SmtpServer.Port = 587;
         SmtpServer.Credentials = new System.Net.NetworkCredential(TextBox5.Text, TextBox6.Text);
         SmtpServer.EnableSsl = true;

         SmtpServer.Send(mail);

     }*/
    private int[] RemoveIndices(int[] IndicesArray, int RemoveAt)
    {
        int[] newIndicesArray = new int[IndicesArray.Length - 1];

        int i = 0;
        int j = 0;
        while ((i + 1) <= IndicesArray.Length)
        {
            if (i != RemoveAt)
            {
                newIndicesArray[j] = IndicesArray[i];

                j++;
            }
            i++;
        }
        return newIndicesArray;
    }



}
