using System.Collections;
using TMPro;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;

namespace GF
{
    internal class TimmingEvent : MonoBehaviour, IEvent
    {

        [SerializeField] private Color _defaultBorderColor;
        [SerializeField] private Color _eventBorderColor;

        [SerializeField] private float _timerStart;
        [SerializeField] private float _timerLeft;

        public float VitesseTimming;
        public GameObject Timming;
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

        void Update()
        {
            var currentScale = Timming.transform.localScale;

            if (Input.GetKey(_button.MappingKeyCode))
            {
                StartCoroutine(Lose());
            }

            if (Timming.transform.localScale.x > 0.2f && Timming.transform.localScale.x < 0.3f)
            {
                if (Input.GetKey(_button.MappingKeyCode))
                {
                    StartCoroutine(Win());
                }
            }

            if (Timming.transform.localScale.x > 0.19f)
            {
                StartCoroutine(Lose());
            }

            var newScale = new Vector3(currentScale.x - Time.deltaTime * VitesseTimming, currentScale.y - Time.deltaTime * VitesseTimming, currentScale.z);

            Timming.transform.localScale = newScale;

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
            ResetState();
            Destroy(gameObject);

            yield return null;
        }

        private void AssignButton()
        {
            var index = Random.Range(0, Button.Buttons.Count);

            _button = Button.Buttons.ElementAtOrDefault(index);
        }
    }
}
