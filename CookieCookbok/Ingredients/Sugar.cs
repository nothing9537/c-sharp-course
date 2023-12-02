namespace CookieCookbook.Ingredients;
class Sugar : Ingredient
{
    public Sugar() : base(5, "Sugar") { }
    public override string Instructions() => "Add to other ingredients.";
}