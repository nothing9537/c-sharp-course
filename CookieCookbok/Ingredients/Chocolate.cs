namespace CookieCookbook.Ingredients;
class Chocolate : Ingredient
{
    public Chocolate() : base(4, "Butter") { }
    public override string Instructions() => "Melt in a water bath. Add to other ingredients.";
}