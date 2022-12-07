using System.IO;

namespace CSV_Converter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var pathff = Path.Combine(Directory.GetCurrentDirectory(), "\\data\\dane.csv");
            var pathUgly = "C:\\Users\\Dell\\Desktop\\Studying\\PJATK\\APBD\\APBD-Cwiczenia2\\CSV_Converter\\data\\dane.csv";
            var path = Directory.GetCurrentDirectory() + "\\data\\dane.csv";

            Console.WriteLine("The current directory is " + Directory.GetCurrentDirectory());
            Console.WriteLine(Directory.GetCurrentDirectory()  + "\\data\\dane.csv");
            Console.WriteLine(pathff);
            Console.WriteLine(pathUgly);
            Console.WriteLine(path);

            using (var reader = new StreamReader(path))
            {
                List<string> listA = new List<string>();
                List<string> listB = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    listA.Add(values[0]);
                    listB.Add(values[1]);

                    foreach(string item in listA)
                    {

                        Console.WriteLine(item);
                    }

                }
            }
        }


    }
}