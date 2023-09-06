using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GF
{
    internal class Button : MonoBehaviour
    {
        public static readonly List<Button> Buttons = new();

        [field: SerializeField] public EInputMap Mapping { get; private set; }

        [SerializeField] private Image _image;

        public KeyCode MappingKeyCode => (KeyCode)Mapping;

        private void Awake()
        {
            if (!Buttons.Contains(this))
                Buttons.Add(this);

            if (Mapping is EInputMap.NO_MAPPING)
                Debug.LogWarning(nameof(EInputMap.NO_MAPPING), this);

            if (TryGetComponent(out Image image))
                _image = image;
        }

        private void Update()
        {
            if (Input.GetKeyDown(MappingKeyCode))
                Debug.Log(Mapping);

            _image.color = Input.GetKey(MappingKeyCode) ? Color.red : Color.white;
        }
    }
}