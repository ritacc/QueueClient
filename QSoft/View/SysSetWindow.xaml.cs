using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using System.Collections.ObjectModel;

namespace QSoft.View
{
    /// <summary>
    /// SysSetWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SysSetWindow : MetroWindow
    {

        public ObservableCollection<Student> ListStu { get; set; }
        public SysSetWindow()
        {
            InitializeComponent();


            ListStu = new ObservableCollection<Student>();
            ListStu.Add(new Student() { Name = "MM" });
            ListStu.Add(new Student() { Name = "MM1" });
            this.DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ListStu.Add(new Student() { Name = "MM1" });
        }
    }
    public class Student
    {
        public string Name { get; set; }
        public List<CliassID> ChildItems
        {
            get
            {
                List<CliassID> listC = new List<CliassID>();
                listC.Add(new CliassID() { ID = Guid.NewGuid().ToString() });
                listC.Add(new CliassID() { ID = Guid.NewGuid().ToString() });
                return listC;
            }
        }
    }

    public class CliassID
    {
        public string ID { get; set; }
    }
}
