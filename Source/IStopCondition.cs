using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lopaco
{
	public interface IStopCondition
	{
		void Update(double bestFitness);
		bool ShouldStop { get; }
	}
}
