using System.Collections;
using UnityEngine;

namespace GF
{
    internal interface IEvent
    {
        IEnumerator Win();
        IEnumerator Lose();
    }

    internal abstract class Event : MonoBehaviour
    {
    }
}