using UnityEngine;

namespace GF
{
    internal class MaintainEvent : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private void Awake()
        {
            var r = Random.Range(0, Button.Buttons.Count);
        }
    }
}