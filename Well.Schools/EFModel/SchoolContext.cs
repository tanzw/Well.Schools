using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Well.Schools.EFModel
{

    public class SchoolContext : DbContext
    {
        public DbSet<tb_grade> tb_grade { get; set; }
        public DbSet<tb_course> tb_course { get; set; }

        public DbSet<tb_student> tb_student { get; set; }

        public DbSet<tb_Register> tb_Register { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var grade1 = new tb_grade { Id = 1, Name = "幼儿" };
            modelBuilder.Entity<tb_grade>().HasData(
             grade1,
                new tb_grade { Id = 2, Name = "学前" },
                new tb_grade { Id = 3, Name = "一年级" },
                new tb_grade { Id = 4, Name = "二年级" },
                new tb_grade { Id = 5, Name = "三年级" },
                new tb_grade { Id = 6, Name = "四年级" },
                new tb_grade { Id = 7, Name = "五年级" },
                new tb_grade { Id = 8, Name = "六年级" }
               );
            var c = new tb_course { Id = 1, Name = "春季" };
            modelBuilder.Entity<tb_course>().HasData(
              c,
                new tb_course { Id = 2, Name = "秋季" },
                new tb_course { Id = 3, Name = "全年" }
            );

            modelBuilder.Entity<tb_student>().HasData(new tb_student()
            {
                Id = 10001,
                Address = "杭州市文三路XXX号",
                Contact = "13888888888",
                Description = "测试说明",
                Name = "张三",
                RegisterList = new List<tb_Register>() {
                     new tb_Register(){  Id=1, Course=c, CreateAt=DateTime.Now, Grade=grade1, Money=100, States=1, Year=2018 }

                },
                Sex = 1
            });
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=School.db");
        }
    }

    public class tb_grade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }

    public class tb_course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }

    public class tb_student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Sex { get; set; }

        public string Address { get; set; }

        public string Contact { get; set; }

        public string Description { get; set; }

        public ICollection<tb_Register> RegisterList { get; set; }
    }

    public class tb_Register
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("StudentId")]
        public tb_student Student { get; set; }

        public tb_grade Grade { get; set; }

        public tb_course Course { get; set; }

        public decimal Money { get; set; }

        public int Year { get; set; }

        public int States { get; set; }

        public DateTime CreateAt { get; set; }

    }
}
