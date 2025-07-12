using System;

public class Program
{
    public static void Main(string[] args)
    {
        // Create fractions using all three constructors
        Fraction fraction1 = new Fraction(); // 1/1
        Fraction fraction2 = new Fraction(6); // 6/1
        Fraction fraction3 = new Fraction(6, 7); // 6/7
        Fraction fraction4 = new Fraction(1, 3); // 1/3

        // Display initial fractions
        Console.WriteLine(fraction1.GetFractionString());
        Console.WriteLine(fraction1.GetDecimalValue());

        Console.WriteLine(fraction2.GetFractionString());
        Console.WriteLine(fraction2.GetDecimalValue());

        Console.WriteLine(fraction3.GetFractionString());
        Console.WriteLine(fraction3.GetDecimalValue());

        Console.WriteLine(fraction4.GetFractionString());
        Console.WriteLine(fraction4.GetDecimalValue());

        Console.WriteLine();

        // Demonstrate setters and getters
        fraction1.SetTop(5);
        Console.WriteLine($"{fraction1.GetTop()}/{fraction1.GetBottom()}");
        Console.WriteLine(fraction1.GetDecimalValue());

        fraction2.SetBottom(4);
        Console.WriteLine($"{fraction2.GetTop()}/{fraction2.GetBottom()}");
        Console.WriteLine(fraction2.GetDecimalValue());

        Console.WriteLine();

        // Sample Output as requested
        Console.WriteLine("Sample Output:");
        Fraction sample1 = new Fraction();
        Console.WriteLine(sample1.GetFractionString());
        Console.WriteLine(sample1.GetDecimalValue());

        Fraction sample2 = new Fraction(5);
        Console.WriteLine(sample2.GetFractionString());
        Console.WriteLine(sample2.GetDecimalValue());

        Fraction sample3 = new Fraction(3, 4);
        Console.WriteLine(sample3.GetFractionString());
        Console.WriteLine(sample3.GetDecimalValue());

        Fraction sample4 = new Fraction(1, 3);
        Console.WriteLine(sample4.GetFractionString());
        Console.WriteLine(sample4.GetDecimalValue());
    }
}