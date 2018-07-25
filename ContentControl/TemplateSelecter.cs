using ContentControl.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
namespace ContentControl
{
    class TemplateSelecter : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;
            if (item == null)
                return null;
            if (item.GetType()==typeof(VM1))
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
