using System.Collections;
using UnityEngine;

namespace GF
{
    internal interface IEvent
    {
        IEnumerator Win();
        IEnumerator Lose();
    }

    internal class Event : MonoBehaviour
    { }
}