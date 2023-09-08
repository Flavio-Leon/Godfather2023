using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using JSAM;

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

        //insert variable audio
        [SerializeField] private SoundFileObject _audio1;
        [SerializeField] private SoundFileObject _audio2;
        [SerializeField] private SoundFileObject _audio3;
        [SerializeField] private SoundFileObject _audio4;
        [SerializeField] private SoundFileObject _audio5;
        [SerializeField] private SoundFileObject _audio6;
        [SerializeField] private SoundFileObject _audio7;
        [SerializeField] private SoundFileObject _audio8;
        [SerializeField] private SoundFileObject _audio9;
        [SerializeField] private SoundFileObject _audio10;
        [SerializeField] private SoundFileObject _audio11;
        [SerializeField] private SoundFileObject _audio12;



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

            if (Sprite != null && 
                    Mapping != EInputMap.UP_PANNEL_WHITE_BUTTON_1 &&
                    Mapping != EInputMap.UP_PANNEL_WHITE_BUTTON_2 &&
                    Mapping != EInputMap.UP_PANNEL_WHITE_BUTTON_3 &&
                    Mapping != EInputMap.UP_PANNEL_WHITE_BUTTON_4 &&
                    Mapping != EInputMap.UP_PANNEL_WHITE_BUTTON_5 &&
                    Mapping != EInputMap.UP_PANNEL_WHITE_BUTTON_6)
            {
                Sprite.SetActive(false);
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(MappingKeyCode))
            {
                //marahere
                if (Mapping == EInputMap.UP_PANNEL_WHITE_BUTTON_1) {
                    //play sound
                    AudioManager.PlaySound(_audio1);

                }
                if (Mapping == EInputMap.UP_PANNEL_WHITE_BUTTON_2)
                {
                    //play sound
                    AudioManager.PlaySound(_audio2);
                }
                if (Mapping == EInputMap.UP_PANNEL_WHITE_BUTTON_3)
                {
                    //play sound
                    AudioManager.PlaySound(_audio3);
                }
                if (Mapping == EInputMap.UP_PANNEL_WHITE_BUTTON_4)
                {
                    //play sound
                    AudioManager.PlaySound(_audio4);
                }
                if (Mapping == EInputMap.UP_PANNEL_WHITE_BUTTON_5)
                {
                    //play sound
                    AudioManager.PlaySound(_audio5);
                }
                if (Mapping == EInputMap.UP_PANNEL_WHITE_BUTTON_6)
                {
                    //play sound
                    AudioManager.PlaySound(_audio6);
                }
                if (Mapping == EInputMap.UP_PANNEL_LEFT_YELLOW)
                {
                    //play sound
                    AudioManager.PlaySound(_audio7);
                }
                if (Mapping == EInputMap.UP_PANNEL_LEFT_RED)
                {
                    //play sound
                    AudioManager.PlaySound(_audio8);
                }
                if (Mapping == EInputMap.UP_PANNEL_LEFT_GREEN)
                {
                    //play sound
                    AudioManager.PlaySound(_audio9);
                }
                if (Mapping == EInputMap.UP_PANNEL_LEFT_BLUE)
                {
                    //play sound
                    AudioManager.PlaySound(_audio10);
                }
                if (Mapping == EInputMap.UP_PANNEL_RIGHT_RED)
                {
                    //play sound
                    AudioManager.PlaySound(_audio11);
                }
                if (Mapping == EInputMap.UP_PANNEL_RIGHT_BLUE)
                {
                    //play sound
                    AudioManager.PlaySound(_audio12);
                }


                //Debug.Log(Mapping);

                _lastColor = Background.color;
                Background.color = Color.green;
                if (Sprite != null && 
                    Mapping != EInputMap.UP_PANNEL_WHITE_BUTTON_1 &&
                    Mapping != EInputMap.UP_PANNEL_WHITE_BUTTON_2 &&
                    Mapping != EInputMap.UP_PANNEL_WHITE_BUTTON_3 &&
                    Mapping != EInputMap.UP_PANNEL_WHITE_BUTTON_4 &&
                    Mapping != EInputMap.UP_PANNEL_WHITE_BUTTON_5 &&
                    Mapping != EInputMap.UP_PANNEL_WHITE_BUTTON_6)
                {
                    Sprite?.SetActive(true);
                }
            }
            else if (Input.GetKeyUp(MappingKeyCode))
            {
                if (Sprite != null &&
                    Mapping != EInputMap.UP_PANNEL_WHITE_BUTTON_1 &&
                    Mapping != EInputMap.UP_PANNEL_WHITE_BUTTON_2 &&
                    Mapping != EInputMap.UP_PANNEL_WHITE_BUTTON_3 &&
                    Mapping != EInputMap.UP_PANNEL_WHITE_BUTTON_4 &&
                    Mapping != EInputMap.UP_PANNEL_WHITE_BUTTON_5 &&
                    Mapping != EInputMap.UP_PANNEL_WHITE_BUTTON_6)
                {
                    Sprite?.SetActive(false);
                }
                Background.color = DefaultColor;
            }

            if (Sprite != null &&
                    Mapping == EInputMap.UP_PANNEL_WHITE_BUTTON_1 ||
                    Mapping == EInputMap.UP_PANNEL_WHITE_BUTTON_2 ||
                    Mapping == EInputMap.UP_PANNEL_WHITE_BUTTON_3 ||
                    Mapping == EInputMap.UP_PANNEL_WHITE_BUTTON_4 ||
                    Mapping == EInputMap.UP_PANNEL_WHITE_BUTTON_5 ||
                    Mapping == EInputMap.UP_PANNEL_WHITE_BUTTON_6)
            {
                Sprite.SetActive(!IsBusy);
            }
        }
    }
}