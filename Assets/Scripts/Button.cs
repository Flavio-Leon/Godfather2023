using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GF
{
    internal class Button : MonoBehaviour
    {
        public static readonly List<Button> Buttons = new();

        [field: SerializeField] public EInputMap Mapping { get; private set; }
        public KeyCode MappingKeyCode => (KeyCode)Mapping;

        [field: SerializeField] public Image Border { get; private set; }

        private Image _bg;

        private void Awake()
        {
            if (!Buttons.Contains(this))
                Buttons.Add(this);

            if (Mapping is EInputMap.NO_MAPPING)
                Debug.LogWarning(nameof(EInputMap.NO_MAPPING), this);

            if (TryGetComponent(out Image image))
                _bg = image;
        }

        private void Update()
        {
            if (Input.GetKeyDown(MappingKeyCode))
                Debug.Log(Mapping);

            _bg.color = Input.GetKey(MappingKeyCode) ? Color.red : Color.white;
        }
    }
}