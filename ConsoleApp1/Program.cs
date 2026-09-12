using System;

int a;
int b;
int c;

Console.Write("Nhập a: ");

while (true)
{
    try
    {
        a = int.Parse(Console.ReadLine()!);
        break;
    }
    catch (Exception)
    {
        Console.WriteLine("Nhập sai, vui lòng nhập lại!");
        Console.Write("Nhập a: ");
    }
}


while (true)
{
    Console.Write("Nhập b: ");

    try
    {
        b = int.Parse(Console.ReadLine()!);
        break;
    }
    catch (Exception)
    {
        Console.WriteLine("Nhập sai, vui lòng nhập lại!");
    }
}

while (true)
{
    Console.Write("Nhập c: ");

    try
    {
        c = int.Parse(Console.ReadLine()!);
        break;
    }
    catch (Exception)
    {
        Console.WriteLine("Nhập sai, vui lòng nhập lại!");
    }
}

Console.WriteLine();
Console.WriteLine("KẾT QUẢ");
Console.WriteLine($"a = {a}");
Console.WriteLine($"b = {b}");
Console.WriteLine($"c = {c}");
