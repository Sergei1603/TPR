using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TPR
{
    class MarkModelViewModel : INotifyPropertyChanged
    {
        private List<Strategy> strategies;
        public MarkModel model;


        private List<Strategy> strategies;
        public int StrategyCount
        { 
            get => model.StrategyCount;
            set
            {
                model.StrategyCount = value;
                OnPropertyChanged(nameof(MarkModel.StrategyCount));
                UpdateMatrix(value);
            }
        }

        public void UpdateMatrix(int strategyCount)
        {
            var tmp1 =new List<List<double>>();
            for (int i = 0; i < strategyCount; i++)
            {
                tmp1.Add(new List<double>(strategyCount));
                for (int j = 0; j < strategyCount; j++)
                {
                    tmp1[i].Add(0);
                }
       //         var tmp = new List<double>(strategyCount);
            }


            for (int i = 0; i < strategyCount; i++)
            {
                var strat = new Strategy();
                strat.Probabilites = new List<List<double>>(tmp1);
                strat.Profit = new List<List<double>>(tmp1);
                strategies.Add(strat);
            }
        }
        public int StateCount
        {
            get => model.StateCount;
            set
            {
                model.StateCount = value;
                OnPropertyChanged(nameof(MarkModel.StateCount));
            }
        }
        public int Steps
        {
            get => model.Steps;
            set
            {
                model.Steps = value;
                OnPropertyChanged(nameof(MarkModel.Steps));
            }
        }

        public int curentStrategy { get; set; } = 0;

        private DataTable _dataTable;
        public DataTable MyDataTable
        {
            get
            {
                return _dataTable;
 //               return ConvertMatrixToDataTable(strategies[curentStrategy].Profit);
            }
            set
            {
                _dataTable = value;
 //               ConvertMatrixToDataTable(strategies[curentStrategy].Profit = _dataTable.;
            }
        }

        private DataTable ConvertMatrixToDataTable(List<List<double>> matrix)
        {
            DataTable dataTable = new DataTable();

            // Определяем количество строк и столбцов в матрице
            int rows = matrix.Count();
            int cols = matrix.Count();

            // Создаем столбцы в DataTable
            for (int i = 0; i < cols; i++)
            {
                dataTable.Columns.Add($"Column {i + 1}", typeof(int));
            }

            // Заполняем DataTable данными из матрицы
            for (int i = 0; i < rows; i++)
            {
                DataRow row = dataTable.NewRow();
                for (int j = 0; j < cols; j++)
                {
                    row[j] = matrix[i][j];
                }
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
        public int curentStrategy { get; set; } = 0;
        public event PropertyChangedEventHandler? PropertyChanged;

        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public MarkModelViewModel()
        {
            this.model = new MarkModel();
            strategies = new List<Strategy>();
            UpdateMatrix(4);
            MyDataTable = ConvertMatrixToDataTable(strategies[curentStrategy].Profit);
            //           LoadService.Save(strategies[0].Probabilites);
            //          strategies[0].Profit = LoadService.Load();
        }

        private RelayCommand<object> _updateCommand;
        public RelayCommand<object> UpdateCommand
        {
            get
            {
                return _updateCommand ??
                  (_updateCommand = new RelayCommand<object>(Ubdatecom));
            }
        }

        public void Ubdatecom(object obj)
        {
            var table = obj as DataTable;
            MyDataTable = table;
        }
    }
}
