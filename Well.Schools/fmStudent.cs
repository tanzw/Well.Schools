using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Well.Schools.Common;
using Well.Schools.Data;
using Well.Schools.EFModel;
using Well.Schools.ViewModel;


namespace Well.Schools
{
    public partial class fmStudent : Form
    {
        public fmStudent()
        {
            InitializeComponent();
            this.SetDefaultSetting();
            cbxCourse.SetDefaultSetting();
            cbxGrade.SetDefaultSetting();
            cbxYear.SetDefaultSetting();
            cbxStates.SetDefaultSetting();
            dataGridView1.SetDefaultSetting();
            ControlBindDataSource.BindCourse(cbxCourse);
            ControlBindDataSource.BindGrade(cbxGrade);
            ControlBindDataSource.BindYear(cbxYear, false, 1);
            ControlBindDataSource.BindStates(cbxStates);
        }

        public fmStudent(int a) : this()
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                tb_student student = new tb_student();
                student.Address = txtAddress.Text.Trim();
                student.Contact = txtPhone.Text.Trim();
                student.Description = txtRemarks.Text.Trim();
                student.Name = txtStudentName.Text.Trim();
                student.Sex = radioButton1.Checked ? 1 : 0;

                tb_Register reg = new tb_Register();
                //reg.CourseId = cbxCourse.SelectedValue.TryToInt(-1);
                reg.CreateAt = DateTime.Now;
                //reg.GradeId = cbxGrade.SelectedValue.ToInt();
                reg.Money = txtMoney.Text.ToToDecimal();
                reg.States = cbxStates.SelectedValue.ToInt();
                reg.Year = cbxYear.SelectedValue.ToInt();

                DataService service = new DataService();
                if (service.InsertRegister(student, reg) > 0)
                {
                    MessageBox.Show("成功");
                }
                else
                {
                    MessageBox.Show("失败");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("失败");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fmStudent_Load(object sender, EventArgs e)
        {

        }
    }
}
