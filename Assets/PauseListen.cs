using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseListen : MonoBehaviour
{

    public GameObject PauseMenu;
    public bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P) && !isPaused)
        {

            PauseMenu.SetActive(true);
            Time.timeScale = 0;
            isPaused = true;
        }

        else if (Input.GetKeyDown(KeyCode.P) && isPaused)
        {
            isPaused = false;
            PauseMenu.SetActive(false);
            Time.timeScale = 1;

        }

    }
}
