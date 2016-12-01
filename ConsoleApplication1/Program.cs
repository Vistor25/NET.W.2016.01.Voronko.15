using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Comparer<int> comparer = Comparer<int>.Default;
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.comparer = comparer;
            for (int i = 0; i < 5; i++)
            {
                Random rn = new Random();
                tree.Add(rn.Next(1,100));
            }
            int[] array = tree.PreOrder().ToArray();
            for(int i = 0; i<array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
            Console.ReadKey();
        }
    }
}
