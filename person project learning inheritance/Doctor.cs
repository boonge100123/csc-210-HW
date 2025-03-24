using System;

class Doctor : Person
{
    private string _specialization;
    private string _hospital;

    public Doctor(string firstName, string lastName, int age, string specialization, string hospital) : base (firstName, lastName, age)
    {
        _specialization = specialization;
        _hospital = hospital;
    }

    public string GetPersonInfoWithSpecialization()
    {
        return $"information {_specialization}, Info: {GetPersonInfo()}";
    }

    public override string GetName()
    {
        return "Dr. " + base.GetName();
    }

    public override string GetHobbies()
    {
        return "I like to play golf";
    }
}