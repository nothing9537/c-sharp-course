namespace CookieCookbook.Ingredients;
class CocaPowder : Ingredient
{
    public CocaPowder() : base(8, "Cocoa powder") { }
    public override string Instructions() => "Add to other ingredients.";
}