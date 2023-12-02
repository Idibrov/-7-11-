using System;
using System.Collections.Generic;

abstract class Shape
{
    public abstract double CalculatePerimeter();
    public abstract double CalculateArea();
    public virtual void DisplayInfo()
    {
        Console.WriteLine("Фигура");
    }
}

interface IRotatable
{
    void Rotate();
}

class Triangle : Shape, IRotatable
{
    private double sideA;
    private double sideB;
    private double sideC;

    public Triangle(double a, double b, double c)
    {
        sideA = a;
        sideB = b;
        sideC = c;
    }

    public override double CalculatePerimeter()
    {
        return sideA + sideB + sideC;
    }

    public override double CalculateArea()
    {
        double s = CalculatePerimeter() / 2;
        return Math.Sqrt(s * (s - sideA) * (s - sideB) * (s - sideC));
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Треугольник со сторонами: {sideA}, {sideB}, {sideC}");
    }

    public void Rotate()
    {
        Console.WriteLine("Треугольник вращается.");
    }
}

class Circle : Shape
{
    private double radius;

    public Circle(double r)
    {
        radius = r;
    }

    public override double CalculatePerimeter()
    {
        return 2 * Math.PI * radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * Math.Pow(radius, 2);
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Окружность с радиусом: {radius}");
    }
}

class Square : Shape, IRotatable
{
    private double side;

    public Square(double s)
    {
        side = s;
    }

    public override double CalculatePerimeter()
    {
        return 4 * side;
    }

    public override double CalculateArea()
    {
        return Math.Pow(side, 2);
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Квадрат со стороной: {side}");
    }

    public void Rotate()
    {
        Console.WriteLine("Квадрат вращается вокруг своего центра.");
    }
}

class Program
{
    static void Main()
    {
        List<Shape> shapes = new List<Shape>();

        Console.WriteLine("Выберите фигуру: 1 - Треугольник, 2 - Окружность, 3 - Квадрат");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.Write("Введите сторону A: ");
                double sideA = double.Parse(Console.ReadLine());

                Console.Write("Введите сторону B: ");
                double sideB = double.Parse(Console.ReadLine());

                Console.Write("Введите сторону C: ");
                double sideC = double.Parse(Console.ReadLine());

                shapes.Add(new Triangle(sideA, sideB, sideC));
                break;

            case 2:
                Console.Write("Введите радиус окружности: ");
                double radius = double.Parse(Console.ReadLine());
                shapes.Add(new Circle(radius));
                break;

            case 3:
                Console.Write("Введите сторону квадрата: ");
                double squareSide = double.Parse(Console.ReadLine());
                shapes.Add(new Square(squareSide));
                break;

            default:
                Console.WriteLine("Некорректный выбор.");
                return;
        }

        Console.WriteLine("\nИнформация о фигуре:");
        foreach (var shape in shapes)
        {
            shape.DisplayInfo();
            Console.WriteLine($"Периметр: {shape.CalculatePerimeter()}");
            Console.WriteLine($"Площадь: {shape.CalculateArea()}");

            if (shape is IRotatable rotatableShape)
            {
                rotatableShape.Rotate();
            }

            Console.WriteLine();
        }
    }
}
