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
        protected void SendWin()
        {
            EventPool.Instance.GameSpeed += .1f;
            EventPool.Instance.Text.text = "Speed: " + EventPool.Instance.GameSpeed.ToString("0.0");
        }

        protected void SendLose()
        {
            EventPool.Instance.LoseGame();
        }
    }
}