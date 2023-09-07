using System.Collections;
using System.Linq;
using UnityEngine;

namespace GF
{
    internal class SequenceEvent: Event, IEvent
    {
        [SerializeField] private Color _defaultBorderColor;
        [SerializeField] private Color _eventBorderColor;

        [SerializeField] private float _timerStart;
        [SerializeField] private float _timerLeft;

        private Button _button1;
        private Button _button2;
        private Button _button3;
        private Button _button4;
        private Button _button5;

        private int _assignCount;
        private int _signalIt;
        public float SequenceTimer;

        private void Awake()
        {
            _button1 = GetButton();
            _button1.IsBusy = true;
            _button2 = GetButton();
            _button2.IsBusy = true;
            _button3 = GetButton();
            _button3.IsBusy = true;
            _button4 = GetButton();
            _button4.IsBusy = true;
            _button5 = GetButton(); 
            _button5.IsBusy = true; 
            InitTimer();
            SetState();
        }

        private void Update()
        {
            if (Input.GetKeyDown(_button1.MappingKeyCode))
            {
                if (Input.GetKeyDown(_button2.MappingKeyCode) )
                {
                    if (Input.GetKeyDown(_button3.MappingKeyCode ))
                    {
                        if (Input.GetKeyDown(_button4.MappingKeyCode) )
                        {
                            if (Input .GetKeyDown(_button5.MappingKeyCode) ) 
                            {
                                StartCoroutine(Win());
                            }
                        }
                    }
                }
            }
            if (_timerStart <= 0f)
            {
                StartCoroutine(Lose());
            }

            _timerStart -= Time.deltaTime;
        }

        private Button GetButton()
        {
            var index = Random.Range(0, Button.Buttons.Count);

            var button = Button.Buttons.ElementAtOrDefault(index);

            if (button.IsBusy)
            {
                if (_assignCount <= Button.Buttons.Count)
                {
                    _assignCount++;
                  return  GetButton();
                }

                Destroy(gameObject);

            }

            return button;
        }

        private void InitTimer()
        {
            _timerStart = SequenceTimer * 1 / EventPool.Instance.GameSpeed;
        }

        private void SetState()
        {

            _button1.Border.color = _eventBorderColor;
            _button2.Border.color = _eventBorderColor;
            _button3.Border.color = _eventBorderColor;
            _button4.Border.color = _eventBorderColor;
            _button5.Border.color = _eventBorderColor;

            _button1.InnerTimer.enabled = true;
            _button2.InnerTimer.enabled = true;
            _button3.InnerTimer.enabled = true;
            _button4.InnerTimer.enabled = true;
            _button5.InnerTimer.enabled = true;

            _button1.Text.text = _timerStart.ToString("0.0");
            _button2.Text.text = _timerStart.ToString("0.0");
            _button3.Text.text = _timerStart.ToString("0.0");
            _button4.Text.text = _timerStart.ToString("0.0");
            _button5.Text.text = _timerStart.ToString("0.0");
        }

        private void ResetState()
        {
            _button1.IsBusy = false;
            _button2.IsBusy = false;
            _button3.IsBusy = false;
            _button4.IsBusy = false;
            _button5.IsBusy = false;

            _button1.Border.color = _defaultBorderColor;
            _button2.Border.color = _defaultBorderColor;
            _button3.Border.color = _defaultBorderColor;
            _button4.Border.color = _defaultBorderColor;
            _button5.Border.color = _defaultBorderColor;

            _button1.Border.fillAmount = 1;
            _button2.Border.fillAmount = 1;
            _button3.Border.fillAmount = 1;
            _button4.Border.fillAmount = 1;
            _button5.Border.fillAmount = 1;

            _button1.Background.color = _button1.DefaultColor;
            _button2.Background.color = _button2.DefaultColor;
            _button3.Background.color = _button3.DefaultColor;
            _button4.Background.color = _button4.DefaultColor;
            _button5.Background.color = _button5.DefaultColor;

            _button1.InnerTimer.enabled = false;
            _button2.InnerTimer.enabled = false;
            _button3.InnerTimer.enabled = false;
            _button4.InnerTimer.enabled = false;
            _button5.InnerTimer.enabled = false;
            _button1.InnerTimer.fillAmount = 1;
            _button2.InnerTimer.fillAmount = 1;
            _button3.InnerTimer.fillAmount = 1;
            _button4.InnerTimer.fillAmount = 1;
            _button5.InnerTimer.fillAmount = 1;

            _button1.Text.text = _button1.DefaultText;
            _button2.Text.text = _button2.DefaultText;
            _button3.Text.text = _button3.DefaultText;
            _button4.Text.text = _button4.DefaultText;
            _button5.Text.text = _button5.DefaultText;
        }

        public IEnumerator Win()
        {
            ResetState();
            Destroy(gameObject);

            yield return null;
        }

        public IEnumerator Lose()
        {

            ResetState();
            Destroy(gameObject);

            yield return null;
        }
    }
}