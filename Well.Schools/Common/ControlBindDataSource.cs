using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Well.Schools.Common
{
    public class ControlBindDataSource
    {
        public static void BindGrade(System.Windows.Forms.ComboBox cbx, bool isDefault = true)
        {
            using (Schools.EFModel.SchoolContext context = new EFModel.SchoolContext())
            {
                var data = context.tb_grade.ToList();
                if (isDefault)
                {
                    data.Insert(0, new EFModel.tb_grade() { Id = 0, Name = "请选择年级" });
                }
                cbx.DataSource = data;
                cbx.DisplayMember = "Name";
                cbx.ValueMember = "Id";
            }
        }

        public static void BindCourse(System.Windows.Forms.ComboBox cbx, bool isDefault = true)
        {
            using (Schools.EFModel.SchoolContext context = new EFModel.SchoolContext())
            {
                var data = context.tb_course.ToList();
                if (isDefault)
                {
                    data.Insert(0, new EFModel.tb_course() { Id = 0, Name = "请选择班类" });
                }
                cbx.DataSource = data;
                cbx.DisplayMember = "Name";
                cbx.ValueMember = "Id";
            }
        }

        public static void BindYear(System.Windows.Forms.ComboBox cbx, bool isDefault = true, int selectIndex = 0)
        {
            List<KeyValue<int, String>> data = new List<KeyValue<int, string>>();
            if (isDefault)
            {
                data.Add(new KeyValue<int, string>() { Key = 0, Value = "请选择年份" });
            }

            data.Add(new KeyValue<int, string>() { Key = DateTime.Now.Year - 1, Value = (DateTime.Now.Year - 1).ToString() });
            data.Add(new KeyValue<int, string>() { Key = DateTime.Now.Year, Value = (DateTime.Now.Year).ToString() });
            data.Add(new KeyValue<int, string>() { Key = DateTime.Now.Year + 1, Value = (DateTime.Now.Year + 1).ToString() });
            data.Add(new KeyValue<int, string>() { Key = DateTime.Now.Year + 2, Value = (DateTime.Now.Year + 2).ToString() });

            cbx.DataSource = data;
            cbx.DisplayMember = "Value";
            cbx.ValueMember = "Key";

            cbx.SelectedIndex = selectIndex;
        }

        public static void BindStates(System.Windows.Forms.ComboBox cbx, bool isDefault = true)
        {
            List<KeyValue<int, String>> data = new List<KeyValue<int, string>>();
            if (isDefault)
            {
                data.Add(new KeyValue<int, string>() { Key = 0, Value = "请选择" });
            }
            data.Add(new KeyValue<int, string>() { Key = (int)EFModel.States.已缴, Value = EFModel.States.已缴.ToString() });
            data.Add(new KeyValue<int, string>() { Key = (int)EFModel.States.未缴, Value = EFModel.States.未缴.ToString() });
            cbx.DataSource = data;
            cbx.DisplayMember = "Value";
            cbx.ValueMember = "Key";
        }
    }

    public class KeyValue<K, V>
    {
        public K Key { get; set; }

        public V Value { get; set; }
    }
}
