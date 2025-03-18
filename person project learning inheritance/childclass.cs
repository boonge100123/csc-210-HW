class PoliceMan : Person
{
    private string _weapon;

    public PoliceMan(string firstName, string lastName, int age, string weapon) : base (firstName, lastName, age)
    {
        _weapon = weapon;
    }

    public string DisplayPersonInfoWithItem()
    {
        return $"information {_weapon}, Info: {DisplayPersonInfo()}";
    }
}