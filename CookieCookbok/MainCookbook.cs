using CookieCookbook.Helpers;
using CookieCookbook.Ingredients;
using CookieCookbook.Types;

namespace CookieCookbook;

class MainCookbook
{
    public List<int> IngredientsId = new List<int>();
    public List<Ingredient> AvailableIngredients { get; init; }

    private string _filePath;
    private FileFormat _readWriteFileFormat;
    private MainHelper _helper;
    public MainCookbook(FileFormat fileFormat, string filePath)
    {
        _filePath = filePath;
        _readWriteFileFormat = fileFormat;
        AvailableIngredients = new List<Ingredient>
        {
            new WheatFlour(),
            new CoconutFlour(),
            new Butter(),
            new Chocolate(),
            new Sugar(),
            new Cardamon(),
            new Cinnamon(),
            new CocaPowder(),
        };
    }

    public void Init()
    {
        _helper = new MainHelper(this, _readWriteFileFormat, _filePath);
        _helper.DisplayReceiptsFromFile();

        DisplayAvailabelIngredients();

        _helper.ReadAndValidateUserInput();
        _helper.WriteReceiptToFile(IngredientsId);
    }

    public void DisplayAvailabelIngredients()
    {
        Console.WriteLine("Create new cookie recipe! Available ingredients are:");

        foreach (var ingredient in AvailableIngredients)
        {
            Console.WriteLine($"{ingredient.Id}. {ingredient.Name}");
        }
    }
}
