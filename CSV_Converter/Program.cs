using Newtonsoft.Json;
using System.IO;

namespace CSV_Converter
{
    public class Program
    {
        public static void Main(string[] args)
        {

            List<string[]> list = new List<string[]>();
            List<string> badItems = new List<string>();
            List<Student> studentList = new List<Student>();
            List<ActiveStudy> activeStudies = new List<ActiveStudy>();
            string[] formats = { "JSON" };
            string activeStudiesJson = "";
            string studentJson = "";

            try
            {
                if (args.Length < 3)
                {
                    throw new ArgumentException("Missing parameters - to run the application please provide the following: [CSV input path], [Output destination], [Output format] ");
                }
                if (!formats.Contains(args[2].ToUpper()))
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
                            if (activeStudies.Find(p => p.Name == activeStudy.Name) == null)
                            {
                                activeStudies.Add(activeStudy);
                            }
                            else
                            {
                                var repeatedActiveStudy = activeStudies.Find(p => p.Name == activeStudy.Name);
                                repeatedActiveStudy.NumberOfStudents++;
                            }

                            studentList.Add(student);
                           
                        }

                        else
                        { 
                            badItems.Add(String.Join(",",item));
                        }
                       


                    }

                     activeStudiesJson = JsonConvert.SerializeObject(activeStudies, Formatting.Indented);
                     studentJson = JsonConvert.SerializeObject(studentList, Formatting.Indented);
                    
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {

                var outputPath = args[1];
                var format = args[2].ToUpper();
                DateTime currentDate = DateTime.Today;
                string dateString = currentDate.ToString("MM/dd/yyyy");

                if (format == "JSON")
                {
                    using (StreamWriter sw = File.CreateText(outputPath))
                    {
                        var university = new University(dateString, "Jan Kowalski", studentList, activeStudies);
                        var universityJson = JsonConvert.SerializeObject(university, Formatting.Indented);
                        sw.WriteLine(universityJson);
                    }
                }

                
            }
            



        }


    }
}