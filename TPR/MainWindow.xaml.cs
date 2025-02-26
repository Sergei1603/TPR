using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TPR
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            // Проверяем, что редактирование завершено
            if (e.EditAction == DataGridEditAction.Commit)
            {
                // Получаем измененную ячейку
                var editedCell = e.Column.GetCellContent(e.Row);

                // Получаем новое значение
                if (editedCell is TextBox textBox)
                {
                    string newValue = textBox.Text;

                    MessageBox.Show($"Изменено значение: {newValue}");
                }
            }
        }
    }
}