using CookieCookbok.DataAccess;
using CookieCookbook.DataAccess.BaseRepository;
using CookieCookbook.Types;

namespace CookieCookbook.Helpers;
class MainHelper
{
    private MainCookbook _cookbook;
    private ValidationHelper _validationHelper;
    private IBaseRepository _repository;
    private string _filePath;
    public MainHelper(MainCookbook cookbook, FileFormat fileFormat, string filePath)
    {
        _filePath = filePath;
        _cookbook = cookbook;
        _validationHelper = new ValidationHelper(cookbook);
        _repository = fileFormat == FileFormat.JSON
            ? new JSONTextualRepository()
            : new StringsTextualRepository();
    }

    public List<int> WriteToCookbook()
    {
        while (true)
        {
            Console.WriteLine("Add an ingredient by it's Id or type anything else when finished.");

            _validationHelper.IsUserInputValidInt(Console.ReadLine()!, out int id);
            bool isUserInputMatchIngredientId = _validationHelper.IsUserInputMatchIngredientId(id);

            if (isUserInputMatchIngredientId)
            {
                _cookbook.IngredientsId.Add(id);
            }
            else
            {
                Console.WriteLine(_cookbook.IngredientsId.Count == 0
                    ? "No ingredients have been selected. Recipe will not be saved."
                    : "Recipe added:"
                    );

                DisplayReceipt(_cookbook.IngredientsId);

                return _cookbook.IngredientsId;
            }
        };
    }

    private void DisplayReceipt(List<int> ids)
    {
        foreach (var id in ids)
        {
            var ingredient = _cookbook.AvailableIngredients.Find(ingredient => ingredient.Id == id);
            Console.WriteLine($"{ingredient?.Name}. {ingredient?.Instructions()}");
        }
    }

    public void WriteReceiptToFile(List<int> data)
    {
        _repository.Write(_filePath, data);
    }

    public void DisplayReceiptsFromFile()
    {
        var receipts = _repository.Read(_filePath);

        if (receipts.Count != 0)
        {
            Console.WriteLine("Existing receipts are:\n");

            for (int i = 0; i < receipts.Count; i++)
            {
                string receipt = receipts[i];
                Console.WriteLine($"***** {i + 1} *****");

                List<int> strIds = receipt.Split(",").ToList().ConvertAll(int.Parse);

                DisplayReceipt(strIds);

                Console.WriteLine("\n");
            }
        }
    }
}

