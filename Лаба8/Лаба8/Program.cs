using System;

class Triangle
{
    private double sideA;
    private double sideB;
    private double sideC;

    public Triangle(double a, double b, double c)
    {
        if (IsValidTriangle(a, b, c))
        {
            sideA = a;
            sideB = b;
            sideC = c;
        }
        else
        {
            Console.WriteLine("Треугольник с такими сторонами не существует. Используются значения по умолчанию.");
        }
    }

    public Triangle(double sideLength)
    {
        if (sideLength > 0)
        {
            sideA = sideB = sideC = sideLength;
        }
        else
        {
            Console.WriteLine("Некорректная длина стороны.");
        }
    }

    public double CalculatePerimeter()
    {
        return sideA + sideB + sideC;
    }

    public double CalculateArea()
    {
        double halfPerimeter = CalculatePerimeter() / 2;
        return Math.Sqrt(halfPerimeter * (halfPerimeter - sideA) * (halfPerimeter - sideB) * (halfPerimeter - sideC));
    }

    public void DisplaySides()
    {
        Console.WriteLine($"Стороны треугольника: {sideA}, {sideB}, {sideC}");
    }

    private bool IsValidTriangle(double a, double b, double c)
    {
        return a + b > c && a + c > b && b + c > a;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Выберите тип треугольника:");
        Console.WriteLine("1. Треугольник с заданными длинами сторон");
        Console.WriteLine("2. Равносторонний треугольник");

        int choice = int.Parse(Console.ReadLine());

        Triangle triangle;

        switch (choice)
        {
            case 1:
                Console.Write("Введите длину стороны A: ");
                double sideA = double.Parse(Console.ReadLine());

                Console.Write("Введите длину стороны B: ");
                double sideB = double.Parse(Console.ReadLine());

                Console.Write("Введите длину стороны C: ");
                double sideC = double.Parse(Console.ReadLine());

                triangle = new Triangle(sideA, sideB, sideC);
                break;

            case 2:
                Console.Write("Введите длину стороны: ");
                double sideLength = double.Parse(Console.ReadLine());
                triangle = new Triangle(sideLength);
                break;

            default:
                Console.WriteLine("Некорректный выбор. Программа завершает выполнение.");
                return;
        }

        if (triangle.CalculatePerimeter() > 0)
        {
            Console.WriteLine($"Периметр треугольника: {triangle.CalculatePerimeter()}");
            Console.WriteLine($"Площадь треугольника: {triangle.CalculateArea()}");
            triangle.DisplaySides();
        }
    }
}
