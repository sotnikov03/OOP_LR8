using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OOP_LR8.Matrix;
using System.Windows;
using System.Windows.Controls;

namespace OOP_LR8
{
    public class SumObserver : IMatrixObserver
    {
        private readonly TextBox _resultDisplay;

        public SumObserver(TextBox resultDisplay)
        {
            _resultDisplay = resultDisplay;
        }

        public void Update(int[,] matrix)
        {
            int sum = 0;
            foreach (var value in matrix)
            {
                sum += value; // Складываем все элементы матрицы
            }

            
            _resultDisplay.Text = $"Сумма элементов матрицы: {sum}\n"; 
        }
    }


}
