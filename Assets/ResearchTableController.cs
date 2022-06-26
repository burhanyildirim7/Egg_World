using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchTableController : MonoBehaviour
{
    bool canDo = true;
    public int neededEgg = 5;
    public GameObject kazKumes;
    float delayTime = 0;

    public bool canOpenKazKumes = false;
    void Start()
    {
       
    }

 
    void Update()
    {
        if (transform.childCount >= neededEgg )
        {
            canOpenKazKumes = true;

        }
    }

  


}
