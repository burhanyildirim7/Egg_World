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
    public GameObject kazKumesObject;
    public GameObject kazKumesLevel2;
    public GameObject kazKumesModul2;
    public GameObject kazTezgah;


    public GameObject researchTable;
    public GameObject researchTableNeededTavukEgg;
    public GameObject researchTableNeededKazEgg;
    public GameObject researchTableNeededDevekusuEgg;
    public GameObject researchTableNeededTimsahEgg;


    public GameObject devekusuKumes;
    public GameObject devekusuKumesObject;
    public GameObject devekusuKumesLevel2Canvas;
    public GameObject devekusuKumesLevel2;
    public GameObject devekusuTezgah;


    public GameObject timsahKumes;
    public GameObject timsahKumesObject;
    public GameObject timsahKumesLevel2Canvas;
    public GameObject timsahKumesLevel2;
    public GameObject timsahTezgah;


    public GameObject ejderKumes;
    public GameObject ejderKumesObject;
    public GameObject ejderTezgah;




    bool canOpenResearchPlace = true;
    bool canOpenKazKumes = true;
    bool canOpenTavukTezgah2 = true;
    bool canOpenDevekusuKumes = true;
    bool canOpenTimsahKumes = true;
    bool canOpenNeededKaz = true;
    bool canOpenNeededDevekusu = true;
    bool canOpenDevekusuKumesLevel2 = true;
    bool canOpenEjderKumes = true;
    
    void Start()
    {
 


    }

    // Update is called once per frame
    void Update()
    {
        
        if (tavukKumes.activeSelf && canOpenResearchPlace && tavukTezgah.activeSelf)
        {
            researchPlace.SetActive(true);
      
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>().KamerayiYonlendir(researchPlace);
            canOpenResearchPlace = false;
        }

         if (researchTable.GetComponent<ResearchTableController>().canOpenKazKumes && canOpenKazKumes)
        {
            kazKumes.SetActive(true);
            kazTezgah.SetActive(true);
           
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>().KamerayiYonlendir(kazKumes);
            canOpenKazKumes = false;
        }
        
        
         if(kazKumesObject.activeSelf && canOpenTavukTezgah2)
        {
            tavukKumesLevel2.SetActive(true);
            //tavukTezgah2.SetActive(true);
            tavukKuluckaMakinesi.SetActive(true);
            //GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>().target = tavukTezgah2.transform.GetChild(0).gameObject;
            canOpenTavukTezgah2 = false;

        }
        


         if(tavukKümesModul2.activeSelf && canOpenNeededKaz)
        {
            researchTableNeededTavukEgg.SetActive(false);
            researchTableNeededKazEgg.SetActive(true);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>().KamerayiYonlendir(researchPlace);
            canOpenNeededKaz = false;
        }


         if (researchTable.GetComponent<ResearchTableController>().canOpenDevekusuKumes && canOpenDevekusuKumes)
        {
            devekusuKumes.SetActive(true);
            devekusuTezgah.SetActive(true);


            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>().KamerayiYonlendir(devekusuKumes);
            canOpenDevekusuKumes = false;
        }

         if (devekusuKumesObject.activeSelf)
        {
            Debug.Log("Burasý Çalýþtý");
            kazKumesLevel2.SetActive(true);
        }

         if (kazKumesModul2.activeSelf && canOpenNeededDevekusu)
        {
            Debug.Log("Burasý Çalýþtý 2"); 
            researchTableNeededTavukEgg.SetActive(false);
            researchTableNeededKazEgg.SetActive(false);
            researchTableNeededDevekusuEgg.SetActive(true);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>().KamerayiYonlendir(researchPlace);
            canOpenNeededDevekusu = false;

        }



         if (researchTable.GetComponent<ResearchTableController>().canOpenTimsahKumes && canOpenTimsahKumes)
        {
            timsahKumes.SetActive(true);
            timsahTezgah.SetActive(true);
          

            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>().KamerayiYonlendir(timsahKumesObject);
            canOpenTimsahKumes = false;
        }

         if (timsahKumesObject.activeSelf)
        {
            devekusuKumesLevel2Canvas.SetActive(true);
        }

         if (devekusuKumesLevel2.activeSelf && canOpenDevekusuKumesLevel2)
        {
            researchTableNeededTavukEgg.SetActive(false);
            researchTableNeededKazEgg.SetActive(false);
            researchTableNeededDevekusuEgg.SetActive(false);
            researchTableNeededTimsahEgg.SetActive(true);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>().KamerayiYonlendir(researchPlace);
            canOpenDevekusuKumesLevel2 = false;
        }

         if (researchTable.GetComponent<ResearchTableController>().canOpenEjderKumes && canOpenEjderKumes)
        {
            ejderKumes.SetActive(true);
            ejderTezgah.SetActive(true);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>().KamerayiYonlendir(ejderKumesObject);
            canOpenEjderKumes = false;
        }

         if (ejderKumesObject.activeSelf)
        {
            timsahKumesLevel2Canvas.SetActive(true);
            
        }
     
    }
}
