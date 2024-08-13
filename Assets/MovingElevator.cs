using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovingElevator : MonoBehaviour
{
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    GameObject presser;
    AudioSource sound;
    bool isPressed;
    Vector3 origin;
    
    GameObject cabin;
    GameObject elevator;

    public bool canMove;
    [SerializeField] bool isOutside;
    [SerializeField] bool isDown;

    GameObject kabineTR;
    GameObject kabineTL;
    GameObject erdgeschossTR;
    GameObject erdgeschossTL;
    GameObject cafeteraiaTR;
    GameObject cafeteraiaTL;


    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        isPressed = false;
        cabin = GameObject.Find("Aufzug_kabine");
        elevator = GameObject.Find("Aufzug");
        canMove = true;
        origin = button.transform.localPosition;
        kabineTR = GameObject.Find("Kabine Tür rechts");
        kabineTL = GameObject.Find("Kabine Tür links");
        erdgeschossTR = GameObject.Find("Erd Tür rechts");
        erdgeschossTL = GameObject.Find("Erd Tür links");
        cafeteraiaTR = GameObject.Find("Cafe Tür rechts");
        cafeteraiaTL = GameObject.Find("Cafe Tür links");
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            button.transform.localPosition = new Vector3(-0.00600000005f, 0.063000001f, -0.0309999995f);
            presser = other.gameObject;
            onPress.Invoke();
            sound.Play();
            isPressed = true;
        }

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser)
        {
            button.transform.localPosition = origin;
            presser = other.gameObject;
            onRelease.Invoke();
            isPressed = false;
        }
    }

    public void InitiateMovement()
    {
        if (isOutside)
        {
            if (isDown && cabin.GetComponent<Moving>().reverse || !isDown && !cabin.GetComponent<Moving>().reverse)
            {
                Invoke("MoveCabin", 0.5f);
                Invoke("MoveCabin", 14f);
            }
            else
            {
                Invoke("OpenClose", 0.5f);

                Invoke("MoveCabin", 7.5f);
            }
        }
        else
        {
            Invoke("MoveCabin", 6.5f);
        }
    }

    private void MoveDoors()
    {
        // if reverse is true, the door is open/elevator is up(erdgeschoss), else(false) the door is closed/elevator is down(cafeteria).
        if (cabin.GetComponent<Moving>().reverse)
        {
            erdgeschossTR.GetComponent<Moving>().move = true;
            erdgeschossTL.GetComponent<Moving>().move = true;
        }
        else
        {
            cafeteraiaTR.GetComponent<Moving>().move = true;
            cafeteraiaTL.GetComponent<Moving>().move = true;
        }

        kabineTR.GetComponent<Moving>().move = true;
        kabineTL.GetComponent<Moving>().move = true;

    }

    private void MoveCabin()
    {
        cabin.GetComponent<Moving>().move = true;
        Invoke("OpenClose", 6f);
        
    }

    public void OpenClose()
    {
        Invoke("MoveDoors", 0.5f);
        Invoke("MoveDoors", 5f);
    }
    
}
