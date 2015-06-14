using System;

namespace MCSD
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("MCSD");
            //Threads.StartThread();
            //ThreadPools.RunFromPool();
            Tasks.RunTask();
            Tasks.TaskWithChildren();
            ParallelClass.For();
            ParallelClass.ForEach();
            ParallelClass.Break();
            ParallelClass.Stop();
            var asyncTask = AsyncAwait.DoSomethingAsync();
            Console.WriteLine("reading text");
            Console.WriteLine(asyncTask.Result);
            Console.WriteLine("Done");
        }
    }
}
