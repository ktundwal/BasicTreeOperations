using System;
using System.Collections.Generic;

namespace BasicTreeOperations.Lib
{
    public class BinarySearchTree<T> : IBinarySearchTree<T> where T : IComparable<T>
    {
        public Node RootNode { get; private set; } = null;

        public BinarySearchTree(T data)
        {
            RootNode = new Node(data);
        }

        public BinarySearchTree()
        {
        }

        public void IterativeInsert(T data)
        {
            if (RootNode == null)
            {
                RootNode = new Node(data);
                return;
            }

            var curNode = RootNode;
            var parentNode = curNode;

            // find a leaf Node
            while (curNode != null)
            {
                if (curNode.Data.CompareTo(data) == 0)
                {
                    throw new ArgumentException($"{data} is already present in the tree");
                }

                parentNode = curNode;
                curNode = curNode.Data.CompareTo(data) > 0 ? curNode.LeftNode : curNode.RightNode;
            }
            // we found a parent which either has left or right node null.
            if (parentNode.Data.CompareTo(data) > 0)
            {
                parentNode.LeftNode = new Node(data) {ParentNode = parentNode};
            }
            else
            {
                parentNode.RightNode = new Node(data) {ParentNode = parentNode};
            }
        }

        public void InsertRecursively(T data)
        {
            if (RootNode == null) RootNode = new Node(data);
            else InsertRecursively(RootNode, data);
        }

        // ReSharper disable once FunctionRecursiveOnAllPaths
        private static void InsertRecursively(Node root, T data)
        {
            if (data.CompareTo(root.Data) > 0)
            {
                if (root.RightNode == null)
                {
                    root.RightNode = new Node(data);
                    return;
                }
                InsertRecursively(root.RightNode, data);
            }
            else if (data.CompareTo(root.Data) < 0)
            {
                if (root.LeftNode == null)
                {
                    root.LeftNode = new Node(data);
                    return;
                }
                InsertRecursively(root.LeftNode, data);
            }
        }

        public bool Search(T data)
        {
            var curNode = RootNode;
            while (curNode != null)
            {
                if (curNode.Data.CompareTo(data) == 0) return true;
                curNode = curNode.Data.CompareTo(data) > 0 ? curNode.LeftNode : curNode.RightNode;
            }
            return false;
        }

        public T Max()
        {
            throw new NotImplementedException();
        }

        public T Min()
        {
            throw new NotImplementedException();
        }

        public List<T> PreOrderTraversal()
        {
            throw new NotImplementedException();
        }

        public List<T> PostOrderTraversal()
        {
            throw new NotImplementedException();
        }

        public class Node
        {
            public Node(T data)
            {
                Data = data;
            }

            public T Data { get; private set; }
            public Node LeftNode { get; set; } = null;
            public Node RightNode { get; set; } = null;
            public Node ParentNode { get; set; } = null;
            public override string ToString()
            {
                return $"{LeftNode?.Data.ToString() ?? ""} <- {Data} -> {RightNode?.Data.ToString() ?? ""}";
            }
        }
    }
}
