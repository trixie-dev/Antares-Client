using DefaultNamespace;
using UnityEngine;

namespace Units
{
    public class BaseUnit : MonoBehaviour
    {
        public UnitStats Stats { get; private set; }

        protected virtual void Initialize()
        {
            
        }
    }
}