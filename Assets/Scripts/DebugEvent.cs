using UnityEngine;

internal class DebugEvent : MonoBehaviour
{
    [SerializeField] private GameObject _event;

    [SerializeField] private Transform _parent;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Instantiate(_event, _parent, true);
        }
    }
}