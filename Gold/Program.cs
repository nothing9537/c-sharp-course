const int threshold = 30_000;

var goldPriceReader = new GoldPriceReader();

//public delegate void ReadPrice(decimal price); // custom event

bool areNotificationsEnabled = true;

if (areNotificationsEnabled)
{
    var emailPriceChangeNotifier = new EmailPriceChangeNotifier(threshold);
    var pushPriceChangeNotifier = new PushPriceChangeNotifier(threshold);

    goldPriceReader.ReadPrice += emailPriceChangeNotifier.Update; // both custom and pre-builded events
    goldPriceReader.ReadPrice += pushPriceChangeNotifier.Update; // both custom and pre-builded events

    for (int i = 0; i < 3; i++)
    {
        goldPriceReader.ReadCurrentPrice();
    }

    goldPriceReader.ReadPrice -= emailPriceChangeNotifier.Update;
    goldPriceReader.ReadPrice -= pushPriceChangeNotifier.Update;
}

public class ReadPriceEventArgs : EventArgs
{
    public decimal Price { get; }

    public ReadPriceEventArgs(decimal price)
    {
        Price = price;
    }
}

public class GoldPriceReader
{
    //public event ReadPrice? ReadPrice; // custom event
    public event EventHandler<ReadPriceEventArgs>? ReadPrice;

    public void ReadCurrentPrice()
    {
        decimal _currentGoldPrice = new Random().Next(20_000, 50_000);

        OnReadPrice(_currentGoldPrice);
    }

    private void OnReadPrice(decimal price)
    {
        ReadPrice?.Invoke(this, new ReadPriceEventArgs(price));
    }
}

public class EmailPriceChangeNotifier
{
    private readonly decimal _notificationThreshold;

    public EmailPriceChangeNotifier(decimal notificationThreshold)
    {
        _notificationThreshold = notificationThreshold;
    }

    public void Update(object? sender, ReadPriceEventArgs eventArgs) // Event will call it as delegate
    {
        if (eventArgs.Price > _notificationThreshold)
        {
            Console.WriteLine($"Sending an email saying that the gold price exceeded {_notificationThreshold} and now price is: {eventArgs.Price}\n");
        }
    }
}

public class PushPriceChangeNotifier
{
    private readonly decimal _notificationThreshold;

    public PushPriceChangeNotifier(decimal notificationThreshold)
    {
        _notificationThreshold = notificationThreshold;
    }

    public void Update(object? sender, ReadPriceEventArgs eventArgs) // Event will call it as delegate
    {
        if (eventArgs.Price > _notificationThreshold)
        {
            Console.WriteLine($"Sending a push notification that the gold price exceeded {_notificationThreshold} and now price is: {eventArgs.Price}\n");
        }
    }
}