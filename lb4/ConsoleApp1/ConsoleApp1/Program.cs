
class TCircle
{
    protected double radius;

    public TCircle()
    {
        radius = 0;
    }

    public TCircle(double r)
    {
        radius = r; 
    }

    public TCircle(TCircle circle)
    {
        radius = circle.radius;
    }

    public virtual void Input_Val()
    {
        Console.Write("Змiнити радiус: "); 
        radius = Convert.ToDouble(Console.ReadLine());
    }

    public void Out_Val()
    {
        Console.WriteLine($"Радiус кола: {radius}");
    }

    public double Area()
    {
        return Math.PI * radius * radius;
    }
    public double Circumference() 
    {
        return 2 * Math.PI * radius;
    }

    public bool CompareWith(TCircle otherCircle)
    {
        return this.radius == otherCircle.radius;
    }

    public static TCircle operator +(TCircle circle1, TCircle circle2)
    {
        return new TCircle(circle1.radius + circle2.radius);
    }

    public static TCircle operator -(TCircle circle1, TCircle circle2)
    {
        return new TCircle(circle1.radius - circle2.radius);
    }

    public static TCircle operator *(TCircle circle, double factor)
    {
        return new TCircle(circle.radius * factor);
    }
}

class TCylinder : TCircle
{
    private double height;

    public TCylinder() : base()
    {
        height = 0;
    }

    public TCylinder(double r, double h) : base(r)
    {
        height = h;
    }

    public TCylinder(TCylinder cylinder) : base(cylinder)
    {
        height = cylinder.height;
    }

    public override void Input_Val()
    {
        base.Input_Val();
        Console.Write("Змiнити висоту цилiндру: ");
        height = Convert.ToDouble(Console.ReadLine());
    }

    public new void Out_Val()
    {
        base.Out_Val();
        Console.WriteLine($"Висота цилiндра: {height}");
    }

    public double Volume() 
    {
        return base.Area() * height;
    }
}

class Program
{
    static void Main()
    {
        TCircle circle1 = new TCircle(5);
        TCircle circle2 = new TCircle(7);

        TCircle circle3 = circle1 + circle2;
        TCircle circle4 = circle1 - circle2;
        TCircle circle5 = circle1 * 2;

        Console.Write("Circle1: "); 
        circle1.Out_Val();
        Console.Write("Circle2: ");
        circle2.Out_Val();
        Console.Write("Circle3: ");
        circle3.Out_Val();

        if(circle1.CompareWith(circle3))
        {
            Console.WriteLine("cirlce1 == circle3"); 
        }
        else
        {
            Console.WriteLine("cirlce != circle3"); 
        }

        TCylinder cylinder = new TCylinder(4.0,5.0);
        cylinder.Out_Val();
        double x = cylinder.Volume();
        Console.WriteLine($"V = {x}"); 
        Console.ReadLine();
    }
}
