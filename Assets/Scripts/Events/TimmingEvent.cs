using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;

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
        }

        private void Update()
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

            if (Timming.transform.localScale.x < 0.19f)
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
        }

        private void ResetState()
        {
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