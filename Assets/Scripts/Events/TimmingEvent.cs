using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GF
{
    internal class TimmingEvent : Event, IEvent
    {
        [SerializeField] private Color _defaultBorderColor;
        [SerializeField] private Color _eventBorderColor;
        [SerializeField] private float _timerStart;
        [SerializeField] private float _timerLeft;
        [SerializeField] private float _timerWindow;

        public GameObject Timming;
        public GameObject Repere1;
        public GameObject Repere2;
        private Button _button;
        public float ScaleStart = 3;
        public float ScaleEnd = 0;
        private TextMeshProUGUI _buttonText;

        private bool _hasBegunPressing;
        private int _signalIt;

        private void Awake()
        {
            AssignButton();
            InitTimer();
            SetState();

            _timerLeft = _timerStart;

            float repere1ScaleFactor = Mathf.Lerp(ScaleEnd, ScaleStart, _timerWindow);
            var repere1NewScale = new Vector3(repere1ScaleFactor, repere1ScaleFactor, Repere1.transform.localScale.z);
            Repere1.transform.localScale = repere1NewScale;

            Repere2.transform.localScale = new Vector3(ScaleEnd, ScaleEnd, Repere2.transform.localScale.z); ;
        }

        private void Update()
        {
            var currentScale = Timming.transform.localScale;

            if (Input.GetKey(_button.MappingKeyCode))
            {
                if (_timerLeft < _timerWindow * _timerStart)
                {
                    StartCoroutine(Win());
                    Debug.Log("Win");
                }
                else
                {
                    StartCoroutine(Lose());
                    Debug.Log("Loose");
                }
            }
            if (_timerLeft < _timerWindow * _timerStart)
            {
                Timming.GetComponent<Image>().color = Color.green;
            }
            if (_timerLeft <= 0f)
            {
                StartCoroutine(Lose());
            }

            _timerLeft -= Time.deltaTime;
            float percent = _timerLeft / _timerStart;
            float ScaleFactor = Mathf.Lerp(ScaleEnd, ScaleStart, percent);
            var newScale = new Vector3(ScaleFactor, ScaleFactor, currentScale.z);

            Timming.transform.localScale = newScale;
        }

        private void InitTimer()
        {
            _timerStart = 1 / EventPool.Instance.GameSpeed + 1 / EventPool.Instance.GameSpeed * Random.Range(0f, 0.20f);
        }
        private void SetState()
        {
            // var worldPos = Camera.main.ScreenToWorldPoint(_button.transform.position); worldPos.z
            // = 0;

            Timming.transform.position = _button.transform.position;
            Repere1.transform.position = _button.transform.position;
            Repere2.transform.position = _button.transform.position;
        }

        private void ResetState()
        {
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