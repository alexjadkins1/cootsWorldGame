using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogController : MonoBehaviour
{
    [System.Serializable]
    public class DiaList
    {
       
        public string[] dia;

    }

    public DiaList[] dialogs;

    public DialogueController d;

    public bool check = false;

    public string name;

    // Update is called once per frame
    void Update()
    {
        
        if (check)
        {

           
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (!d.gameObject.activeInHierarchy)
                {
                    int choice = Random.Range(0, dialogs.Length);
                   
                    d.SendDialog(dialogs[choice].dia, name);
                }
                        
            }
           

        }

    }



    void OnTriggerStay(Collider col)
    {

        if (col.gameObject.tag == "Player")
        {
            check = true;
        }
        

    }

    void OnTriggerExit(Collider col)
    {

        if (col.gameObject.tag == "Player")
        {
            check = false;
            d.gameObject.SetActive(false);
        }

    }

}

