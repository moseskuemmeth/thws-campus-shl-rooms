using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AufzugFahren : MonoBehaviour
        
{
    public GameObject door1;
    public GameObject door2;
    AufzugFahrenOben aufzug;
    public bool bewegen;
    public bool ;

    // Start is called before the first frame update
    void Start()
    {
        door1 = transform.GetChild(4).gameObject;
        door2 = transform.GetChild(5).gameObject;
        aufzug = GetComponent<AufzugFahrenOben>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bewegen)
        {
            door2.GetComponent<TuerenBewegen>().aufmachen = true;
            door1.GetComponent<TuerenBewegen>().aufmachen = true;
            bewegen = false;
            Invoke("TuerenSchliessen", 5f);
        }
    }

    private void TuerenSchliessen()
    {
        //bewegen = true;
        door2.GetComponent<TuerenBewegen>().aufmachen = true;
        door1.GetComponent<TuerenBewegen>().aufmachen = true;
        Invoke("Fahren", 2);
    }

    private void Fahren()
    {
        aufzug.kannFahren = true;
        Invoke("ResetBewegen", 6.5f);
    }

    private void ResetBewegen()
    {
        bewegen = true;
    }
}
