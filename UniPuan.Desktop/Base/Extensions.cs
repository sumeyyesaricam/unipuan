using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniPuan.Desktop
{
    public static class WinFormsControlExtensions
    {
        public static void SelectValue<T>(this ComboBox cb)
        {
            if (cb.SelectedIndex > -1 && cb.SelectedValue != "0")
            {
                T entity = ((T)cb.SelectedItem);
            }
        }
    }
}
