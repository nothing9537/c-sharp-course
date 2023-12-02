namespace CookieCookbook.Helpers;

abstract class BaseHelper
{
    public MainCookbook rootCookbook;

    public BaseHelper(MainCookbook cookbook)
    {
        rootCookbook = cookbook;
    }
}
