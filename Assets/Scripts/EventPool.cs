using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GF
{
    internal class EventPool : MonoBehaviour
    {
        public static EventPool Instance { get; private set; }

        [field: SerializeField] public float GameSpeed { get; private set; }

        [SerializeField] private int _maxConsecutiveEvent;

        [SerializeField] private List<GameObject> _events = new();

        private Event _lastEvent;
        private int _sameEventCounter;
        private bool _isSame;

        public float TimeScale;

        private void Awake() => Instance = this;

        private void Start()
        {
            Time.timeScale = TimeScale;
        }

        private IEnumerator Loop()
        {
            yield return new WaitForSeconds(2);

            while (true)
            {
                var index = Random.Range(0, _events.Count);
                var eventObject = _events.ElementAtOrDefault(index);
                var currentEvent = eventObject.GetComponent<Event>();

                _isSame = _lastEvent != null && currentEvent.GetType() == _lastEvent.GetType();

                if (_isSame)
                    _sameEventCounter++;
                else
                    _sameEventCounter = 0;

                Debug.Log(_sameEventCounter);

                if (_sameEventCounter < _maxConsecutiveEvent)
                {
                    Instantiate(eventObject);

                    _lastEvent = currentEvent;

                    yield return new WaitForSeconds(5);
                }
            }
        }

        public void Begin()
        {
            Time.timeScale = 1;

            StartCoroutine(Loop());
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(0);
        }
    }
}