namespace CookieCookbook;
public abstract class Ingredient
{
    public int Id { get; private set; }
    public string Name { get; private set; }

    public Ingredient(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public abstract string Instructions();
}