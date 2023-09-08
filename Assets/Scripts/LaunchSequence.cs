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
            if ((Input.GetKey((KeyCode)EInputMap.JOYSTICK_1_RIGHT) &&
                Input.GetKey((KeyCode)EInputMap.JOYSTICK_2_UP) &&
                Input.GetKey((KeyCode)EInputMap.JOYSTICK_3_UP) &&
                Input.GetKey((KeyCode)EInputMap.JOYSTICK_4_LEFT)) ||
                Input.GetKey(KeyCode.Return))
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