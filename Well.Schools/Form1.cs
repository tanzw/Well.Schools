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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            //标签背景填充颜色
            SolidBrush BackBrush = new SolidBrush(Color.Yellow);
            //标签文字填充颜色
            SolidBrush FrontBrush = new SolidBrush(Color.Black);
            StringFormat StringF = new StringFormat();
            //设置文字对齐方式
            StringF.Alignment = StringAlignment.Center;
            StringF.LineAlignment = StringAlignment.Center;

            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                //获取标签头工作区域
                Rectangle Rec = tabControl1.GetTabRect(i);
                //绘制标签头背景颜色
                e.Graphics.FillRectangle(BackBrush, Rec);
                //绘制标签头文字
                e.Graphics.DrawString(tabControl1.TabPages[i].Text, new Font("宋体", 12), FrontBrush, Rec, StringF);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.SetDefaultSetting();
            cbxCourse.SetDefaultSetting();
            cbxGrade.SetDefaultSetting();
            cbxYear.SetDefaultSetting();
            cbxStates.SetDefaultSetting();
            dataGridView1.SetDefaultSetting();
            dataGridView2.SetDefaultSetting();
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
                dataGridView1.DataSource = service.QueryRegList();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }


        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            fmStudent fm = new fmStudent(1);
            fm.ShowDialog();
        }
    }
}
