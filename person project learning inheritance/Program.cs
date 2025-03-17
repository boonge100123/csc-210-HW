using System;


class Program
{
    public static void Main()
    {
        PoliceMan policeMan1 = new PoliceMan("John", "Doe", 25, "Gun");
        Console.WriteLine(policeMan1.DisplayPersonInfoWithItem());

        Doctor doctor1 = new Doctor("Jane", "Doe", 30, "Cardiologist", "General Hospital");
        Console.WriteLine(doctor1.DisplayPersonInfoWithSpecialization());
    }
}
