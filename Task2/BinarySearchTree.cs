using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class BinarySearchTree<T>:IEnumerable<T>
    {
        private Node<T> root;
        private IComparer<T> comparer;

        class Node<T>
        {
            public T Value { get; set; }
            public Node<T> leftNode;
            public Node<T> rightNode;
            public Node(T element)
            {
                Value = element;
            }

        }

        public void Add(T element)
        {
            Node<T> current = root;
            while (!ReferenceEquals(current, null))
            {
                if (comparer.Compare(current.Value, element) > 0)
                {
                    current = current.rightNode;}
                if(comparer.Compare(current.Value, element) == 0) { throw new ArgumentException("There is already such element!");}
                if (comparer.Compare(current.Value, element) < 0)
                {
                    current = current.leftNode;
                }
            }
            current = new Node<T>(element); 
        }

        public bool Contains(T element)
        {
            Node<T> current = root;
            while (!ReferenceEquals(current, null))
            {
                if (comparer.Compare(current.Value, element) > 0)
                {
                    current = current.rightNode;
                }
                if (comparer.Compare(current.Value, element) == 0) {return true; }
                if (comparer.Compare(current.Value, element) < 0)
                {
                    current = current.leftNode;
                }
            }
            return false;
        }

        private IEnumerable<T> PreOrder(Node<T> node)
        {
            if(ReferenceEquals(node, null)) { yield break;}
            yield return node.Value;
            foreach (var element in PreOrder(node.leftNode))
            {
                yield return element;
            }
            foreach (var element in PreOrder(node.rightNode))
            {
                yield return element;
            }
            
        }

        private IEnumerable<T> InOrder(Node<T> node)
        {
            if (ReferenceEquals(node, null)) { yield break; }
            foreach (var element in InOrder(node.leftNode))
            {
                yield return element;
            }
            yield return node.Value;
            foreach (var element in InOrder(node.rightNode))
            {
                yield return element;
            }
        }

        private IEnumerable<T> PostOrder(Node<T> node)
        {
            if (ReferenceEquals(node, null)) { yield break; }
            foreach (var element in PostOrder(node.leftNode))
            {
                yield return element;
            }
            foreach (var element in PostOrder(node.rightNode))
            {
                yield return element;
            }
            yield return node.Value;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return PreOrder(root).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
           return GetEnumerator();
        }
    }
}
