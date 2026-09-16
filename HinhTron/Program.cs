using System;

class Program
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        double banKinh = 0;

        Console.Write("Nhập vào bán kính hình tròn (m): ");
        banKinh = double.Parse(Console.ReadLine()!);

        double chuVi = 2 * Math.PI * banKinh;
        double dienTich = Math.PI * banKinh * banKinh;

        Console.WriteLine("Chu vi hình tròn là: {0}", chuVi);
        Console.WriteLine("Diện tích hình tròn là: {0}", dienTich);

        Console.WriteLine("Nhập phím bất kỳ để thoát");
        Console.ReadKey();
    }
}
