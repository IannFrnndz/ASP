using System;

class A
{
    private int _x;
    public A(int x)
    {
        _x = x;

        //this._x = _x;
    }
    public virtual void Soy()
    {
        Console.WriteLine($"Soy la clase A y x vale {_x}");
    }
}

class B:A(int x ): base (x)
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