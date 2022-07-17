using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollectControl : MonoBehaviour
{
    bool stopSendEgg = true;
    Vector3 lastPos;
    public bool isPlayerMove;
    public int totalMoney = 100;
    public float eggSpawnTime;
    public float eggMoveToPlayerTime;
    float distanceY = 0;
    float delayTime = 0;
    public GameObject egg;
    bool canEggSpawn = true;
    bool canEggSpend = true;
    public List<GameObject> eggList = new List<GameObject>();
    public List<GameObject> eggStackTransform = new List<GameObject>();
    public List<GameObject> eggSpendTransform = new List<GameObject>();

    bool canDo = true;

    string nameOfEggSpawnPlace;


    int number = 0;

    public GameObject EggStackTransform;
    public GameObject researchTable;

    int researchTableYumurtaVermeSaniye = 1;
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        MakeGameFaster();
        IsPlayerMove();


        UIController.instance.tapToStartScoreText.text = "" + PlayerPrefs.GetInt("Money");
        UIController.instance.gamePlayScoreText.text = "" + PlayerPrefs.GetInt("Money");
        if (eggList.Count == eggStackTransform.Count)
        {
            canEggSpawn = false;
        }

        for (var i = eggList.Count - 1; i > -1; i--)
        {
            if (eggList[i] == null)
                eggList.RemoveAt(i);
        }

    }

    void MakeGameFaster()
    {

    }

    public void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.tag == "empty")
        {

            MoveEggToKumes(other.gameObject);
        }

        if (other.gameObject.tag == "money")
        {

            if (other.gameObject.transform.parent != null)
            {
                other.gameObject.transform.parent.tag = "empty";
            }

            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 100);
            // UIController.instance.CoinEffect();
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "tavukEgg")
        {
            nameOfEggSpawnPlace = "tavukEggSpawn";
            MoveEggToSepet(other.gameObject);
        }

        if (other.gameObject.tag == "timsahEgg")
        {
            nameOfEggSpawnPlace = "timsahEggSpawn";
            MoveEggToSepet(other.gameObject);
        }

        if (other.gameObject.tag == "devekusuEgg")
        {
            nameOfEggSpawnPlace = "devekusuEggSpawn";
            MoveEggToSepet(other.gameObject);
        }

        if (other.gameObject.tag == "ejderEgg")
        {
            nameOfEggSpawnPlace = "ejderEggSpawn";
            MoveEggToSepet(other.gameObject);
        }

        if (other.gameObject.tag == "kazEgg")
        {
            nameOfEggSpawnPlace = "kazEggSpawn";
            MoveEggToSepet(other.gameObject);
        }

        if (other.gameObject.tag == "customer")
        {
            other.gameObject.GetComponent<CustomerNavMesh>().canShoopingStart = true;
        }



    }


    void OnTriggerStay(Collider other)
    {


        if (other.gameObject.tag == "spendTimsahEgg")
        {
            MoveTimsahEggsToSpend(other.gameObject);

        }

        if (other.gameObject.tag == "spendEjderEgg")
        {
            MoveEjderEggsToSpend(other.gameObject);

        }

        if (other.gameObject.tag == "spendDevekusuEgg")
        {
            MoveDeveKusuEggsToSpend(other.gameObject);

        }

        if (other.gameObject.tag == "spendKazEgg")
        {
            MoveKazEggsToSpend(other.gameObject);

        }


        if (other.gameObject.tag == "spendTavukEgg")
        {
            MoveTavukEggsToSpend(other.gameObject);
        }




        if (other.gameObject.tag == "researchTable")
        {






            if (PlayerPrefs.GetInt("neededTavukEgg") > 0)
            {
                MoveToResearchPlaceTavuk(other.gameObject);
            }

            if (PlayerPrefs.GetInt("neededKazEgg") > 0)
            {

                MoveToResearchPlaceKaz(other.gameObject);
            }

            if (other.GetComponent<ResearchTableController>().neededDevekusuEgg > 0)
            {

                MoveToResearchPlaceDevekusu(other.gameObject);
            }

            if (other.GetComponent<ResearchTableController>().neededTimsahEgg > 0)
            {

                MoveToResearchPlaceTimsah(other.gameObject);
            }




        }


        if (other.gameObject.name == "TavukKuluckaMakinesi" && other.gameObject.GetComponent<TavukMakerController>().kuluckaMakinesiFull == false)
        {

            MoveToTavukKuluckaMakine(other.gameObject);

        }  
        
        if (other.gameObject.name == "KazMaker" && other.gameObject.GetComponent<TavukMakerController>().kuluckaMakinesiFull == false)
        {

            MoveToKazKuluckaMakine(other.gameObject);

        }


    }

    void MoveToResearchPlaceTavuk(GameObject otherObject)
    {
        delayTime += Time.deltaTime;

        if (PlayerPrefs.GetInt("neededTavukEgg") > 0 && otherObject.GetComponent<ResearchTableController>().tavukNeededFull == false)
        {

            for (int i = 0; i < PlayerPrefs.GetInt("neededTavukEgg"); i++)
            {

                if (delayTime > researchTableYumurtaVermeSaniye)
                {
                    for (int a = eggList.Count - 1; a >= 0; a--)
                    {
                        if (eggList[a].tag == "tavukEgg")
                        {


                            eggList[a].transform.parent.tag = "empty";
                            eggList[a].transform.parent = otherObject.transform;
                            eggList[a].transform.rotation = otherObject.transform.rotation;
                            //eggList[a].transform.DOLocalMove(Vector3.zero + Vector3.up * 2, 0.7f);
                            eggList[a].transform.DOLocalJump(Vector3.zero, 3, 1, 1);

                            eggList[a].transform.tag = "Untagged";

                            eggList.Remove(eggList[a]);
                            delayTime = 0;
                           
                            PlayerPrefs.SetInt("currentTavukEgg", PlayerPrefs.GetInt("currentTavukEgg") + 1);
                            PlayerPrefs.SetInt("currentTavukEggArttýmý", 1);
                            break;
                        }

                    }

                }



            }


        }






    }

    void MoveToResearchPlaceKaz(GameObject otherObject)
    {
        delayTime += Time.deltaTime;

        if (PlayerPrefs.GetInt("neededKazEgg") > 0 && otherObject.GetComponent<ResearchTableController>().kazNeededFull == false)
        {
            //Buraya girdi

            for (int i = 0; i < PlayerPrefs.GetInt("neededKazEgg"); i++)
            {
                //Buraya girdi

                if (delayTime > researchTableYumurtaVermeSaniye)
                {
                    //Buraya girdi
                    for (int a = eggList.Count - 1; a >= 0; a--)
                    {
                        //Buraya girmedi
                        if (eggList[a].tag == "kazEgg")
                        {

                            eggList[a].transform.parent.tag = "empty";
                            eggList[a].transform.parent = otherObject.transform;
                            eggList[a].transform.rotation = otherObject.transform.rotation;
                            //eggList[a].transform.DOLocalMove(Vector3.zero + Vector3.up * 2, 0.7f);
                            eggList[a].transform.DOLocalJump(Vector3.zero, 3, 1, 1);

                            eggList[a].transform.tag = "Untagged";

                            eggList.Remove(eggList[a]);
                            delayTime = 0;
                            PlayerPrefs.SetInt("currentKazEgg", PlayerPrefs.GetInt("currentKazEgg") + 1);
                            PlayerPrefs.SetInt("currentKazEggArttýmý", 1);
                            break;
                        }

                    }

                }
                //Buraya girdi


            }


        }
    }


    void MoveToResearchPlaceDevekusu(GameObject otherObject)
    {
        delayTime += Time.deltaTime;
        if (otherObject.GetComponent<ResearchTableController>().neededDevekusuEgg > 0 && otherObject.GetComponent<ResearchTableController>().devekusuNeededFull == false)
        {
            //Buraya girdi
            for (int i = 0; i < otherObject.GetComponent<ResearchTableController>().neededDevekusuEgg; i++)
            {
                //Buraya girdi

                if (delayTime > researchTableYumurtaVermeSaniye)
                {
                    //Buraya girdi
                    for (int a = eggList.Count - 1; a >= 0; a--)
                    {
                        //Buraya girmedi
                        if (eggList[a].tag == "devekusuEgg")
                        {

                            eggList[a].transform.parent.tag = "empty";
                            eggList[a].transform.parent = otherObject.transform;
                            eggList[a].transform.rotation = otherObject.transform.rotation;
                            //eggList[a].transform.DOLocalMove(Vector3.zero + Vector3.up * 2, 0.7f);
                            eggList[a].transform.DOLocalJump(Vector3.zero, 3, 1, 1);

                            eggList[a].transform.tag = "Untagged";

                            eggList.Remove(eggList[a]);
                            delayTime = 0;
                            otherObject.GetComponent<ResearchTableController>().currentDevekusuEgg++;
                            break;
                        }

                    }

                }
                //Buraya girdi


            }


        }
    }

    void MoveToResearchPlaceTimsah(GameObject otherObject)
    {
        delayTime += Time.deltaTime;
        if (otherObject.GetComponent<ResearchTableController>().neededTimsahEgg > 0 && otherObject.GetComponent<ResearchTableController>().timsahNeededFull == false)
        {
            //Buraya girdi
            for (int i = 0; i < otherObject.GetComponent<ResearchTableController>().neededTimsahEgg; i++)
            {
                //Buraya girdi

                if (delayTime > researchTableYumurtaVermeSaniye)
                {
                    //Buraya girdi
                    for (int a = eggList.Count - 1; a >= 0; a--)
                    {
                        //Buraya girmedi
                        if (eggList[a].tag == "timsahEgg")
                        {

                            eggList[a].transform.parent.tag = "empty";
                            eggList[a].transform.parent = otherObject.transform;
                            eggList[a].transform.rotation = otherObject.transform.rotation;
                            //eggList[a].transform.DOLocalMove(Vector3.zero + Vector3.up * 2, 0.7f);
                            eggList[a].transform.DOLocalJump(Vector3.zero, 3, 1, 1);

                            eggList[a].transform.tag = "Untagged";

                            eggList.Remove(eggList[a]);
                            delayTime = 0;
                            otherObject.GetComponent<ResearchTableController>().currentTimsahEgg++;
                            break;
                        }

                    }

                }
                //Buraya girdi


            }


        }
    }
    void MoveToTavukKuluckaMakine(GameObject otherObject)
    {
        for (int i = 0; i < 1; i++)
        {
            for (int a = eggList.Count - 1; a >= 0; a--)
            {
                if (eggList[a].tag == "tavukEgg")
                {

                    eggList[a].transform.parent.tag = "empty";
                    eggList[a].transform.parent = otherObject.transform;
                    eggList[a].transform.rotation = otherObject.transform.rotation;
                    //eggList[a].transform.DOLocalMove(Vector3.zero + Vector3.up * 2, 0.7f);
                    eggList[a].transform.DOLocalJump(Vector3.zero, 3f, 1, 1);

                    eggList[a].transform.tag = "Untagged";

                    eggList.Remove(eggList[a]);
                    delayTime = 0;
                    otherObject.gameObject.GetComponent<TavukMakerController>().kuluckaMakinesiFull = true;
                    break;
                }

            }


        }


        
        if (otherObject.GetComponent<ResearchTableController>().researchTableFull == true)
        {
            canDo = false;
        }



    }

    void MoveToKazKuluckaMakine(GameObject otherObject)
    {
        for (int i = 0; i < 1; i++)
        {
            for (int a = eggList.Count - 1; a >= 0; a--)
            {
                if (eggList[a].tag == "kazEgg")
                {

                    eggList[a].transform.parent.tag = "empty";
                    eggList[a].transform.parent = otherObject.transform;
                    eggList[a].transform.rotation = otherObject.transform.rotation;
                    //eggList[a].transform.DOLocalMove(Vector3.zero + Vector3.up * 2, 0.7f);
                    eggList[a].transform.DOLocalJump(Vector3.zero, 3f, 1, 1);

                    eggList[a].transform.tag = "Untagged";

                    eggList.Remove(eggList[a]);
                    delayTime = 0;
                    otherObject.gameObject.GetComponent<TavukMakerController>().kuluckaMakinesiFull = true;
                    break;
                }

            }


        }


        if (researchTable.gameObject.activeSelf)
        {

       
        if (otherObject.GetComponent<ResearchTableController>().researchTableFull == true)
        {
            canDo = false;
        }
        }


    }
    public void MoveEggToSepet(GameObject otherObject)
    {


        for (int i = 0; i < eggStackTransform.Count; i++)
        {
            if (eggStackTransform[i].tag == "empty")
            {
                eggStackTransform[i].tag = "full";
                eggList.Add(otherObject);




                GameObject.FindGameObjectWithTag(nameOfEggSpawnPlace).GetComponent<CollectBoxControl>().eggList2.Remove(otherObject.gameObject);




                otherObject.transform.parent.gameObject.tag = "empty";
                otherObject.transform.parent = eggStackTransform[i].transform;
                otherObject.transform.rotation = eggStackTransform[i].transform.rotation;
                otherObject.transform.DOLocalJump(new Vector3(0, 0, 0), 2, 1, (Time.deltaTime / eggMoveToPlayerTime) * 100);

                break;
            }
        }


    }



    void MoveEggsToSpend(GameObject otherObject)
    {



        delayTime += Time.deltaTime;

        for (int i = 0; i < otherObject.transform.childCount; i++)
        {

            if (otherObject.transform.GetChild(i).tag == "empty")
            {
                if (delayTime > 0.05f)
                {

                    eggList[eggList.Count - 1].transform.parent.tag = "empty";
                    eggList[eggList.Count - 1].transform.parent = otherObject.transform.GetChild(i).transform;
                    eggList[eggList.Count - 1].transform.rotation = otherObject.transform.GetChild(i).transform.rotation;
                    eggList[eggList.Count - 1].transform.DOLocalMove(Vector3.zero + Vector3.up * 2, 0.7f);
                    otherObject.gameObject.GetComponent<SpendBoxControl>().spendEggList.Add(eggList[eggList.Count - 1]);
                    eggList[eggList.Count - 1].transform.tag = "Untagged";
                    otherObject.transform.GetChild(i).transform.tag = "full";
                    eggList.Remove(eggList[eggList.Count - 1]);
                    delayTime = 0;
                    break;

                }

            }

        }

    }


    void MoveTavukEggsToSpend(GameObject otherObject)
    {
        delayTime += Time.deltaTime;

        for (int i = 0; i < otherObject.transform.childCount; i++)
        {

            if (otherObject.transform.GetChild(i).tag == "empty")
            {

                if (delayTime > 0.05f)
                {
                    for (int a = eggList.Count - 1; a >= 0; a--)
                    {
                        if (eggList[a].tag == "tavukEgg")
                        {
                            eggList[a].transform.parent.tag = "empty";
                            eggList[a].transform.parent = otherObject.transform.GetChild(i).transform;
                            eggList[a].transform.rotation = otherObject.transform.GetChild(i).transform.rotation;
                            //eggList[a].transform.DOLocalMove(Vector3.zero + Vector3.up * 2, 0.7f);
                            eggList[a].transform.DOLocalJump(Vector3.zero + Vector3.up * 2, 20, 1, 0.7f);
                            otherObject.gameObject.GetComponent<SpendBoxControl>().spendEggList.Add(eggList[a]);
                            eggList[a].transform.tag = "Untagged";
                            otherObject.transform.GetChild(i).transform.tag = "full";
                            eggList.Remove(eggList[a]);
                            delayTime = 0;
                            break;
                        }

                    }

                }

            }

        }

    }
    void MoveTimsahEggsToSpend(GameObject otherObject)
    {
        delayTime += Time.deltaTime;

        for (int i = 0; i < otherObject.transform.childCount; i++)
        {

            if (otherObject.transform.GetChild(i).tag == "empty")
            {

                if (delayTime > 0.05f)
                {
                    for (int a = eggList.Count - 1; a >= 0; a--)
                    {
                        if (eggList[a].tag == "timsahEgg")
                        {
                            eggList[a].transform.parent.tag = "empty";
                            eggList[a].transform.parent = otherObject.transform.GetChild(i).transform;
                            eggList[a].transform.rotation = otherObject.transform.GetChild(i).transform.rotation;
                            //eggList[a].transform.DOLocalMove(Vector3.zero + Vector3.up * 2, 0.7f);
                            eggList[a].transform.DOLocalJump(Vector3.zero + Vector3.up * 2, 20, 1, 0.7f);
                            otherObject.gameObject.GetComponent<SpendBoxControl>().spendEggList.Add(eggList[a]);
                            eggList[a].transform.tag = "Untagged";
                            otherObject.transform.GetChild(i).transform.tag = "full";
                            eggList.Remove(eggList[a]);
                            delayTime = 0;
                            break;
                        }

                    }

                }

            }

        }

    }

    void MoveEjderEggsToSpend(GameObject otherObject)
    {
        delayTime += Time.deltaTime;

        for (int i = 0; i < otherObject.transform.childCount; i++)
        {

            if (otherObject.transform.GetChild(i).tag == "empty")
            {

                if (delayTime > 0.05f)
                {
                    for (int a = eggList.Count - 1; a >= 0; a--)
                    {
                        if (eggList[a].tag == "ejderEgg")
                        {
                            eggList[a].transform.parent.tag = "empty";
                            eggList[a].transform.parent = otherObject.transform.GetChild(i).transform;
                            eggList[a].transform.rotation = otherObject.transform.GetChild(i).transform.rotation;
                            //eggList[a].transform.DOLocalMove(Vector3.zero + Vector3.up * 2, 0.7f);
                            eggList[a].transform.DOLocalJump(Vector3.zero + Vector3.up * 2, 20, 1, 0.7f);
                            otherObject.gameObject.GetComponent<SpendBoxControl>().spendEggList.Add(eggList[a]);
                            eggList[a].transform.tag = "Untagged";
                            otherObject.transform.GetChild(i).transform.tag = "full";
                            eggList.Remove(eggList[a]);
                            delayTime = 0;
                            break;
                        }

                    }

                }

            }

        }

    }

    void MoveDeveKusuEggsToSpend(GameObject otherObject)
    {
        delayTime += Time.deltaTime;

        for (int i = 0; i < otherObject.transform.childCount; i++)
        {

            if (otherObject.transform.GetChild(i).tag == "empty")
            {

                if (delayTime > 0.05f)
                {
                    for (int a = eggList.Count - 1; a >= 0; a--)
                    {
                        if (eggList[a].tag == "devekusuEgg")
                        {
                            eggList[a].transform.parent.tag = "empty";
                            eggList[a].transform.parent = otherObject.transform.GetChild(i).transform;
                            eggList[a].transform.rotation = otherObject.transform.GetChild(i).transform.rotation;
                            // eggList[a].transform.DOLocalMove(Vector3.zero + Vector3.up * 2, 0.7f);
                            eggList[a].transform.DOLocalJump(Vector3.zero + Vector3.up * 2, 20, 1, 0.7f);
                            otherObject.gameObject.GetComponent<SpendBoxControl>().spendEggList.Add(eggList[a]);
                            eggList[a].transform.tag = "Untagged";
                            otherObject.transform.GetChild(i).transform.tag = "full";
                            eggList.Remove(eggList[a]);
                            delayTime = 0;
                            break;
                        }

                    }

                }

            }

        }

    }

    void MoveKazEggsToSpend(GameObject otherObject)
    {
        delayTime += Time.deltaTime;

        for (int i = 0; i < otherObject.transform.childCount; i++)
        {

            if (otherObject.transform.GetChild(i).tag == "empty")
            {

                if (delayTime > 0.05f)
                {
                    for (int a = eggList.Count - 1; a >= 0; a--)
                    {
                        if (eggList[a].tag == "kazEgg")
                        {
                            eggList[a].transform.parent.tag = "empty";
                            eggList[a].transform.parent = otherObject.transform.GetChild(i).transform;
                            eggList[a].transform.rotation = otherObject.transform.GetChild(i).transform.rotation;
                            // eggList[a].transform.DOLocalMove(Vector3.zero + Vector3.up * 2, 0.7f);
                            eggList[a].transform.DOLocalJump(Vector3.zero + Vector3.up * 2, 20, 1, 0.7f);
                            otherObject.gameObject.GetComponent<SpendBoxControl>().spendEggList.Add(eggList[a]);
                            eggList[a].transform.tag = "Untagged";
                            otherObject.transform.GetChild(i).transform.tag = "full";
                            eggList.Remove(eggList[a]);
                            delayTime = 0;
                            break;
                        }

                    }

                }

            }

        }

    }




    void MoveEggToKumes(GameObject otherObject)
    {
        if (otherObject.tag == "empty")
        {
            eggList[eggList.Count - 1].transform.parent.tag = "empty";
            eggList[eggList.Count - 1].transform.parent = otherObject.transform;
            eggList[eggList.Count - 1].transform.rotation = otherObject.transform.rotation;
            //eggList[eggList.Count - 1].transform.DOLocalMove(Vector3.zero + Vector3.up*2, 0.7f);
            eggList[eggList.Count - 1].transform.DOLocalJump(Vector3.zero + Vector3.up * 2, 15, 1, 1);
            eggList[eggList.Count - 1].transform.tag = "Untagged";

            otherObject.tag = "full";
            otherObject.gameObject.GetComponent<EggEvolution>().eggForChicken = eggList[eggList.Count - 1].gameObject;
            eggList.Remove(eggList[eggList.Count - 1]);

        }
    }

    void IsPlayerMove()
    {


        if (transform.position != lastPos)
        {
            isPlayerMove = true;

        }
        else
        {
            isPlayerMove = false;

        }

        lastPos = transform.position;

    }

}






