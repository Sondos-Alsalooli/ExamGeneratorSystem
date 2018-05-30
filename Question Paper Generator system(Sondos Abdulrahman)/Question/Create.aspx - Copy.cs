using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
//using Microsoft.Office.Interop.Word;
using System.Diagnostics;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.Net.Mail;


public partial class Create : System.Web.UI.Page

{
    public class Qtype
    {
        public string name;
        public int numOfType;
        public Qtype(string s, int i)
        {
            this.name = s;
            this.numOfType = i;
        }
    }
    // question class here with all properties 
    public class Gene
    {
        public string question { get; set; }
        public string CLO { get; set; }
        public string type { get; set; }
        public string Answer { get; set; }
        public string mark { get; set; }
        public string chapter { get; set; }
        public Gene(string s, string t, string i, string a, string m, string c)
        {
            this.question = s;
            this.type = t;
            this.CLO = i;
            this.Answer = a;
            this.mark = m;
            this.chapter = c;

        }
    }
    // make list of type Gene
    static  List<Gene> QuestionList = new List<Gene>();

    public static List<Gene> QuestionList1
    {
        get { return QuestionList; }
        set { QuestionList = value; }
    }

    static List<List<Gene>> PaperList = new List<List<Gene>>();

    public static List<List<Gene>> PaperList1
    {
        get { return PaperList; }
        set { PaperList = value; }
    }

    public int TotalLength;
    bool flag;
    public string sub;
    public string[] chapter;
    List<string> CLOSum = new List<string>();
    public List<string> CLOCourse = new List<string>();
    List<Qtype> QuestionTList = new List<Qtype>();

    public static string Connection_String = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Sondos\Downloads\For the project\suz\ExamGenerationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
    SqlConnection con = new SqlConnection(Create.Connection_String);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SqlDataAdapter da;
            SqlConnection con = new SqlConnection(Create.Connection_String);
            DataSet ds = new DataSet();
            string po = "select distinct Course_Code from Course";
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
protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
        {
             sub = DropDownList5.Text;
             chapter = TextBox8.Text.Split(',');

             
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Sondos\Downloads\For the project\suz\ExamGenerationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");

        string s3 = "select top 1 Question_ID From QuestionBank ORDER BY Question_ID Desc";
        con.Open();
        SqlCommand cmd3 = new SqlCommand(s3, con);
        object count = cmd3.ExecuteScalar();
        if (count != null)
        {
            TotalLength = Convert.ToInt32(count);
        }
        con.Close();

    // bring all question from database from selected course and store in instances off class gene then add them to list
            string s = "select * FROM QuestionBank WHERE (Cource_Code = '" + DropDownList5.SelectedItem.Text + "') ORDER BY RAND()";
                    SqlCommand cmd = new SqlCommand(s, con);
                    SqlDataReader dr;
                    con.Open();
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    while (dr.Read())
                    {
                        string ques = dr["Question"].ToString();
                        string questype = dr["Question_Type"].ToString();
                        string quesCLO = dr["CLO"].ToString();
                        string quesAnswer = dr["Answer"].ToString();
                        string quesMark = dr["Mark"].ToString();
                        string quesChapter = dr["Chapter"].ToString();
                        QuestionList1.Add(new Gene(ques, questype, quesCLO, quesAnswer, quesMark, quesChapter)); 
                        respos
                    }

                    con.Close();

                    SqlDataAdapter da;
                    DataSet ds = new DataSet();
                    da = new SqlDataAdapter("SELECT distinct CLO_Code FROM CLO WHERE (Cource_Code = '" + DropDownList5.Text + "')", con);
                    con.Open();             
                    ds = new DataSet();
                    da.Fill(ds);
                    int j = Convert.ToInt32(ds.Tables[0].Rows.Count);
                    for (int y = 0; y < j; y++)
                    {
                        CLOCourse.Add(ds.Tables[0].Rows[y][0].ToString());
                    }
                    con.Close();
        }
   




