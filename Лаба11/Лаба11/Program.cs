using System;

public class Distance
{
    public int Feet { get; set; }
    public int Inches { get; set; }

    public Distance(int feet, int inches)
    {
        Feet = feet;
        Inches = inches;
    }

    public override string ToString()
    {
        return $"{Feet}'-{Inches}\"";
    }

    public static Distance operator +(Distance d1, Distance d2)
    {
        int totalInches = d1.Feet * 12 + d1.Inches + d2.Feet * 12 + d2.Inches;
        int feet = totalInches / 12;
        int inches = totalInches % 12;

        return new Distance(feet, inches);
    }

    public static Distance operator -(Distance d1, Distance d2)
    {
        int totalInches = d1.Feet * 12 + d1.Inches - (d2.Feet * 12 + d2.Inches);
        int feet = totalInches / 12;
        int inches = totalInches % 12;

        return new Distance(feet, inches);
    }

    public static bool operator ==(Distance d1, Distance d2)
    {
        return d1.Feet == d2.Feet && d1.Inches == d2.Inches;
    }

    public static bool operator !=(Distance d1, Distance d2)
    {
        return !(d1 == d2);
    }

    public static bool operator >(Distance d1, Distance d2)
    {
        return d1.Feet > d2.Feet || (d1.Feet == d2.Feet && d1.Inches > d2.Inches);
    }

    public static bool operator <(Distance d1, Distance d2)
    {
        return d1.Feet < d2.Feet || (d1.Feet == d2.Feet && d1.Inches < d2.Inches);
    }
}

class Program
{
    static void Main()
    {
        Distance distance1, distance2, distance3, distance4;

        Console.Write("Введите расстояние 1 (футы): ");
        if (int.TryParse(Console.ReadLine(), out int feet1) && feet1 >= 0)
        {
            Console.Write("Введите расстояние 1 (дюймы): ");
            if (int.TryParse(Console.ReadLine(), out int inches1) && inches1 >= 0)
            {
                distance1 = new Distance(feet1, inches1);

                Console.Write("Введите расстояние 2 (футы): ");
                if (int.TryParse(Console.ReadLine(), out int feet2) && feet2 >= 0)
                {
                    Console.Write("Введите расстояние 2 (дюймы): ");
                    if (int.TryParse(Console.ReadLine(), out int inches2) && inches2 >= 0)
                    {
                        distance2 = new Distance(feet2, inches2);

                        distance3 = distance1 + distance2;
                        distance4 = distance1 - distance2;

                        Console.WriteLine("Расстояние 1: {0}", distance1);
                        Console.WriteLine("Расстояние 2: {0}", distance2);
                        Console.WriteLine("Сумма: {0}", distance3);
                        Console.WriteLine("Разность: {0}", distance4);

                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Ошибка ввода. Введите корректное значение для дюймов.");
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка ввода. Введите корректное значение для футов.");
                }
            }
            else
            {
                Console.WriteLine("Ошибка ввода. Введите корректное значение для дюймов.");
            }
        }
        else
        {
            Console.WriteLine("Ошибка ввода. Введите корректное значение для футов.");
        }
    }
}
