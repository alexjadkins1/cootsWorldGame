using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPosition;

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKey(KeyCode.LeftControl))
        {

            transform.position = new Vector3(cameraPosition.position.x,
                cameraPosition.position.y-0.5f,
                cameraPosition.position.z);

        }
        else
            transform.position = cameraPosition.position;
    }
}
