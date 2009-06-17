using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lopaco.Strategies
{
	public class OneAntPerNodeGenerator : AntsGenerator
	{
		public OneAntPerNodeGenerator(double[,] problem, double[,] heuristic)
			: base(problem, heuristic)
		{
		}

		public override IEnumerable<Ant> Generate(double[,] pheromone)
		{
			for (int i = 0; i < Problem.Length; i++)
			{
				yield return new Ant { Alpha = Alpha, Beta = Beta };
			}
		}
	}
}
