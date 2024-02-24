using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDoorTrigger : MonoBehaviour
{
    [SerializeField] private Animator door = null;
    [SerializeField] private string openAnimationName = null;
    [SerializeField] private string closeAnimationName = null;
    [SerializeField] private float waitTimer = 3;
    [SerializeField] private bool pauseInteraction = false;
    private bool isOpen = false;

    private IEnumerator PauseDoorInteraction()
    {
        pauseInteraction = true;
        yield return new WaitForSeconds(waitTimer);
        pauseInteraction = false;
    }

    public void OpenDoor()
    {
        if (!isOpen && !pauseInteraction)
        {
            door.Play(openAnimationName, 0, 0.0f);
            isOpen = true;
            if (waitTimer > 0)
            {
                StartCoroutine(PauseDoorInteraction());
            }
        }
    }
}
