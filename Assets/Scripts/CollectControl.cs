using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollectControl : MonoBehaviour
{
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


    int number = 0;

    public GameObject EggStackTransform;
    void Start()
    {

   
    }

    // Update is called once per frame
    void Update()
    {
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

     public void OnTriggerEnter(Collider other)
    {
     

        if (other.gameObject.tag == "empty")
        {
        
            MoveEggToKümes(other.gameObject);
        }

        if (other.gameObject.tag == "money")
        {
            totalMoney += 100;
            UIController.instance.CoinEffect();
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "egg" || other.gameObject.tag == "timsahEgg" || other.gameObject.tag == "devekusuEgg" || other.gameObject.tag == "ejderhaEgg")
        {
            
            MoveEggToSepet(other.gameObject);
        }
       
    }
    void OnTriggerStay(Collider other)
    {
   

        if (other.gameObject.tag == "spend")
        {
            MoveEggsToSpend(other.gameObject);
        }

        if (other.gameObject.tag == "collect")
        {
           //MoveEggToSepet(other.gameObject);
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
                GameObject.FindGameObjectWithTag("collect").GetComponent<CollectBoxControl>().eggList2.Remove(otherObject.gameObject);
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

    /*
    void MoveEggToSepet(GameObject otherObject)
    {
        delayTime += Time.deltaTime;

        for (int i = eggStackTransform.Count-1; i >= 0; i--)
        {
            if (otherObject.GetComponent<CollectBoxControl>().eggStackPlace[i].tag == "full")
            {
                if (delayTime >= 0.5f)
                {
                    for (int a = 0; a < eggStackTransform.Count; a++)
                    {
                        if (eggStackTransform[a].tag == "empty")
                        {




                            eggList.Add(otherObject.GetComponent<CollectBoxControl>().eggStackPlace[i].transform.GetChild(0).gameObject);

                            GameObject.FindGameObjectWithTag("collect").GetComponent<CollectBoxControl>().eggList2.Remove(otherObject.GetComponent<CollectBoxControl>().eggStackPlace[i].transform.GetChild(0).gameObject);
                            otherObject.GetComponent<CollectBoxControl>().eggStackPlace[i].transform.GetChild(0).transform.parent = eggStackTransform[a].transform;

                            otherObject.GetComponent<CollectBoxControl>().eggStackPlace[i].transform.tag = "empty";
                            eggList[a].transform.rotation = eggStackTransform[a].transform.rotation;
                            eggStackTransform[a].transform.tag = "full";
                            eggList[a].transform.DOLocalJump(new Vector3(0, 0, 0), 5, 1, (Time.deltaTime / eggMoveToPlayerTime) * 100);
                            delayTime = 0;
                            break;

                        }
                    }

                }
           
            }
        }
    }

  */

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
                    eggList[eggList.Count - 1].transform.DOLocalMove(Vector3.zero + Vector3.up*2, 0.7f);
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

    void MoveEggToKümes(GameObject otherObject)
    {
        if (otherObject.tag == "empty")
        {
            eggList[eggList.Count - 1].transform.parent.tag = "empty";
            eggList[eggList.Count - 1].transform.parent = otherObject.transform;
            eggList[eggList.Count - 1].transform.rotation = otherObject.transform.rotation;
            //eggList[eggList.Count - 1].transform.DOLocalMove(Vector3.zero + Vector3.up*2, 0.7f);
            eggList[eggList.Count - 1].transform.DOLocalJump(Vector3.zero + Vector3.up * 2,15,1,1);
            eggList[eggList.Count - 1].transform.tag = "Untagged";
            
            otherObject.tag = "full";
            otherObject.gameObject.GetComponent<EggEvolution>().eggForChicken = eggList[eggList.Count - 1].gameObject;
            eggList.Remove(eggList[eggList.Count - 1]);
       
        }
    }

}
