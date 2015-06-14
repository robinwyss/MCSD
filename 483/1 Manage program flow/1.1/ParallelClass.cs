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
		
		public static void Break(){
			Parallel.For(1,10, (i,loopState) => {
				System.Console.WriteLine(i);
				if(i == 5){
					loopState.Break();
					System.Console.WriteLine("loop has been interupted");
				}
				Thread.Sleep(1000/i);
			});
		}
		
		public static void Stop(){
			Parallel.For(1,10, (i,loopState) => {
				System.Console.WriteLine(i);
				if(i == 5){
					loopState.Stop();
					System.Console.WriteLine("loop has been stopped");
				}
				Thread.Sleep(1000/i);
			});
		}
	}	
}