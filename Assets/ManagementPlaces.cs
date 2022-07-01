using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagementPlaces : MonoBehaviour
{
    public GameObject tavukKumes;
    public GameObject tavukKumesLevel2;
    public GameObject tavukKuluckaMakinesi;
    public GameObject tavukTezgah;
    public GameObject tavukTezgah2;
    public GameObject tavukKümesModul2;


    public GameObject researchPlace;
    public GameObject kazKumes;
    public GameObject kazKumesLevel2;
    public GameObject kazTezgah;

    public GameObject researchTable;
    public GameObject researchTableNeededTavukEgg;
    public GameObject researchTableNeededKazEgg;
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
        
        if (tavukKumes.activeSelf && canOpenResearchPlace && tavukTezgah.activeSelf)
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
            tavukKumesLevel2.SetActive(true);
            tavukTezgah2.SetActive(true);
            tavukKuluckaMakinesi.SetActive(true);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>().target = tavukTezgah2.transform.GetChild(0).gameObject;
            canOpenTavukTezgah2 = false;

        }

        if (tavukKümesModul2.activeSelf)
        {
            researchTableNeededTavukEgg.SetActive(false);
            researchTableNeededKazEgg.SetActive(true);
        }

        if (researchTable.GetComponent<ResearchTableController>().canOpenKazKumesLevel2)
        {
            kazKumesLevel2.SetActive(true);
        }
        
    }
}
