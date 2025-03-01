using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.Spreadsheet;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace TPR
{
    class MarkModelViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public MarkModel model;

        private List<Tuple<DataTable, DataTable>> DataTablePairs;

        Tuple<DataTable, DataTable> currentDataTablePair;


        private int curentStrategy;

        public int CurrentStrategy
        {
            get
            {
                return this.curentStrategy;
            }
            set
            {
                this.curentStrategy = value;
                this.CurrentDataTablePair = this.DataTablePairs[value - 1];
                this.OnPropertyChanged(nameof(CurrentStrategy));
            }
        }

        public List<int> ListOfStrategies => BuildStrategiesNumbersList();

        public Tuple<DataTable, DataTable> CurrentDataTablePair
        {
            get
            {
                return this.currentDataTablePair;
            }
            set
            {
                this.currentDataTablePair = value;
                this.OnPropertyChanged(nameof(CurrentDataTablePair));
            }
        }

        /// <summary>
        /// количество состояний
        /// </summary>
        public int StateCount
        {
            get => model.StateCount;
            set
            {
                if (value != model.StateCount)
                {
                    this.model.ClearStrats();
                    this.model.UpdateMatrix(this.StrategyCount, value);
                    this.DataTablePairs = this.BuildDataTables(this.model.Strategies);
                    CurrentDataTablePair = this.DataTablePairs.First();
                }
                model.StateCount = value;
                OnPropertyChanged(nameof(MarkModel.StateCount));
            }
        }
        /// <summary>
        /// количество шагов моделирования
        /// </summary>
        public int Steps
        {
            get => model.Steps;
            set
            {
                model.Steps = value;
                OnPropertyChanged(nameof(MarkModel.Steps));
            }
        }

        /// <summary>
        /// количество стратегий
        /// </summary>
        public int StrategyCount
        { 
            get => model.StrategyCount;
            set
            {
                var oldValue = model.StrategyCount;
                if (value < model.StrategyCount)
                {
                    this.CurrentStrategy = ListOfStrategies.FirstOrDefault(0);
                    var count = this.model.Strategies.Count;
                    this.model.RemoveStrats(value, count - value);
                }
                model.StrategyCount = value;

                // добавляем новые пары таблиц, не меняя остальных
                this.model.UpdateMatrix(value - oldValue, this.StateCount);

                this.DataTablePairs = this.BuildDataTables(this.model.Strategies);
                UpdateProperties();
            }
        }

        public void UpdateProperties()
        {
            OnPropertyChanged(nameof(MarkModel.StrategyCount));
            OnPropertyChanged(nameof(MarkModel.StateCount));
            OnPropertyChanged(nameof(ListOfStrategies));
            OnPropertyChanged(nameof(CurrentStrategy));
            OnPropertyChanged(nameof(MarkModel.Steps));
            OnPropertyChanged(nameof(CurrentDataTablePair));
        }

        public bool IsResultVisible { get => isResultVisible;
            set
            {
                isResultVisible = value;
                this.OnPropertyChanged(nameof(IsResultVisible));
            }
        }
        public DataTable ResultTable { get; }

        private bool isResultVisible = false;

        private DelegateCommand countCommand;

        public ICommand CountCommand => countCommand ??= new DelegateCommand(CountProfit);  
        
        private DelegateCommand loadCommand;

        public ICommand LoadExcel => loadCommand ??= new DelegateCommand(LoadExcelHandler);

        private void LoadExcelHandler()
        {
            var service = new LoadService();
            // список матриц вероятностей
            List<List<List<double>>> ProbabilityMatrices = [service.Load()];
            var stateCount = ProbabilityMatrices[0].Count;
            for (int i = 0; i < stateCount; i++)
            {
                ProbabilityMatrices.Add(service.Load((stateCount + 1) * (i + 1), 0));
            }

            var strategyCount = ProbabilityMatrices.Count;
            // список матриц доходов
            List<List<List<double>>> ProfitMatrices = [service.Load(0, stateCount + 1)];
            for (int i = 0; i < stateCount; i++)
            {
                ProfitMatrices.Add(service.Load((stateCount + 1) * (i + 1), stateCount + 1));
            }

            List<Strategy> strats = new List<Strategy>();
            for (int i = 0; i < strategyCount; i++)
            {
                Strategy temp = new Strategy
                { Probabilites = ProbabilityMatrices[i], Profit = ProfitMatrices[i] };
                strats.Add(temp);
            }

            this.model = new MarkModel(strategyCount, stateCount, 3, strats);
            this.curentStrategy = this.ListOfStrategies.First();
            this.DataTablePairs = this.BuildDataTables(this.model.Strategies);
            CurrentDataTablePair = this.DataTablePairs.First();
            UpdateProperties();
        }

        private List<int> BuildStrategiesNumbersList()
        {
            var strats = new List<int>();
            for (int i = 0; i < StrategyCount; i++)
            {
                strats.Add(i + 1);
            }
            return strats;

        }

        private DataTable ConvertMatrixToDataTable(List<List<double>> matrix)
        {
            DataTable dataTable = new DataTable();

            // Определяем количество строк и столбцов в матрице
            int rows = matrix.Count();
            int cols = matrix.Count();

            dataTable.Columns.Add("--", typeof(string));
            // Создаем столбцы в DataTable
            for (int i = 0; i < cols; i++)
            {
                dataTable.Columns.Add($"Состояние {i + 1}", typeof(double));
            }

            // Заполняем DataTable данными из матрицы
            for (int i = 0; i < rows; i++)
            {
                DataRow row = dataTable.NewRow();
                for (int j = 0; j < rows + 1; j++)
                {
                    if (j == 0)
                    {
                        row[j] = $"Состояние {i + 1}";
                    }
                    else
                    {
                        row[j] = matrix[i][j - 1];
                    }
                }
                dataTable.Rows.Add(row);
            }
            return dataTable;
        }

        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public DelegateCommand<object> GridCellChanged { get; set; }
        public MarkModelViewModel()
        {
            this.model = new MarkModel();
            this.curentStrategy = this.ListOfStrategies.First();
            this.DataTablePairs = this.BuildDataTables(this.model.Strategies);
            CurrentDataTablePair = this.DataTablePairs.First();
        }

        private List<Tuple<DataTable, DataTable>> BuildDataTables(List<Strategy> strategies)
        {
            var dataTablePairs = new List<Tuple<DataTable, DataTable>>();
            for (int i = 0; i < strategies.Count; i++)
            {
                var dataTableProb = ConvertMatrixToDataTable(strategies[i].Probabilites);
                var dataTableProfit = ConvertMatrixToDataTable(strategies[i].Profit);
                dataTablePairs.Add(new Tuple<DataTable, DataTable>(dataTableProb, dataTableProfit));
            }
            return dataTablePairs;
        }

        private void CountProfit()
        {
            IsResultVisible = true;

            for (int i = 0; i < this.DataTablePairs.Count; i++)
            {
                var probsTable = this.DataTablePairs[i].Item1;
                var profitsTable = this.DataTablePairs[i].Item2;

                for (int j = 0; j < probsTable.Rows.Count; j++)
                {
                    var probsRow = probsTable.Rows[j].ItemArray.OfType<double>();
                    var profitsRow = profitsTable.Rows[j].ItemArray.OfType<double>();
                    model.Strategies[i].Profit[j] = [.. profitsRow];
                    model.Strategies[i].Probabilites[j] = [.. probsRow];
                }
                var result = this.model.Count();
            }
        }
    }
}
