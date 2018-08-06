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
                    dataReg.Year = reg.Year;
                    dataReg.CourseId = reg.CourseId;
                    dataReg.GradeId = reg.GradeId;

                }
                else
                {
                    reg.Student = student;
                    reg.Course = context.tb_course.FirstOrDefault(x => x.Id == reg.CourseId);
                    reg.Grade = context.tb_grade.FirstOrDefault(x => x.Id == reg.GradeId);
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

        public List<RegisterView> QueryRegList(int studentId, string name, int year, int courseId, int gradeId, int states)
        {
            var result = new List<RegisterView>();
            using (SchoolContext context = new SchoolContext())
            {
                var sql = new StringBuilder();
                sql.Append(@"SELECT
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
INNER JOIN tb_course AS d ON a.CourseId = d.Id");
                sql.Append(" where 1=1 ");
                if (studentId > 0)
                {
                    sql.AppendFormat(" and a.StudentId={0}", studentId);
                }
                if (!string.IsNullOrWhiteSpace(name))
                {
                    name = name.Replace("'", "").Replace("\"", "").Replace("+", "");

                    sql.AppendFormat(" and b.Name like '%{0}%'", name);
                }
                if (year > 0)
                {
                    sql.AppendFormat(" and a.Year={0}", year);
                }
                if (courseId > 0)
                {
                    sql.AppendFormat(" and a.CourseId={0}", courseId);
                }
                if (gradeId > 0)
                {
                    sql.AppendFormat(" and a.GradeId={0}", gradeId);
                }
                if (states >= 0)
                {
                    sql.AppendFormat(" and a.States={0}", states);
                }
                result = context.Database.SqlQuery<RegisterView>(sql.ToString()).ToList();




            }

            return result;
        }

        public tb_Register GetRegisterModel(int id)
        {
            tb_Register result = null;
            using (SchoolContext context = new SchoolContext())
            {
                result = context.tb_Register.FirstOrDefault(x => x.Id == id);
            }
            return result;
        }

        public tb_student GetStudentModel(int id)
        {
            tb_student result = null;
            using (SchoolContext context = new SchoolContext())
            {
                result = context.tb_student.FirstOrDefault(x => x.Id == id);
            }
            return result;
        }

        public int DeleteReg(int regId)
        {
            int result = 0;
            using (SchoolContext context = new SchoolContext())
            {
                context.tb_Register.Remove(context.tb_Register.FirstOrDefault(x => x.Id == regId));
                result = context.SaveChanges();
            }
            return result;

        }
    }
}
