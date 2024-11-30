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
    public class ProductObserver : IMatrixObserver
    {
        private readonly TextBox _resultDisplay;

        public ProductObserver(TextBox resultDisplay)
        {
            _resultDisplay = resultDisplay;
        }

        public void Update(int[,] matrix)
        {
            long product = 1;
            bool hasNonZero = false;

            foreach (var value in matrix)
            {
                if (value != 0)
                {
                    product *= value;
                    hasNonZero = true;
                }
            }

            if (!hasNonZero)
            {
                product = 0;
            }

            
            _resultDisplay.Text += $"Произведение элементов матрицы: {product}"; 
        }
    }
}
