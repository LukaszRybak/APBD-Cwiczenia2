using System;


namespace CSV_Converter
{
    internal class Student
    {
        public string IndexNumber { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Birthdate { get; set; }
        public string Email { get; set; }
        public string MothersName { get; set; }
        public string FathersName { get; set; }
        public Study Studies { get; set; }

        internal Student(
            string indexNumber, 
            string fname,
            string lname, 
            string birthdate, 
            string email, 
            string mothersName, 
            string fathersName,
            Study studies
            )
        {
            this.IndexNumber = indexNumber;
            this.Fname = fname;
            this.Lname = lname;
            this.Birthdate = birthdate;
            this.Email = email;
            this.MothersName = mothersName;
            this.FathersName = fathersName;
            this.Studies = studies;
        }
    }
}
