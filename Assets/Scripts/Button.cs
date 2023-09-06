using UnityEngine;

namespace GF
{
    internal class Button : MonoBehaviour
    {
        [field: SerializeField] public EInputMap Mapping { get; private set; }

        private void Awake()
        {
            if (Mapping is EInputMap.NO_MAPPING)
                Debug.LogWarning(nameof(EInputMap.NO_MAPPING), this);
        }

        private void Update()
        {
            if (Input.GetKeyDown((KeyCode)Mapping))
                Debug.Log(Mapping);
        }
    }
}