using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_Converter
{
    internal class Study
    {
        public string Name { get; set; }
        public string Mode { get; set; }

        internal Study(string name, string mode)
        {
            this.Name = name;
            this.Mode = mode;
        }
    }
}
