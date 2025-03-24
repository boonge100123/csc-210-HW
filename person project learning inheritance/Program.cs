using System;


class Program
{
    public static void Main()
    {
        // PoliceMan policeMan1 = new PoliceMan("John", "Doe", 25, "Gun");
        // Console.WriteLine(policeMan1.GetPoliceManInfo());

        // Doctor doctor1 = new Doctor("Jane", "Doe", 30, "Cardiologist", "General Hospital");
        // Console.WriteLine(doctor1.DisplayPersonInfoWithSpecialization());

        // policeMan1.SetHeight(73);
        // Console.WriteLine(policeMan1.GetHeight());

        // doctor1.SetHeight(70);
        // Console.WriteLine(doctor1.GetHeight());

        PoliceMan policeMan2 = new PoliceMan("John", "Doe", 25, "Gun");
        Console.WriteLine(policeMan2.GetName());
        Console.WriteLine(policeMan2.GetHobbies());

        Doctor doctor2 = new Doctor("Jane", "Doe", 30, "Cardiologist", "General Hospital");
        Console.WriteLine(doctor2.GetName());
        Console.WriteLine(doctor2.GetHobbies());

    }
}
