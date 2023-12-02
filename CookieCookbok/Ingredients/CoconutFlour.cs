namespace CookieCookbook.Ingredients;
class CoconutFlour : Ingredient
{
    public CoconutFlour() : base(2, "Coconut Flour") { }
    public override string Instructions() => "Sieve. Add to other ingredients.";
}