using System;

namespace Task1New
{
    public class AdditionVisitor<T> : IVisitor<T> where T : struct
    {
        public SquareMatrix<T> Visit(SquareMatrix<T> first, SquareMatrix<T> second)
        {
        if (first.Size != second.Size)
            {
                throw new ArgumentException("You can't add matrices of differnt dimensions.");
            }

            var source = new T[first.Size, first.Size];
            for (var i = 0; i < first.Size; i++)
            {
                for (var j = 0; j < first.Size; j++)
                {
                    source[i, j] = (dynamic)first[i, j] + (second[i, j]);
                }

            }
            return new SquareMatrix<T>(source);
        }
    
    }
}