using System.Collections;
using System.Linq;
using UnityEngine;

namespace GF
{
    internal class MaintainEvent : MonoBehaviour
    {
        [SerializeField] private Color _defaultBorderColor;
        [SerializeField] private Color _eventBorderColor;

        private Button _button;

        private void Awake() => AssignButton();

        private IEnumerator Start()
        {
            _button.Border.color = _eventBorderColor;

            yield return null;
        }

        private void AssignButton()
        {
            var index = Random.Range(0, Button.Buttons.Count);

            _button = Button.Buttons.ElementAtOrDefault(index);
        }
    }
}