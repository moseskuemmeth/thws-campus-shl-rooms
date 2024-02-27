using System.Collections;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

namespace UnityEngine.XR.Content.Interaction
{
    /// <summary>
    /// An interactable that can be pressed by a direct interactor
    /// </summary>
    public class XRDoorOpener : XRBaseInteractable
    {
        [SerializeField]
        [Tooltip("The object that is visually pressed down")]
        Animator button = null;

        [SerializeField]
        [Tooltip("The buttons animation name")]
        string buttonAnimationName = "DoorOpener";

        [SerializeField]
        [Tooltip("The door to control")]
        Animator door = null;

        [SerializeField]
        [Tooltip("The doors animation name")]
        string doorAnimationName = "TimedDoor";

        [SerializeField]
        [Tooltip("The time it takes to open and close the door")]
        private float doorAnimationTime = float.NaN;

        private bool pauseInteraction = false;

        private IEnumerator PauseInteraction(float waitTimer)
        {
            Debug.Log("Pause Interaction");
            pauseInteraction = true;
            yield return new WaitForSeconds(waitTimer);
            pauseInteraction = false;
            Debug.Log("Unpause Interaction");
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            selectEntered.AddListener(StartPress);
        }

        protected override void OnDisable()
        {
            selectEntered.RemoveListener(StartPress);
            base.OnDisable();
        }

        void StartPress(SelectEnterEventArgs args)
        {
            button.Play(buttonAnimationName, 0, 0.0f);
            if (!pauseInteraction)
            { 
                door.Play(doorAnimationName, 0, 0.0f);
                StartCoroutine(PauseInteraction(doorAnimationTime));
            }
        }
    }
}
