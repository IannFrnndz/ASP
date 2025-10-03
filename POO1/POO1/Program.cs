using System;

class A
{
    public virtual void Soy()
    {
        Console.WriteLine("Soy la clase A");
    }
}

class B:A
{
    public override void Soy()
    {
        Console.WriteLine("Soy la clase B");
    }
}
public class  Programa
{
    public static void Main()
    {
        new A().Soy();
        new B().Soy();

        A a = new B();
        a.Soy();
    }
}