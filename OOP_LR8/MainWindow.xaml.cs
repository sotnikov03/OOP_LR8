using System;
using System.Collections.Generic;
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


namespace OOP_LR8
{
    
    public partial class MainWindow : Window
    {
        private readonly Matrix _matrix = new();
        private readonly List<IGenerator> _generators = new()
        {
            new ZeroGenerator(),
            new IdentityGenerator(),
            new SpiralGenerator()
        };

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }
        public MainWindow()
        {
            InitializeComponent();

            _matrix = new Matrix();

            _matrix.AddObserver(new SumObserver(ResultDisplay));
            _matrix.AddObserver(new ProductObserver(ResultDisplay));

            
            StrategySelector.ItemsSource = new List<string> { "Zero Generator", "Identity Generator", "Spiral Generator" };
            StrategySelector.SelectedIndex = 0;
        }



        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedGenerator = _generators[StrategySelector.SelectedIndex]; 
            _matrix.Generate(5, selectedGenerator); // Генерация матрицы 5x5

            
            DisplayMatrix(_matrix.GetMatrix());
        }


        private void DisplayMatrix(int[,] matrix)
        {
            MatrixDisplay.Text = string.Join("\n", Enumerable.Range(0, matrix.GetLength(0))
                .Select(row => string.Join("\t", Enumerable.Range(0, matrix.GetLength(1))
                .Select(col => matrix[row, col]))));
        }
    }
}
