using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagementPlaces : MonoBehaviour
{
    public GameObject tavukKümes;
    public GameObject tavukKümesLevel2;
    public GameObject tavukKuluckaMakinesi;
    public GameObject tavukTezgah;
    public GameObject tavukTezgah2;
    public GameObject researchPlace;
    public GameObject kazKumes;
    public GameObject kazTezgah;

    GameObject researchTable;
    bool canOpenResearchPlace = true;
    bool canOpenKazKumes = true;
    bool canOpenTavukTezgah2 = true;
    
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

         if (researchTable.GetComponent<ResearchTableController>().canOpenKazKumes && canOpenKazKumes)
        {
            kazKumes.SetActive(true);
            kazTezgah.SetActive(true);
           
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>().target = kazKumes;
            canOpenKazKumes = false;
        }

        if (kazKumes.transform.GetChild(0).gameObject.activeSelf && canOpenTavukTezgah2)
        {
            tavukKümesLevel2.SetActive(true);
            tavukTezgah2.SetActive(true);
            tavukKuluckaMakinesi.SetActive(true);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>().target = tavukTezgah2.transform.GetChild(0).gameObject;
            canOpenTavukTezgah2 = false;

        }
    }
}
