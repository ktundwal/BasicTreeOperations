using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BasicTreeOperations.Lib.Test
{
    [TestClass()]
    public class BinarySearchTreeTests
    {
        [TestMethod()]
        public void InsertRecursivelyTest()
        {
            IBinarySearchTree<int> tree = new BinarySearchTree<int>(100);
            tree.InsertRecursively(50);
            tree.InsertRecursively(150);
            tree.InsertRecursively(200);

            Assert.IsTrue(tree.Search(150), "150 should be in the tree");
            Assert.IsFalse(tree.Search(125), "125 should not be in the tree");
        }

        [TestMethod()]
        public void InsertRecursivelyUsingRandomNumbersTest()
        {
            const int quantity = 150;
            InsertRecursivelyTestHelper(quantity);
        }

        private static void InsertRecursivelyTestHelper(int quantity)
        {
            IBinarySearchTree<int> tree = new BinarySearchTree<int>();
            var listGenerator = new ListOfIntGenerator(quantity);
            foreach (var randomInt in listGenerator.RandomInts)
            {
                tree.InsertRecursively(randomInt);
            }

            // test for presence
            var randomEntry = listGenerator.FindRandomIntFromList();
            Assert.IsTrue(tree.Search(randomEntry), message: $"{randomEntry} should be in the tree");

            // test for absence
            var entryThatIsNotInTheList = listGenerator.FindRandomIntThatIsNotInList();
            Assert.IsFalse(tree.Search(entryThatIsNotInTheList), 
                message: $"{entryThatIsNotInTheList} should not be in the tree");
        }

        [TestMethod()]
        public void IterativeInsertTest()
        {
            IBinarySearchTree<int> tree = new BinarySearchTree<int>(100);
            tree.IterativeInsert(50);
            tree.IterativeInsert(150);
            tree.IterativeInsert(200);

            Assert.IsTrue(tree.Search(150), "150 should be in the tree");
            Assert.IsFalse(tree.Search(125), "125 should not be in the tree");
        }
    }
}