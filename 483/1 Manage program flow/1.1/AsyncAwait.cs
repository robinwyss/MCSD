using System.IO;
using System.Text;
using System.Threading.Tasks;
using System;

namespace MCSD
{

    public static class AsyncAwait
    {
        public static async Task<string> DoSomethingAsync()
        {
            Console.WriteLine("Read file async");
            var buffer = new byte[12];
            string txt = "";
            using (var stream = new FileStream("project.json", FileMode.Open))
            {
                var read = 0;
                while ((read = await stream.ReadAsync(buffer, 0, 12).ConfigureAwait(false)) > 0)
                {
                    txt += Encoding.UTF8.GetString(buffer);
                    Console.Write('.');
                }
            }
            Console.WriteLine("File read");
            return txt;
        }
    }
}