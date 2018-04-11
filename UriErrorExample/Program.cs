using System;
using System.IO;

namespace UriErrorExample
{
    class Program
    {
        static void Main(string[] args)
        {
            
            FileInfo file = new FileInfo(new Uri(typeof(Program).Assembly.Location+"/testing#folder/testingdoc.txt").LocalPath);
            using (FileStream x = file.OpenRead())
            {
                byte[] buffer = new byte[x.Length];
                int numBytesToRead = (int)x.Length;
                int numBytesRead = 0;
                while (numBytesToRead > 0)
                {
                    int n = x.Read(buffer, numBytesRead, numBytesToRead);
                    if (n == 0) break;
                    numBytesRead += n;
                    numBytesToRead -= n;
                }
                Console.WriteLine(System.Text.Encoding.Default.GetString(buffer));
            }
        }
    }
}