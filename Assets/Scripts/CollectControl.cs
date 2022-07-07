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
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        MakeGameFaster();
        IsPlayerMove();

       
        UIController.instance.tapToStartScoreText.text = "" + totalMoney;
        UIController.instance.gamePlayScoreText.text = "" + totalMoney;
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
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Oyun Hýzlandý");
            Time.timeScale = 5;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.tag == "empty")
        {

            MoveEggToKümes(other.gameObject);
        }

        if (other.gameObject.tag == "money")
        {
          
            if (other.gameObject.transform.parent != null)
            {
                other.gameObject.transform.parent.tag = "empty";
            }
           
            totalMoney += 100;
            UIController.instance.CoinEffect();
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

        if (other.gameObject.tag == "spendTavukEgg")
        {
            MoveTavukEggsToSpend(other.gameObject);
        }

   


        if (other.gameObject.tag == "researchTable")
        {
            
      

       

            
                if (other.GetComponent<ResearchTableController>().tavukEggNeededText.activeSelf)
                {
                    MoveToResearchPlaceTavuk(other.gameObject);
                }

                else if (other.GetComponent<ResearchTableController>().kazEggNeededText.activeSelf)
                {
                    
                    MoveToResearchPlaceKaz(other.gameObject);
                }


          

        }

      
            if (other.gameObject.name == "TavukKuluckaMakinesi" && other.gameObject.GetComponent<TavukMakerController>().kuluckaMakinesiFull==false)
            {
            
            MoveToTavukKuluckaMakine(other.gameObject);
        
        }
           
       
    }

    void MoveToResearchPlaceTavuk(GameObject otherObject)
    {
        delayTime += Time.deltaTime;

        if (otherObject.GetComponent<ResearchTableController>().tavukEggNeededText.activeSelf && otherObject.GetComponent<ResearchTableController>().researchTableFull == false)
        {

            for (int i = 0; i < otherObject.GetComponent<ResearchTableController>().neededEgg; i++)
            {
                
                if (delayTime > 0.05f)
                {
                    for (int a = eggList.Count - 1; a >= 0; a--)
                    {
                        if (eggList[a].tag == "tavukEgg")
                        {
                         
                            Debug.Log("Tavuk yumurtasý fýrlatýldý");
                            eggList[a].transform.parent.tag = "empty";
                            eggList[a].transform.parent = otherObject.transform;
                            eggList[a].transform.rotation = otherObject.transform.rotation;
                            //eggList[a].transform.DOLocalMove(Vector3.zero + Vector3.up * 2, 0.7f);
                            eggList[a].transform.DOLocalJump(Vector3.zero, 3, 1, 1);

                            eggList[a].transform.tag = "Untagged";

                            eggList.Remove(eggList[a]);
                            delayTime = 0;
                            otherObject.GetComponent<ResearchTableController>().currentEggNumber++;
                            break;
                        }

                    }

                }



            }

           
        }

      

       


    }

    void MoveToResearchPlaceKaz(GameObject otherObject)
    {
        if (otherObject.GetComponent<ResearchTableController>().kazEggNeededText.activeSelf && otherObject.GetComponent<ResearchTableController>().researchTableFull == false)
        {
            //Buraya girdi
            for (int i = 0; i < otherObject.GetComponent<ResearchTableController>().neededEgg; i++)
            {
                //Buraya girdi

                if (delayTime > 0.05f)
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
                            otherObject.GetComponent<ResearchTableController>().currentEggNumber++;
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

        /*
        for (int i = 0; i < eggStackTransform.Count; i++)
        {
            if (eggStackTransform[i].tag == "empty")
            {

                eggList.Add(otherObject);
                GameObject.FindGameObjectWithTag("collect").GetComponent<CollectBoxControl>().eggList2.Remove(otherObject.gameObject);
                otherObject.transform.parent.gameObject.tag = "empty";
                otherObject.transform.parent = EggStackTransform.transform;
                otherObject.transform.rotation = EggStackTransform.transform.rotation;
                otherObject.transform.DOLocalJump(new Vector3(0, distanceY, 0), 2, 1, (Time.deltaTime / eggMoveToPlayerTime) * 100);
                eggStackTransform[i].tag = "full";
                distanceY += 0.5f;
                break;
            }
        }
        */
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
                            eggList[a].transform.DOLocalJump(Vector3.zero +Vector3.up*2,20,1,0.7f);
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
                      for (int a = eggList.Count-1; a >= 0; a--)
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




    void MoveEggToKümes(GameObject otherObject)
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






