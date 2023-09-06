using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;

namespace GF
{
    internal class MaintainEvent : MonoBehaviour
    {
        [SerializeField] private Color _defaultBorderColor;
        [SerializeField] private Color _eventBorderColor;

        [SerializeField] private float _timerStart;
        [SerializeField] private float _timerLeft;

        private Button _button;
        private TextMeshProUGUI _buttonText;

        private bool _hasBegunPressing;

        private IEnumerator Start()
        {
            AssignButton();

            InitTimer();

            _button.Border.color = _eventBorderColor;
            _buttonText = _button.GetComponentInChildren<TextMeshProUGUI>();
            _buttonText.text = $"{_timerStart}";

            yield return null;
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

        private IEnumerator Win()
        {
            ResetState();
            Destroy(gameObject);

            yield return null;
        }

        private IEnumerator Lose()
        {
            _hasBegunPressing = false;

            ResetState();
            Destroy(gameObject);

            yield return null;
        }

        private void ResetState()
        {
            _button.Border.color = _defaultBorderColor;
            _button.Border.fillAmount = 1;

            _buttonText.text = string.Empty;
        }
    }
}