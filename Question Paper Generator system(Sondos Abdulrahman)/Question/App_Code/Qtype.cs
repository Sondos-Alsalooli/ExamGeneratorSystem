using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Qtype
/// </summary>
public class Qtype
{
    public string name;
    public int numOfType;
    public int numquestion;
    public double mark;
    public Qtype(string s, int i, double m)
    {
        this.name = s;
        this.mark = m;
        numquestion = this.numOfType = i;
    }
}