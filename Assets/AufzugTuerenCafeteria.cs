using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AufzugTuerenCafeteria : MonoBehaviour
{
    // Start is called before the first frame update
    public bool kannFahren;

    [SerializeField] float speed;
    [SerializeField] int startPoint;
    [SerializeField] Transform[] points;


    int i;
    bool umkehren;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[startPoint].position;
        i = startPoint;
    }

    // Update is called once per frame
    void Update()
    {
        TuerenBewegen();
        Invoke("TuerenBewegen", 5);

    }

    public void TuerenBewegen ()
    {
        if (Vector3.Distance(transform.position, points[i].position) < 0.01f)
        {
            kannFahren = false;

            if (i == points.Length - 1)
            {
                umkehren = true;
                i--;
                return;
            }
            else if (i == 0)
            {
                umkehren = false;
                i++;
                return;
            }

            if (umkehren)
            {
                i--;
            }
            else
            {
                i++;
            }
        }

        if (kannFahren)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
        }
        
    }

    public void Zumachen()
    {
        if (Vector3.Distance(transform.position, points[i].position) < 0.01f)
        {


            if (i == points.Length - 1)
            {
                umkehren = true;
                i--;
                return;
            }
            else if (i == 0)
            {
                umkehren = false;
                i++;
                return;
            }

            if (umkehren)
            {
                i--;
            }
            else
            {
                i++;
            }
        }

        if (kannFahren)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
        }

        kannFahren = false;
    }
}