using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_Converter
{
    internal class ActiveStudy
    {
        public string Name { get; set; }
        public int NumberOfStudents{ get; set; }

        internal ActiveStudy(string name, int numberOfStudents)
        {
            this.Name = name;
            this.NumberOfStudents = numberOfStudents;

        }

    }

   
}
