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

    public string DisplayPersonInfoWithSpecialization()
    {
        return $"information {_specialization}, Info: {DisplayPersonInfo()}";
    }
}