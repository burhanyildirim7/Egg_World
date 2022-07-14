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
           
            _neededText.text = " " + researchTable.GetComponent<ResearchTableController>().currentEggNumber + " / " + researchTable.GetComponent<ResearchTableController>().neededEgg;
            if (canDo)
            {
                researchTable.GetComponent<ResearchTableController>().neededEgg = 2;
                researchTable.GetComponent<ResearchTableController>().currentEggNumber = 0;
                canDo = false;
            }
            if (researchTable.GetComponent<ResearchTableController>().researchTableFull)
            {
                gameObject.SetActive(false);
            }
        }

        if (gameObject.name == "KazEggNeeded")
        {

            if (canDo)
            {
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

        if (gameObject.name == "DevekusuEggNeeded")
        {

            if (canDo)
            {
                researchTable.GetComponent<ResearchTableController>().neededEgg = 3;
                researchTable.GetComponent<ResearchTableController>().currentEggNumber = 0;
                canDo = false;
            }

            if (researchTable.GetComponent<ResearchTableController>().currentEggNumber == researchTable.GetComponent<ResearchTableController>().neededEgg)
            {
                gameObject.SetActive(false);
            }

            _neededText.text = " " + researchTable.GetComponent<ResearchTableController>().currentEggNumber + " / " + researchTable.GetComponent<ResearchTableController>().neededEgg;
        }

        if (gameObject.name == "TimsahEggNeeded")
        {

            if (canDo)
            {
                researchTable.GetComponent<ResearchTableController>().neededEgg = 1;
                researchTable.GetComponent<ResearchTableController>().currentEggNumber = 0;
                canDo = false;
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
