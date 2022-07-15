using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagementPlaces : MonoBehaviour
{
    public GameObject locationArrow;

    public GameObject tavukKumes;
    public GameObject tavukKumesLevel2;
    public GameObject tavukKumesLevel3;
    public GameObject tavukKuluckaMakinesi;
    public GameObject tavukTezgah;
    public GameObject tavukTezgah2;
    public GameObject tavukKumesModul2;
    public GameObject tavukKumesModul3;


    public GameObject researchPlace;
    public GameObject kazKumes;
    public GameObject kazKumesCanvas;
    public GameObject kazKumesObject;
    public GameObject kazKumesLevel2;
    public GameObject kazKumesLevel3;
    public GameObject kazKumesModul2;
    public GameObject kazKumesModul3;
    public GameObject kazTezgah;


    public GameObject researchTable;
    public GameObject researchTableNeededTavukEgg;
    public GameObject researchTableNeededKazEgg;
    public GameObject researchTableNeededDevekusuEgg;
    public GameObject researchTableNeededTimsahEgg;


    public GameObject devekusuKumes;
    public GameObject devekusuKumesCanvas;
    public GameObject devekusuKumesObject;
    public GameObject devekusuKumesLevel2Canvas;
    public GameObject devekusuKumesLevel3Canvas;
    public GameObject devekusuKumesLevel2;
    public GameObject devekusuKumesLevel3;
    public GameObject devekusuTezgah;


    public GameObject timsahKumes;
    public GameObject timsahKumesCanvas;
    public GameObject timsahKumesObject;
    public GameObject timsahKumesLevel2Canvas;
    public GameObject timsahKumesLevel3Canvas;
    public GameObject timsahKumesLevel2;
    public GameObject timsahKumesLevel3;
   
    public GameObject timsahTezgah;


    public GameObject ejderKumes;
    public GameObject ejderKumesLevel2;
    public GameObject ejderKumesCanvas;
    public GameObject ejderKumesLevel2Canvas;
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

            locationArrow.SetActive(true);
            locationArrow.transform.position = researchPlace.transform.position + (Vector3.up * 3);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>().KamerayiYonlendir(researchPlace);
            canOpenResearchPlace = false;
        }

         if (researchTable.GetComponent<ResearchTableController>().canOpenKazKumes && canOpenKazKumes)
        {
            kazKumes.SetActive(true);
            kazTezgah.SetActive(true);
           
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>().KamerayiYonlendir(kazKumesCanvas);
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
        


         if(tavukKumesModul2.activeSelf && canOpenNeededKaz)
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


            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>().KamerayiYonlendir(devekusuKumesCanvas);
            canOpenDevekusuKumes = false;
        }

         if (devekusuKumesObject.activeSelf)
        {

            kazKumesLevel2.SetActive(true);
        }

         if (kazKumesModul2.activeSelf && canOpenNeededDevekusu)
        {

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
          

            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>().KamerayiYonlendir(timsahKumesCanvas);
            canOpenTimsahKumes = false;
        }

         if (timsahKumesObject.activeSelf)
        {
            devekusuKumesLevel2Canvas.SetActive(true);
        }

       

       



      if (devekusuKumesLevel2.activeSelf && canOpenDevekusuKumesLevel2)
     {
            /*
         researchTableNeededTavukEgg.SetActive(false);
         researchTableNeededKazEgg.SetActive(false);
         researchTableNeededDevekusuEgg.SetActive(false);
         researchTableNeededTimsahEgg.SetActive(true);
         GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>().KamerayiYonlendir(researchPlace);
         canOpenDevekusuKumesLevel2 = false;
            */
            tavukKumesLevel3.SetActive(true);
     }

        if (tavukKumesModul3.activeSelf)
        {
            kazKumesLevel3.SetActive(true);
        }

        if (kazKumesModul3.activeSelf)
        {
            timsahKumesLevel2Canvas.SetActive(true);
        }

        if (timsahKumesLevel2.activeSelf && canOpenDevekusuKumesLevel2)
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
         GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>().KamerayiYonlendir(ejderKumesCanvas);
         canOpenEjderKumes = false;
     }
      

        if (ejderKumesObject.activeSelf)
        {
            timsahKumesLevel3Canvas.SetActive(true);
            
        }

        if (timsahKumesLevel3.activeSelf)
        {
            devekusuKumesLevel3Canvas.SetActive(true);
        }

        if (devekusuKumesLevel3.activeSelf)
        {
            ejderKumesLevel2Canvas.SetActive(true);
        }
     
    }
}
