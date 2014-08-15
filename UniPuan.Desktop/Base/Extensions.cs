using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniPuan.Desktop
{
    public static class WinFormsControlExtensions
    {
        
        public static E SelectedFunc<T, E>(this ComboBox cb, Expression<Func<T, E>> t)
        {
            if (cb.SelectedIndex > -1 && cb.SelectedValue != "0")
            {
                var member = (MemberExpression)t.Body;
                string propertyName = member.Member.Name;
                var value = t.Compile();
                E val = value.Invoke((T)cb.SelectedItem);
                return val;
            }
            return default(E);
        }
        private static string PropertyName<E>(Expression<Func<E>> prop)
        {
            var expression = (MemberExpression)prop.Body;
            var propertyName = expression.Member.Name;
            return propertyName;
        }
        
    }
}
