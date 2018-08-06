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
        DataService service = new DataService();
        int _studentId = 0;
        int _regId = 0;
        public fmStudent()
        {
            InitializeComponent();
            this.SetDefaultSetting();
            cbxCourse.SetDefaultSetting();
            cbxGrade.SetDefaultSetting();
            cbxYear.SetDefaultSetting();
            cbxStates.SetDefaultSetting();

            ControlBindDataSource.BindCourse(cbxCourse);
            ControlBindDataSource.BindGrade(cbxGrade);
            ControlBindDataSource.BindYear(cbxYear, false, 1);
            ControlBindDataSource.BindStates(cbxStates);

            txtMoney.KeyPress += new KeyPressEventHandler(EventHelper.TextBox_FilterString_KeyPress);
        }

        public fmStudent(int regId) : this()
        {
            BindValue(regId);
        }

        private void BindValue(int regId)
        {
            _regId = regId;
            var result = service.GetRegisterModel(regId);

            if (result != null)
            {
                _studentId = result.StudentId;

                result.Student = service.GetStudentModel(result.StudentId);
                txtAddress.Text = result.Student.Address;
                txtMoney.Text = result.Money.ToString();
                txtPhone.Text = result.Student.Contact;
                txtRemarks.Text = result.Student.Description;
                txtStudentName.Text = result.Student.Name;
                if (result.Student.Sex == 1)
                {
                    radioButton1.Checked = true;
                    radioButton2.Checked = false;
                }
                else
                {
                    radioButton1.Checked = false;
                    radioButton2.Checked = true;
                }

                cbxCourse.SelectedValue = result.CourseId;
                cbxGrade.SelectedValue = result.GradeId;
                cbxStates.SelectedValue = result.States;
                cbxYear.SelectedValue = result.Year;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStudentName.Text))
            {
                MessageBox.Show("请输入学生姓名！");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtMoney.Text))
            {
                MessageBox.Show("请输入金额！");
                return;
            }
            if (cbxYear.SelectedValue.ToInt() == 0)
            {
                MessageBox.Show("请选择入学年份！");
                return;
            }
            if (cbxGrade.SelectedValue.ToInt() == 0)
            {
                MessageBox.Show("请选择入学年级！");
                return;
            }
            if (cbxCourse.SelectedValue.ToInt() == 0)
            {
                MessageBox.Show("请选择入学班类！");
                return;
            }
            if (cbxStates.SelectedValue.ToInt() == -1)
            {
                MessageBox.Show("请选择缴费状态！");
                return;
            }

            try
            {
                tb_student student = new tb_student();
                student.Id = _studentId;
                student.Address = txtAddress.Text.Trim();
                student.Contact = txtPhone.Text.Trim();
                student.Description = txtRemarks.Text.Trim();
                student.Name = txtStudentName.Text.Trim();
                student.Sex = radioButton1.Checked ? 1 : 0;

                tb_Register reg = new tb_Register();
                reg.Id = _regId;
                reg.CourseId = cbxCourse.SelectedValue.ToInt();
                reg.CreateAt = DateTime.Now;
                reg.GradeId = cbxGrade.SelectedValue.ToInt();
                reg.Money = txtMoney.Text.ToToDecimal();
                reg.States = cbxStates.SelectedValue.ToInt();
                reg.Year = cbxYear.SelectedValue.ToInt();


                if (service.InsertRegister(student, reg) > 0)
                {

                    MessageBox.Show("成功");
                    DialogResult = DialogResult.OK;
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

        private void txtMoney_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
