using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1New
{
    public class SquareMatrix<T>:AbstarctMatrix<T> where T: struct
    {
        private readonly T[] _data;

        public int Size;

        public SquareMatrix(T[,] source)
        {
            if (source.GetLength(0) != source.GetLength(1))
            {
                throw new ArgumentException("Can't create the matrix from provided array.");
            }
            Size = source.GetLength(0);
            _data = new T[Size*Size];
            int count=0;
            for(int i= 0; i<Size; i++)
            {
                for(int j = 0; j < Size; j++)
                {
                    _data[count++] = source[i, j];
                }
            }
        }

       
        public void Accept(IVisitor<T> visitor, SquareMatrix<T> other)
        {
            visitor.Visit((dynamic) this, other);
        }

        protected override T GetElement(int i, int j)
        {
            return _data[i * Size + j];
        }

        protected override void SetElement(T element, int i, int j)
        {
            _data[i* Size +j]= element;
        }
    }
}
