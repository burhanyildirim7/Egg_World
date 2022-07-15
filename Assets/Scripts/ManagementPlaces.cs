using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagementPlaces : MonoBehaviour
{
    int deleteStartingMoney = 0;
    

    public GameObject Startingmoney;
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

    public GameObject Table;

    bool tavukKumesAlreadyOpen = false;
    bool tavukTezgahAlreadyOpen = false;
    bool researchTableAlreadyOpen = false;
    bool kazKumesCanvasAlreadyOpen = false;
    bool kazKumesAlreadyOpen = false;
    bool kazTezgahAlreadyOpen = false;
    bool tavukKumesModul2AlreadyOpen = false;

    bool lockCameraToResearchPlaceFirst = true;
    bool lockCameraToResearchPlaceSecond = true;


    bool canOpenResearchPlace = false;
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

        if (PlayerPrefs.GetInt("gameStart")>0 && PlayerPrefs.GetInt("deleteStartingMoney") == 1)
        {
            Startingmoney.SetActive(false);
        }

        if (PlayerPrefs.GetInt("tavukKumesOpen") == 1)
        {
            tavukKumes.SetActive(true);
            tavukKumesAlreadyOpen = true;
            Destroy(GameObject.Find("OpenTavukKumes"));
            canOpenResearchPlace = true;
        }
        
        if (PlayerPrefs.GetInt("tavukTezgahOpen") == 1)
        {
            tavukTezgah.SetActive(true);
            tavukTezgahAlreadyOpen = true;
            Destroy(GameObject.Find("PutTavukEggsCanvas"));
            canOpenResearchPlace = true;

        } 
        
        if (PlayerPrefs.GetInt("researchTableOpen") == 1)
        {
            researchPlace.SetActive(true);
            researchTable.transform.parent.gameObject.SetActive(true);
            researchTableAlreadyOpen = true;
            Destroy(GameObject.Find("ResearchPlaceCanvas"));

        }
        
        if (PlayerPrefs.GetInt("kazKumesCanvasOpen") == 1)
        {
           

            researchTable.GetComponent<ResearchTableController>().canOpenKazKumes = true;
            researchTableNeededTavukEgg.SetActive(false);
        }  
        
        if (PlayerPrefs.GetInt("kazKumesOpen") == 1)
        {
            kazKumesObject.SetActive(true);
            kazKumesObject.transform.parent.gameObject.SetActive(true);
        
            kazKumesAlreadyOpen = true;
            kazTezgah.SetActive(true);
            Destroy(GameObject.Find("OpenKazKumes"));
        }
        
        if (PlayerPrefs.GetInt("kazTezgahOpen") == 1)
        {
            kazTezgah.SetActive(true);
            kazTezgah.transform.GetChild(0).gameObject.SetActive(true);
            kazTezgahAlreadyOpen = true;
            Destroy(GameObject.Find("OpenPutKazEgg"));
        } 
          
        if (PlayerPrefs.GetInt("tavukKumesModul2Open") == 1)
        {
            tavukKumesModul2.SetActive(true);
            canOpenNeededKaz = true;
            GameObject.Find("UpgradeLevel2").GetComponent<BuyText>().buyPrice = 0;
            tavukKumesModul2AlreadyOpen = true;
        } 

        
    }

 
    void Update()
    {
        if (Startingmoney == null)
        {
            PlayerPrefs.SetInt("deleteStartingMoney", 1);
        }

        if (tavukKumes.activeSelf && !tavukKumesAlreadyOpen)
        {
            canOpenResearchPlace = true;
            PlayerPrefs.SetInt("tavukKumesOpen", 1);
         
           
        }

        if (tavukTezgah.activeSelf && !tavukTezgahAlreadyOpen)
        {
            canOpenResearchPlace = true;
            PlayerPrefs.SetInt("tavukTezgahOpen", 1);
        }

        if (Table.activeSelf && !researchTableAlreadyOpen)
        {
            PlayerPrefs.SetInt("researchTableOpen", 1);
        }

        if (kazKumes.activeSelf && !kazKumesCanvasAlreadyOpen)
        {
            PlayerPrefs.SetInt("kazKumesCanvasOpen", 1);
        }

        if (kazKumesObject.activeSelf && !kazKumesAlreadyOpen)
        {
            PlayerPrefs.SetInt("kazKumesOpen", 1);
        }

        if (kazTezgah.transform.GetChild(0).gameObject.activeSelf && !kazTezgahAlreadyOpen)
        {
            PlayerPrefs.SetInt("kazTezgahOpen", 1);
        }

        if (tavukKumesModul2.activeSelf && !tavukKumesModul2AlreadyOpen)
        {
            PlayerPrefs.SetInt("tavukKumesModul2Open", 1);
        }





        if (tavukKumes.activeSelf && canOpenResearchPlace && tavukTezgah.activeSelf && lockCameraToResearchPlaceFirst && !researchTableAlreadyOpen)
        {    
            researchPlace.SetActive(true);

            locationArrow.SetActive(true);
            locationArrow.transform.position = researchPlace.transform.position + (Vector3.up * 3);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>().KamerayiYonlendir(researchPlace);
            canOpenResearchPlace = false;
            lockCameraToResearchPlaceFirst = false;
        }

         if (researchTable.GetComponent<ResearchTableController>().canOpenKazKumes && canOpenKazKumes && !kazKumesAlreadyOpen)
        {
            kazKumes.SetActive(true);
            kazTezgah.SetActive(true);

            locationArrow.SetActive(true);
            locationArrow.transform.position = kazKumesCanvas.transform.position + (Vector3.up * 3);
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
        


         if(tavukKumesModul2.activeSelf && canOpenNeededKaz && lockCameraToResearchPlaceSecond)
        {
            researchTableNeededTavukEgg.SetActive(false);
            researchTableNeededKazEgg.SetActive(true);

            locationArrow.SetActive(true);
            locationArrow.transform.position = researchPlace.transform.position + (Vector3.up * 3);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>().KamerayiYonlendir(researchPlace);
            lockCameraToResearchPlaceSecond = false;
            canOpenNeededKaz = false;
        }


         if (researchTable.GetComponent<ResearchTableController>().canOpenDevekusuKumes && canOpenDevekusuKumes)
        {
            devekusuKumes.SetActive(true);
            devekusuTezgah.SetActive(true);

            locationArrow.SetActive(true);
            locationArrow.transform.position = devekusuKumesCanvas.transform.position + (Vector3.up * 3);
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

            locationArrow.SetActive(true);
            locationArrow.transform.position = researchPlace.transform.position + (Vector3.up * 3);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>().KamerayiYonlendir(researchPlace);

            canOpenNeededDevekusu = false;

        }



         if (researchTable.GetComponent<ResearchTableController>().canOpenTimsahKumes && canOpenTimsahKumes)
        {
            timsahKumes.SetActive(true);
            timsahTezgah.SetActive(true);

            locationArrow.SetActive(true);
            locationArrow.transform.position = timsahKumesCanvas.transform.position + (Vector3.up * 3);
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

            locationArrow.SetActive(true);
            locationArrow.transform.position = researchPlace.transform.position + (Vector3.up * 3);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>().KamerayiYonlendir(researchPlace);

            canOpenDevekusuKumesLevel2 = false;
        }




      if (researchTable.GetComponent<ResearchTableController>().canOpenEjderKumes && canOpenEjderKumes)
     {
         ejderKumes.SetActive(true);
         ejderTezgah.SetActive(true);

            locationArrow.SetActive(true);
            locationArrow.transform.position = ejderKumesCanvas.transform.position + (Vector3.up * 3);
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
