using System;

public class  Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Cuantos años tiene?: ");
        int años = int.Parse(Console.ReadLine());

        int meses = años * 12;
        Console.WriteLine("Usted tiene " + meses + " meses");
    }
   
}