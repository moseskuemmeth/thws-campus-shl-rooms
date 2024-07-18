using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBoden : MonoBehaviour
{
    AufzugFahrenOben aufzug;

    void Start()
    {
        aufzug = GetComponent<AufzugFahrenOben>();
    }

    private void OnTriggerEnter(Collider other)
    {
        aufzug.kannFahren = true;
    }
}