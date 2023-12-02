namespace CookieCookbook.Ingredients;
class Butter : Ingredient
{
    public Butter() : base(3, "Butter") { }
    public override string Instructions() => "Melt on low heat. Add to other ingredients.";
}
