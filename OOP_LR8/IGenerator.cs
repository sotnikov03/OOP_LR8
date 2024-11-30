using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LR8
{
    public interface IGenerator
    {
        int[,] GenerateMatrix(int size);
    }

    public interface IMatrixObserver
    {
        void Update(int[,] matrix);
    }

    public class ZeroGenerator : IGenerator
    {
        public int[,] GenerateMatrix(int size)
        {
            return new int[size, size]; // Матрица из нулей
        }
    }

    public class IdentityGenerator : IGenerator
    {
        public int[,] GenerateMatrix(int size)
        {
            var matrix = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                matrix[i, i] = 1;
            }
            return matrix;
        }
    }

    public class SpiralGenerator : IGenerator
    {
        public int[,] GenerateMatrix(int size)
        {
            var matrix = new int[size, size];
            int value = 1, minRow = 0, maxRow = size - 1, minCol = 0, maxCol = size - 1;

            while (value <= size * size)
            {
                for (int col = minCol; col <= maxCol; col++) matrix[minRow, col] = value++;
                minRow++;
                for (int row = minRow; row <= maxRow; row++) matrix[row, maxCol] = value++;
                maxCol--;
                for (int col = maxCol; col >= minCol; col--) matrix[maxRow, col] = value++;
                maxRow--;
                for (int row = maxRow; row >= minRow; row--) matrix[row, minCol] = value++;
                minCol++;
            }

            return matrix;
        }
    }
}
