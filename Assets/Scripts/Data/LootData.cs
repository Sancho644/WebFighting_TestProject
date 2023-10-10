using System;

namespace Data
{
    [Serializable]
    public class LootData
    {
        public int Collected;
        public Action Changed;

        public void Add(int value)
        {
            Collected += value;
            Changed?.Invoke();
        }
    }
}