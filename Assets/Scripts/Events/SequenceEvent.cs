using JSAM;
using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;

namespace GF
{
    internal class SequenceEvent : Event, IEvent
    {
        [SerializeField] private Color _defaultBorderColor;
        [SerializeField] private Color _eventBorderColor;

        [SerializeField] private float _timerStart;
        [SerializeField] private float _timerLeft;
        [field: SerializeField] public TextMeshProUGUI Text { get; private set; }

        private Button _button1;
        private Button _button2;
        private Button _button3;
        private Button _button4;
        private Button _button5;

        private int _assignCount;
        private int _signalIt;
        public float SequenceTimer;
        public bool istimed;

        //insert variable audio
        [SerializeField] private SoundFileObject _audio1;
        [SerializeField] private SoundFileObject _audio2;
        [SerializeField] private SoundFileObject _audio3;
        [SerializeField] private SoundFileObject _audio4;
        [SerializeField] private SoundFileObject _audio5;
        [SerializeField] private SoundFileObject _audio6;
        [SerializeField] private SoundFileObject _audio7;
        [SerializeField] private SoundFileObject _audio8;

        private void Start()
        {
            _button1 = GetButton();
            _button1.IsBusy = true;
            if (_button1 == null) Destroy(gameObject);

            _button2 = GetButton();
            _button2.IsBusy = true;
            if (_button2 == null) Destroy(gameObject);

            _button3 = GetButton();
            _button3.IsBusy = true;
            if (_button3 == null) Destroy(gameObject);

            _button4 = GetButton();
            _button4.IsBusy = true;
            if (_button4 == null) Destroy(gameObject);

            _button5 = GetButton();
            _button5.IsBusy = true;
            if (_button5 == null) Destroy(gameObject);

            InitTimer();
            _timerLeft = _timerStart;
            StartCoroutine(Button1Activate());

            //audio 1 ici
            AudioManager.PlaySound(_audio8);
        }

        private void Update()
        {
            if (istimed == true)
            {
                _timerLeft -= Time.deltaTime;
                Text.text = _timerLeft.ToString("0.0");

                if (_timerLeft < 0f)
                {
                    StartCoroutine(Lose());
                }
            }
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }

        private Button GetButton()
        {
            var busyButtons = Button.Buttons.FindAll(x => x.IsBusy).ToList();
            if (busyButtons.Count == Button.Buttons.Count)
            {
                print("AssignButton: all busy");
                return null;
            }

            var index = Random.Range(0, Button.Buttons.Count);
            var button = Button.Buttons.ElementAtOrDefault(index);

            if (button.IsBusy)
            {
                print("AssignButton: retry");
                return GetButton();
            }

            return button;
        }

        private void InitTimer()
        {
            _timerStart = SequenceTimer * 1 / EventPool.Instance.GameSpeed;
        }

        private void ResetState()
        {
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
            //audio win
            AudioManager.PlaySound(_audio6);
            SendWin();

            ResetState();
            Destroy(gameObject);

            yield return null;
        }

        public IEnumerator Lose()
        {
            //audio lose
            AudioManager.PlaySound(_audio7);
            SendLose();

            ResetState();
            Destroy(gameObject);

            yield return null;
        }
        private IEnumerator Button1Activate()
        {
            if (_button1.Background != null)
            {
                var _ = _button1.DefaultColor;
                _button1.DefaultColor = Color.cyan;
                _button1.Background.color = Color.cyan;
                yield return new WaitUntil(() => Input.GetKeyDown(_button1.MappingKeyCode));
                _button1.DefaultColor = _;
                _button1.Background.color = _defaultBorderColor;

                //audio 1 ici
                AudioManager.PlaySound(_audio1);

                _button1.IsBusy = false;
                StartCoroutine(Button2Activate());
            }
        }

        private IEnumerator Button2Activate()
        {
            if (_button2.Background != null)
            {
                var _ = _button2.DefaultColor;
                _button2.DefaultColor = Color.cyan;
                _button2.Background.color = Color.cyan;
                yield return new WaitUntil(() => Input.GetKeyDown(_button2.MappingKeyCode));
                _button2.DefaultColor = _;
                _button2.Background.color = _defaultBorderColor;

                //audio 2 ici
                AudioManager.PlaySound(_audio2);

                _button2.IsBusy = false;
                StartCoroutine(Button3Activate());
            }
        }

        private IEnumerator Button3Activate()
        {
            if (_button3.Background != null)
            {
                var _ = _button3.DefaultColor;
                _button3.DefaultColor = Color.cyan;
                _button3.Background.color = Color.cyan;
                yield return new WaitUntil(() => Input.GetKeyDown(_button3.MappingKeyCode));
                _button3.DefaultColor = _;
                _button3.Background.color = _defaultBorderColor;

                //audio 3 ici
                AudioManager.PlaySound(_audio3);

                _button3.IsBusy = false;
                StartCoroutine(Button4Activate());
            }
        }

        private IEnumerator Button4Activate()
        {
            if (_button4.Background != null)
            {
                var _ = _button4.DefaultColor;
                _button4.DefaultColor = Color.cyan;
                _button4.Background.color = Color.cyan;
                yield return new WaitUntil(() => Input.GetKeyDown(_button4.MappingKeyCode));
                _button4.DefaultColor = _;
                _button4.Background.color = _defaultBorderColor;

                //audio 4 ici
                AudioManager.PlaySound(_audio4);

                _button4.IsBusy = false;
                StartCoroutine(Button5Activate());
            }
        }

        private IEnumerator Button5Activate()
        {
            if (_button5.Background != null)
            {
                var _ = _button5.DefaultColor;
                _button5.DefaultColor = Color.cyan;
                _button5.Background.color = Color.cyan;
                yield return new WaitUntil(() => Input.GetKeyDown(_button5.MappingKeyCode));
                _button5.DefaultColor = _;
                _button5.Background.color = _defaultBorderColor;

                //audio 5 ici
                AudioManager.PlaySound(_audio5);

                _button5.IsBusy = false;
                StartCoroutine(Win());
            }
        }
    }
}