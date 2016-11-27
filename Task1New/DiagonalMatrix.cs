using System;

namespace Task1New
{
    public class DiagonalMatrix<T> : SquareMatrix<T>
        where T : struct
    {
        public DiagonalMatrix(T[,] source) : base(source)
        {
            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    if (i != j && !this[i, j].Equals(default(T)))
                    {
                        throw new ArgumentException("You can't create a matrix from such array.");
                    }
                }
            }
        }
    }
}