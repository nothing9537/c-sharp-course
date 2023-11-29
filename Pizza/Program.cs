using Pizza.Extensions;

string multilineString = @"this
is
a
multi
line
string";

Console.WriteLine(multilineString.LinesCount());

public abstract class Ingredient
{
    public virtual string Name { get; } = "Some ingredient";
}

public class PizzaFood : Ingredient
{
    private readonly List<Ingredient> _ingridients = new List<Ingredient>();

    public void AddIngredient(Ingredient ingridient) => _ingridients.Add(ingridient);
    public string Describe() => $"This is z pizza with {string.Join(", ", _ingridients)}";
}

public class Cheddar : Ingredient
{
    override public string Name => "Cheddar cheese";
    public int AgedForMonths { get; }
}

public class TomatoSauce : Ingredient
{
    override public string Name => "Tomato sauce";
    public int TomatoesIn100Grams { get; }

}

public class Mozzarella : Ingredient
{
    override public string Name => "Mozzarella";
    public bool IsLight { get; }
}