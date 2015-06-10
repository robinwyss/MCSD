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
            Console.WriteLine("Done");
        }
    }
}
