using System;
using System.Threading;

namespace MCSD {
	public static class ThreadPools {
		
		public static void RunFromPool(){
			ThreadPool.QueueUserWorkItem((s) => {
				Console.WriteLine("I am in a thread pool!");
			});
			
			Console.ReadLine();
		}
	}
}