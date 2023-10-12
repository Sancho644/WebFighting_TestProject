using UnityEngine;

namespace Infrastructure.Services.Randomizer
{
    public class RandomService : IRandomService
    {
        public int Next(int minValue, int maxValue)
        {
            return Random.Range(minValue, maxValue);
        }
    }
}