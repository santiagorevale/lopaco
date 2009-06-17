using System;
using System.Collections.Generic;

namespace Lopaco
{
	public interface IAntsGenerator
	{
		IEnumerable<Ant> Generate(double[,] pheromone);
	}
}
