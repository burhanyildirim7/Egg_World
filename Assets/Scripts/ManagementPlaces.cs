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
    public GameObject tavukLevel2OrtaCitler;
    public GameObject tavukLevel2AcilacakCitler;
    public GameObject tavukLevel3SilinecekCitler;
    public GameObject tavukLevel3AcilacakCitler;


    //public GameObject researchPlace;
    public GameObject kazKumes;
    public GameObject kazKumesCanvas;
    public GameObject kazKumesObject;
    public GameObject kazKumesLevel2;
    public GameObject kazKumesLevel3;
    public GameObject kazKumesModul2;
    public GameObject kazKumesModul3;
    public GameObject kazTezgah;
    public GameObject kazLevel2SilinecekCitler;
    public GameObject kazLevel2Citler;
    public GameObject kazLevel3SilinecekCitler;
    public GameObject kazLevel3AcilacakCitler;


    //public GameObject researchTable;
    //public GameObject researchTableNeededTavukEgg;
    //public GameObject researchTableNeededKazEgg;
    //public GameObject researchTableNeededDevekusuEgg;
    //public GameObject researchTableNeededTimsahEgg;


    public GameObject devekusuKumes;
    public GameObject devekusuKumesCanvas;
    public GameObject devekusuKumesObject;
    public GameObject devekusuKumesLevel2Canvas;
    public GameObject devekusuKumesLevel3Canvas;
    public GameObject devekusuKumesLevel2;
    public GameObject devekusuKumesLevel3;
    public GameObject devekusuTezgah;
    public GameObject devekusuTezgahCanvas;



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
    bool devekusuKumesCanvasAlreadyOpen = false;
    bool devekusuKumesObjectAlreadyOpen = false;
    bool devekusuTezgahAlreadyOpen = false;
    bool kazKumesiModul2AlreadyOpen = false;
    bool timsahKumesCanvasAlreadyOpen = false;
    bool timsahKumesAlreadyOpen = false;
    bool timsahTezgahAlreadyOpen = false;
    bool devekusuLevel2AlreadyOpen = false;
    bool tavukKumesLevel3AlreadyOpen = false;
    bool kazKumesLevel3AlreadyOpen = false;
    bool timsahKumesLevel2AlreadyOpen = false;
    bool ejderKumesCanvasAlreadyOpen = false;
    bool ejderKumesAlreadyOpen = false;
    bool ejderTezgahAlreadyOpen = false;
    bool timsahKumesLevel3AlreadyOpen = false;
    bool devekusuKumesLevel3AlreadyOpen = false;
    bool ejderKumesLevel2AlreadyOpen = false;


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

    public GameObject TapToStart;
    bool gameStart = false;
    void Start()
    {

        if (PlayerPrefs.GetInt("gameStart") > 0 && PlayerPrefs.GetInt("deleteStartingMoney") == 1)
        {
            Startingmoney.SetActive(false);
        }

        if (PlayerPrefs.GetInt("tavukKumesOpen") == 1)
        {
            tavukKumes.SetActive(true);
            tavukKumesAlreadyOpen = true;
            GameObject.Find("OpenTavukKumes").SetActive(false);
            canOpenResearchPlace = true;
        }

        if (PlayerPrefs.GetInt("tavukTezgahOpen") == 1)
        {
            tavukTezgah.SetActive(true);
            tavukTezgahAlreadyOpen = true;
            //GameObject.Find("TavukTezgah1").SetActive(false);
            canOpenResearchPlace = true;

        }

        if (PlayerPrefs.GetInt("researchTableOpen") == 1)
        {
            //researchPlace.SetActive(true);
            //researchTable.transform.parent.gameObject.SetActive(true);
            //researchTableAlreadyOpen = true;
            //GameObject.Find("ResearchPlaceCanvas").SetActive(false);

        }

        if (PlayerPrefs.GetInt("kazKumesCanvasOpen") == 1)
        {
            //researchTable.GetComponent<ResearchTableController>().canOpenKazKumes = true;
            //researchTableNeededTavukEgg.SetActive(false);
        }

        if (PlayerPrefs.GetInt("kazKumesOpen") == 1)
        {
            kazKumesObject.SetActive(true);
            kazKumesObject.transform.parent.gameObject.SetActive(true);

            kazKumesAlreadyOpen = true;
            kazTezgah.SetActive(true);
            GameObject.Find("OpenKazKumes").SetActive(false);
        }

        if (PlayerPrefs.GetInt("kazTezgahOpen") == 1)
        {
            kazTezgah.SetActive(true);
            kazTezgah.transform.GetChild(0).gameObject.SetActive(true);
            kazTezgahAlreadyOpen = true;
            //GameObject.Find("KazTezgah1").SetActive(false);
        }

        if (PlayerPrefs.GetInt("tavukKumesModul2Open") == 1)
        {
            tavukKumesModul2.SetActive(true);
            tavukLevel2AcilacakCitler.SetActive(true);
            canOpenNeededKaz = true;
            tavukLevel2OrtaCitler.SetActive(false);
            tavukKumesLevel2.SetActive(false);
            tavukKumesModul2AlreadyOpen = true;
        }

        if (PlayerPrefs.GetInt("devekusuKumesOpen") == 1)
        {
            tavukKumesLevel2.SetActive(false);
            //researchTable.GetComponent<ResearchTableController>().canOpenDevekusuKumes = true;
            devekusuKumesCanvasAlreadyOpen = true;
            canOpenDevekusuKumes = true;
            //researchTableNeededKazEgg.SetActive(false);

        }

        if (PlayerPrefs.GetInt("devekusuKumesObjectOpen") == 1)
        {
            devekusuKumesObject.transform.parent.gameObject.SetActive(true);
            devekusuKumesObject.SetActive(true);
            devekusuTezgah.SetActive(true);
            devekusuKumesObjectAlreadyOpen = true;
            devekusuKumesCanvas.SetActive(false);

        }

        if (PlayerPrefs.GetInt("devekusuTezgahOpen") == 1)
        {
            devekusuTezgah.SetActive(true);
            devekusuTezgah.transform.GetChild(0).gameObject.SetActive(true);
            devekusuTezgahAlreadyOpen = true;


            // devekusuTezgahCanvas.SetActive(false);

        }

        if (PlayerPrefs.GetInt("kazKumesiModul2Open") == 1)
        {
            kazKumesModul2.SetActive(true);
            kazKumesiModul2AlreadyOpen = true;
            kazLevel2SilinecekCitler.SetActive(false);
            kazLevel2Citler.SetActive(true);

        }

        if (PlayerPrefs.GetInt("timsahKumesCanvasOpen") == 1)
        {
            timsahKumes.SetActive(true);
            timsahTezgah.SetActive(true);
            //researchTable.GetComponent<ResearchTableController>().canOpenTimsahKumes = true;
            timsahKumesCanvasAlreadyOpen = true;
            //researchTableNeededDevekusuEgg.SetActive(false);
        }

        if (PlayerPrefs.GetInt("timsahKumesOpen") == 1)
        {
            timsahKumesObject.transform.parent.gameObject.SetActive(true);
            timsahKumesObject.SetActive(true);
            timsahKumesAlreadyOpen = true;
            timsahKumesCanvas.SetActive(false);

        }

        if (PlayerPrefs.GetInt("timsahTezgahOpen") == 1)
        {
            timsahTezgah.SetActive(true);
            timsahTezgah.transform.GetChild(0).gameObject.SetActive(true);
            timsahTezgahAlreadyOpen = true;

        }

        if (PlayerPrefs.GetInt("devekusuLevel2Open") == 1)
        {
            devekusuKumesLevel2.SetActive(true);
            devekusuLevel2AlreadyOpen = true;
        }

        if (PlayerPrefs.GetInt("tavukKumesLevel3Open") == 1)
        {
            tavukKumesModul3.SetActive(true);
            tavukLevel3SilinecekCitler.SetActive(false);
            tavukLevel3AcilacakCitler.SetActive(true);
            tavukKumesLevel3AlreadyOpen = true;
        }

        if (PlayerPrefs.GetInt("kazKumesLevel3Open") == 1)
        {
            kazKumesModul3.SetActive(true);
            kazLevel3SilinecekCitler.SetActive(false);
            kazLevel3AcilacakCitler.SetActive(true);
            kazKumesLevel3AlreadyOpen = true;
        }

        if (PlayerPrefs.GetInt("timsahKumesLevel2Open") == 1)
        {
            timsahKumesLevel2.SetActive(true);
            timsahKumesLevel2AlreadyOpen = true;
            canOpenDevekusuKumesLevel2 = true;
        }

        if (PlayerPrefs.GetInt("ejderKumesCanvasOpen") == 1)
        {
            //researchTable.GetComponent<ResearchTableController>().canOpenEjderKumes = true;
            ejderKumesCanvasAlreadyOpen = true;
            //researchTableNeededTimsahEgg.SetActive(false);

        }

        if (PlayerPrefs.GetInt("ejderKumesOpen") == 1)
        {
            ejderKumesObject.transform.parent.gameObject.SetActive(true);
            ejderKumesObject.SetActive(true);
            ejderKumesAlreadyOpen = true;
        }

        if (PlayerPrefs.GetInt("ejderTezgahOpen") == 1)
        {
            ejderTezgah.SetActive(true);
            ejderTezgah.transform.GetChild(0).gameObject.SetActive(true);
            ejderTezgahAlreadyOpen = true;

        }

        if (PlayerPrefs.GetInt("timsahKumesLevel3Open") == 1)
        {
            timsahKumesLevel3.SetActive(true);
            timsahKumesLevel3AlreadyOpen = true;

        }

        if (PlayerPrefs.GetInt("devekusuKumesLevel3Open") == 1)
        {
            devekusuKumesLevel3.SetActive(true);
            devekusuKumesLevel3AlreadyOpen = true;

        }

        if (PlayerPrefs.GetInt("ejderKumesLevel2Open") == 1)
        {
            ejderKumesLevel2.SetActive(true);
            ejderKumesLevel2AlreadyOpen = true;

        }




    }


    void Update()
    {

        if (!TapToStart.activeSelf)
        {
            gameStart = true;
        }

        if (Startingmoney == null)
        {
            PlayerPrefs.SetInt("deleteStartingMoney", 1);
        }

        if (tavukKumes.activeSelf && !tavukKumesAlreadyOpen)
        {
            //canOpenResearchPlace = true;
            PlayerPrefs.SetInt("tavukKumesOpen", 1);


        }

        if (tavukTezgah.activeSelf && !tavukTezgahAlreadyOpen)
        {
            //canOpenResearchPlace = true;
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

        if (devekusuKumes.activeSelf && !devekusuKumesCanvasAlreadyOpen)
        {
            PlayerPrefs.SetInt("devekusuKumesOpen", 1);
        }

        if (devekusuKumesObject.activeSelf && !devekusuKumesObjectAlreadyOpen)
        {
            PlayerPrefs.SetInt("devekusuKumesObjectOpen", 1);
        }

        if (devekusuTezgah.transform.GetChild(0).gameObject.activeSelf && !devekusuTezgahAlreadyOpen)
        {
            PlayerPrefs.SetInt("devekusuTezgahOpen", 1);
        }

        if (kazKumesModul2.activeSelf && !kazKumesiModul2AlreadyOpen)
        {
            PlayerPrefs.SetInt("kazKumesiModul2Open", 1);
        }

        if (timsahKumes.activeSelf && !timsahKumesCanvasAlreadyOpen)
        {
            PlayerPrefs.SetInt("timsahKumesCanvasOpen", 1);
        }

        if (timsahKumesObject.activeSelf && !timsahKumesAlreadyOpen)
        {
            PlayerPrefs.SetInt("timsahKumesOpen", 1);
        }

        if (timsahTezgah.transform.GetChild(0).gameObject.activeSelf && !timsahTezgahAlreadyOpen)
        {
            PlayerPrefs.SetInt("timsahTezgahOpen", 1);
        }

        if (devekusuKumesLevel2.activeSelf && !devekusuLevel2AlreadyOpen)
        {
            PlayerPrefs.SetInt("devekusuLevel2Open", 1);
        }

        if (tavukKumesModul3.activeSelf && !tavukKumesLevel3AlreadyOpen)
        {
            PlayerPrefs.SetInt("tavukKumesLevel3Open", 1);
        }

        if (kazKumesModul3.activeSelf && !kazKumesLevel3AlreadyOpen)
        {
            PlayerPrefs.SetInt("kazKumesLevel3Open", 1);
        }

        if (timsahKumesLevel2.activeSelf && !timsahKumesLevel2AlreadyOpen)
        {
            PlayerPrefs.SetInt("timsahKumesLevel2Open", 1);
        }

        if (ejderKumes.activeSelf && !ejderKumesCanvasAlreadyOpen)
        {
            PlayerPrefs.SetInt("ejderKumesCanvasOpen", 1);
        }

        if (ejderKumesObject.activeSelf && !ejderKumesAlreadyOpen)
        {
            PlayerPrefs.SetInt("ejderKumesOpen", 1);
        }

        if (ejderTezgah.transform.GetChild(0).gameObject.activeSelf && !ejderTezgahAlreadyOpen)
        {
            PlayerPrefs.SetInt("ejderTezgahOpen", 1);
        }

        if (timsahKumesLevel3.activeSelf && !timsahKumesLevel3AlreadyOpen)
        {
            PlayerPrefs.SetInt("timsahKumesLevel3Open", 1);
        }

        if (devekusuKumesLevel3.activeSelf && !devekusuKumesLevel3AlreadyOpen)
        {
            PlayerPrefs.SetInt("devekusuKumesLevel3Open", 1);
        }


        if (ejderKumesLevel2.activeSelf && !ejderKumesLevel2AlreadyOpen)
        {
            PlayerPrefs.SetInt("ejderKumesLevel2Open", 1);
        }






        /*
        if (tavukKumes.activeSelf && canOpenResearchPlace && tavukTezgah.activeSelf && lockCameraToResearchPlaceFirst && !researchTableAlreadyOpen && gameStart)
        {
            researchPlace.SetActive(true);

            locationArrow.SetActive(true);
            locationArrow.transform.position = researchPlace.transform.position + (Vector3.up * 3);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>().KamerayiYonlendir(researchPlace);
            canOpenResearchPlace = false;
            lockCameraToResearchPlaceFirst = false;
        }

        if (researchTable.GetComponent<ResearchTableController>().canOpenKazKumes && canOpenKazKumes && !kazKumesAlreadyOpen && gameStart)
        {
            kazKumes.SetActive(true);
            kazTezgah.SetActive(true);

            locationArrow.SetActive(true);
            locationArrow.transform.position = kazKumesCanvas.transform.position + (Vector3.up * 3);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>().KamerayiYonlendir(kazKumesCanvas);
            canOpenKazKumes = false;
        }
        */

        if (kazKumesObject.activeSelf && canOpenTavukTezgah2 && !devekusuKumesCanvasAlreadyOpen)
        {
            tavukKumesLevel2.SetActive(true);
            //tavukTezgah2.SetActive(true);
            //tavukKuluckaMakinesi.SetActive(true);

            //GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>().target = tavukTezgah2.transform.GetChild(0).gameObject;
            canOpenTavukTezgah2 = false;

        }


        /*
        if (tavukKumesModul2.activeSelf && canOpenNeededKaz && lockCameraToResearchPlaceSecond && !devekusuKumesCanvasAlreadyOpen && gameStart)
        {
            tavukKumesLevel2.SetActive(false);
            researchTableNeededTavukEgg.SetActive(false);
            researchTableNeededKazEgg.SetActive(true);

            locationArrow.SetActive(true);
            locationArrow.transform.position = researchPlace.transform.position + (Vector3.up * 3);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>().KamerayiYonlendir(researchPlace);
            lockCameraToResearchPlaceSecond = false;
            canOpenNeededKaz = false;
        }


        if (researchTable.GetComponent<ResearchTableController>().canOpenDevekusuKumes && canOpenDevekusuKumes && !devekusuKumesObjectAlreadyOpen && gameStart)
        {
            devekusuKumes.SetActive(true);
            devekusuTezgah.SetActive(true);

            locationArrow.SetActive(true);
            locationArrow.transform.position = devekusuKumesCanvas.transform.position + (Vector3.up * 3);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>().KamerayiYonlendir(devekusuKumesCanvas);

            canOpenDevekusuKumes = false;
        }
        */
        if (devekusuKumesObject.activeSelf)
        {

            kazKumesLevel2.SetActive(true);
        }
        /*
        if (kazKumesModul2.activeSelf && canOpenNeededDevekusu && !timsahKumesCanvasAlreadyOpen && gameStart)
        {

            researchTableNeededTavukEgg.SetActive(false);
            researchTableNeededKazEgg.SetActive(false);
            researchTableNeededDevekusuEgg.SetActive(true);

            locationArrow.SetActive(true);
            locationArrow.transform.position = researchPlace.transform.position + (Vector3.up * 3);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>().KamerayiYonlendir(researchPlace);

            canOpenNeededDevekusu = false;

        }



        if (researchTable.GetComponent<ResearchTableController>().canOpenTimsahKumes && canOpenTimsahKumes && !timsahKumesAlreadyOpen && gameStart)
        {
            timsahKumes.SetActive(true);

            timsahTezgah.SetActive(true);



            locationArrow.SetActive(true);
            locationArrow.transform.position = timsahKumesCanvas.transform.position + (Vector3.up * 3);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>().KamerayiYonlendir(timsahKumesCanvas);

            canOpenTimsahKumes = false;
        }
        */

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
        /*
        if (timsahKumesLevel2.activeSelf && canOpenDevekusuKumesLevel2 && !ejderKumesCanvasAlreadyOpen && gameStart)
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




        if (researchTable.GetComponent<ResearchTableController>().canOpenEjderKumes && canOpenEjderKumes && !ejderKumesAlreadyOpen && gameStart)
        {

            ejderKumes.SetActive(true);
            ejderTezgah.SetActive(true);

            locationArrow.SetActive(true);
            locationArrow.transform.position = ejderKumesCanvas.transform.position + (Vector3.up * 3);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>().KamerayiYonlendir(ejderKumesCanvas);

            canOpenEjderKumes = false;
        }
        */

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
