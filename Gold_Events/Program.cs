const int threshold = 30_000;

var emailPriceChangeNotifier = new EmailPriceChangeNotifier(threshold);
var pushPriceChangeNotifier = new PushPriceChangeNotifier(threshold);
var goldPriceReader = new GoldPriceReader();

goldPriceReader.AttachObserver([emailPriceChangeNotifier, pushPriceChangeNotifier]);

Console.WriteLine("Before detach");

for (var i = 0; i < 3; i++)
{
    goldPriceReader.ReadCurrentPrice();
}

Console.WriteLine("After detach");

goldPriceReader.DetachObserver(emailPriceChangeNotifier);

for (var i = 0; i < 3; i++)
{
    goldPriceReader.ReadCurrentPrice();
}

Console.ReadKey();

public class GoldPriceReader : IObservable<decimal>
{
    private int _currentGoldPrice;
    private List<IObserver<decimal>> _observers = new();

    public void ReadCurrentPrice()
    {
        _currentGoldPrice = new Random().Next(20_000, 50_000);

        NotifyObservers();
    }

    public void AttachObserver(IObserver<decimal> observer)
    {
        _observers.Add(observer);
    }

    public void DetachObserver(IObserver<decimal> observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.Update(_currentGoldPrice);
        }
    }

    public void AttachObserver(IEnumerable<IObserver<decimal>> observers)
    {
        foreach (var observer in observers)
        {
            AttachObserver(observer);
        }
    }

    public void DetachObserver(IEnumerable<IObserver<decimal>> observers)
    {
        foreach (var observer in observers)
        {
            DetachObserver(observer);
        }
    }
}

public class EmailPriceChangeNotifier : IObserver<decimal>
{
    private readonly decimal _notificationThreshold;

    public EmailPriceChangeNotifier(decimal notificationThreshold)
    {
        _notificationThreshold = notificationThreshold;
    }

    public void Update(decimal price)
    {
        if (price > _notificationThreshold)
        {
            Console.WriteLine($"Sending an email saying that the gold price exceeded {_notificationThreshold} and now price is: {price}\n");
        }
    }
}

public class PushPriceChangeNotifier : IObserver<decimal>
{
    private readonly decimal _notificationThreshold;

    public PushPriceChangeNotifier(decimal notificationThreshold)
    {
        _notificationThreshold = notificationThreshold;
    }

    public void Update(decimal price)
    {
        if (price > _notificationThreshold)
        {
            Console.WriteLine($"Sending a push notification that the gold price exceeded {_notificationThreshold} and now price is: {price}\n");
        }
    }
}

public interface IObserver<TPayload>
{
    void Update(TPayload data);
}

public interface IObservable<TPayload>
{
    void AttachObserver(IObserver<TPayload> observer);
    void AttachObserver(IEnumerable<IObserver<TPayload>> observers);
    void DetachObserver(IObserver<TPayload> observer);
    void DetachObserver(IEnumerable<IObserver<TPayload>> observers);
    void NotifyObservers();
}