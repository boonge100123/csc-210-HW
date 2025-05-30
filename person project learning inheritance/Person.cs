abstract class Person
{
    private string _firstName;
    private string _lastName;
    private int _age;
    protected int _height;

    public Person(string firstName, string lastName, int age)
    {
        _firstName = firstName;
        _lastName = lastName;
        _age = age;
        _height = 0;
    }

    public int GetHeight()
    {
        return _height;
    }

    public void SetHeight(int height)
    {
        _height = height;
    }

    public string GetPersonInfo()
    {
        return $"information {_firstName} {_lastName} {_age}";
    }

    public virtual string GetName()
    {
        return _firstName + " " + _lastName;
    }

    public abstract string GetHobbies();
    }