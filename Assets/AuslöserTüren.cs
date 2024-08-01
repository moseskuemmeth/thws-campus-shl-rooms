using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    TuerenAufmachen tuerenAufmachen;

    void Start()
    {
        tuerenAufmachen = GetComponent<TuerenAufmachen>();
    }

    private void OnTriggerEnter(Collider other)
    {
        tuerenAufmachen.bewegen = true;
    }
}
