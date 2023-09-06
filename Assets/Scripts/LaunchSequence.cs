using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace GF
{
    internal class LaunchSequence : MonoBehaviour, IEvent
    {
        [SerializeField] private Image _background;

        private void Update()
        {
            if (Input.GetKey(KeyCode.Return))
            {
                StartCoroutine(Win());
            }
        }

        public IEnumerator Lose()
        {
            Destroy(gameObject);

            yield return null;
        }

        public IEnumerator Win()
        {
            EventPool.Instance.Begin();

            Destroy(gameObject);

            yield return null;
        }
    }
}