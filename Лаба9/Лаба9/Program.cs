using System;

interface IRotatable
{
    void Rotate();
}

abstract class Shape
{
    public abstract void DisplayInfo();
    public abstract double CalculatePerimeter();
    public abstract double CalculateArea();
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

    public override void DisplayInfo()
    {
        Console.WriteLine($"Треугольник со сторонами: {sideA}, {sideB}, {sideC}");
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

    public void Rotate()
    {
        Console.WriteLine("Треугольник вращается.");
    }
}

class Circle : Shape, IRotatable
{
    private double radius;

    public Circle(double r)
    {
        radius = r;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Окружность с радиусом: {radius}");
    }

    public override double CalculatePerimeter()
    {
        return 2 * Math.PI * radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * Math.Pow(radius, 2);
    }

    public void Rotate()
    {
        Console.WriteLine("Окружность вращается.");
    }
}

class Square : Shape, IRotatable
{
    private double side;

    public Square(double s)
    {
        side = s;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Квадрат со стороной: {side}");
    }

    public override double CalculatePerimeter()
    {
        return 4 * side;
    }

    public override double CalculateArea()
    {
        return Math.Pow(side, 2);
    }

    public void Rotate()
    {
        Console.WriteLine("Квадрат вращается.");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Выберите фигуру: 1 - Треугольник, 2 - Окружность, 3 - Квадрат");
        int choice = int.Parse(Console.ReadLine());

        Shape shape;

        switch (choice)
        {
            case 1:
                Console.Write("Введите сторону A: ");
                double sideA = double.Parse(Console.ReadLine());

                Console.Write("Введите сторону B: ");
                double sideB = double.Parse(Console.ReadLine());

                Console.Write("Введите сторону C: ");
                double sideC = double.Parse(Console.ReadLine());

                shape = new Triangle(sideA, sideB, sideC);
                break;

            case 2:
                Console.Write("Введите радиус окружности: ");
                double radius = double.Parse(Console.ReadLine());
                shape = new Circle(radius);
                break;

            case 3:
                Console.Write("Введите сторону квадрата: ");
                double squareSide = double.Parse(Console.ReadLine());
                shape = new Square(squareSide);
                break;

            default:
                Console.WriteLine("Некорректный выбор.");
                return;
        }

        Console.WriteLine("\nИнформация о фигуре:");
        shape.DisplayInfo();

        Console.WriteLine("\nПериметр фигуры: " + shape.CalculatePerimeter());
        Console.WriteLine("Площадь фигуры: " + shape.CalculateArea());

        Console.WriteLine("\nВращение фигуры:");
        if (shape is IRotatable rotatableShape)
        {
            rotatableShape.Rotate();
        }
    }
}
