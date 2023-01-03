using Newtonsoft.Json;
using System.IO;

namespace CSV_Converter
{
    public class Program
    {

        public static void Log(string line)
        {
            using (StreamWriter sw = File.AppendText(Directory.GetCurrentDirectory() + "\\log.txt"))
            {
                DateTime currentDate = DateTime.Now;
                string dateString = currentDate.ToString("MM/dd/yyyy HH:mm:ss");
                sw.WriteLine("[" + dateString + "]: " + line);
            }
        }


        public static void Main(string[] args)
        {

            List<string[]> list = new List<string[]>();
            List<string> badItems = new List<string>();
            List<string> duplicatedItems = new List<string>();
            List<Student> studentList = new List<Student>();
            List<ActiveStudy> activeStudies = new List<ActiveStudy>();
            string[] formats = { "JSON" };

            try
            {
                if (args.Length != 3)
                {
                    throw new ArgumentException("Missing parameters - to run the application please provide the following: [CSV input path], [Output destination], [Output format] ");
                }
                else if (!formats.Contains(args[2].ToUpper()))
                {
                    throw new ArgumentException("Output format " + args[2] + " is not supported");
                }

                var csvPath = args[0];

                using (var reader = new StreamReader(csvPath))
                {

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var value = line.Split(',');
                        list.Add(value);

                    }
                    foreach (string[] item in list)
                    {
                        if (item.Length == 9 && !item.Any(string.IsNullOrEmpty))
                        {
                            var indexNumber = "s" + item[4];
                            var fname = item[0];
                            var lname = item[1];
                            var birthdate = item[5];
                            var email = item[6];
                            var mothersName = item[7];
                            var fathersName = item[8];
                            var studies = new Study(item[2], item[3]);
                            var student = new Student(indexNumber, fname, lname, birthdate, email, mothersName, fathersName, studies);
                            var activeStudy = new ActiveStudy(item[2], 1);



                            if (studentList.Find(p =>
                            p.Fname == student.Fname &&
                            p.Lname == student.Lname &&
                            p.IndexNumber == student.IndexNumber) != null)
                            {
                                duplicatedItems.Add("[Duplicated record] " + String.Join(",", item));
                            }
                            else
                            {
                                studentList.Add(student);

                                if (activeStudies.Find(p => p.Name == activeStudy.Name) == null)
                                {
                                    activeStudies.Add(activeStudy);
                                }
                                else
                                {
                                    var repeatedActiveStudy = activeStudies.Find(p => p.Name == activeStudy.Name);
                                    repeatedActiveStudy.NumberOfStudents++;
                                }

                            }

                        }

                        else
                        {
                            badItems.Add("[Incorrect record] " + String.Join(",", item));
                        }

                    }

                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                Log(e.Message);

            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                Log(e.Message);
            }
            finally
            {
                if (args.Length == 3)
                {
                    var outputPath = args[1];
                    var format = args[2].ToUpper();
                    DateTime currentDate = DateTime.Today;
                string dateString = currentDate.ToString("MM/dd/yyyy");

                if (format == "JSON")
                {
                    using (StreamWriter sw = File.CreateText(outputPath))
                    {
                        var output = new University(dateString, "Jan Kowalski", studentList, activeStudies);
                        var university = new Output(output);
                        var universityJson = JsonConvert.SerializeObject(university, Formatting.Indented);
                        sw.WriteLine(universityJson);
                    }
                }

                }

                foreach (string item in badItems)
                {
                    Log(item);
                }

                foreach (string item in duplicatedItems)
                {
                    Log(item);
                }

                

            }




        }


    }
}