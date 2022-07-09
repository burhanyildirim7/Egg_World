using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class neededText : MonoBehaviour
{
    public GameObject researchTable;
    Text _neededText;
    bool canDo = true;
    void Start()
    {
        _neededText = GetComponent<Text>();

      
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "TavukEggNeeded")
        {

            _neededText.text = " " + researchTable.GetComponent<ResearchTableController>().currentEggNumber + " / " + researchTable.GetComponent<ResearchTableController>().neededEgg;
        }

        if (gameObject.name == "KazEggNeeded")
        {

            if (canDo)
            {
                researchTable.GetComponent<ResearchTableController>().neededEgg = 1;
                researchTable.GetComponent<ResearchTableController>().currentEggNumber = 0;
                canDo = false;
            }
          
            _neededText.text = " " + researchTable.GetComponent<ResearchTableController>().currentEggNumber + " / " + researchTable.GetComponent<ResearchTableController>().neededEgg;
        }

        if (gameObject.name == "DevekusuEggNeeded")
        {

            if (canDo)
            {
                researchTable.GetComponent<ResearchTableController>().neededEgg = 1;
                researchTable.GetComponent<ResearchTableController>().currentEggNumber = 0;
                canDo = false;
            }

            _neededText.text = " " + researchTable.GetComponent<ResearchTableController>().currentEggNumber + " / " + researchTable.GetComponent<ResearchTableController>().neededEgg;
        }

    }
}
