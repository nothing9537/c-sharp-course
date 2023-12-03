namespace CookieCookbook.Ingredients;
class Chocolate : Ingredient
{
    public Chocolate() : base(4, "Chocolate") { }
    public override string Instructions() => "Melt in a water bath. Add to other ingredients.";
}