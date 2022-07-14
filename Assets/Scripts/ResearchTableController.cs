using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchTableController : MonoBehaviour
{
    bool canDo = true;
    public bool researchTableFull = false;
    public int neededEgg = 2;
    public int currentEggNumber = 0;
    public GameObject kazKumes;
    public GameObject tavukEggNeededText;

    public GameObject kazEggNeededText;
    public GameObject devekusuEggNeededText;
    public GameObject timsahEggNeededText;
    float delayTime = 0;


    public bool canTavukMoneyPaid = false;
    public bool canKazMoneyPaid = false;
    public bool canDevekusuMoneyPaid = false;
    public bool canTimsahMoneyPaid = false;


    public bool canOpenKazKumes = false;
    public bool canOpenDevekusuKumes = false;
    public bool canOpenTimsahKumes = false;
    public bool canOpenEjderKumes = false;
    void Start()
    {
       
    }

 
    void Update()
    {
        if (currentEggNumber == neededEgg )
        {
            researchTableFull = true;

            delayTime += Time.deltaTime;

        
             
          

            if (canTavukMoneyPaid)
            {
               canOpenKazKumes = true;
                canTavukMoneyPaid = false;
            }

            if (canKazMoneyPaid)
            {
                canOpenDevekusuKumes = true;
                canKazMoneyPaid = false;

            } 
            
            if (canDevekusuMoneyPaid)
            {
                canOpenTimsahKumes = true;
                canDevekusuMoneyPaid = false;

            }
            
            if (canTimsahMoneyPaid)
            {
                canOpenEjderKumes = true;
                canTimsahMoneyPaid = false;

            }


     

        }
        else
        {
            researchTableFull = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
      

       
    }




}
