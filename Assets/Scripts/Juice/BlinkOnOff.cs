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
                _target.SetActive(!_target.activeSelf);
                yield return new WaitForSeconds(.5f);
            }
        }
    }
}