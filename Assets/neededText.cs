using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class neededText : MonoBehaviour
{
    public GameObject researchTable;
    Text _neededText;
    void Start()
    {
        _neededText = GetComponent<Text>();

      
    }

    // Update is called once per frame
    void Update()
    {
        _neededText.text = " " + researchTable.GetComponent<ResearchTableController>().currentEggNumber + " / " + researchTable.GetComponent<ResearchTableController>().neededEgg;
    }
}
