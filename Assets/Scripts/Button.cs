using System.Collections.Generic;
using TMPro;
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

        [field: SerializeField] public TextMeshProUGUI Text { get; private set; }
        public string DefaultText { get; private set; }

        [field: SerializeField] public bool IsBusy { get; set; }
        public GameObject Sprite;

        private Color _lastColor;

        //mara here

        private void Awake()
        {
            if (!Buttons.Contains(this))
                Buttons.Add(this);

            if (Mapping is EInputMap.NO_MAPPING)
                Debug.LogWarning(nameof(EInputMap.NO_MAPPING), this);

            _lastColor = Background.color;
            DefaultColor = _lastColor;

            Text.text = MappingKeyCode.ToString().Replace("Alpha", string.Empty).Replace("Arrow", string.Empty);
            DefaultText = Text.text;

            if (Sprite != null)
            {
                Sprite.SetActive(false);
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(MappingKeyCode))
            {
                //marahere
                if (Mapping == EInputMap.UP_PANNEL_WHITE_BUTTON_1) { }


                //Debug.Log(Mapping);

                _lastColor = Background.color;
                Background.color = Color.green;
                if (Sprite != null)
                {
                    Sprite?.SetActive(true);
                }
            }
            else if (Input.GetKeyUp(MappingKeyCode))
            {
                if (Sprite != null)
                {
                    Sprite?.SetActive(false);
                }
                Background.color = DefaultColor;
            }
        }
    }
}