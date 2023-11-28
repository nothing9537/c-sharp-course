namespace Names_SRP.Formatter;

class NamesFormatter
{
    public string Format(List<string> names) => string.Join(Environment.NewLine, names);
}
