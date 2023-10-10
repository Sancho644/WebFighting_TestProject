using System;

namespace Data
{
    [Serializable]
    public class PlayerData
    {
        public string PlayerName;

        public void SetName(string name)
        {
            PlayerName = name;
        }
    }
}