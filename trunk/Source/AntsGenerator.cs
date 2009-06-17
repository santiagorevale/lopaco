using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lopaco
{
	public abstract class AntsGenerator : IAntsGenerator
	{
		protected AntsGenerator(double[,] problem, double[,] heuristic)
		{
			this.Problem = problem;
			this.Heuristic = heuristic;
		}

		public abstract IEnumerable<Ant> Generate(double[,] pheromone);

		public double Alpha { get; set; }
		public double Beta { get; set; }
		public double[,] Problem { get; private set; }
		public double[,] Heuristic { get; private set; }
	}
}
