using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MahAppsMetroCustomDialogExample
{
    public class MainViewModel
    {
        public ExampleData Data{ get; set; }
        public ICommand ValidateCommand { get; set; }
        public BindingList<ExampleData> ExampleDataList { get; set; }
        public MainViewModel()
        {
            ValidateCommand = new RelayCommand(Validate);
            Data = new ExampleData();
            ExampleDataList = new BindingList<ExampleData>();
            foreach (var i in Enumerable.Range(0, 10))
            {
                ExampleDataList.Add(new ExampleData()
                {
                    Id = i + 1,
                    Amount = 1 + (i % 3),
                    Name = "Item" + i,
                    Email = $"test{i}.example.com",
                    Price = (decimal)((i + 1) * 1.99)
                });
            }
        }

        private void Validate()
        {

            Data.Validate();
            foreach (var exampleData in ExampleDataList)
            {
                exampleData.Validate();
            }
        }
    }
}
