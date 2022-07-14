using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchTableController : MonoBehaviour
{
    bool canDo = true;
    public bool researchTableFull = false;

    public bool tavukNeededFull = false;
    public bool kazNeededFull = false;
    public bool devekusuNeededFull = false;
    public bool timsahNeededFull = false;

    public int neededEgg = 2;

    public int neededTavukEgg;
    public int neededKazEgg;
    public int neededDevekusuEgg;
    public int neededTimsahEgg;

    public int currentTavukEgg = 0;
    public int currentKazEgg = 0;
    public int currentDevekusuEgg = 0;
    public int currentTimsahEgg = 0;

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

    public bool eggsAreReady = false;
    void Start()
    {
       
    }

 
    void Update()
    {
        /*
        if (currentEggNumber == neededEgg )
        {
            researchTableFull = true;

            delayTime += Time.deltaTime;

        
             
          

            if (canTavukMoneyPaid && eggsAreReady)
            {
               canOpenKazKumes = true;
                canTavukMoneyPaid = false;
                eggsAreReady = false;
            }

            if (canKazMoneyPaid && eggsAreReady)
            {
                canOpenDevekusuKumes = true;
                canKazMoneyPaid = false;
                eggsAreReady = false;
            } 
            
            if (canDevekusuMoneyPaid && eggsAreReady)
            {
                canOpenTimsahKumes = true;
                canDevekusuMoneyPaid = false;
                eggsAreReady = false;
            }
            
            if (canTimsahMoneyPaid && eggsAreReady)
            {
                canOpenEjderKumes = true;
                canTimsahMoneyPaid = false;
                eggsAreReady = false;
            }


     

        }
        */
        if (currentTavukEgg == neededTavukEgg)
        {
            tavukNeededFull = true;


            delayTime += Time.deltaTime;
            if (canTavukMoneyPaid)
            {
                canOpenKazKumes = true;
                canTavukMoneyPaid = false;
     
            }
        }


      
        if (currentKazEgg == neededKazEgg)
        {
            kazNeededFull = true;

            delayTime += Time.deltaTime;
            if (canKazMoneyPaid)
            {
                canOpenDevekusuKumes = true;
                canKazMoneyPaid = false;
               
            }
        }
        
        if (currentDevekusuEgg == neededDevekusuEgg)
        {
            devekusuNeededFull = true;

            delayTime += Time.deltaTime;
            if (canDevekusuMoneyPaid)
            {
                canOpenTimsahKumes = true;
                canDevekusuMoneyPaid = false;
               
            }
        }  

 
        
        
        if (currentTimsahEgg == neededTimsahEgg)
        {
            timsahNeededFull = true;

            delayTime += Time.deltaTime;
            if (canTimsahMoneyPaid)
            {
                canOpenEjderKumes = true;
                canTimsahMoneyPaid = false;
               
            }
        }
        

      
        
    }


}
