using UnityEngine;

namespace GF
{
    internal class EventPool : MonoBehaviour
    {
        public static EventPool Instance { get; private set; }

        [field: SerializeField] public float GameSpeed { get; private set; }

        private void Awake() => Instance = this;

        public void Begin()
        {
        }
    }
}