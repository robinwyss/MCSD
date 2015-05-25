using System;
using System.Threading;

namespace MCSD
{
    public static class Threads
    {
        public static void StartThread()
        {
            var thread = new Thread(new ThreadStart(ThreadMethod));
            thread.Start();
            for(var i = 1; i < 10; i++){
                Console.WriteLine("Main");
                Thread.Sleep(0);
            }
            thread.Join();
    	}
        
		public static void ThreadMethod()
        {
            for(var i = 0; i < 15; i++){
                Console.WriteLine("Thread");
                Thread.Sleep(0);
            }
        }
    }
}