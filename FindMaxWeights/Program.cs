public static class Exercise
{
    public static Dictionary<PetType, double> FindMaxWeights(List<Pet> pets)
    {
        var res = new Dictionary<PetType, double>();
        var temp = new Dictionary<PetType, List<double>>();

        foreach (var pet in pets)
        {
            if (!temp.ContainsKey(pet.PetType))
            {
                temp[pet.PetType] = new List<double> { pet.Weight };
            }

            temp[pet.PetType].Add(pet.Weight);
        }

        foreach (var tempPet in temp)
        {
            res.Add(tempPet.Key, tempPet.Value.Max());
        }

        return res;
    }
}

public class Pet
{
    public PetType PetType { get; }
    public double Weight { get; }

    public Pet(PetType petType, double weight)
    {
        PetType = petType;
        Weight = weight;
    }

    public override string ToString() => $"{PetType}, {Weight} kilos";
}

public enum PetType { Dog, Cat, Fish }