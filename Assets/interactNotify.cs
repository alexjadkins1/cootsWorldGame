using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactNotify : MonoBehaviour
{

    public GameObject Message;
    bool turnOffMessage = false;

    void Update()
    {

        if(turnOffMessage)
        {
            if(Input.GetKeyDown(KeyCode.F))
                Message.SetActive(false);

        }

    }
    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Player")
            Message.SetActive(true);
        
        turnOffMessage = false;

    }

    void OnTriggerStay(Collider col){

        if (col.gameObject.tag == "Player")
        {
            turnOffMessage = true;
        }

    }
    void OnTriggerExit(Collider col)
    {

        if (col.gameObject.tag == "Player")
            Message.SetActive(false);

        turnOffMessage = true;

    }
}
