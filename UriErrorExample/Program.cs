using System;
using System.IO;

namespace UriErrorExample
{
    class Program
    {
        static void Main(string[] args)
        {

            FileInfo uriFile = new FileInfo(new Uri(typeof(Program).Assembly.Location + "/testing#folder/testingdoc.txt").LocalPath);
            FileInfo stringFile = new FileInfo(typeof(Program).Assembly.Location + "/testing#folder/testingdoc.txt");
            try
            {

                ReadFile(uriFile);
            }
            catch (Exception) { }
            try
            {
                ReadFile(stringFile);
            }
            catch (Exception) { }
            Console.ReadKey();
        }
        static void ReadFile(FileInfo info)
        {
            using (FileStream x = info.OpenRead())
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