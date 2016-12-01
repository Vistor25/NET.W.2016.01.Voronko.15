using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1New
{
    public class SquareMatrix<T>:AbstarctMatrix<T> where T: struct
    {
        private readonly T[,] _data;

        public int Size => _data.GetLength(0);

        public SquareMatrix(T[,] source)
        {
            if (source.GetLength(0) != source.GetLength(1))
            {
                throw new ArgumentException("Can't create the matrix from provided array.");
            }

            _data = source;
        }

        public event Action<T, T, int, int> ElementChanged;

        public T this[int i, int j]
        {
            get
            {
                return _data[i, j];
            }
            set
            {
                var previousValue = _data[i, j];
                _data[i, j] = value;
                OnElementChanged(previousValue, value, i, j);
            }
        }

        protected virtual void OnElementChanged(T arg1, T arg2, int arg3,
            int arg4)
        {
            ElementChanged?.Invoke(arg1, arg2, arg3, arg4);
        }

       

        public void Accept(IVisitor<T> visitor, SquareMatrix<T> other)
        {
            visitor.Visit((dynamic) this, other);
        }

        protected override T GetElement(int i, int j)
        {
            throw new NotImplementedException();
        }

        protected override void SetElement(T element, int i, int j)
        {
            throw new NotImplementedException();
        }
    }
}
