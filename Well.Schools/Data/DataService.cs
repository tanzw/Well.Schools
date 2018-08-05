using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Well.Schools.Common;
using Well.Schools.EFModel;
using Well.Schools.ViewModel;

namespace Well.Schools.Data
{
    public class DataService
    {
        public int InsertRegister(tb_student student, tb_Register reg)
        {
            int result = 0;
            using (SchoolContext context = new SchoolContext())
            {
                 
                if (student.Id > 0)
                {
                    var dataStudent = context.tb_student.FirstOrDefault(x => x.Id == student.Id);
                    dataStudent.Name = student.Name;
                    dataStudent.Sex = student.Sex;
                    dataStudent.Contact = student.Contact;
                    dataStudent.Address = student.Address;
                    dataStudent.Description = student.Description;
                }
                else
                {
                    context.tb_student.Add(student);
                }

                if (reg.Id > 0)
                {
                    var dataReg = context.tb_Register.FirstOrDefault(x => x.Id == reg.Id);
                    dataReg.Money = reg.Money;
                    dataReg.States = reg.States;
                    //dataReg.StudentId = student.Id;
                    dataReg.Year = reg.Year;
                }
                else
                {
                    //reg.StudentId = student.Id;
                    context.tb_Register.Add(reg);
                }

                result = context.SaveChanges();
            }
            return result;
        }

        public int SaveStudent(tb_student student)
        {
            int result = 0;
            using (SchoolContext context = new SchoolContext())
            {
                if (student.Id > 0)
                {
                    var dataStudent = context.tb_student.FirstOrDefault(x => x.Id == student.Id);
                    dataStudent.Name = student.Name;
                    dataStudent.Sex = student.Sex;
                    dataStudent.Contact = student.Contact;
                    dataStudent.Address = student.Address;
                    dataStudent.Description = student.Description;
                }
                else
                {
                    context.tb_student.Add(student);
                }
                result = context.SaveChanges();
            }
            return result;
        }

        public int UpdateRegister(tb_Register reg)
        {
            int result = 0;
            using (SchoolContext context = new SchoolContext())
            {

                var dataReg = context.tb_Register.FirstOrDefault(x => x.Id == reg.Id);
                dataReg.Money = reg.Money;
                dataReg.States = reg.States;
               // dataReg.StudentId = reg.StudentId;
                dataReg.Year = reg.Year;
                result = context.SaveChanges();
            }
            return result;
        }


        public List<tb_student> QueryStudentList(tb_student student)
        {

            var result = new List<tb_student>();
            using (SchoolContext context = new SchoolContext())
            {
           
                var data = context.tb_student.AsQueryable();

                if (student != null && !string.IsNullOrWhiteSpace(student.Name))
                {
                    data = data.Where(x => x.Name.Contains(student.Name));
                }

                if (student != null && student.Id > 0)
                {
                    data = data.Where(x => x.Id == student.Id);
                }

                result = data.ToList();
            }
            return result;
        }

        public List<RegisterView> QueryRegList()
        {
            var result = new List<RegisterView>();
            using (SchoolContext context = new SchoolContext())
            {
                var s = context.tb_student.FirstOrDefault(x => x.Id == 1);
                
                result = context.Database.SqlQuery<RegisterView>(@"SELECT
	a.Id AS RegId,
	a.StudentId,
	b.Name AS StudentName,
	a.GradeId,
	c.Name AS GradeName,
	a.CourseId,
	d.Name AS CourseName,
	a.Money,
	a.States,
	(
		CASE a.States
		WHEN 0 THEN
			'未缴'
		WHEN 1 THEN
			'已缴'
		ELSE
			'其他'
		END
	) AS StatesName,
	a.Year,
	a.CreateAt
FROM
	tb_Register AS a
INNER JOIN tb_student AS b ON a.StudentId = b.Id
INNER JOIN tb_grade AS c ON a.GradeId = c.Id
INNER JOIN tb_course AS d ON a.CourseId = d.Id").ToList();




            }

            return result;
        }

    }
}
