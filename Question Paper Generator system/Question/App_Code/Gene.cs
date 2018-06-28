using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
// question class here with all properties 
public class Gene : ICloneable
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
     public object Clone()
    {
        return new Gene(question, type, CLO, Answer, mark, chapter);
    }
     public override string ToString()
     {
         return "question:" + question + " CLO:" + CLO + " type:" + type + " Answer:" + Answer + " mark:" + mark + " chapter:" + chapter;
     }
}
