namespace CookieCookbook.Helpers;

class ValidationHelper : BaseHelper
{
    public ValidationHelper(MainCookbook cookbook) : base(cookbook) { }

    public bool IsUserInputMatchIngredientId(int id)
    {
        return rootCookbook.AvailableIngredients.Any(ingredient => ingredient.Id == id);
    }

    public bool IsUserInputValidInt(string userInput, out int id)
    {
        return int.TryParse(userInput, out id);
    }
}