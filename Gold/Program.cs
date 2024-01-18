const int threshold = 30_000;

var emailPriceChangeNotifier = new EmailPriceChangeNotifier(threshold);
var pushPriceChangeNotifier = new PushPriceChangeNotifier(threshold);

var goldPriceReader = new GoldPriceReader();

goldPriceReader.ReadPrice += emailPriceChangeNotifier.Update;
goldPriceReader.ReadPrice += pushPriceChangeNotifier.Update;

public delegate void ReadPrice(decimal price);

public class GoldPriceReader
{
    public event ReadPrice? ReadPrice; // event

    public void ReadCurrentPrice()
    {
        decimal _currentGoldPrice = new Random().Next(20_000, 50_000);

        OnReadPrice(_currentGoldPrice);
    }

    private void OnReadPrice(decimal price)
    {
        ReadPrice?.Invoke(price);
    }
}

public class EmailPriceChangeNotifier
{
    private readonly decimal _notificationThreshold;

    public EmailPriceChangeNotifier(decimal notificationThreshold)
    {
        _notificationThreshold = notificationThreshold;
    }

    public void Update(decimal price) // Event will call it as delegate
    {
        if (price > _notificationThreshold)
        {
            Console.WriteLine($"Sending an email saying that the gold price exceeded {_notificationThreshold} and now price is: {price}\n");
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

    public void Update(decimal price) // Event will call it as delegate
    {
        if (price > _notificationThreshold)
        {
            Console.WriteLine($"Sending a push notification that the gold price exceeded {_notificationThreshold} and now price is: {price}\n");
        }
    }
}