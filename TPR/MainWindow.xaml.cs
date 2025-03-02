using Microsoft.Msagl.GraphViewerGdi;
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

           var viewModel = new MarkModelViewModel();
            var graphViewer = new GViewer();
            graphViewer.Graph = viewModel.Graph;
            DataContext = viewModel;
            // Встраиваем GraphViewer в WindowsFormsHost
            windowsFormsHost.Child = graphViewer;

            viewModel.GraphUpdated += (sender, args) =>
            {
                var graphViewer = new GViewer();
                graphViewer.Graph = viewModel.Graph;

                // Встраиваем GraphViewer в WindowsFormsHost
                windowsFormsHost.Child = graphViewer;
            };
        }
    }
}