using System;
using System.Threading.Tasks;

namespace MCSD
{
	public static class Tasks
	{
		public static void RunTask(){
			Task<string> t = Task.Run(() => "I am a Task");
			Console.WriteLine("Task: {0}", t.Result);
		}
	}
}