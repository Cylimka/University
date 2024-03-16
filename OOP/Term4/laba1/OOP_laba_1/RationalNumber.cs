using System;

public class RationalNumber
{
    public int Numerator { get; private set; }
    public int Denominator { get; private set; }

    public RationalNumber(int numerator, int denominator)
    {
        if (denominator == 0)
            throw new ArgumentException("Знаминатель не может быть равен 0.", nameof(denominator));

        Numerator = numerator;
        Denominator = denominator;
        if (Denominator < 0 & Numerator < 0)
        {
            Denominator *= -1;
            Numerator *= -1;
        }
    }
    
    /// Сокращение
    private void Reduce()
    {
        int gcd = GCD(Math.Abs(Numerator), Math.Abs(Denominator));
        Numerator /= gcd;
        Denominator /= gcd;
    }
    /// НОД
    private int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    public override string ToString()
    {
        Reduce();
        return $"{Numerator}/{Denominator}";
    }

    public static RationalNumber operator +(RationalNumber a, RationalNumber b)
    {
       RationalNumber result = new RationalNumber(a.Numerator * b.Denominator + b.Numerator * a.Denominator, a.Denominator * b.Denominator);
       result.Reduce();
       return result ;
    }
    public static RationalNumber operator -(RationalNumber a, RationalNumber b)
    {
        RationalNumber result = new RationalNumber(a.Numerator * b.Denominator - b.Numerator * a.Denominator, a.Denominator * b.Denominator);
        result.Reduce();
        return result;
    }
    public static RationalNumber operator *(RationalNumber a, RationalNumber b)
    {
        RationalNumber result = new RationalNumber(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
        result.Reduce();
        return result;
    }

    public static RationalNumber operator /(RationalNumber a, RationalNumber b) { 
        RationalNumber result = new RationalNumber(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
        result.Reduce();
        return result;
    }

    public static bool operator ==(RationalNumber a, RationalNumber b) =>
        a.Numerator * b.Denominator == b.Numerator * a.Denominator;

    public static bool operator !=(RationalNumber a, RationalNumber b) =>
        !(a == b);

    public static bool operator <(RationalNumber a, RationalNumber b) =>
        a.Numerator * b.Denominator < b.Numerator * a.Denominator;

    public static bool operator >(RationalNumber a, RationalNumber b) =>
        a.Numerator * b.Denominator > b.Numerator * a.Denominator;

    public static bool operator <=(RationalNumber a, RationalNumber b) =>
        a.Numerator * b.Denominator <= b.Numerator * a.Denominator;

    public static bool operator >=(RationalNumber a, RationalNumber b) =>
        a.Numerator * b.Denominator >= b.Numerator * a.Denominator;
}


class Program
{
    static void Main(string[] args)
    {
        var test_1 = new RationalNumber(-1, 2);
        var test_2 = new RationalNumber(1, -2);

        /// act
        var actual = test_1 + test_2;
        Console.WriteLine((actual));
    }
}
