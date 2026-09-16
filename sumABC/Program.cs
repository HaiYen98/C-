using System;

class Program
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        double A = 0;
        double B = 0;
        double C = 0;

        Console.Write("Nhập vào số A: ");
        A = double.Parse(Console.ReadLine()!);

        Console.Write("Nhập vào số B: ");
        B = double.Parse(Console.ReadLine()!);

        Console.Write("Nhập vào số C: ");
        C = double.Parse(Console.ReadLine()!);

        double sum = A + B + C;

        Console.WriteLine("Tổng của A + B + C là: {0}", sum);

        Console.WriteLine("Nhập phím bất kỳ để thoát");
        Console.ReadKey();
    }
}
