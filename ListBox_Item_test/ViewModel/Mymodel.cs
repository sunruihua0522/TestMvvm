using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ListBox_Item_test.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ListBox_Item_test.ViewModel
{
    public class Mymodel : ViewModelBase
    {
        public ObservableCollection<Student> StuList { set; get; }
        public Mymodel()
        {
            StuList = new ObservableCollection<Student>()
            {
                new Student() { Name = "Ricky",Age = 32,ID = "111111",Index=0},
                new Student() { Name = "Tony",Age = 27,ID = "22222",Index=1},
                new Student() { Name = "Lucy",Age = 10,ID = "33333",Index=2},
                new Student() { Name = "Lance",Age = 36,ID = "4444",Index=3},
                new Student() { Name = "Oliu",Age = 76,ID = "5555",Index=4},
                new Student() { Name = "Lance",Age = 90,ID = "6666",Index=5}

            };
        }
        public RelayCommand<int> StartTast {
            get {
                return new RelayCommand<int>(
                    i => {
                        Task t = new Task(()=> {
                            if (StuList[i].Age < 50)
                            {
                                while (++StuList[i].Age < 100)
                                {
                                    Console.WriteLine(StuList[i].Age);
                                    Thread.Sleep(100);
                                }
                            }
                            else
                            {
                                while (--StuList[i].Age>1)
                                {
                                    Console.WriteLine(StuList[i].Age);
                                    Thread.Sleep(100);
                                }
                            }
                        });
                        t.Start();
                    }
                    );
            }
        }
    }
}
