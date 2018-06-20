using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataTableBinding
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public DataTable dt = new DataTable();
        public DataTable Dt { get { return dt; } set { dt = value; } }
        private string[] name = new string[] {"Tom","张三","李四","Lucy","Tony","aaa","ccc","ddd","eeee","ttttt" };
        public MainWindow()
        {
            dt.Columns.Add(new DataColumn("ID"));
            dt.Columns.Add(new DataColumn("Name"));
            dt.Columns.Add(new DataColumn("Age"));
            
            for (int i = 0; i < 10; i++)
            {
                DataRow dr = dt.NewRow();
                dr["ID"] = i;
                dr["Name"] = name[i];
                dr["Age"] = i*3;
                dt.Rows.Add(dr);
            }

            InitializeComponent();
        }
    }
}
