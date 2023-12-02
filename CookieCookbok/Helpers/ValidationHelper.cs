namespace CookieCookbook.Helpers;

class ValidationHelper : BaseHelper
{
    public ValidationHelper(MainCookbook cookbook) : base(cookbook) { }

    public bool IsUserInputMatchIngredientId(int id)
    {
        foreach (var ingredient in rootCookbook.AvailableIngredients)
        {
            if (ingredient.Id == id) return true;
        }

        return false;
    }

    public bool IsUserInputValidInt(string userInput, out int id)
    {
        bool isUserInputValidInt = int.TryParse(userInput, out id);

        if (!isUserInputValidInt)
        {
            return false;
        }

        return true;
    }
}
