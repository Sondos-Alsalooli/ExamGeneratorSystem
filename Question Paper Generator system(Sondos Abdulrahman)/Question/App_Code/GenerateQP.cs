using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GenerateQP
/// </summary>
public class GenerateQP<T>
{
    public T[] Genes { get; private set; }
    public float Fitness { get; private set; }

    private Random random;
    private Func<int,T> getRandomGene;
    private Func<GenerateQP<T>, float> fitnessFunction;

    public GenerateQP(int size, Random random, Func<int,T> getRandomGene, Func<GenerateQP<T>, float> fitnessFunction, bool shouldInitGenes = true)
    {
        Genes = new T[size];
        this.random = random;
        this.getRandomGene = getRandomGene;
        this.fitnessFunction = fitnessFunction;

        if (shouldInitGenes)
        {
            for (int i = 0; i < Genes.Length; i++)
            {
                Genes[i] = getRandomGene(i);
            }
        }
    }
    public float CalculateFitness()
    {
        Fitness = fitnessFunction(this);
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
                Genes[i] = getRandomGene(i);
            }
        }
    }
    public object Clone()
    {
        return new GenerateQP<T>(Genes.Length, random, getRandomGene, fitnessFunction);
    }
}