    protected void Button2_Click(object sender, EventArgs e)
    {
        //Button2.Visible = false;
        DropDownList5_SelectedIndexChanged(sender, e);
        sample1();

    }
    
    
public void paper()
    {
      
    sub = DropDownList5.Text;
            chapter = TextBox8.Text.Split(',');
        int marks = Convert.ToInt32(DropDownList2.Text);
        //string sub = DropDownList5.Text;
       
        //int chapter = Convert.ToInt32(TextBox8.Text);
       
        int Short = Convert.ToInt32(TextBox11.Text);
        int Long = Convert.ToInt32(TextBox10.Text);
        int choose = Convert.ToInt32(TextBox4.Text);
        int TorF = Convert.ToInt32(TextBox3.Text);
        int fill = Convert.ToInt32(TextBox9.Text);
        total = Short + Long + choose + TorF + fill; 
        double tmarks = ((fill * 0.5) + (choose * 0.5) + (TorF * 0.5) + (Short * 2) + (Long * 5));


        QuestionTList.Add(new Qtype("fill", fill));
        QuestionTList.Add(new Qtype("choose", choose));
        QuestionTList.Add(new Qtype("TorF", TorF));
        QuestionTList.Add(new Qtype("Short", Short));
        QuestionTList.Add(new Qtype("Long", Long));


             
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Sondos\Downloads\For the project\suz\ExamGenerationSystem.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        
       string s3 = "select top 1 Question_ID From QuestionBank ORDER BY Question_ID Desc";
       con.Open();
       SqlCommand cmd3 = new SqlCommand(s3, con);
       object count = cmd3.ExecuteScalar();
       if (count != null)
       {
           TotalLength = Convert.ToInt32(count);
       }
       con.Close();
       


        if (marks == tmarks)
        {
            flag = true;
        }
        else
        {
            flag = false;
        }

     for(int i=0; i < populationSize; i++)
      {
   // bring all question from database from selected course and store in instances off class gene then add them to list
     foreach (Qtype qt in QuestionTList)
      {
           string s = "select '"+ qt.numOfType  + "' FROM QuestionBank WHERE (Cource_Code = '" + DropDownList5.SelectedItem.Text + "') AND (Question_Type = '" + qt.name + "') ORDER BY RAND()";
                   SqlCommand cmd = new SqlCommand(s, con);
                   SqlDataReader dr;
                   con.Open();
                   dr = cmd.ExecuteReader();
                   dr.Read();
                   while (dr.Read())
                   {
                       string ques = dr["Question"].ToString();
                       string questype = dr["Question_Type"].ToString();
                       string quesCLO = dr["CLO"].ToString();
                       string quesAnswer = dr["Answer"].ToString();
                       string quesMark = dr["Mark"].ToString();
                       string quesChapter = dr["Chapter"].ToString();
                       List<Gene> QuestionList2 = new List<Gene>();
                       QuestionList2.Add(new Gene(ques, questype, quesCLO, quesAnswer, quesMark, quesChapter));
                       PaperList1.Add(QuestionList2);
                   }

                   con.Close();
    }
     
                   
    }              
    }
    
   

    int populationSize = 20;
        float mutationRate = 0.01f;
        int elitism = 5;
        //int numCharsPerText = 15000;
        //Text targetText;
        //Text bestText;
        List<Gene> bestPaper;
        List<Gene> bestFitnessPaper;
        List<Gene> numGenerationsPaper;
    

        private GeneticAlgorithm<Gene> ga;
        private System.Random randome;
        
    //Gene[] s;
        // make array  QuestionPool of type gene, convert QuestionList ToArray
        Gene[] QuestionPool { get  { return QuestionList1.ToArray(); } }
                
        void Start()
        {
            randome = new System.Random();
            //make instance  ga of getiticalgorithm class
            ga = new GeneticAlgorithm<Gene>(populationSize, total, randome, GetRandomQuestion, FitnessFunction, elitism, mutationRate);
          
        }
        public List<Gene> update()
        {
            ga.NewGeneration();
        
            if (ga.BestFitness != CLOCourse.Count)
            {
                ga.NewGeneration();
                UpdatePaper(ga.BestGenes, ga.BestFitness, ga.Generation, ga.Population.Count, (j) => ga.Population[j].Genes);
            }
            return bestPaper;
            
        }
    // get randome quesyion get elemnt from questionpool randomly 
        private Gene GetRandomQuestion()
        {
           
            randome = new System.Random();
           // int i = randome.Next(QuestionList.Count);
            //return QuestionList[i];
            int i = 0;
            if(QuestionPool.Length-1>-1)
             i = randome.Next(QuestionPool.Length-1);
            //string o= QuestionPool[i].question;
            return QuestionPool[i];
           // return QuestionPool[randome.Next(QuestionPool.Length - 1)];
        }

        public float FitnessFunction(int index)
        {
            float score = 0;

            GenerateQP<Gene> dna = ga.Population[index];
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
                        }
                        break;
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

    public class GenerateQP<T>
    {
        public T[] Genes { get; private set; }
        public float Fitness { get; private set; }

        private Random random;
        private Func<T> getRandomGene;
        private Func<int, float> fitnessFunction;

        public GenerateQP(int size, Random random, Func<T> getRandomGene, Func<int, float> fitnessFunction, bool shouldInitGenes = true)
	    {
		Genes = new T [size];
		this.random = random;
		this.getRandomGene = getRandomGene;
		this.fitnessFunction = fitnessFunction;

		if (shouldInitGenes)
		{
			for (int i = 0; i < Genes.Length; i++)
			{
				Genes[i] = getRandomGene();
			}
		}
	}
        public float CalculateFitness(int index)
        {
            Fitness = fitnessFunction(index);
            return Fitness;
        }

