using UnityEngine;

namespace Managers
{
    public class EntryPoint : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            MapManager.Instance.Initialize();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
