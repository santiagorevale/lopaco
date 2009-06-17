using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lopaco
{
	public interface IFitness
	{
		double Calculate(double[,] problem, int[] solution);
	}
}
