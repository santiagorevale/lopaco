using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Lopaco.Strategies;

namespace Lopaco.Tests
{
	[TestFixture]
	public class AntsControllerFixture
	{
		[Test]
		public void ShouldHookEverything()
		{
			var stop = new MockStop();
			var fitness = new MockFitness();
			var generator = new MockGenerator();
			var updater = new MockUpdater();

			var controller = new AntsController(
				new double[,] { { 1, 3 }, { 2, 5 } },
				new double[,] { { 1, 1 }, { 1, 1 } },
				generator, stop, updater, fitness);

			var result = controller.Run();

			Assert.AreEqual(2, result.Length);
		}

		public class MockStop : IStopCondition
		{
			int count;
			public void Update(double bestFitness)
			{
				count++;
			}

			public bool ShouldStop
			{
				get { return count == 5; }
			}
		}

		public class MockFitness : IFitness
		{
			public double Calculate(double[,] problem, int[] solution)
			{
				return 0;
			}
		}

		public class MockGenerator : IAntsGenerator
		{
			public IEnumerable<Ant> Generate(double[,] pheromone)
			{
				yield return new Ant();
				yield return new Ant();
			}
		}

		public class MockUpdater : IPheromoneUpdater
		{
			public double[,] Update(double[,] problem, double[,] pheromone, IEnumerable<int[]> results)
			{
				return pheromone;
			}
		}
	}


}
