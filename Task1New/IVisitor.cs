namespace Task1New
{
    public interface IVisitor<T> where T:struct
    {
        SquareMatrix<T> Visit(SquareMatrix<T> first, SquareMatrix<T> second);

    }
}