
using System.Security.AccessControl;

[TestFixture]
public class RationalNumberTests
{

    [Test]
    public void ToStringReduce()
    {
        /// arrange
        string expected = "11/12";

        ///act
        RationalNumber test = new RationalNumber(11 * 8, 12 * 8);
        string actual = test.ToString();
        ///assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCase(-11 * 8, -12 * 8, "11/12")]
    public void ToString_Reduce_Neg(int a1, int a2, string result)
    {
        /// arrange
        var test = new RationalNumber(a1, a2);

        ///act

        string actual = test.ToString();
        ///assert
        Assert.AreEqual(result, actual);
    }

    [Test]
    [TestCase(11*8, -12*8, "11/-12")]
    public void ToString_Reduce_Neg_Down(int a1, int a2, string result)
    {
        /// arrange
        var test = new RationalNumber(a1, a2);

        ///act

        string actual = test.ToString();
        ///assert
        Assert.AreEqual(result, actual);
    }

    [Test]
    [TestCase(-11 * 8, 12 * 8, "-11/12")]
    public void ToString_Reduce_Neg_Up(int a1, int a2, string result)
    {
        /// arrange
        var test = new RationalNumber(a1, a2);

        ///act

        string actual = test.ToString();
        ///assert
        Assert.AreEqual(result, actual);
    }

    [Test]
    [TestCase(11 * 8, 0, "11/0")]
    public void ToString_Numerator_Zero(int a1, int a2, string result)
    {
        Assert.Throws<ArgumentException>(() => { new RationalNumber(a1, a2); });
    }

    [Test]
    [TestCase(1, 2, 1, 2, 1, 1)]
    public void Plus_Positive(int a1_1, int a1_2, int a2_1, int a2_2, int result_a1, int result_a2)
    {
        /// arrange
        var test_1 = new RationalNumber(a1_1, a1_2);
        var test_2 = new RationalNumber(a2_1, a2_2);

        /// act
        var actual = test_1 + test_2;

        /// assert
        Assert.AreEqual(result_a1, actual.Numerator);
        Assert.AreEqual(result_a2, actual.Denominator);
    }

    [Test]
    [TestCase(1, 2, -1, 2, 0, 1)]
    public void Plus_Zero(int a1_1, int a1_2, int a2_1, int a2_2, int result_a1, int result_a2)
    {
        /// arrange
        var test_1 = new RationalNumber(a1_1, a1_2);
        var test_2 = new RationalNumber(a2_1, a2_2);

        /// act
        var actual = test_1 + test_2;

        /// assert
        Assert.AreEqual(result_a1, actual.Numerator);
        Assert.AreEqual(result_a2, actual.Denominator);
    }

    [Test]
    [TestCase(1, 2, -2, 2, -1, 2)]
    public void Plus_Negative_Positive(int a1_1, int a1_2, int a2_1, int a2_2, int result_a1, int result_a2)
    {
        /// arrange
        var test_1 = new RationalNumber(a1_1, a1_2);
        var test_2 = new RationalNumber(a2_1, a2_2);

        /// act
        var actual = test_1 + test_2;

        /// assert
        Assert.AreEqual(result_a1, actual.Numerator);
        Assert.AreEqual(result_a2, actual.Denominator);
    }
    [Test]
    [TestCase(-1, 2, -1, 2, -1, 1)]
    public void Plus_Negative_Negative(int a1_1, int a1_2, int a2_1, int a2_2, int result_a1, int result_a2)
    {
        /// arrange
        var test_1 = new RationalNumber(a1_1, a1_2);
        var test_2 = new RationalNumber(a2_1, a2_2);

        /// act
        var actual = test_1 + test_2;

        /// assert
        Assert.AreEqual(result_a1, actual.Numerator);
        Assert.AreEqual(result_a2, actual.Denominator);
    }
    [Test]
    [TestCase(-1, 2, 1, -2, 1, -1)]
    public void Plus_Negative_Denominator(int a1_1, int a1_2, int a2_1, int a2_2, int result_a1, int result_a2)
    {
        /// arrange
        var test_1 = new RationalNumber(a1_1, a1_2);
        var test_2 = new RationalNumber(a2_1, a2_2);

        /// act
        var actual = test_1 + test_2;

        /// assert
        Assert.AreEqual(result_a1, actual.Numerator);
        Assert.AreEqual(result_a2, actual.Denominator);
    }

    [Test]
    [TestCase(1, 2, 1, 2, 0, 1)]
    public void Subtraction_Positive_To_Zero(int a1_1, int a1_2, int a2_1, int a2_2, int result_a1, int result_a2)
    {
        /// arrange
        var test_1 = new RationalNumber(a1_1, a1_2);
        var test_2 = new RationalNumber(a2_1, a2_2);

        /// act
        var actual = test_1 - test_2;

        /// assert
        Assert.AreEqual(result_a1, actual.Numerator);
        Assert.AreEqual(result_a2, actual.Denominator);
    }

    [Test]
    [TestCase(2, 2, 1, 2, 1, 2)]
    public void Subtraction_Positive_To_Positive(int a1_1, int a1_2, int a2_1, int a2_2, int result_a1, int result_a2)
    {
        /// arrange
        var test_1 = new RationalNumber(a1_1, a1_2);
        var test_2 = new RationalNumber(a2_1, a2_2);

        /// act
        var actual = test_1 - test_2;

        /// assert
        Assert.AreEqual(result_a1, actual.Numerator);
        Assert.AreEqual(result_a2, actual.Denominator);
    }

    [Test]
    [TestCase(-1, 2, 1, 2, -1, 1)]
    public void Subtraction_Positive_To_Negative(int a1_1, int a1_2, int a2_1, int a2_2, int result_a1, int result_a2)
    {
        /// arrange
        var test_1 = new RationalNumber(a1_1, a1_2);
        var test_2 = new RationalNumber(a2_1, a2_2);

        /// act
        var actual = test_1 - test_2;

        /// assert
        Assert.AreEqual(result_a1, actual.Numerator);
        Assert.AreEqual(result_a2, actual.Denominator);
    }

    [Test]
    [TestCase(-1, 2, -2, 2, 1, 2)]
    public void Subtraction_Negative_Negative_To_Positive(int a1_1, int a1_2, int a2_1, int a2_2, int result_a1, int result_a2)
    {
        /// arrange
        var test_1 = new RationalNumber(a1_1, a1_2);
        var test_2 = new RationalNumber(a2_1, a2_2);

        /// act
        var actual = test_1 - test_2;

        /// assert
        Assert.AreEqual(result_a1, actual.Numerator);
        Assert.AreEqual(result_a2, actual.Denominator);
    }

    [Test]
    [TestCase(1, 2, -1, 2, 1, 1)]
    public void Subtraction_Positive_Negative_To_Positive(int a1_1, int a1_2, int a2_1, int a2_2, int result_a1, int result_a2)
    {
        /// arrange
        var test_1 = new RationalNumber(a1_1, a1_2);
        var test_2 = new RationalNumber(a2_1, a2_2);

        /// act
        var actual = test_1 - test_2;

        /// assert
        Assert.AreEqual(result_a1, actual.Numerator);
        Assert.AreEqual(result_a2, actual.Denominator);
    }

    [Test]
    [TestCase(2, 3, 2, 2, 2, 3)]
    public void Multiplication_Positive_Positive_Positive(int a1_1, int a1_2, int a2_1, int a2_2, int result_a1, int result_a2)
    {
        /// arrange
        var test_1 = new RationalNumber(a1_1, a1_2);
        var test_2 = new RationalNumber(a2_1, a2_2);

        /// act
        var actual = test_1 * test_2;

        /// assert
        Assert.AreEqual(result_a1, actual.Numerator);
        Assert.AreEqual(result_a2, actual.Denominator);
    }
    [Test]
    [TestCase(2, 3, 0, 2, 0, 1)]
    public void Multiplication_Positive_Zero_Zero(int a1_1, int a1_2, int a2_1, int a2_2, int result_a1, int result_a2)
    {
        /// arrange
        var test_1 = new RationalNumber(a1_1, a1_2);
        var test_2 = new RationalNumber(a2_1, a2_2);

        /// act
        var actual = test_1 * test_2;

        /// assert
        Assert.AreEqual(result_a1, actual.Numerator);
        Assert.AreEqual(result_a2, actual.Denominator);
    }

    [Test]
    [TestCase(2, 3, -2, 2, -2, 3)]
    public void Multiplication_Positive_Negative_Nagative1(int a1_1, int a1_2, int a2_1, int a2_2, int result_a1, int result_a2)
    {
        /// arrange
        var test_1 = new RationalNumber(a1_1, a1_2);
        var test_2 = new RationalNumber(a2_1, a2_2);

        /// act
        var actual = test_1 * test_2;

        /// assert
        Assert.AreEqual(result_a1, actual.Numerator);
        Assert.AreEqual(result_a2, actual.Denominator);
    }

    [Test]
    [TestCase(2, 3, -2, -2, 2, 3)]
    public void Multiplication_Positive_Negative_Nagative2(int a1_1, int a1_2, int a2_1, int a2_2, int result_a1, int result_a2)
    {
        /// arrange
        var test_1 = new RationalNumber(a1_1, a1_2);
        var test_2 = new RationalNumber(a2_1, a2_2);

        /// act
        var actual = test_1 * test_2;

        /// assert
        Assert.AreEqual(result_a1, actual.Numerator);
        Assert.AreEqual(result_a2, actual.Denominator);
    }

    [Test]
    [TestCase(-2, 3, -2, 2, 2, 3)]
    public void Multiplication_Negative_Negative_Positive1(int a1_1, int a1_2, int a2_1, int a2_2, int result_a1, int result_a2)
    {
        /// arrange
        var test_1 = new RationalNumber(a1_1, a1_2);
        var test_2 = new RationalNumber(a2_1, a2_2);

        /// act
        var actual = test_1 * test_2;

        /// assert
        Assert.AreEqual(result_a1, actual.Numerator);
        Assert.AreEqual(result_a2, actual.Denominator);
    }
    [Test]
    [TestCase(-2, -3, -2, -2, 2, 3)]
    public void Multiplication_Negative_Negative_Positive2(int a1_1, int a1_2, int a2_1, int a2_2, int result_a1, int result_a2)
    {
        /// arrange
        var test_1 = new RationalNumber(a1_1, a1_2);
        var test_2 = new RationalNumber(a2_1, a2_2);

        /// act
        var actual = test_1 * test_2;

        /// assert
        Assert.AreEqual(result_a1, actual.Numerator);
        Assert.AreEqual(result_a2, actual.Denominator);
    }

    [Test]
    [TestCase(2, 3, 2, 2, 2, 3)]
    public void Division_Positive_Positive_Positive(int a1_1, int a1_2, int a2_1, int a2_2, int result_a1, int result_a2)
    {
        /// arrange
        var test_1 = new RationalNumber(a1_1, a1_2);
        var test_2 = new RationalNumber(a2_1, a2_2);

        /// act
        var actual = test_1 * test_2;

        /// assert
        Assert.AreEqual(result_a1, actual.Numerator);
        Assert.AreEqual(result_a2, actual.Denominator);
    }
    [Test]
    [TestCase(2, 3, 0, 2, 0, 1)]
    public void Division_Positive_Zero_Zero(int a1_1, int a1_2, int a2_1, int a2_2, int result_a1, int result_a2)
    {
        /// arrange
        var test_1 = new RationalNumber(a1_1, a1_2);
        var test_2 = new RationalNumber(a2_1, a2_2);

        /// act
        var actual = test_1 * test_2;

        /// assert
        Assert.AreEqual(result_a1, actual.Numerator);
        Assert.AreEqual(result_a2, actual.Denominator);
    }

    [Test]
    [TestCase(2, 3, -2, 2, -2, 3)]
    public void Division_Positive_Negative_Nagative1(int a1_1, int a1_2, int a2_1, int a2_2, int result_a1, int result_a2)
    {
        /// arrange
        var test_1 = new RationalNumber(a1_1, a1_2);
        var test_2 = new RationalNumber(a2_1, a2_2);

        /// act
        var actual = test_1 * test_2;

        /// assert
        Assert.AreEqual(result_a1, actual.Numerator);
        Assert.AreEqual(result_a2, actual.Denominator);
    }

    [Test]
    [TestCase(2, 3, -2, -2, 2, 3)]
    public void Division_Positive_Negative_Nagative2(int a1_1, int a1_2, int a2_1, int a2_2, int result_a1, int result_a2)
    {
        /// arrange
        var test_1 = new RationalNumber(a1_1, a1_2);
        var test_2 = new RationalNumber(a2_1, a2_2);

        /// act
        var actual = test_1 * test_2;

        /// assert
        Assert.AreEqual(result_a1, actual.Numerator);
        Assert.AreEqual(result_a2, actual.Denominator);
    }

    [Test]
    [TestCase(-2, 3, -2, 2, 2, 3)]
    public void Division_Negative_Negative_Positive1(int a1_1, int a1_2, int a2_1, int a2_2, int result_a1, int result_a2)
    {
        /// arrange
        var test_1 = new RationalNumber(a1_1, a1_2);
        var test_2 = new RationalNumber(a2_1, a2_2);

        /// act
        var actual = test_1 * test_2;

        /// assert
        Assert.AreEqual(result_a1, actual.Numerator);
        Assert.AreEqual(result_a2, actual.Denominator);
    }
    [Test]
    [TestCase(-2, -3, -2, -2, 2, 3)]
    public void Division_Negative_Negative_Positive2(int a1_1, int a1_2, int a2_1, int a2_2, int result_a1, int result_a2)
    {
        /// arrange
        var test_1 = new RationalNumber(a1_1, a1_2);
        var test_2 = new RationalNumber(a2_1, a2_2);

        /// act
        var actual = test_1 * test_2;

        /// assert
        Assert.AreEqual(result_a1, actual.Numerator);
        Assert.AreEqual(result_a2, actual.Denominator);
    }

    [Test]
    [TestCase(1, 2, 1, 2)]
    public void Equality_Same(int a1_1, int a1_2, int a2_1, int a2_2)
    {
        /// arrange
        var test_1 = new RationalNumber(a1_1, a1_2);
        var test_2 = new RationalNumber(a2_1, a2_2);

        /// act
        bool actual = test_1 == test_2;
        /// assert
        Assert.IsTrue(actual);
    }
    [Test]
    [TestCase(1, 2, 2, 4)]
    public void Equality_Not_Same(int a1_1, int a1_2, int a2_1, int a2_2)
    {
        /// arrange
        var test_1 = new RationalNumber(a1_1, a1_2);
        var test_2 = new RationalNumber(a2_1, a2_2);

        /// act
        bool actual = test_1 == test_2;
        /// assert
        Assert.IsTrue(actual);
    }

    [Test]
    [TestCase(2, 2, 1, 2)]
    public void Equality_More_Less_False(int a1_1, int a1_2, int a2_1, int a2_2)
    {
        /// arrange
        var test_1 = new RationalNumber(a1_1, a1_2);
        var test_2 = new RationalNumber(a2_1, a2_2);

        /// act
        bool actual = test_1 == test_2;
        /// assert
        Assert.IsFalse(actual);
    }
    [Test]
    [TestCase(1, 2, 2, 2)]
    public void Equality_Less_More_False(int a1_1, int a1_2, int a2_1, int a2_2)
    {
        /// arrange
        var test_1 = new RationalNumber(a1_1, a1_2);
        var test_2 = new RationalNumber(a2_1, a2_2);

        /// act
        bool actual = test_1 == test_2;
        /// assert
        Assert.IsFalse(actual);
    }
    [Test]
    [TestCase(1, 2, 1, 2)]
    public void Not_Equality_Same(int a1_1, int a1_2, int a2_1, int a2_2)
    {
        /// arrange
        var test_1 = new RationalNumber(a1_1, a1_2);
        var test_2 = new RationalNumber(a2_1, a2_2);

        /// act
        bool actual = test_1 != test_2;
        /// assert
        Assert.IsFalse(actual);
    }
    [Test]
    [TestCase(1, 2, 2, 4)]
    public void Not_Equality_Not_Same(int a1_1, int a1_2, int a2_1, int a2_2)
    {
        /// arrange
        var test_1 = new RationalNumber(a1_1, a1_2);
        var test_2 = new RationalNumber(a2_1, a2_2);

        /// act
        bool actual = test_1 != test_2;
        /// assert
        Assert.IsFalse(actual);
    }

    [Test]
    [TestCase(2, 2, 1, 2)]
    public void Not_Equality_More_Less_False(int a1_1, int a1_2, int a2_1, int a2_2)
    {
        /// arrange
        var test_1 = new RationalNumber(a1_1, a1_2);
        var test_2 = new RationalNumber(a2_1, a2_2);

        /// act
        bool actual = test_1 != test_2;
        /// assert
        Assert.IsTrue(actual);
    }
    [Test]
    [TestCase(1, 2, 2, 2)]
    public void Not_Equality_Less_More_False(int a1_1, int a1_2, int a2_1, int a2_2)
    {
        /// arrange
        var test_1 = new RationalNumber(a1_1, a1_2);
        var test_2 = new RationalNumber(a2_1, a2_2);

        /// act
        bool actual = test_1 != test_2;
        /// assert
        Assert.IsTrue(actual);
    }
    [Test]
    [TestCase(1, 2, 1, 2)]
    public void Less_Same(int a1_1, int a1_2, int a2_1, int a2_2)
    {
        /// arrange
        var test_1 = new RationalNumber(a1_1, a1_2);
        var test_2 = new RationalNumber(a2_1, a2_2);

        /// act
        bool actual = test_1 < test_2;
        /// assert
        Assert.IsFalse(actual);
    }
    [Test]
    [TestCase(1, 2, 2, 4)]
    public void Less_Not_Same(int a1_1, int a1_2, int a2_1, int a2_2)
    {
        /// arrange
        var test_1 = new RationalNumber(a1_1, a1_2);
        var test_2 = new RationalNumber(a2_1, a2_2);

        /// act
        bool actual = test_1 < test_2;
        /// assert
        Assert.IsFalse(actual);
    }

    [Test]
    [TestCase(2, 2, 1, 2)]
    public void Less_More_Less_False(int a1_1, int a1_2, int a2_1, int a2_2)
    {
        /// arrange
        var test_1 = new RationalNumber(a1_1, a1_2);
        var test_2 = new RationalNumber(a2_1, a2_2);

        /// act
        bool actual = test_1 < test_2;
        /// assert
        Assert.IsFalse(actual);
    }
    [Test]
    [TestCase(1, 2, 2, 2)]
    public void Less_Less_More_False(int a1_1, int a1_2, int a2_1, int a2_2)
    {
        /// arrange
        var test_1 = new RationalNumber(a1_1, a1_2);
        var test_2 = new RationalNumber(a2_1, a2_2);

        /// act
        bool actual = test_1 < test_2;
        /// assert
        Assert.IsTrue(actual);
    }

    [Test]
    [TestCase(1, 2, 1, 2)]
    public void More_Same(int a1_1, int a1_2, int a2_1, int a2_2)
    {
        /// arrange
        var test_1 = new RationalNumber(a1_1, a1_2);
        var test_2 = new RationalNumber(a2_1, a2_2);

        /// act
        bool actual = test_1 > test_2;
        /// assert
        Assert.IsFalse(actual);
    }
    [Test]
    [TestCase(1, 2, 2, 4)]
    public void More_Not_Same(int a1_1, int a1_2, int a2_1, int a2_2)
    {
        /// arrange
        var test_1 = new RationalNumber(a1_1, a1_2);
        var test_2 = new RationalNumber(a2_1, a2_2);

        /// act
        bool actual = test_1 > test_2;
        /// assert
        Assert.IsFalse(actual);
    }

    [Test]
    [TestCase(2, 2, 1, 2)]
    public void More_More_Less_False(int a1_1, int a1_2, int a2_1, int a2_2)
    {
        /// arrange
        var test_1 = new RationalNumber(a1_1, a1_2);
        var test_2 = new RationalNumber(a2_1, a2_2);

        /// act
        bool actual = test_1 > test_2;
        /// assert
        Assert.IsTrue(actual);
    }
    [Test]
    [TestCase(1, 2, 2, 2)]
    public void More_Less_More_False(int a1_1, int a1_2, int a2_1, int a2_2)
    {
        /// arrange
        var test_1 = new RationalNumber(a1_1, a1_2);
        var test_2 = new RationalNumber(a2_1, a2_2);

        /// act
        bool actual = test_1 > test_2;
        /// assert
        Assert.IsFalse(actual);
    }
    [Test]
    [TestCase(1, 2, 1, 2)]
    public void Less_Or_Equal_Same(int a1_1, int a1_2, int a2_1, int a2_2)
    {
        /// arrange
        var test_1 = new RationalNumber(a1_1, a1_2);
        var test_2 = new RationalNumber(a2_1, a2_2);

        /// act
        bool actual = test_1 <= test_2;
        /// assert
        Assert.IsTrue(actual);
    }
    [Test]
    [TestCase(1, 2, 2, 4)]
    public void Less_Or_Equal_Not_Same(int a1_1, int a1_2, int a2_1, int a2_2)
    {
        /// arrange
        var test_1 = new RationalNumber(a1_1, a1_2);
        var test_2 = new RationalNumber(a2_1, a2_2);

        /// act
        bool actual = test_1 <= test_2;
        /// assert
        Assert.IsTrue(actual);
    }

    [Test]
    [TestCase(2, 2, 1, 2)]
    public void Less_Or_Equal_More_Less_False(int a1_1, int a1_2, int a2_1, int a2_2)
    {
        /// arrange
        var test_1 = new RationalNumber(a1_1, a1_2);
        var test_2 = new RationalNumber(a2_1, a2_2);

        /// act
        bool actual = test_1 <= test_2;
        /// assert
        Assert.IsFalse(actual);
    }
    [Test]
    [TestCase(1, 2, 2, 2)]
    public void Less_Or_Equal_Less_More_False(int a1_1, int a1_2, int a2_1, int a2_2)
    {
        /// arrange
        var test_1 = new RationalNumber(a1_1, a1_2);
        var test_2 = new RationalNumber(a2_1, a2_2);

        /// act
        bool actual = test_1 <= test_2;
        /// assert
        Assert.IsTrue(actual);
    }

    [Test]
    [TestCase(1, 2, 1, 2)]
    public void More_Or_Equal_Same(int a1_1, int a1_2, int a2_1, int a2_2)
    {
        /// arrange
        var test_1 = new RationalNumber(a1_1, a1_2);
        var test_2 = new RationalNumber(a2_1, a2_2);

        /// act
        bool actual = test_1 >= test_2;
        /// assert
        Assert.IsTrue(actual);
    }
    [Test]
    [TestCase(1, 2, 2, 4)]
    public void More_Or_Equal_Not_Same(int a1_1, int a1_2, int a2_1, int a2_2)
    {
        /// arrange
        var test_1 = new RationalNumber(a1_1, a1_2);
        var test_2 = new RationalNumber(a2_1, a2_2);

        /// act
        bool actual = test_1 >= test_2;
        /// assert
        Assert.IsTrue(actual);
    }

    [Test]
    [TestCase(2, 2, 1, 2)]
    public void More_Or_Equal_More_Less_False(int a1_1, int a1_2, int a2_1, int a2_2)
    {
        /// arrange
        var test_1 = new RationalNumber(a1_1, a1_2);
        var test_2 = new RationalNumber(a2_1, a2_2);

        /// act
        bool actual = test_1 >= test_2;
        /// assert
        Assert.IsTrue(actual);
    }
    [Test]
    [TestCase(1, 2, 2, 2)]
    public void More_Or_Equal_Less_More_False(int a1_1, int a1_2, int a2_1, int a2_2)
    {
        /// arrange
        var test_1 = new RationalNumber(a1_1, a1_2);
        var test_2 = new RationalNumber(a2_1, a2_2);

        /// act
        bool actual = test_1 >= test_2;
        /// assert
        Assert.IsFalse(actual);
    }
}

