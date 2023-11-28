using Names_SRP.Validator;

class Names
{
    public List<string> AllNames { get; } = new List<string>();
    private readonly NamesValidator _namesValidator = new NamesValidator();

    public void AddName(string name)
    {
        if (_namesValidator.IsValid(name))
        {
            AllNames.Add(name);
        }
    }
    public void AddNames(List<string> stringsFromFile)
    {
        foreach (var name in stringsFromFile)
        {
            AddName(name);
        }
    }
}