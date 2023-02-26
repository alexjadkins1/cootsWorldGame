using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    public float camX;
    public float camY;

    float xRotation;
    public float yRotation;

    public Transform orientation;

    //public PauseListen p;

    // Start is called before the first frame update
    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        //if (!p.isPaused)
        //{
            float mouseX = Input.GetAxisRaw("Mouse X") * camX;
            float mouseY = Input.GetAxisRaw("Mouse Y") * camY;

            yRotation += mouseX;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);
       // }
    }
}
