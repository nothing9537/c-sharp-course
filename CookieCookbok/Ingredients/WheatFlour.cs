namespace CookieCookbook.Ingredients;
class WheatFlour : Ingredient
{
    public WheatFlour() : base(1, "Wheat Flour") { }
    public override string Instructions() => "Sieve. Add to other ingredients.";
}
