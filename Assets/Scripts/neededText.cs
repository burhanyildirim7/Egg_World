using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class neededText : MonoBehaviour
{
    public GameObject researchTable;
    GameObject moneyForNewResearch;
    Text _neededText;
    bool canDo = true;

    bool currentTavukEggArttýmý = false;


    void Start()
    {
        _neededText = GetComponent<Text>();
        moneyForNewResearch = transform.GetChild(0).gameObject;
 

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "TavukEggNeeded")
        {        
            _neededText.text = " " + PlayerPrefs.GetInt("currentTavukEgg") + " / " + PlayerPrefs.GetInt("neededTavukEgg");
            if (canDo)
            {
                researchTable.GetComponent<ResearchTableController>().tavukNeededFull = false;
                if (PlayerPrefs.GetInt("TavukEggNeededEggs") != 1)
                {
                    PlayerPrefs.SetInt("neededTavukEgg", 2);
                    PlayerPrefs.SetInt("currentTavukEgg", 0);
                }

                PlayerPrefs.SetInt("TavukEggNeededEggs", 1);
                canDo = false;        
            }
            if (PlayerPrefs.GetInt("currentTavukEgg") >= PlayerPrefs.GetInt("neededTavukEgg"))
            {
                gameObject.SetActive(false);

            
                
            }
        }

        if (gameObject.name == "KazEggNeeded")
        {        
            if (canDo)
            {           
                researchTable.GetComponent<ResearchTableController>().kazNeededFull = false;
                if (PlayerPrefs.GetInt("KazEggNeededEggs") != 1)
                {
                    PlayerPrefs.SetInt("neededTavukEgg", 2);
                    PlayerPrefs.SetInt("currentTavukEgg", 0);
                    PlayerPrefs.SetInt("neededKazEgg", 2);
                    PlayerPrefs.SetInt("currentKazEgg", 0);

                }
                  
                PlayerPrefs.SetInt("KazEggNeededEggs", 1);
                canDo = false;          
            }           
            if (PlayerPrefs.GetInt("currentKazEgg") >= PlayerPrefs.GetInt("neededKazEgg"))
            {
                gameObject.SetActive(false);
            }       
            _neededText.text = " " + PlayerPrefs.GetInt("currentKazEgg") + " / " + PlayerPrefs.GetInt("neededKazEgg");

        
        }

        if (gameObject.name == "DevekusuEggNeeded")
        {
            if (canDo)
            {
                researchTable.GetComponent<ResearchTableController>().devekusuNeededFull = false;
                if (PlayerPrefs.GetInt("DevekusuEggNeededEggs") != 1)
                {
                    PlayerPrefs.SetInt("neededTavukEgg", 2);
                    PlayerPrefs.SetInt("currentTavukEgg", 0);
                    PlayerPrefs.SetInt("neededKazEgg", 2);
                    PlayerPrefs.SetInt("currentKazEgg", 0);
                    PlayerPrefs.SetInt("neededDevekusuEgg", 2);
                    PlayerPrefs.SetInt("currentDevekusuEgg", 0);
                }
                PlayerPrefs.SetInt("DevekusuEggNeededEggs", 1);
                canDo = false;
            }
            if (PlayerPrefs.GetInt("currentDevekusuEgg") >= PlayerPrefs.GetInt("neededDevekusuEgg"))
            {
                gameObject.SetActive(false);
            }
            _neededText.text = " " + PlayerPrefs.GetInt("currentDevekusuEgg") + " / " + PlayerPrefs.GetInt("neededDevekusuEgg");
        }

        if (gameObject.name == "TimsahEggNeeded")
        {
            if (canDo)
            {
                researchTable.GetComponent<ResearchTableController>().timsahNeededFull = false;

                if (PlayerPrefs.GetInt("TimsahEggNeededEggs") != 1)
                {
                    PlayerPrefs.SetInt("neededTavukEgg", 2);
                    PlayerPrefs.SetInt("currentTavukEgg", 0);
                    PlayerPrefs.SetInt("neededKazEgg", 2);
                    PlayerPrefs.SetInt("currentKazEgg", 0);
                    PlayerPrefs.SetInt("neededDevekusuEgg", 2);
                    PlayerPrefs.SetInt("currentDevekusuEgg", 0);  
                    PlayerPrefs.SetInt("neededTimsahEgg", 2);
                    PlayerPrefs.SetInt("currentTimsahEgg", 0);
                }
                PlayerPrefs.SetInt("TimsahEggNeededEggs", 1);
                canDo = false;
            }
            if (PlayerPrefs.GetInt("currentTimsahEgg") >= PlayerPrefs.GetInt("neededTimsahEgg"))
            {
                gameObject.SetActive(false);
            }
            _neededText.text = " " + PlayerPrefs.GetInt("currentTimsahEgg") + " / " + PlayerPrefs.GetInt("neededTimsahEgg");
        } 
        
        if (gameObject.name == "TavukEggNeededForKaz")
        {

            if (canDo)
            {
                researchTable.GetComponent<ResearchTableController>().researchTableFull = false;
                researchTable.GetComponent<ResearchTableController>().neededEgg = 2;
                researchTable.GetComponent<ResearchTableController>().currentEggNumber = 0;
                canDo = false;
            }

            if (researchTable.GetComponent<ResearchTableController>().currentEggNumber >= researchTable.GetComponent<ResearchTableController>().neededEgg)
            {
                gameObject.SetActive(false);
            }

            _neededText.text = " " + researchTable.GetComponent<ResearchTableController>().currentEggNumber + " / " + researchTable.GetComponent<ResearchTableController>().neededEgg;
        }
        
        if (gameObject.name == "TavukEggNeededMoney")
        {

            

            _neededText.text = "$" + moneyForNewResearch.GetComponent<BuyText>().buyPrice;
            if (moneyForNewResearch.GetComponent<BuyText>().buyPrice <= 0)
            {
                
                researchTable.GetComponent<ResearchTableController>().canTavukMoneyPaid = true;
                Destroy(gameObject);
            }
        }
        
        if (gameObject.name == "KazEggNeededMoney")
        {

            

            _neededText.text = "$" + moneyForNewResearch.GetComponent<BuyText>().buyPrice;
            if (moneyForNewResearch.GetComponent<BuyText>().buyPrice <= 0)
            {
                researchTable.GetComponent<ResearchTableController>().canKazMoneyPaid = true;
                Destroy(gameObject);
            }
        }
        
        if (gameObject.name == "DevekusuEggNeededMoney")
        {

            

            _neededText.text = "$" + moneyForNewResearch.GetComponent<BuyText>().buyPrice;
            if (moneyForNewResearch.GetComponent<BuyText>().buyPrice <= 0)
            {
                researchTable.GetComponent<ResearchTableController>().canDevekusuMoneyPaid = true;
                Destroy(gameObject);
            }
        } 
        
        if (gameObject.name == "TimsahEggNeededMoney")
        {

            

            _neededText.text = "$" + moneyForNewResearch.GetComponent<BuyText>().buyPrice;
            if (moneyForNewResearch.GetComponent<BuyText>().buyPrice <= 0)
            {
                researchTable.GetComponent<ResearchTableController>().canTimsahMoneyPaid = true;
                Destroy(gameObject);
            }
        }

        
    }
}