        public GenerateQP<T> Crossover(GenerateQP<T> otherParent)
        {
            GenerateQP<T> child = new GenerateQP<T>(Genes.Length, random, getRandomGene, fitnessFunction, shouldInitGenes: false);

            for (int i = 0; i < Genes.Length; i++)
            {
                child.Genes[i] = random.NextDouble() < 0.5 ? Genes[i] : otherParent.Genes[i];
            }

            return child;
        }
        public void Mutate(float mutationRate)
        {
            for (int i = 0; i < Genes.Length; i++)
            {
                if (random.NextDouble() < mutationRate)
                {
                    Genes[i] = getRandomGene();
                }
            }
        }
    }

    public class GeneticAlgorithm<T>
    {
        public List<GenerateQP<T>> Population { get; private set; }
        public int Generation { get; private set; }
        public float BestFitness { get; private set; }
        public T[] BestGenes { get; private set; }

        public int Elitism;
        public float MutationRate;

        private List<GenerateQP<T>> newPopulation;
        private Random random;
        private float fitnessSum;
        private int dnaSize;
        private Func<T> getRandomGene;
        private Func<int, float> fitnessFunction;


        public GeneticAlgorithm(int populationSize, int dnaSize, Random random, Func<T> getRandomGene, Func<int, float> fitnessFunction,
            int elitism, float mutationRate = 0.01f)
        {
            Generation = 1;
            Elitism = elitism;
            MutationRate = mutationRate;
            Population = new List<GenerateQP<T>>(populationSize);
            newPopulation = new List<GenerateQP<T>>(populationSize);
            this.random = random;
            this.dnaSize = dnaSize;
            this.getRandomGene = getRandomGene;
            this.fitnessFunction = fitnessFunction;

            BestGenes = new T[dnaSize];
            for (int i = 0; i < populationSize; i++)
            {
                Population.Add(new GenerateQP<T>(dnaSize, random, getRandomGene, fitnessFunction, shouldInitGenes: true));
            }
        }
        public void NewGeneration(int numNewDNA = 0, bool crossoverNewDNA = false)
        {
            int finalCount = Population.Count + numNewDNA;

            if (finalCount <= 0)
            {
                return;
            }

            if (Population.Count > 0)
            {
                CalculateFitness();
                Population.Sort(CompareDNA);
            }
            newPopulation.Clear();

            
		for (int i = 0; i < Population.Count; i++)
		{
			if (i < Elitism && i < Population.Count)
			{
				newPopulation.Add(Population[i]);
			}
			else if (i < Population.Count || crossoverNewDNA)
			{
                GenerateQP<T> parent1 = ChooseParent();
                GenerateQP<T> parent2 = ChooseParent();
                //if (parent1 == null)
                //{
                  //  return;
                //}
                if (parent1 == null) HttpContext.Current.Response.Write("NULL");
                    GenerateQP<T> child = parent1.Crossover(parent2);
                  //  if (child == null)
                    //{
                      //  return;
                    //}

                    child.Mutate(MutationRate);

                    newPopulation.Add(child);
                
			}
			else
			{
                newPopulation.Add(new GenerateQP<T>(dnaSize, random, getRandomGene, fitnessFunction, shouldInitGenes: true));
			}
        }

        List<GenerateQP<T>> tmpList = Population;
        Population = newPopulation;
        newPopulation = tmpList;

        Generation++;
        }

        private int CompareDNA(GenerateQP<T> a, GenerateQP<T> b)
        {
            if (a.Fitness > b.Fitness)
            {
                return -1;
            }
            else if (a.Fitness < b.Fitness)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        private void CalculateFitness()
        {
            fitnessSum = 0;
            GenerateQP<T> best = Population[0];

            for (int i = 0; i < Population.Count; i++)
            {
                fitnessSum += Population[i].CalculateFitness(i);

                if (Population[i].Fitness > best.Fitness)
                {
                    best = Population[i];
                }
            }

            BestFitness = best.Fitness;
            best.Genes.CopyTo(BestGenes, 0);

        }
        private GenerateQP<T> ChooseParent()
        {
            double randomNumber = random.NextDouble() * fitnessSum;

            for (int i = 0; i < Population.Count; i++)
            {
                if (randomNumber < Population[i].Fitness)
                {
                    return Population[i];
                }

                randomNumber -= Population[i].Fitness;
            }

            return null;
        }

    }

     
        


