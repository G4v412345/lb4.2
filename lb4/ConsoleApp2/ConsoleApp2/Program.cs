class TFraction
{
    protected int numerator;
    protected int denominator;

    public TFraction()
    {
        numerator = 0;
        denominator = 1;
    }

    public TFraction(int num, int den)
    {
        if (den == 0)
        {
            throw new ArgumentException("Знаменик не може бути нулем");
        }

        numerator = num;
        denominator = den;
    }

    public TFraction(TFraction fraction)
    {
        numerator = fraction.numerator;
        denominator = fraction.denominator;
    }

    public void Input_Val()
    {
        Console.Write("Напиши чисельник: ");
        numerator = Convert.ToInt32(Console.ReadLine());

        Console.Write("Напиши знаменник: ");
        int inputDenominator = Convert.ToInt32(Console.ReadLine());

        if (inputDenominator == 0)
        {
            throw new ArgumentException("Знаменик не може бути нулем");
        }

        denominator = inputDenominator;
    }

    public void Out_Val()
    {
        Console.WriteLine($"{numerator}/{denominator}");
    }

    private int FindGCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    public void Simplify()
    {
        int gcd = FindGCD(numerator, denominator);
        numerator /= gcd;
        denominator /= gcd;
    }

    public static TFraction operator +(TFraction fraction1, TFraction fraction2)
    {
        int resultNumerator = fraction1.numerator * fraction2.denominator + fraction2.numerator * fraction1.denominator;
        int resultDenominator = fraction1.denominator * fraction2.denominator;
        return new TFraction(resultNumerator, resultDenominator);
    }

    public static TFraction operator -(TFraction fraction1, TFraction fraction2)
    {
        int resultNumerator = fraction1.numerator * fraction2.denominator - fraction2.numerator * fraction1.denominator;
        int resultDenominator = fraction1.denominator * fraction2.denominator;
        return new TFraction(resultNumerator, resultDenominator);
    }

    public static TFraction operator *(TFraction fraction1, TFraction fraction2)
    {
        int resultNumerator = fraction1.numerator * fraction2.numerator;
        int resultDenominator = fraction1.denominator * fraction2.denominator;
        return new TFraction(resultNumerator, resultDenominator);
    }

    public static TFraction operator /(TFraction fraction1, TFraction fraction2)
    {
        if (fraction2.numerator == 0) 
        {
            throw new DivideByZeroException("Дiлити на нуль неможливо");
        }

        int resultNumerator = fraction1.numerator * fraction2.denominator;
        int resultDenominator = fraction1.denominator * fraction2.numerator;
        return new TFraction(resultNumerator, resultDenominator);
    }
}

class TMixFraction : TFraction
{
    private int wholePart;

    public TMixFraction() : base()
    {
        wholePart = 0;
    }

    public TMixFraction(int whole, int num, int den) : base(num, den)
    {
        wholePart = whole;
    }

    public TMixFraction(TMixFraction mixFraction) : base(mixFraction)
    {
        wholePart = mixFraction.wholePart;
    }

    public new void Out_Val()
    {
        Console.WriteLine($"{wholePart} {base.numerator}/{base.denominator}");
    }
}

class Program
{
    static void Main()
    {
        TFraction fraction1 = new TFraction(1, 2);
        TFraction fraction2 = new TFraction(3, 4);

        TFraction sum = fraction1 + fraction2;
        TFraction difference = fraction1 - fraction2;
        TFraction multi = fraction1 * fraction2;
        TFraction quotient = fraction1 / fraction2;

        Console.WriteLine("Сума:");
        sum.Out_Val();

        Console.WriteLine("Рiзниця:");
        difference.Out_Val();

        Console.WriteLine("Множення:");
        multi.Out_Val(); 

        Console.WriteLine("Частка:");
        quotient.Out_Val();

        TMixFraction mixFraction = new TMixFraction(2, 1, 3);
        Console.WriteLine("Мiшана дрiб:");
        mixFraction.Out_Val();

        Console.ReadLine();
    }
}
