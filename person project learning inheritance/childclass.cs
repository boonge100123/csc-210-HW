class PoliceMan : Person
{
    private string _weapon;

    public PoliceMan(string firstName, string lastName, int age, string weapon) : base (firstName, lastName, age)
    {
        _weapon = weapon;
    }

    public string GetPoliceManInfo()
    {
        return $"information {_weapon}, Info: {GetPersonInfo()}";
    }

    public override string GetName()
    {
        return "Officer " + base.GetName();
    }

    public override string GetHobbies()
    {
        return "I like to play basketball";
    }
}