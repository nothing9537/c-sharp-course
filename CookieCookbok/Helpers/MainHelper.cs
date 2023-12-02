using CookieCookbok.DataAccess;
using CookieCookbook.DataAccess.BaseRepository;
using CookieCookbook.Types;

namespace CookieCookbook.Helpers;
class MainHelper
{
    private MainCookbook _cookbook;
    private ValidationHelper _validationHelper;
    private BaseRepository _repository;
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

                _cookbook.DisplayReceipt();

                return _cookbook.IngredientsId;
            }
        };
    }

    public void WriteReceiptToFile(List<int> data)
    {
        _repository.Write(_filePath, data);
    }
}

