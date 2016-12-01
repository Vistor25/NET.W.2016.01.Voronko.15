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
        public IComparer<T> comparer;

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
        /// <summary>
        /// Creates new BinarySearchTree
        /// </summary>
        /// <param name="elements">Some ienumerable elements</param>
        /// <param name="comparer">Comparer that we want to use</param>
        public BinarySearchTree(IEnumerable<T> elements, IComparer<T> comparer)
        {
            if(ReferenceEquals(elements,null)) throw new ArgumentException();
            if (ReferenceEquals(comparer, null))
            {
                this.comparer = Comparer<T>.Default;
            }
            else
            {
                this.comparer = comparer;
            }
            foreach (var element in elements)
            {
                Add(element);
            }
        }
        /// <summary>
        /// Adds some element into the BinarySearchTree.
        /// </summary>
        /// <param name="element">element that we add.</param>
        public void Add(T element)
        {
            if (ReferenceEquals(root, null))
            {
                root = new Node<T>(element);
                return;
            }
            Node<T> current = root;
            Node<T> leaf = null;
            while (!ReferenceEquals(current, null))
            {
                leaf = current;
                var cmpr = (comparer.Compare(current.Value, element) < 0)?
               
                    current = current.rightNode:
               
                    current = current.leftNode;
            }
            var cmp = (comparer.Compare(leaf.Value, element) < 0)?
            
                leaf.rightNode = new Node<T>(element):
            
                leaf.leftNode = new Node<T>(element);
            
            
        }
        /// <summary>
        /// Show us exists such element into BinarySearchTree or not.
        /// </summary>
        /// <param name="element">Element that we check existance</param>
        /// <returns>True or false</returns>
        public bool Contains(T element)
        {
            Node<T> current = root;
            while (!ReferenceEquals(current, null))
            {
                if (comparer.Compare(current.Value, element) == 0) { return true; }
                var cmp = (comparer.Compare(current.Value, element) > 0)?
                
                current = current.leftNode:
                current = current.rightNode;
                
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
        /// <summary>
        /// Represents the BinarySearchTree in Preorder mode.
        /// </summary>
        /// <returns>The representation of BinarySearchTree in Preoder mode</returns>
        public IEnumerable<T> PreOrder() => PreOrder(root);
        /// <summary>
        /// Represents the BinarySearchTree in InOrder mode.
        /// </summary>
        /// <returns>The representation of BinarySearchTree in InOrder mode</returns>
        public IEnumerable<T> InOrder() => InOrder(root);
        /// <summary>
        ///  Represents the BinarySearchTree in PostOrder mode.
        /// </summary>
        /// <returns>The representation of BinarySearchTree in PostOrder mode</returns>
        public IEnumerable<T> PostOrder() => PostOrder(root);
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
