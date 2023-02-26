using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starSparkle : MonoBehaviour
{
    Animator an;
    bool sendSpark;
    // Start is called before the first frame update
    void Start()
    {
        sendSpark = false;
        an = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(sendSpark == false)
        {
            sendSpark = true;
            StartCoroutine("spark");
        }


    }

    IEnumerator spark()
    {
        yield return new WaitForSeconds(Random.Range(0.0f, 5f));
        an.SetTrigger("spark");
        sendSpark = false;

    }
}
