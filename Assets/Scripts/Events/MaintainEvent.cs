using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;

namespace GF
{
    internal class MaintainEvent : MonoBehaviour, IEvent
    {
        [SerializeField] private Color _defaultBorderColor;
        [SerializeField] private Color _eventBorderColor;

        [SerializeField] private float _timerStart;
        [SerializeField] private float _timerLeft;

        private Button _button;
        private TextMeshProUGUI _buttonText;

        private bool _hasBegunPressing;
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
                _buttonText.text = _timerLeft.ToString("0.0");

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
        }

        private void InitTimer()
        {
            _timerStart = Random.Range(1, 5);
        }

        private void SetState()
        {
            _button.Border.color = _eventBorderColor;

            _button.Background.color = Color.red;

            _button.InnerTimer.enabled = true;

            _buttonText = _button.GetComponentInChildren<TextMeshProUGUI>();
            _buttonText.text = _timerStart.ToString("0.0");
        }

        private void ResetState()
        {
            _button.Border.color = _defaultBorderColor;
            _button.Border.fillAmount = 1;

            _button.Background.color = _button.DefaultColor;

            _button.InnerTimer.enabled = false;
            _button.InnerTimer.fillAmount = 1;

            _buttonText.text = string.Empty;
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
            ResetState();
            Destroy(gameObject);

            yield return null;
        }

        public IEnumerator Lose()
        {
            _hasBegunPressing = false;

            ResetState();
            Destroy(gameObject);

            yield return null;
        }
    }
}