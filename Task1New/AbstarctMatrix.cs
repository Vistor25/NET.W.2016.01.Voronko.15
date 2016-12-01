using System;

namespace Task1New
{
    public class AbstarctMatrix<T>
    {
        private int dimension;

        public int Size => _data.GetLength(0);

    
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
            visitor.Visit((dynamic)this, other);
        }
    }
}
}