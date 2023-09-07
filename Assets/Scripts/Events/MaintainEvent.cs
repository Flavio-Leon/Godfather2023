using System.Collections;
using System.Linq;
using UnityEngine;

namespace GF
{
    internal class MaintainEvent : Event, IEvent
    {
        [SerializeField] private Color _defaultBorderColor;
        [SerializeField] private Color _eventBorderColor;

        [SerializeField] private float _timerStart;
        [SerializeField] private float _timerLeft;

        private Button _button;

        private bool _hasBegunPressing;
        private int _assignCount;
        private int _signalIt;

        private void Awake()
        {
            AssignButton();
            InitTimer();
            SetState();

            StartCoroutine(Signal());
        }

        private void Update()
        {
            if (Input.GetKey(_button.MappingKeyCode))
            {
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

        private void AssignButton()
        {
            var index = Random.Range(0, Button.Buttons.Count);

            _button = Button.Buttons.ElementAtOrDefault(index);

            if (_button.IsBusy)
            {
                if (_assignCount <= Button.Buttons.Count)
                {
                    _assignCount++;
                    AssignButton();
                }

                Destroy(gameObject);
            }
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
                _button.Background.color = _signalIt % 2 == 0 ? Color.red : _button.DefaultColor;
                _signalIt++;
                yield return new WaitForSeconds(.5f);
            }
        }

        public IEnumerator Win()
        {
            SendWin();

            ResetState();
            Destroy(gameObject);

            yield return null;
        }

        public IEnumerator Lose()
        {
            SendLose();

            _hasBegunPressing = false;

            ResetState();
            Destroy(gameObject);

            yield return null;
        }
    }
}