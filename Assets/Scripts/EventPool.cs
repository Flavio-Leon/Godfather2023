using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GF
{
    internal class EventPool : MonoBehaviour
    {
        public static EventPool Instance { get; private set; }

        [field: SerializeField] public float GameSpeed { get; private set; }

        [SerializeField] private List<GameObject> Events = new();

        private void Awake() => Instance = this;

        private void Start()
        {
            Time.timeScale = 0;
        }

        public void Begin()
        {
            Time.timeScale = 1;
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(0);
        }
    }
}