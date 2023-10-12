using UnityEngine;

namespace Infrastructure.AssetManagement
{
    public class AssetProvider : IAssets
    {
        public GameObject Instantiate(string prefabPath)
        {
            GameObject prefab = Resources.Load<GameObject>(prefabPath);
            return Object.Instantiate(prefab);
        }
    }
}