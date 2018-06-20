using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ContentControl.Model;
namespace ContentControl
{
    class TemplateSelecter : DataTemplateSelector
    {
        public DataTemplate UI_Data { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;
            MyModel bSelectUi1 = item as MyModel;
            if (bSelectUi1.SelectUi1)
            {
                return (DataTemplate)element.TryFindResource("UI1");
            }
            else
            {
                return (DataTemplate)element.TryFindResource("UI2");
            }
        }
    }
}
