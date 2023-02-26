using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawn : MonoBehaviour
{

    public GameObject Star;
    public GameObject StarAnimated;
    public int NumSpawn;
    public int RangeVal;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < NumSpawn; i++)
        {
            
            //randomize location of star
            float x = Random.Range(-RangeVal, RangeVal);
            float y = Random.Range(-RangeVal, RangeVal);
            float z = Random.Range(-RangeVal, RangeVal);


            //Decides whether or not star is animated (for the frames!)
            GameObject spawned;

            if (i % 10 == 0)
                spawned = Instantiate(StarAnimated, new Vector3(x, y, z), Quaternion.identity);
            else
                spawned = Instantiate(Star, new Vector3(x, y, z), Quaternion.identity);

            //Sets scale and applies as child
            float scale = Random.Range(5.0f, 25.0f);
          
            Vector3 sc = new Vector3(scale, scale, scale);
            spawned.transform.localScale = sc;
            spawned.transform.parent = gameObject.transform;
        }
    }

   
}
