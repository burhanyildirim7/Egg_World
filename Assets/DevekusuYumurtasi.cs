using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevekusuYumurtasi : MonoBehaviour
{
    float delayTime = 0;
    void Start()
    {
   
      
     
 
    }

    // Update is called once per frame
    void Update()
    {
        delayTime += Time.deltaTime;
        if (transform.childCount > 0 && delayTime < 3)
        {
            transform.GetChild(0).transform.localPosition = new Vector3(0, 0, 0);
           
        }

        if (delayTime >= 5)
        {
            Destroy(GetComponent<DevekusuYumurtasi>());

           
        }
    }
}
