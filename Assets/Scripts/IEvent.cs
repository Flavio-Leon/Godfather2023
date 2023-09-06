using System.Collections;

internal interface IEvent
{
    IEnumerator Win();
    IEnumerator Lose();
}