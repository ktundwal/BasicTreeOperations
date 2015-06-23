using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicTreeOperations.Lib.Test
{
    public class ListOfIntGenerator
    {
        private readonly Random _random;

        public ListOfIntGenerator(int quantity)
        {
            _random = new Random();
            RandomInts = RandomSequence().Take(quantity).ToList();
        }

        public List<int> RandomInts { get; private set; }

        public int FindRandomIntFromList()
        {
            return RandomInts[_random.Next(RandomInts.Count)];
        }

        public int FindRandomIntThatIsNotInList()
        {
            return _random.Next();
        }

        private IEnumerable<int> RandomSequence()
        {
            while (true)
            {
                yield return _random.Next();
            }
            // ReSharper disable once FunctionNeverReturns
        }
    }
}
