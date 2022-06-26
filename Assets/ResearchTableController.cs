using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchTableController : MonoBehaviour
{
    bool canDo = true;
    public int neededEgg = 5;
    public GameObject kazKumes;
    float delayTime = 0;
    void Start()
    {
       
    }

 
    void Update()
    {
        if (transform.childCount >= neededEgg )
        {
            delayTime += Time.deltaTime;

            if (delayTime>=2 && canDo)
            {
                kazKumes.SetActive(true);
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>().target = kazKumes;
                canDo = false;

            }
           
        }
    }

  


}
