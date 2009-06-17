using System;
using System.Collections.Generic;
using System.Linq;

namespace Lopaco
{
	public class AntsController
	{
		double[,] problemDefinition;
		double[,] pheromones;
		IAntsGenerator generator;
		IStopCondition stopCondition;
		IPheromoneUpdater pheromoneUpdater;
		IFitness fitness;

		public AntsController(
			double[,] problemDefinition,
			double[,] initialPheromones,
			IAntsGenerator generator,
			IStopCondition stopCondition,
			IPheromoneUpdater pheromoneUpdater,
			IFitness fitness)
		{
			this.problemDefinition = problemDefinition;
			this.pheromones = initialPheromones;
			this.generator = generator;
			this.stopCondition = stopCondition;
			this.pheromoneUpdater = pheromoneUpdater;
			this.fitness = fitness;
		}

		public int[] Run()
		{
			int[] bestSolution = null;
			double bestFitness = 0;

			while (!stopCondition.ShouldStop)
			{
				var population = generator.Generate(pheromones);

				var solutions = from ant in population
								select ant.FindPath(problemDefinition, pheromones);

				var fitnessCollector = new BestFitnessCollector(problemDefinition, fitness);

				solutions = fitnessCollector.Collect(solutions);

				pheromones = pheromoneUpdater.Update(problemDefinition, pheromones, solutions);

				stopCondition.Update(fitnessCollector.BestFitness);

				if (fitnessCollector.BestFitness >= bestFitness)
				{
					bestSolution = fitnessCollector.BestSolution;
					bestFitness = fitnessCollector.BestFitness;
				}
			}

			return bestSolution;
		}

		private class BestFitnessCollector
		{
			double bestFitness;
			int[] bestSolution;
			double[,] problem;
			IFitness fitness;

			public BestFitnessCollector(double[,] problem, IFitness fitness)
			{
				this.problem = problem;
				this.fitness = fitness;
			}

			public IEnumerable<int[]> Collect(IEnumerable<int[]> solutions)
			{
				foreach (var solution in solutions)
				{
					var fit = fitness.Calculate(problem, solution);
					if (fit > bestFitness)
					{
						bestFitness = fit;
						bestSolution = solution;
					}

					yield return solution;
				}
			}

			public double BestFitness { get { return bestFitness; } }
			public int[] BestSolution { get { return bestSolution; } }
		}
	}
}
