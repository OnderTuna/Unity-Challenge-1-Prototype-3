using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    Vector3 startPos;
    public float repeatWidth; /*Tekrar edeceði kýsmý alcaz.*/

    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / 2; /*Arka planýn tam ortasýndan kesip oradan tekrar ettireceðiz.*/
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
