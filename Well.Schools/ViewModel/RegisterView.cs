using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Well.Schools.ViewModel
{
    public class RegisterView
    {
        public int RegId { get; set; }

        public int StudentId { get; set; }

        public string StudentName { get; set; }

        public int CourseId { get; set; }

        public string CourseName { get; set; }

        public int GradeId { get; set; }

        public string GradeName { get; set; }

        public decimal Money { get; set; }

        public int Year { get; set; }

        public int States { get; set; }

        public string StatesName { get; set; }

        public DateTime CreateAt { get; set; }
    }
}
