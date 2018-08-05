using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Well.Schools.Common
{
    public class EventHelper
    {
        public static void TextBox_FilterString_KeyPress(object sender, KeyPressEventArgs e)
        {
            var txt = sender as TextBox;
            if (e.KeyChar == '.' && txt.Text.IndexOf(".") != -1)
            {
                e.Handled = true;
            }
            if (!((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == '.' || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }
    }
}
