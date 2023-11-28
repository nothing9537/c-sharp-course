var accountState = new DailyAccountState(2000, 200);

Console.WriteLine(accountState.EndOfDayState);
Console.WriteLine(accountState.Report);

Console.ReadKey();

public class DailyAccountState
{
    public int InitialState { get; }

    public int SumOfOperations { get; }

    public DailyAccountState(int initialState, int sumOfOperations)
    {
        InitialState = initialState;
        SumOfOperations = sumOfOperations;
    }

    public int EndOfDayState => InitialState + SumOfOperations;
    public string Report => $"Day: {DateTime.Now.Day}, " +
        $"month: {DateTime.Now.Month}, " +
        $"year: {DateTime.Now.Year}, " +
        $"initial state: {InitialState}, " +
        $"end of day state: {EndOfDayState}";
}