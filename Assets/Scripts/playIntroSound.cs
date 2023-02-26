using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playIntroSound : MonoBehaviour
{

    public AudioSource sound;

    bool sceneSwitch;

    void Start()
    {
        sceneSwitch = false;
    }

    void Update()
    {

        if(sceneSwitch == true)
        {

            SceneManager.LoadScene("Menu");

        }

    }
    public void playSound()
    {
        sound.Play();
        StartCoroutine("MainMenu");
    }

    IEnumerator MainMenu()
    {
        yield return new WaitForSeconds(2f);
        sceneSwitch = true;

    }
}
