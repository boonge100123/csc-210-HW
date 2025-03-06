using System;
class Program
{
    static void Main(string[] args)
    {
        // Create a Circle object
        Circle myCircle = new Circle(10);

        // Display the properties and methods of the Circle object
        Console.WriteLine($"Radius: {myCircle.Radius}");
        Console.WriteLine($"Area: {myCircle.GetArea()}");
        Console.WriteLine($"Circumference: {myCircle.GetCircumference()}");
        Console.WriteLine($"Diameter: {myCircle.GetDiameter()}");

    Cyilnder myCyilnder = new Cyilnder(10, myCircle);
    double volume = myCyilnder.GetVolume();
    Console.WriteLine($"The cyilnder volue is: {volume}");
    }
}