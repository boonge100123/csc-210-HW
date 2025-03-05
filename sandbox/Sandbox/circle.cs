// c#
using System;

class Circle
{
    private double radius;

    public Circle(double r)
    {
        radius = r;
    }

    public double Radius
    {
        get { return radius; }
        set { radius = value; }
    }

    public double GetArea()
    {
        return Math.PI * (radius * radius);
    }

    public double GetDiameter()
    {
        return radius * 2;
    }

    public double GetCircumference()
    {
        return 2 * Math.PI * radius;
    }

    public void SetRadius(double r)
    {
        radius = r;
    }
}
