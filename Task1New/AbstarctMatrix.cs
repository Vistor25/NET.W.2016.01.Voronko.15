using System;

namespace Task1New
{
    public abstract class AbstarctMatrix<T>
    {
        private int Size;

        protected abstract T GetElement(int i, int j);
        protected abstract void SetElement(T element, int i, int j);

    
        public event Action<T, T, int, int> ElementChanged;


        public T this[int i, int j]
        {
            get
            {
                ValidateIndexes(i, j);
                return GetElement(i, j);
            }
            set
            {
                var previousValue = GetElement(i, j);
                SetElement(value, i, j);
                OnElementChanged(previousValue, value, i, j);
            }
        }
        private void ValidateIndexes(int i, int j)
        {
            if (i < 0 || i >= Size) throw new ArgumentException("Wrong index");
            if (j < 0 || j >= Size) throw new ArgumentException("Wrong index");

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