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
    public float ResearchTableBeklemeSuresi = 1f;
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

   
        if (PlayerPrefs.GetInt("currentTavukEgg") >= PlayerPrefs.GetInt("neededTavukEgg"))
        {
            tavukNeededFull = true;

            if (canTavukMoneyPaid)
            {
                delayTime += Time.deltaTime;

            }
            

            if (delayTime > ResearchTableBeklemeSuresi)
            {
                canOpenKazKumes = true;
                canTavukMoneyPaid = false;
                delayTime = 0;
            }


        }


      
        if (PlayerPrefs.GetInt("currentKazEgg") >= PlayerPrefs.GetInt("neededKazEgg"))
        {
            kazNeededFull = true;

           
        }

        if (tavukNeededFull && kazNeededFull && canKazMoneyPaid)
        {
            delayTime += Time.deltaTime;

            if (delayTime> ResearchTableBeklemeSuresi)
            {
                canOpenDevekusuKumes = true;
                canKazMoneyPaid = false;
                delayTime = 0;

            }
            

        
        }
        
        if (PlayerPrefs.GetInt("currentDevekusuEgg") >= PlayerPrefs.GetInt("neededDevekusuEgg"))
        {
            devekusuNeededFull = true;

           
         
        }


        if (tavukNeededFull && kazNeededFull && devekusuNeededFull && canDevekusuMoneyPaid)
        {

            delayTime += Time.deltaTime;

            if (delayTime > ResearchTableBeklemeSuresi)
            {
                canOpenTimsahKumes = true;
                canDevekusuMoneyPaid = false;
                delayTime = 0;
            }
          
        }

 
        
        
        if (PlayerPrefs.GetInt("currentTimsahEgg") >= PlayerPrefs.GetInt("neededTimsahEgg"))
        {
            timsahNeededFull = true;

        
        }


        if (tavukNeededFull && kazNeededFull && devekusuNeededFull && timsahNeededFull && canTimsahMoneyPaid)
        {
            delayTime += Time.deltaTime;

            if (delayTime > ResearchTableBeklemeSuresi)
            {
                canOpenEjderKumes = true;
                canTimsahMoneyPaid = false;
                delayTime = 0;

            }

          
        }
        

      
        
    }


}
