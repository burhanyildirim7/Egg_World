using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TavukKumesControl : MonoBehaviour
{
   public GameObject tavukPref;
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            /*
           var spawnedTavuk =  Instantiate(tavukPref, new Vector3(Random.Range(-6, 6), 0, Random.Range(10, 20)),Quaternion.identity);
            spawnedTavuk.transform.parent = transform;
            */
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
