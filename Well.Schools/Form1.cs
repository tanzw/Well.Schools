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

namespace Well.Schools
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        }

        private void 新增学生ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 学生列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }



        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindRegisterList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.SetDefaultSetting();
            this.ShowInTaskbar = true;
            cbxCourse.SetDefaultSetting();
            cbxGrade.SetDefaultSetting();
            cbxYear.SetDefaultSetting();
            cbxStates.SetDefaultSetting();
            dataGridView1.SetDefaultSetting();
            dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            ControlBindDataSource.BindCourse(cbxCourse);
            ControlBindDataSource.BindGrade(cbxGrade);
            ControlBindDataSource.BindYear(cbxYear);
            ControlBindDataSource.BindStates(cbxStates);

            BindRegisterList();
        }

        private void BindRegisterList()
        {
            try
            {
                Data.DataService service = new Data.DataService();
                var studentId = !string.IsNullOrWhiteSpace(txtStudentId.Text) ? txtStudentId.Text.TryToInt() : 0;
                var studentName = txtStudentName.Text.Trim();
                var cid = cbxCourse.SelectedValue.ToInt();
                var gid = cbxGrade.SelectedValue.ToInt();
                var year = cbxYear.SelectedValue.ToInt();
                var states = cbxStates.SelectedValue.ToInt();
                dataGridView1.DataSource = service.QueryRegList(studentId, studentName, year, cid, gid, states);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }


        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            fmStudent fm = new fmStudent();
            if (fm.ShowDialog() == DialogResult.OK)
            {
                BindRegisterList();
            }

        }

        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sd = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            fmStudent fm = new fmStudent(sd.ToInt());
            if (fm.ShowDialog() == DialogResult.OK)
            {
                BindRegisterList();
            }
        }

        private void 查看学生ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sd = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            if (MessageBox.Show("确认提醒", "确认删除,删除后数据不可恢复?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                Data.DataService service = new Data.DataService();
                if (service.DeleteReg(sd.ToInt()) > 0)
                {
                    MessageBox.Show("删除成功");
                    BindRegisterList();
                }
                else
                {
                    MessageBox.Show("删除失败");
                }
            }


        }
    }
}
