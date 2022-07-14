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
           
            _neededText.text = " " + researchTable.GetComponent<ResearchTableController>().currentTavukEgg + " / " + researchTable.GetComponent<ResearchTableController>().neededTavukEgg;
            if (canDo)
            {
                researchTable.GetComponent<ResearchTableController>().tavukNeededFull = false;
                researchTable.GetComponent<ResearchTableController>().neededTavukEgg = 2;
                researchTable.GetComponent<ResearchTableController>().currentTavukEgg = 0;
                canDo = false;
            }
            if (researchTable.GetComponent<ResearchTableController>().currentTavukEgg == researchTable.GetComponent<ResearchTableController>().neededTavukEgg)
            {
                gameObject.SetActive(false);
            }
        }

        if (gameObject.name == "KazEggNeeded")
        {

            if (canDo)
            {
                researchTable.GetComponent<ResearchTableController>().kazNeededFull = false;
                researchTable.GetComponent<ResearchTableController>().neededKazEgg = 2;
                researchTable.GetComponent<ResearchTableController>().currentKazEgg = 0;
                canDo = false;
            }
            
            if (researchTable.GetComponent<ResearchTableController>().currentKazEgg == researchTable.GetComponent<ResearchTableController>().neededKazEgg)
            {
                gameObject.SetActive(false);
            }
            
            _neededText.text = " " + researchTable.GetComponent<ResearchTableController>().currentKazEgg + " / " + researchTable.GetComponent<ResearchTableController>().neededKazEgg;
        }

        if (gameObject.name == "DevekusuEggNeeded")
        {

            if (canDo)
            {
                researchTable.GetComponent<ResearchTableController>().devekusuNeededFull = false;
                researchTable.GetComponent<ResearchTableController>().neededDevekusuEgg = 2;
                researchTable.GetComponent<ResearchTableController>().currentDevekusuEgg = 0;
                canDo = false;
            }

            if (researchTable.GetComponent<ResearchTableController>().currentDevekusuEgg == researchTable.GetComponent<ResearchTableController>().neededDevekusuEgg)
            {
                gameObject.SetActive(false);
            }

            _neededText.text = " " + researchTable.GetComponent<ResearchTableController>().currentDevekusuEgg + " / " + researchTable.GetComponent<ResearchTableController>().neededDevekusuEgg;
        }

        if (gameObject.name == "TimsahEggNeeded")
        {

            if (canDo)
            {
                researchTable.GetComponent<ResearchTableController>().timsahNeededFull = false;
                researchTable.GetComponent<ResearchTableController>().neededTimsahEgg = 2;
                researchTable.GetComponent<ResearchTableController>().currentTimsahEgg = 0;
                canDo = false;
            }

            if (researchTable.GetComponent<ResearchTableController>().currentTimsahEgg == researchTable.GetComponent<ResearchTableController>().neededTimsahEgg)
            {
                gameObject.SetActive(false);
            }

            _neededText.text = " " + researchTable.GetComponent<ResearchTableController>().currentTimsahEgg + " / " + researchTable.GetComponent<ResearchTableController>().neededTimsahEgg;
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

            if (researchTable.GetComponent<ResearchTableController>().currentEggNumber == researchTable.GetComponent<ResearchTableController>().neededEgg)
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
