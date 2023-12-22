var time = new Time(5, 12);

Console.WriteLine(time);

Console.ReadKey();

public struct Time : IEquatable<Time>
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

    public bool Equals(Time other)
    {
        return Hour == other.Hour && Minute == other.Minute;
    }

    public override bool Equals(object? obj)
    {
        return obj is Time time && Equals(time);
    }

    public static bool operator ==(Time a, Time b) => a.Equals(b);
    public static bool operator !=(Time a, Time b) => !a.Equals(b);
    public static Time operator +(Time a, Time b)
    {
        var newMinutes = a.Minute + b.Minute;
        var newHours = a.Hour + b.Hour;

        if (newMinutes > 59)
        {
            newMinutes -= 60;
            newHours++;
        }

        if (newHours > 23)
        {
            newHours -= 24;
        }

        return new Time(newHours, newMinutes);
    }
}