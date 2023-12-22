var time = new Time(5, 12);

Console.WriteLine(time);

Console.ReadKey();

public struct Time
{
    public int Hour { get; }
    public int Minute { get; }

    public Time(int hour, int minute)
    {
        ValidateIncomeParams(hour, (hour) => hour > 0 || hour < 23);
        ValidateIncomeParams(minute, (minute) => minute > 0 || minute < 59);

        Hour = hour;
        Minute = minute;
    }

    private bool ValidateIncomeParams(int value, Func<int, bool> predicate, string message = "") => !predicate(value) ? throw new ArgumentOutOfRangeException(message) : true;

    public override string ToString() => $"{Hour.ToString("00")}:{Minute.ToString("00")}";
}