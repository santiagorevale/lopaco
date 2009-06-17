using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lopaco.Strategies
{
	public class PheromoneUpdater : IPheromoneUpdater
	{
		IFitness fitness;

		public PheromoneUpdater(IFitness fitness)
		{
			this.fitness = fitness;
		}

		public double[,] Update(double[,] problem, double[,] pheromone, IEnumerable<int[]> results)
		{
			foreach (var result in results)
			{

			}

			throw new NotImplementedException();
		}

		public double Rho { get; set; }
		public double Theta { get; set; }
	}
}
