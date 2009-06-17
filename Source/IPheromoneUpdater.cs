using System;
using System.Collections.Generic;

namespace Lopaco
{
	public interface IPheromoneUpdater
	{
		double[,] Update(double[,] problem, double[,] pheromone, IEnumerable<int[]> results);
	}
}
