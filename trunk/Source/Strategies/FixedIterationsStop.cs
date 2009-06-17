using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lopaco.Strategies
{
	public class FixedIterationsStop : IStopCondition
	{
		int currentCount;
		int targetCount;

		public FixedIterationsStop(int targetCount)
		{
			this.targetCount = targetCount;
		}

		public void Update(double bestFitness)
		{
			currentCount++;
		}

		public bool ShouldStop
		{
			get { return currentCount == targetCount; }
		}
	}
}
