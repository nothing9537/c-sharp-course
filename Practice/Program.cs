public class Exercise
{
    public List<int> GetCountsOfAnimalsLegs()
    {
        var animals = new List<Animal>
            {
                new Lion(),
                new Tiger(),
                new Duck(),
                new Spider()
            };

        var result = new List<int>();

        foreach (var animal in animals)
        {
            result.Add(animal.NumberOfLegs);
        }

        return result;
    }

    public class Animal
    {
        public virtual int NumberOfLegs { get; set; } = 4;
    }

    public class Lion : Animal
    {

    }

    public class Tiger : Animal
    {

    }

    public class Duck : Animal
    {
        public override int NumberOfLegs { get; set; } = 2;
    }
    public class Spider : Animal
    {
        public override int NumberOfLegs { get; set; } = 8;
    }
}