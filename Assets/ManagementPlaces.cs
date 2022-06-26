using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagementPlaces : MonoBehaviour
{
    public GameObject tavukKümes;
    public GameObject tavukTezgah;
    public GameObject researchPlace;
    GameObject researchTable;
    public GameObject kazKumes;
    public GameObject kazTezgah;
    bool canOpenResearchPlace = true;
    bool canOpenKazKumes = true;
    
    void Start()
    {
        researchTable = researchPlace.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (tavukKümes.activeSelf && canOpenResearchPlace && tavukTezgah.activeSelf)
        {
            researchPlace.SetActive(true);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>().target = researchPlace;
            canOpenResearchPlace = false;
        }

        else if (researchTable.GetComponent<ResearchTableController>().canOpenKazKumes && canOpenKazKumes)
        {
            kazKumes.SetActive(true);
            kazTezgah.SetActive(true);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>().target = kazKumes;
            canOpenKazKumes = false;
        }
    }
}
