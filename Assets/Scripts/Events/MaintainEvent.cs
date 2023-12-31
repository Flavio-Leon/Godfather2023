using JSAM;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GF
{
    internal class MaintainEvent : Event, IEvent
    {
        public static readonly List<MaintainEvent> MaintainEvents = new();

        [SerializeField] private Color _defaultBorderColor;
        [SerializeField] private Color _eventBorderColor;

        [SerializeField] private float _timerStart;
        [SerializeField] private float _timerLeft;

        //insert variable audio
        [SerializeField] private SoundFileObject _audio1;
        [SerializeField] private SoundFileObject _audio2;
        [SerializeField] private SoundFileObject _audio3;
        [SerializeField] private SoundFileObject _audio4;

        private Button _button;

        private bool _hasBegunPressing;
        private int _assignCount;
        private int _signalIt;

        private void Start()
        {
            MaintainEvents.Add(this);

            if (!AssignButton())
            {
                Destroy(gameObject);
                return;
            }

            InitTimer();

            if (_button != null)
            {
                SetState();
            }

            StartCoroutine(Signal());

            //audio 1 ici
            AudioManager.PlaySound(_audio1);
        }

        private void Update()
        {
            if (Input.GetKey(_button.MappingKeyCode))
            {
                //audio 2 ici
                AudioManager.StopSound(_audio1);

                if (!AudioManager.IsSoundPlaying(_audio2))
                {
                    AudioManager.PlaySound(_audio2);
                }
                //fin audio 2

                if (!_hasBegunPressing)
                {
                    _timerLeft = _timerStart;
                }

                _hasBegunPressing = true;

                _timerLeft -= Time.deltaTime;
                _button.Border.fillAmount = _timerLeft / _timerStart;
                _button.InnerTimer.fillAmount = _button.Border.fillAmount;
                _button.Text.text = _timerLeft.ToString("0.0");

                if (_timerLeft < 0)
                {
                    StartCoroutine(Win());
                }
            }
            else if (_hasBegunPressing)
            {
                StartCoroutine(Lose());
            }
        }

        private void OnDestroy()
        {
            MaintainEvents.Remove(this);

            if (_button != null)
            {
                ResetState();
            }
        }

        private bool AssignButton()
        {
            var busyButtons = Button.Buttons.FindAll(x => x.IsBusy).ToList();
            if (busyButtons.Count == Button.Buttons.Count)
            {
                print("AssignButton: all busy");
                return false;
            }

            var index = Random.Range(0, Button.Buttons.Count);
            _button = Button.Buttons.ElementAtOrDefault(index);

            if (_button.IsBusy)
            {
                print("AssignButton: retry");
                return AssignButton();
            }

            return true;
        }

        private void InitTimer()
        {
            _timerStart = Random.Range(1, 3);
        }

        private void SetState()
        {
            _button.IsBusy = true;

            _button.Border.color = _eventBorderColor;

            _button.Background.color = Color.red;

            _button.InnerTimer.enabled = true;

            _button.Text.text = _timerStart.ToString("0.0");
        }

        private void ResetState()
        {
            _button.IsBusy = false;

            _button.Border.color = _defaultBorderColor;
            _button.Border.fillAmount = 1;

            _button.Background.color = _button.DefaultColor;

            _button.InnerTimer.enabled = false;
            _button.InnerTimer.fillAmount = 1;

            _button.Text.text = _button.DefaultText;
        }

        public IEnumerator Signal()
        {
            while (!_hasBegunPressing)
            {
                if (_button.Background != null)
                {
                    _button.Background.color = _signalIt % 2 == 0 ? Color.red : _button.DefaultColor;
                }

                _signalIt++;
                yield return new WaitForSeconds(.5f);
            }
        }

        public IEnumerator Win()
        {
            //audio 3 win ici
            AudioManager.StopSound(_audio2);

            AudioManager.PlaySound(_audio3);

            SendWin();

            Destroy(gameObject);

            yield return null;
        }

        public IEnumerator Lose()
        {
            //audio 4 lose ici
            AudioManager.StopSound(_audio2);

            AudioManager.PlaySound(_audio4);

            SendLose();

            _hasBegunPressing = false;

            Destroy(gameObject);

            yield return null;
        }
    }
}