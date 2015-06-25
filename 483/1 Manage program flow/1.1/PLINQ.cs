using System;
using System.Linq;

namespace MCSD {
	public static class PLINQ {
		public static void ParallelWhere(){
			Console.WriteLine("Parallel Where");
			var range = Enumerable.Range(0, 100);
			range.AsParallel().Where( i => i % 4 == 3).ToList().ForEach(Console.WriteLine);
		}
		
		public static void ParallelOrdering(){
			Console.WriteLine("Parallel Ordered");
			var range = Enumerable.Range(0,500);
			range.AsParallel().AsOrdered().Where( i => i % 4 == 3).AsSequential().ToList().ForEach(Console.WriteLine);
		}
	}
}