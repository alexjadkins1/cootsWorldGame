using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{

    public TextMeshProUGUI text;
    public TextMeshProUGUI name;

    public string[] lines;

    public float textSpeed;

    private int index;

    AudioSource diaSound;

    public Animator c;

    // Start is called before the first frame update
    void Start()
    {
        text.text = string.Empty;
        diaSound = GetComponent<AudioSource>();
  
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (c != null)
                c.SetBool("speaking", false);

            if (text.text == lines[index])
                NextLine();
            else
            {
                StopAllCoroutines();
                text.text = lines[index];
            }
        }
    }

    void StartDialog()
    {

        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        if(c != null)
            c.SetBool("speaking", true);
        int ctr = 0;
        foreach (char c in lines[index].ToCharArray())
        {
            yield return new WaitForSeconds(textSpeed);
            
            text.text += c;
            if(ctr%2 == 0)
                diaSound.Play();
            ctr++;
            
         
        }
        if (c != null)
            c.SetBool("speaking", false);
    }

    void NextLine()
    {

        if(index < lines.Length - 1)
        {

            index++;
            text.text = string.Empty;
            if (c != null)
            {
                if (c.GetBool("speaking") == false)
                    c.SetBool("speaking", true);
            }
            StartCoroutine(TypeLine());

        }
        else
        {
            
            c.SetBool("speaking", false);
            gameObject.SetActive(false);

        }


    }

    public void SendDialog(string[] dia, string diaName)
    {

        lines = dia;
       
        gameObject.SetActive(true);
        text.text = string.Empty;
        Debug.Log(dia[0]);
        name.text = diaName + ":";
        index = 0;
        StartCoroutine(TypeLine());
        
    }
}
