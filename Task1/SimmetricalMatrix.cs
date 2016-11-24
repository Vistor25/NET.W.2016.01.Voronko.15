using System;

namespace Matrices
{
    public class SimmetricalMatrix<T> : SquareMatrix<T>
         where T : IAddiable<T>, IEquatable<T>
    {
        public SimmetricalMatrix(T[,] source) : base(source)
        {
            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    if (i != j && !this[i, j].Equals(this[j, i]))
                    {
                        throw new ArgumentException("You can't create a matrix from such array.");
                    }
                }
            }
        }
    }
}