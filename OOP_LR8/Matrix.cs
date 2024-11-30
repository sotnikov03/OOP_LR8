using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace OOP_LR8
{
    public class Matrix
    {
        private int[,] _data;
        private readonly List<IMatrixObserver> _observers = new();

        public void AddObserver(IMatrixObserver observer)
        {
            _observers.Add(observer);
        }

        public void Generate(int size, IGenerator generator)
        {
            _data = generator.GenerateMatrix(size);
            NotifyObservers();
        }

        public void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Update(_data);
            }
        }

        public int[,] GetMatrix()
        {
            return _data;
        }
    }
}
