using System.Collections;
using UnityEngine;

namespace GF
{
    internal class BlinkOnOff : MonoBehaviour
    {
        [SerializeField] private GameObject _target;

        [SerializeField] private float _intervalSeconds;

        private IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitForSecondsRealtime(.5f);
                _target.SetActive(!_target.activeSelf);
            }
        }
    }
}