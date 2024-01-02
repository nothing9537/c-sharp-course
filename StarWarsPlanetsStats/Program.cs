using StarWarsPlanetsStats;
using StarWarsPlanetsStats.API;
using StarWarsPlanetsStats.Transforms;
using StarWarsPlanetsStats.Types;
using StarWarsPlanetsStats.UniversalPrinter;

var baseUrl = "https://swapi.dev/api/";
var queryUrl = "planets";
string[] availableOptions = ["populations", "diameter", "surface water"];

var apiCaller = new APICaller();
var data = await apiCaller.Fetch<PlanetsResponse>(baseUrl, queryUrl);
var transformedData = MainTransform.TransformToSubset(data.results);
var printer = new UniversalPrinter(16);

printer.Print(transformedData);

var statistics = new Statistics(transformedData, availableOptions);
statistics.DisplayStatistics();

Console.ReadKey();