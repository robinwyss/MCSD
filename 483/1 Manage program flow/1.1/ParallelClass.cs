using System;
using System.Threading;
using System.Threading.Tasks;

namespace MCSD {
	
	public static class ParallelClass {
		
		public static void For(){
			Parallel.For(1,10, i => {
				System.Console.WriteLine(i); 
				Thread.Sleep(1000/i);
			});
		}
		
		public static void ForEach(){
			Parallel.ForEach(new string[]{"Joe","Jack","Jeff","Jones"}, name => {
				System.Console.WriteLine(name); 
			});
		}
	}	
}