using UnityEngine;

internal class DebugEvent : MonoBehaviour
{
    [SerializeField] private GameObject _event;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Instantiate(_event);
        }
    }
}