using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchTableController : MonoBehaviour
{
    bool canDo = true;
    public bool researchTableFull = false;
    public int neededEgg = 1;
    public int currentEggNumber = 0;
    public GameObject kazKumes;
    public GameObject tavukEggNeededText;
    public GameObject kazEggNeededText;
    float delayTime = 0;

    public bool canOpenKazKumes = false;
    void Start()
    {
       
    }

 
    void Update()
    {
        if (currentEggNumber == neededEgg )
        {
            researchTableFull = true;
            delayTime += Time.deltaTime;

            if (delayTime >= 1)
            {
                canOpenKazKumes = true;
            }
     

        }
        else
        {
            researchTableFull = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "tavuk_yumurtasi(Clone)" && tavukEggNeededText.activeSelf)
        {
           
        }

        else if (other.gameObject.name == "devekusu_yumurtasi(Clone)" && kazEggNeededText.activeSelf)
        {
          

        }
    }




}
