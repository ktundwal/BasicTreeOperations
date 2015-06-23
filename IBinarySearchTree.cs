using System.Collections.Generic;

namespace BasicTreeOperations.Lib
{
    public interface IBinarySearchTree<T>
    {
        void IterativeInsert(T data);

        void InsertRecursively(T data);

        bool Search(T data);

        T Max();

        T Min();

        List<T> PreOrderTraversal();

        List<T> PostOrderTraversal();
    }
}