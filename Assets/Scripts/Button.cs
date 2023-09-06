using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GF
{
    internal class Button : MonoBehaviour
    {
        public static readonly List<Button> Buttons = new();

        public Color DefaultColor { get; private set; }

        [field: SerializeField] public EInputMap Mapping { get; private set; }
        public KeyCode MappingKeyCode => (KeyCode)Mapping;

        [field: SerializeField] public Image Border { get; private set; }
        [field: SerializeField] public Image Background { get; private set; }
        [field: SerializeField] public Image InnerTimer { get; private set; }

        private Color _lastColor;

        private void Awake()
        {
            if (!Buttons.Contains(this))
                Buttons.Add(this);

            if (Mapping is EInputMap.NO_MAPPING)
                Debug.LogWarning(nameof(EInputMap.NO_MAPPING), this);

            _lastColor = Background.color;
            DefaultColor = _lastColor;
        }

        private void Update()
        {
            if (Input.GetKeyDown(MappingKeyCode))
            {
                //Debug.Log(Mapping);

                _lastColor = Background.color;
                Background.color = Color.green;
            }
            else if (Input.GetKeyUp(MappingKeyCode))
                Background.color = DefaultColor;
        }
    }
}