    int total;
    public void sample1()
    {
        
        int marks = Convert.ToInt32(DropDownList2.Text);
        string sub = DropDownList5.Text;
       
        //int chapter = Convert.ToInt32(TextBox8.Text);
        bool flag;
        int Short = Convert.ToInt32(TextBox11.Text);
        int Long = Convert.ToInt32(TextBox10.Text);
        int choose = Convert.ToInt32(TextBox4.Text);
        int TorF = Convert.ToInt32(TextBox3.Text);
        int fill = Convert.ToInt32(TextBox9.Text);
        total = Short + Long + choose + TorF + fill; 
        double tmarks = ((fill * 0.5) + (choose * 0.5) + (TorF * 0.5) + (Short * 2) + (Long * 5));

        QuestionTList.Add(new Qtype("fill", fill));
        QuestionTList.Add(new Qtype("choose", choose));
        QuestionTList.Add(new Qtype("TorF", TorF));
        QuestionTList.Add(new Qtype("Short", Short));
        QuestionTList.Add(new Qtype("Long", Long));


        if (marks == tmarks)
        {
            flag = true;
        }
        else
        {
            flag = false;
        }

        //for (int j = 0; j < total; j++)
        //{
          //  foreach (Qtype qt in QuestionTList)
           // {
        if (flag == true)
        {
            Start();
            List<Gene> OurPaper = update();
            //List<String> r = OurPaper.Select(o => OurPaper.question).ToList();
            List<string> OurQuestions = OurPaper.Select(Gene => Gene.question).OrderBy(questype => questype).ToList();
            
//while (ga.BestFitness < CLOCourse.Count)
            //{
            //  ga.NewGeneration();
            //}



            //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-SPKCV2J;Initial Catalog=Question;Integrated Security=True");
            //string s = "select Max(Mod) FROM Ques WHERE (Subject = '" + sub + "') AND (Sem = '" + seme + "') AND (Difficulty = '" + diff + "')";
            //string s = "select * Question, CLO, Question_Type FROM QuestionBank WHERE (Subject = '" + sub + "') AND (chapter = '" + chapter + "') AND (Question_Type = '" + qt.name + "') ORDER BY RAND() LIMIT = '" + qt.numOfType;
            //string s = "select * Question, CLO, Question_Type FROM QuestionBank WHERE (Subject = '" + sub + "') AND (chapter = '" + chapter + "') ORDER BY RAND()'";
            //SqlCommand cmd = new SqlCommand(s, con);
            //SqlDataReader dr;
            //con.Open();
            //dr = cmd.ExecuteReader();
            //dr.Read();
            //while (dr.Read())
            //{
            //  string ques = dr["Question"].ToString();
            //string questype = dr["Question_Type"].ToString();
            //string quesCLO = dr["CLO"].ToString(); 
            //string quesAnswer = dr["Answer"].ToString();
            //string quesMark = dr["Mark"].ToString();
            //string quesChapter = dr["chapter"].ToString(); 
            //QuestionList.Add(new Gene (ques, questype, quesCLO, quesAnswer, quesMark, quesAnswer));
            //}
            //ch = Convert.ToInt32(dr[0].ToString());
            //con.Close();
            //flag = true;



            //  }
            //}
            
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Charset = "";

            HttpContext.Current.Response.ContentType = "application/msword";

            string strFileName = TextBox2.Text + ".doc";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "inline;filename=" + strFileName);

            StringBuilder strHTMLContent = new StringBuilder();

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
            int x = 0;
            int p;

            string[] qu = new string[total];
            for (int i = 0; i < QuestionTList.Count; i++)
            {
                foreach (Qtype qt in QuestionTList)
                {
                    strHTMLContent.Append("<p>".ToString());
                    strHTMLContent.Append("<strong>Q" + (i + 1) + ". &nbsp; &nbsp; </strong><strong>Answer the following questions : &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; " + qt.numOfType + "</strong></p>".ToString());
                }
                p = 0;
            
                while (p < total)
                {
                    foreach (string v in OurQuestions)
                    {
                        strHTMLContent.Append("<p>".ToString());
                        strHTMLContent.Append("<span style='font-size: 14px;'>&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</span><span style='font-size: 14px;'>(" + (p + 1) + ") &nbsp;" + v + "</span></p>".ToString());
                        x++;
                        p++;
                        con.Close();
                    }
                }
                strHTMLContent.Append("<p>".ToString());
                strHTMLContent.Append("&nbsp;</p>".ToString());

            }
            strHTMLContent.Append("<div>".ToString());
            strHTMLContent.Append("<span style='font-family:times new roman,times,serif;'>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;X-X- All The Best -X-X</span></div>".ToString());
            strHTMLContent.Append("</div>".ToString());
            strHTMLContent.Append("<p>".ToString());
            strHTMLContent.Append("&nbsp;</p>".ToString());

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

    public int o=0;

   
    private int[] RemoveIndices(int[] IndicesArray, int RemoveAt)
    {
        int[] newIndicesArray = new int[IndicesArray.Length - 1];

        int i = 0;
        int j = 0;
        while ((i+1) <= IndicesArray.Length)
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
