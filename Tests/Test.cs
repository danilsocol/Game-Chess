using Chess.WPF;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [TestCase(9, 1, ExpectedResult = false)]
        public bool InsideBorder_TestOnw(int i, int j)
        {
            return AvailableMoves.InsideBorder(i, j);
        }

        [TestCase(2, 0, ExpectedResult = false)]
        public bool InsideBorder_TestTwo(int i, int j)
        {
            return AvailableMoves.InsideBorder(i, j);
        }

        [TestCase(5, 4, ExpectedResult = true)]
        public bool InsideBorder_TestThree(int i, int j)
        {
            return AvailableMoves.InsideBorder(i, j);
        }

        [TestCase(-1, 8, ExpectedResult = false)]
        public bool InsideBorder_TestFour(int i, int j)
        {
            return AvailableMoves.InsideBorder(i, j);
        }

        [TestCase(5, -4, ExpectedResult = false)]
        public bool InsideBorder_TestFive(int i, int j)
        {
            return AvailableMoves.InsideBorder(i, j);
        }
    }
}