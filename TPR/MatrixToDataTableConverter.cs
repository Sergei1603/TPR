using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace TPR
{
    class MatrixToDataTableConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var list = value as List<List<double>>;
            DataTable dataTable = new DataTable();

            // Определяем количество строк и столбцов в матрице
            int rows = list.Count();
            int cols = list.Count();

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
                        row[j] = list[i][j - 1];
                    }
                }
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
