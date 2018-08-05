using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Well.Schools.Common
{
    public static class ControlSettingExtensions
    {
        public static void SetDefaultSetting(this Form fm)
        {
            fm.StartPosition = FormStartPosition.CenterParent;
            fm.ShowIcon = true;
            fm.ShowInTaskbar = false;
        }

        public static void SetDefaultSetting(this ComboBox cbx)
        {
            cbx.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public static void SetDefaultSetting(this DataGridView dg)
        {
            dg.AutoGenerateColumns = false;
        }
    }
}
