using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GeneticAlgorithm
/// </summary>
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
    private Func<int, T> getRandomGene;
    private Func<GenerateQP<T>, float> fitnessFunction;
    int popsize;

    public GeneticAlgorithm(int populationSize, int dnaSize, Random random, Func<int, T> getRandomGene, Func<GenerateQP<T>, float> fitnessFunction,
        int elitism, float mutationRate = 0.01f)
    {
        popsize = populationSize;
        Generation = 1;
        Elitism = elitism;
        MutationRate = mutationRate;
        Population = new List<GenerateQP<T>>();
        newPopulation = new List<GenerateQP<T>>();
        this.random = random;
        this.dnaSize = dnaSize;
        this.getRandomGene = getRandomGene;
        this.fitnessFunction = fitnessFunction;

        BestGenes = new T[dnaSize];
        for (int i = 0; i < popsize; i++)
        {
            GenerateQP<T> generateclone = new GenerateQP<T>(dnaSize, random, getRandomGene, fitnessFunction, shouldInitGenes: true);
            Population.Add((GenerateQP<T>)generateclone.Clone());
        }
        CalculateFitness();
    }
    public void NewGeneration(int numNewDNA = 0, bool crossoverNewDNA = false)
    {
        int finalCount = popsize + numNewDNA;

        if (finalCount <= 0)
        {
            return;
        }

        if (popsize > 0)
        {
            CalculateFitness();
            Population.Sort(CompareDNA);
        }
        newPopulation.Clear();
        for (int i = 0; i < popsize; i++)
        {
            if (i < Elitism && i < popsize)
            {
                newPopulation.Add(Population[i]);
            }
            else if (crossoverNewDNA)
            {
                GenerateQP<T> parent1 = ChooseParent();
                GenerateQP<T> parent2 = ChooseParent();
                //if (parent1 == null)
                //{
                //  return;
                //}
                GenerateQP<T> child = parent1.Crossover(parent2);
                //  if (child == null)
                //{
                //  return;
                //}

                //child.Mutate(MutationRate);
                newPopulation.Add(child);

            }
            else
            {
                GenerateQP<T> generateclone = new GenerateQP<T>(dnaSize, random, getRandomGene, fitnessFunction, shouldInitGenes: true);
                newPopulation.Add((GenerateQP<T>)generateclone.Clone());
            }
        }

        List<GenerateQP<T>>tmpList = new List<GenerateQP<T>>(Population);
        Population = new List<GenerateQP<T>>(newPopulation);
        newPopulation = new List<GenerateQP<T>>(tmpList);
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

        foreach (GenerateQP<T> gene in Population)
        {
            fitnessSum += gene.CalculateFitness();

            if (gene.Fitness > best.Fitness)
            {
                best = gene;
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