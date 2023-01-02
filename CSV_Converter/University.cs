using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_Converter
{
    internal class University
    {
        public string CreatedAt { get; set; }
        public string Author { get; set; }
        public List<Student> Students { get; set; }
        public List<ActiveStudy> ActiveStudies { get; set; }

        internal University(string createdAt, string author, List<Student> students, List<ActiveStudy> activeStudies)
        {
            this.CreatedAt = createdAt;
            this.Author = author;
            Students = students;
            ActiveStudies = activeStudies;
        }
    }
}
