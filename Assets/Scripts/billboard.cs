using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class billboard : MonoBehaviour
{

    GameObject Camera;

    /*// Update is called once per frame
    void Update()
    {

        //transform.forward = -Camera.gameObject.transform.forward;
        transform.LookAt(Camera.gameObject.transform);
        transform.Rotate(new Vector3(0f, transform.localRotation.eulerAngles.y,0f), Space.Self);

        /*transform.eulerAngles = new Vector3(
        0f,
        transform.eulerAngles.y,
        0f
        );

    }*/

    void Start()
    {

        Camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void LateUpdate()
    {
        transform.LookAt(Camera.transform);
        transform.Rotate(0, 180, 0);
    }
}
