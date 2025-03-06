//c#

class Cylinder
{
    // **Fields** (private variables that store cylinder data)
    private double height;
    private Circle circle; // Composition: Cylinder has a Circle

    // **Constructor** (initializes the cylinder with height and a base circle)
    public Cylinder(double h, Circle circle)
    {
        height = h;
        this.circle = circle;
    }

    // **Method** (calculates the volume of the cylinder)
    public double GetVolume()
    {
        return height * circle.GetArea();
    }

    // **Property** (for safely getting and setting height)
    public double Height
    {
        get { return height; }
        set { height = value; } // Allows updating the height
    }
}